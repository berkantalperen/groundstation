using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.IO.Ports;

namespace groundstation
{
    partial class MainForm
    {
        public string[] availablePorts() { return SerialPort.GetPortNames().Length != 0 ? SerialPort.GetPortNames() : new[] { "No Ports Available!" }; }
        //SERIAL PORT CONTROL
        private void init_serial()
        {
            serialText.Items.Clear();
            serialText.Items.AddRange(commandList);
            serialText.AutoCompleteCustomSource.AddRange(commandList);
            baudSelect.SelectedIndex = 3;
            endingSelect.SelectedIndex = 1;
        }
        private void serialBtn_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if (fileSenderWorker.IsBusy)
                {
                    DialogResult result = MessageBox.Show("You are transferring a file! Do you want to cancel it and close the port?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        fileSenderWorker.CancelAsync();
                        portOpenCloseWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    portOpenCloseWorker.RunWorkerAsync();
                }
            }
            else
            {
                try
                {
                    serialPort.BaudRate = Convert.ToInt32(baudSelect.Text);
                    serialPort.PortName = portSelect.Text;
                    portOpenCloseWorker.RunWorkerAsync();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void portSelect_DropDown(object sender, EventArgs e)
        {
            portSelect.Items.Clear();
            portSelect.Items.AddRange(availablePorts());
        }
        private void baudSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.BaudRate = Convert.ToInt32(baudSelect.Text);
            }
        }
        private void portOpenCloseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            else
            {
                serialPort.Open();
            }
        }
        private void portOpenCloseWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                serialBtn.Text = serialBtn.Text == "Open Port" ? "Close Port" : "Open Port";
                portSelect.Enabled = !portSelect.Enabled;
                sendLineBtn.Enabled = !sendLineBtn.Enabled;
                sendFileBtn.Enabled = !sendFileBtn.Enabled;
                serialText.Enabled = !serialText.Enabled;
                serialBtn.ForeColor = serialPort.IsOpen ? Color.Red : Color.LimeGreen;
                if (serialPort.IsOpen && logPortOpen.CheckState == CheckState.Checked)
                {
                    newLogFile();
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void serialText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendLineBtn_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        private void serialBtn_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void serialBtn_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        //SERIAL WRITE/TRANSFER
        private void sendFileBtn_Click(object sender, EventArgs e)
        {
            if (!fileSenderWorker.IsBusy)
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        fileSenderWorker.RunWorkerAsync(file);
                    }
                }
            }
            else
            {
                DialogResult result2 = MessageBox.Show("You are already transferring a file! Do you want to cancel it? ", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Yes)
                {
                    fileSenderWorker.CancelAsync();
                    DialogResult result = openFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            fileSenderWorker.RunWorkerAsync(file);
                        }
                    }
                }
            }
        }
        System.Diagnostics.Stopwatch fileWatch = new System.Diagnostics.Stopwatch();
        private void fileSenderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            fileWatch.Start();
            long MAX_BUFFER = 1048576 / 4; //250KB
            long totalBytesWritten = 0;
            using (FileStream fs = File.Open(e.Argument.ToString(), FileMode.Open, FileAccess.Read))
            {
                bool endLoop = false;
                while (true)
                {
                    if (fs.Length < MAX_BUFFER)
                    {
                        MAX_BUFFER = fs.Length;
                        endLoop = true;
                    }
                    else if (totalBytesWritten + MAX_BUFFER > fs.Length)
                    {
                        MAX_BUFFER = fs.Length - totalBytesWritten;
                        endLoop = true;
                    }
                    byte[] buffer = new byte[MAX_BUFFER];
                    fs.Read(buffer, 0, (int)MAX_BUFFER);
                    serialPort.Write(buffer, 0, buffer.Length);
                    while (serialPort.BytesToWrite != 0 && !fileSenderWorker.CancellationPending)
                    {
                        long subTotal = totalBytesWritten + MAX_BUFFER - serialPort.BytesToWrite;
                        decimal progressPercentage = Decimal.Multiply(subTotal, 1000000) / fs.Length;
                        fileSenderWorker.ReportProgress((int)progressPercentage);
                    }
                    totalBytesWritten += MAX_BUFFER;
                    if (endLoop)
                    {
                        break;
                    }
                    if (fileSenderWorker.CancellationPending)
                    {
                        Console.WriteLine("cancelled");
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
        private void fileSenderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            serialProg.Value = e.ProgressPercentage;
        }
        private void fileSenderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fileWatch.Stop();
            DialogResult result;
            if (e.Cancelled)
            {
                result = MessageBox.Show($"File transfer cancelled at {fileWatch.ElapsedMilliseconds}ms!");
            }
            else
            {
                result = MessageBox.Show($"File transfer completed in {fileWatch.ElapsedMilliseconds}ms!");
            }
            if (result == DialogResult.OK)
            {
                serialProg.Value = 0;
            }
            fileWatch.Reset();
        }
        private void loggerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var writer = new StreamWriter(logFilePath(), true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var records = new List<object>
                {
                    e.Argument
                };
                csv.WriteRecords(records);
            }
        }
        private void sendLineBtn_Click(object sender, EventArgs e)
        {
            switch (endingSelect.SelectedIndex)
            {
                case 0:
                    serialPort.Write(Encoding.ASCII.GetBytes(serialText.Text), 0, Encoding.ASCII.GetBytes(serialText.Text).Length);
                    break;
                case 1:
                    serialPort.WriteLine(serialText.Text);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            serialText.Text = "";
        }
    }
}
