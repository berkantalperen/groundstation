using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.IO;
using System.IO.Ports;
using System.Text.Json;
using System.Reflection;
using CsvHelper;
using System.Globalization;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Diagnostics;

namespace groundstation
{
    public partial class Form1 : Form
    {
        public string[] availablePorts() { return SerialPort.GetPortNames().Length != 0 ? SerialPort.GetPortNames() : new[] { "No Ports Available!" }; }
        public string docsFilePath = "Docs";
        public string logFileName = "undefined";
        public string logFilePath()
        {
            if (!Directory.Exists(docsFilePath + "\\Logs"))
            {
                Directory.CreateDirectory(docsFilePath + "\\Logs");
            }
            return $"{docsFilePath}\\Logs\\{logFileName}.csv";
        }
        public string simFilePath = "";
        double[] ort_pos = { 39.89009702352859, 32.77991689326698 };

        public string comPropName = "C";
        public string gpsPropName = "GPS";
        public string timePropName = "T";
        public int successcount = 0, failcount = 0;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            baudSelect.SelectedIndex = 3;
            endingSelect.SelectedIndex = 1;

            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;
            map.MapProvider = GoogleSatelliteMapProvider.Instance;
            map.CacheLocation = "map_cache";
            map.Position = new PointLatLng(ort_pos[0], ort_pos[1]);

            if (!Directory.Exists(docsFilePath))
            {
                Directory.CreateDirectory(docsFilePath);
            }
            docsItem.Text = $"Documents folder: \"{docsFilePath}\"";
            newLogFile();
        }

        public void updateMarker(string markerId, double lat, double lon)
        {
            PointLatLng pos = new PointLatLng(lat, lon);
            map.Position = pos;
            GMapMarker marker = markerId == "Container" ? new GMarkerGoogle(pos, (Bitmap)Image.FromFile("")) : markerId == "Probe" ? new GMarkerGoogle(pos, (Bitmap)Image.FromFile("")) : new GMarkerGoogle(pos, GMarkerGoogleType.red);

            bool overlayExists = false;
            foreach (GMapOverlay overlay in map.Overlays)
            {
                if (overlay.Id == $"{markerId}Overlay")
                {
                    overlay.Clear();
                    overlayExists = true;
                    overlay.Markers.Add(marker);
                }
            }
            if (!overlayExists)
            {
                GMapOverlay markers = new GMapOverlay($"{markerId}Overlay");
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);
            }
            map.Zoom--;
            map.Zoom++;
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
            updateMarker("adada", multiplyWithRandBtw(ort_pos[0], 0.9999, 1.0001), multiplyWithRandBtw(ort_pos[1], 0.9999, 1.0001));
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
                serialBtn.ForeColor = serialPort.IsOpen ? Color.LimeGreen : Color.Red;
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
        //DATA HANDLING
        string incomingdata = string.Empty;
        Stopwatch packetWatch = new Stopwatch();
        long totaldelay = 0, avg = 0;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.WriteLine($"datareceived at {DateTime.Now.Millisecond}");
            while (serialPort.BytesToRead > 0)
            {
                char newbyte = (char)serialPort.ReadByte();

                if (newbyte != '+')
                {
                    incomingdata += newbyte;
                    //Console.WriteLine($"{newbyte} is added to incomingdata={incomingdata}");
                }
                else
                {
                    try
                    {

                        defaultDataset data = JsonSerializer.Deserialize<defaultDataset>(incomingdata);
                        BeginInvoke(new Action(() =>
                        {
                            applyToUI(data);
                            packetLabel.Text = $"Packet count (S/F): {++successcount}/{failcount} ({packetWatch.ElapsedMilliseconds} ms)";
                            totaldelay += packetWatch.ElapsedMilliseconds;
                            avg = (totaldelay + packetWatch.ElapsedMilliseconds) / successcount;
                            delayLabel.Text = $"Avg delay: {avg} ms";
                            if (packetWatch.IsRunning)
                            {
                                packetWatch.Restart();
                            }
                            else
                            {
                                packetWatch.Start();
                            }
                        }));
                        loggerWorker.RunWorkerAsync(data);
                    }
                    catch (Exception)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            packetLabel.Text = $"Packet count (S/F): {successcount}/{++failcount}";
                        }));
                    }
                    //Console.WriteLine($"sequence completed with datastring: {incomingdata}");
                    incomingdata = String.Empty;
                    //serialPort.DiscardInBuffer();
                }
            }
        }
        private void applyToUI(object data)
        {
            if (data.GetType().GetProperty(gpsPropName) != null && data.GetType().GetProperty(gpsPropName).GetValue(data) != null)
            {
                GPS pos = (GPS)data.GetType().GetProperty(gpsPropName).GetValue(data);
                if (data.GetType().GetProperty(comPropName) != null && data.GetType().GetProperty(comPropName).GetValue(data) != null)
                {
                    updateMarker((string)data.GetType().GetProperty(comPropName).GetValue(data), pos.Lat, pos.Lon);
                }
                else
                {
                    updateMarker("unknown", pos.Lat, pos.Lon);
                }
                noGPSLabel.Visible = false;
            }
            else
            {
                noGPSLabel.Visible = true;
            }
            nodesFromObject(null, data);
            chartsFromObject(data);
            treeView.ExpandAll();

        }
        private void nodesFromObject(TreeNode treeNode, object data)
        {
            // USE NULL PARAMETER FOR INITIAL CALL
            foreach (PropertyInfo propinfo in data.GetType().GetProperties())
            {
                if (propinfo.GetValue(data) != null)
                {
                    if (treeNode == null)
                    {
                        int comIndex = -2;
                        string s = propinfo.Name == comPropName ? $"{propinfo.GetValue(data)}" : "(Unknown ID)";
                        if (!propinfo.GetValue(data).GetType().IsSerializable)
                        {
                            if (treeView.Nodes.ContainsKey(s))
                            {
                                comIndex = treeView.Nodes.IndexOfKey(s);
                                nodesFromObject(treeView.Nodes[comIndex], propinfo.GetValue(data));
                            }
                            else
                            {
                                treeView.Nodes.Add(s, s);
                                comIndex = treeView.Nodes.IndexOfKey(s);
                                nodesFromObject(treeView.Nodes[comIndex], propinfo.GetValue(data));
                            }
                        }
                        else
                        {
                            if (treeView.Nodes.ContainsKey(s))
                            {
                                comIndex = treeView.Nodes.IndexOfKey(s);
                            }
                            else
                            {
                                treeView.Nodes.Add(s, s);
                                comIndex = treeView.Nodes.IndexOfKey(s);
                            }
                        }
                        treeNode = treeView.Nodes[comIndex];
                    }
                    else
                    {
                        if (treeNode.Nodes.ContainsKey(propinfo.Name))
                        {
                            if (!propinfo.GetValue(data).GetType().IsSerializable)
                            {
                                nodesFromObject(treeNode.Nodes[treeNode.Nodes.IndexOfKey(propinfo.Name)], propinfo.GetValue(data));
                            }
                            else
                            {
                                treeNode.Nodes[treeNode.Nodes.IndexOfKey(propinfo.Name)].Text = $"{propinfo.Name}: {propinfo.GetValue(data)}";
                            }
                        }
                        else
                        {
                            if (!propinfo.GetValue(data).GetType().IsSerializable)

                            {
                                treeNode.Nodes.Add(propinfo.Name, propinfo.Name);
                                nodesFromObject(treeNode.Nodes[treeNode.Nodes.IndexOfKey(propinfo.Name)], propinfo.GetValue(data));
                            }
                            else
                            {
                                treeNode.Nodes.Add(propinfo.Name, $"{propinfo.Name}: {propinfo.GetValue(data)}");
                            }
                        }
                    }

                }
            }
        }
        private void chartsFromObject(object data)
        {
            foreach (PropertyInfo propinfo in data.GetType().GetProperties())
            {
                if (propinfo.GetValue(data) != null)
                {
                    if (IsDouble(propinfo.GetValue(data).ToString()))
                    {
                        if (!flowLayoutPanel.Controls.ContainsKey($"{propinfo.Name}Chart"))
                        {
                            addChart(propinfo.Name);
                        }
                        Chart relatedChart = (Chart)flowLayoutPanel.Controls.Find($"{propinfo.Name}Chart", false).First();

                        string s = data.GetType().GetProperty(comPropName) != null && data.GetType().GetProperty(comPropName).GetValue(data) != null ? $"{data.GetType().GetProperty(comPropName).GetValue(data)}" : "UnknownID";
                        if (relatedChart.Series.IsUniqueName(s))
                        {
                            relatedChart.Series.Add(s);
                            relatedChart.Series[relatedChart.Series.IndexOf(s)].ChartType = SeriesChartType.Spline;
                            relatedChart.Series[relatedChart.Series.IndexOf(s)].MarkerStyle = MarkerStyle.Diamond;
                        }
                        relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.AddXY(DateTime.Now, propinfo.GetValue(data));

                    }
                    else if (!propinfo.GetValue(data).GetType().IsSerializable)
                    {
                        if (!flowLayoutPanel.Controls.ContainsKey($"{propinfo.Name}Chart"))
                        {
                            addChart(propinfo.Name);
                        }
                        Chart relatedChart = (Chart)flowLayoutPanel.Controls.Find($"{propinfo.Name}Chart", false).First();
                        foreach (PropertyInfo propinfo2 in data.GetType().GetProperty(propinfo.Name).GetValue(data).GetType().GetProperties())
                        {
                            string s = data.GetType().GetProperty(comPropName) != null && data.GetType().GetProperty(comPropName).GetValue(data) != null ? $"{data.GetType().GetProperty(comPropName).GetValue(data)} ({propinfo2.Name})" : "UnknownID";
                            if (relatedChart.Series.IsUniqueName(s))
                            {
                                relatedChart.Series.Add(s);
                                relatedChart.Series[relatedChart.Series.IndexOf(s)].ChartType = SeriesChartType.Spline;
                                relatedChart.Series[relatedChart.Series.IndexOf(s)].MarkerStyle = MarkerStyle.Diamond;

                            }
                            relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.AddXY(DateTime.Now, propinfo.GetValue(data).GetType().GetProperty(propinfo2.Name).GetValue(propinfo.GetValue(data)));
                        }
                    }
                }
            }
        }
        private void addChart(string name)
        {
            var newchart = new Chart();
            ChartArea newChartArea = new ChartArea();
            newchart.ChartAreas.Add(newChartArea);
            newchart.Margin = new Padding(0);
            newchart.Location = new Point(0, 0);
            newchart.Size = new Size(479, 272);
            newchart.Name = $"{name}Chart";
            newchart.Text = $"{name}Chart";
            newchart.Titles.Add(name);
            Legend newlegend = new Legend();
            newlegend.Docking = Docking.Bottom;

            newchart.Legends.Add(newlegend);
            flowLayoutPanel.Controls.Add(newchart);
        }
        private bool IsDouble(string input)
        {
            return double.TryParse(input, out _);
        }



        //DATA SIMULATION
        //bool simIsOn = false;
        private void dataSimWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //int interval = Convert.ToInt32(intervalSelect.SelectedText);
            //stopwatch.Start();
            //simIsOn = !simIsOn;

            //while (simIsOn)
            //{
            //    long time = (long)stopwatch.Elapsed.TotalSeconds;
            //    dataFromCSV(time, "selected path");
            //    Thread.Sleep(interval);
            //}
        }
        private void dataFromCSV(long time, string filepath)
        {
            defaultDataset dataset = new defaultDataset();
            dataset.T = time;
            dataset.S = time < 10 ? "Launch" : time < 180 ? "Burnout" : time < 240 ? "Apogee" : time < 300 ? "First recovery" : time < 360 ? "Second Recovery" : "Landed";
            //dataset.GPS.Longitude *= time / 10000;
            //dataset.GPS.Latitude *= time / 10000;
            //dataset.Tmp = multiplyWithRandBtw(dataset.Tmp, 0.9, 1.1);
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

            }
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

        //FILE SETTINGS
        private void docsNew_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                docsFilePath = folderBrowserDialog.SelectedPath;
                docsItem.Text = $"Documents folder: \"{docsFilePath}\"";
            }
        }
        private void docsItem_Click(object sender, EventArgs e)
        {
            docsOpen_Click(sender,e);
        }
        private void docsOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(docsFilePath);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void docsCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(docsFilePath);
        }
        private void newLogFile()
        {
            logFileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");
            logItem.Text = $"Log file name: \"{logFileName}.csv\"";
        }
        private void logNew_Click(object sender, EventArgs e)
        {
            newLogFile();
        }
        private void logOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(logFilePath());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void logCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logFilePath());
        }
        //CLEAR ITEMS
        private void clearAll_Click(object sender, EventArgs e)
        {
            clearTreeview_Click(sender, e);
            clearCharts_Click(sender, e);
            clearGPS_Click(sender, e);
        }
        private void clearTreeview_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            totaldelay = 0;
            avg = 0;
            successcount = 0;
            failcount = 0;
            packetLabel.Text = $"Packet count (S/F): {successcount}/{failcount}";
            delayLabel.Text = $"Avg delay: {avg} ms";
            packetWatch.Reset();
        }
        private void clearCharts_Click(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
        }
        private void clearGPS_Click(object sender, EventArgs e)
        {
            map.Overlays.Clear();
            map.Zoom--;
            map.Zoom++;
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
    }
}