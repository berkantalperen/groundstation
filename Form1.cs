using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.IO;
using System.IO.Ports;
using System.Text.Json;
using System.Reflection;

namespace groundstation
{
    public partial class Form1 : Form
    {
        public string[] availablePorts() { return SerialPort.GetPortNames().Length != 0 ? SerialPort.GetPortNames() : new[] { "No Ports Available!" }; }
        public string docsFilePath = "GCSDocs\\";
        public string logsFilePath = "adad";
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            timer1.Start();

            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < 30000; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, i * i);
            }
            chart1.Series.Add("Series2");

            chart1.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < 30000; i++)
            {
                chart1.Series["Series2"].Points.AddXY(i, i * i / 2);
            }

            treeView.Nodes.Add("adadad\\adadadadaddada");
        }

        //CAMERA
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            camPicture.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void playBtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (FilterInfo device in videoDevices)
                {

                    if (device.Name == camSelect.SelectedItem.ToString())
                    {
                        videoSource = new VideoCaptureDevice(device.MonikerString);
                    }
                }
                videoSource.NewFrame += VideoSource_NewFrame;
                if (!videoSource.IsRunning)
                {
                    videoSource.Start();
                }
                camSelect.Enabled = false;
                playBtn.Enabled = false;
                pauseBtn.Enabled = true;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Please select a capture device!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pauseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                camPicture.Image = null;
                camSelect.Enabled = true;
                playBtn.Enabled = true;
                pauseBtn.Enabled = false;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Please select a capture device!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void camSelect_DropDown(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camSelect.Items.Clear();
            foreach (FilterInfo device in videoDevices)
            {
                camSelect.Items.Add(device.Name);
            }
        }
        private void ssBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(docsFilePath + "\\Screenshots"))
                {
                    Directory.CreateDirectory(docsFilePath + "\\Screenshots");
                }
                camPicture.Image.Save(docsFilePath + $"\\Screenshots\\{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.bmp", camPicture.Image.RawFormat);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Please select a capture device!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void recBtn_Click(object sender, EventArgs e)
        {
        }

        //SERIAL PORT CONTROL
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
                portLabel.Text = serialPort.IsOpen ? "Port Status: Open" : "Port Status: Closed";
                portLabel.ForeColor = serialPort.IsOpen ? Color.LimeGreen : Color.Red;
            }
            else
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (simIsOn == false)
            {
                BeginInvoke(new Action(() =>
                {
                    defaultDataset data = JsonSerializer.Deserialize<defaultDataset>(serialPort.ReadExisting());
                    applyToUI(data);
                }));
            }
        }
        private void applyToUI(object data)
        {
            //foreach (PropertyInfo propinfo in data.GetType().get.GetProperties())
            //{
            //    if (propinfo.Name == "Computer Name")
            //    {

            //        //treeView.Nodes.Add(data.GetType().GetProperty(propinfo.Name));
            //    }
            //}
        }

        //DATA SIMULATION
        bool simIsOn = false;
        private void dataSimWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            int interval = Convert.ToInt32(intervalSelect.SelectedText);
            stopwatch.Start();
            simIsOn = !simIsOn;

            while (simIsOn)
            {
                long time = (long)stopwatch.Elapsed.TotalSeconds;
                dataFromCSV(time, "selected path");
                Thread.Sleep(interval);
            }
        }
        private defaultDataset dataFromCSV(long time, string filepath)
        {
            defaultDataset dataset = new defaultDataset("default");
            dataset.Time = time;
            dataset.Stage = time < 10 ? "Launch" : time < 180 ? "Burnout" : time < 240 ? "Apogee" : time < 300 ? "First recovery" : time < 360 ? "Second Recovery" : "Landed";
            dataset.GPS[0] *= time / 10000;
            dataset.GPS[1] *= time / 10000;
            dataset.Temperature = multiplyWithRandBtw(dataset.Temperature, 0.9, 1.1);
            return dataset;
        }
        private double multiplyWithRandBtw(double variable, double minVal, double maxVal)
        {
            Random rand = new Random();
            variable *= rand.NextDouble() * (maxVal - minVal) + minVal;
            return variable;
        }
        private void simBtn_Click(object sender, EventArgs e)
        {
            defaultDataset dataset = new defaultDataset();
            //BeginInvoke(new Action(() =>
            //{
            //    applyToUI(data);
            //}));
        }

        //DOCUMENTS FILE LOCATION
        private void fileBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                docsFilePath = folderBrowserDialog.SelectedPath;
                fileText.Text = docsFilePath;
            }
        }

        //EXIT CONDITIONS
        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Do you want to exit GCS?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogresult == DialogResult.Yes)
            {
                Close();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        //SEND FILE
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
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        private void fileSenderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            watch.Start();
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
                        MAX_BUFFER = fs.Length-totalBytesWritten;
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
                    if (endLoop | fileSenderWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
        private void fileSenderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            serialProg.Value = e.ProgressPercentage;
            serialProg.Update();
        }
        private void fileSenderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            watch.Stop();
            DialogResult result;
            if (e.Cancelled)
            {
                result = MessageBox.Show($"File transfer cancelled at {watch.ElapsedMilliseconds}ms!");
            }
            else
            {
                result = MessageBox.Show($"File transfer completed in {watch.ElapsedMilliseconds}ms!");
            }
            if (result == DialogResult.OK)
            {
                serialProg.Value = 0;
                serialProg.Update();
            }
            watch.Reset();
        }
        private void sendLineBtn_Click(object sender, EventArgs e)
        {
            serialPort.Write(Encoding.ASCII.GetBytes(serialText.Text), 0, Encoding.ASCII.GetBytes(serialText.Text).Length);
            serialText.Text = "";
        }
        private void serialText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                serialPort.WriteLine(serialText.Text);
                serialText.Text = "";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
                label3.Text = serialPort.BytesToWrite.ToString() + " " + serialPort.BaudRate + " " + fileSenderWorker.IsBusy + " " + fileSenderWorker.CancellationPending + " " + serialPort.WriteBufferSize;
        }
    }
}
