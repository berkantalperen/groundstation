using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using CsvHelper;

namespace groundstation
{
    partial class MainForm
    {
        public object[] AvailablePorts() { return SerialPort.GetPortNames().Length != 0 ? SerialPort.GetPortNames() : new[] { "No Ports Available!" }; }
        //SERIAL PORT CONTROL
        private void init_serial()
        {
            serialText.Items.Clear();
            serialText.Items.AddRange(CommandList);
            serialText.AutoCompleteCustomSource.AddRange((string[])CommandList);
            baudSelect.SelectedIndex = 3;
            endingSelect.SelectedIndex = 1;
        }
        private void serialBtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (fileSenderWorker.IsBusy)
                {
                    var result = MessageBox.Show("You are transferring a file! Do you want to cancel it and close the port?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result != DialogResult.Yes) return;
                    fileSenderWorker.CancelAsync();
                    portOpenCloseWorker.RunWorkerAsync(1);
                }
                else
                {
                    portOpenCloseWorker.RunWorkerAsync(1);
                }
            }
            else
            {
                try
                {
                    serialPort1.BaudRate = Convert.ToInt32(baudSelect.Text);
                    serialPort1.PortName = portSelect.Text;
                    portOpenCloseWorker.RunWorkerAsync(1);
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
            portSelect.Items.AddRange(AvailablePorts());
        }
        private void baudSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.BaudRate = Convert.ToInt32(baudSelect.Text);
            }
        }
        private void portOpenCloseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            switch (e.Argument)
            {
                case 1:
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    else
                    {
                        serialPort1.Open();
                    }
                    break;
                case 2:
                    if (serialPort2.IsOpen)
                    {
                        serialPort2.Close();
                        Console.WriteLine("close");
                    }
                    else
                    {
                        serialPort2.Open();
                        Console.WriteLine("open");
                    }
                    break;
            }
        }
        private void portOpenCloseWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                switch (e.Result)
                {
                    case 1:
                        serialBtn.Text = serialBtn.Text == "Open Port" ? "Close Port" : "Open Port";
                        portSelect.Enabled = !portSelect.Enabled;
                        sendLineBtn.Enabled = !sendLineBtn.Enabled;
                        sendFileBtn.Enabled = !sendFileBtn.Enabled;
                        serialText.Enabled = !serialText.Enabled;
                        serialBtn.ForeColor = serialPort1.IsOpen ? Color.Red : Color.LimeGreen;
                        if (serialPort1.IsOpen && logPortOpen.CheckState == CheckState.Checked)
                        {
                            NewLogFile();
                            
                        }
                        break;
                    case 2:
                        transferItem.Checked = !transferItem.Checked;
                        Console.WriteLine("+");
                        break;
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
        System.Diagnostics.Stopwatch _fileWatch = new System.Diagnostics.Stopwatch();
        private void fileSenderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _fileWatch.Start();
            long maxBuffer = 1048576 / 4; //250KB
            long totalBytesWritten = 0;
            using (FileStream fs = File.Open(e.Argument.ToString(), FileMode.Open, FileAccess.Read))
            {
                bool endLoop = false;
                while (true)
                {
                    if (fs.Length < maxBuffer)
                    {
                        maxBuffer = fs.Length;
                        endLoop = true;
                    }
                    else if (totalBytesWritten + maxBuffer > fs.Length)
                    {
                        maxBuffer = fs.Length - totalBytesWritten;
                        endLoop = true;
                    }
                    byte[] buffer = new byte[maxBuffer];
                    fs.Read(buffer, 0, (int)maxBuffer);
                    serialPort1.Write(buffer, 0, buffer.Length);
                    while (serialPort1.BytesToWrite != 0 && !fileSenderWorker.CancellationPending)
                    {
                        long subTotal = totalBytesWritten + maxBuffer - serialPort1.BytesToWrite;
                        decimal progressPercentage = Decimal.Multiply(subTotal, 1000000) / fs.Length;
                        fileSenderWorker.ReportProgress((int)progressPercentage);
                    }
                    totalBytesWritten += maxBuffer;
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
            _fileWatch.Stop();
            DialogResult result;
            if (e.Cancelled)
            {
                result = MessageBox.Show($"File transfer cancelled at {_fileWatch.ElapsedMilliseconds}ms!");
            }
            else
            {
                result = MessageBox.Show($"File transfer completed in {_fileWatch.ElapsedMilliseconds}ms!");
            }
            if (result == DialogResult.OK)
            {
                serialProg.Value = 0;
            }
            _fileWatch.Reset();
        }
        private void loggerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var writer = new StreamWriter(LogFilePath(), true))
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
                    serialPort1.Write(Encoding.ASCII.GetBytes(serialText.Text), 0, Encoding.ASCII.GetBytes(serialText.Text).Length);
                    break;
                case 1:
                    serialPort1.WriteLine(serialText.Text);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            serialText.Text = "";
        }
        private void transferItem_Click(object sender, EventArgs e)
        {
            portOpenCloseWorker.RunWorkerAsync(2);
        }
        private void portItem_DropDownOpening(object sender, EventArgs e)
        {
            var arr = AvailablePorts();
            portItem.DropDownItems.Clear();
            foreach (var s in arr)
            {
                portItem.DropDownItems.Add((string)s);
            }

            foreach (ToolStripMenuItem item in portItem.DropDownItems)
            {
                item.Click += new EventHandler(portItem_Click);
            }
        }
        private void portItem_Click(object sender, EventArgs e)
        {
            portItem.Text = $"Port ({sender})"; 
        }
    }
}