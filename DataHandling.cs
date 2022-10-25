using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.Json;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace groundstation
{
    partial class MainForm
    {
        private int successcount = 0, failcount = 0;
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
                        Console.WriteLine("++");
                        var definition = new
                        {
                            ComputerName = string.Empty,
                            Time = new long?(),
                            Stage = string.Empty,
                            Temperature = new long?(),
                            Altitude = new double?(),
                            Pressure = new int?(),
                            Humidity = new int?(),
                            GPS = new { Latitude = new double?(), Longitude = new double?() },
                            Acceleration = new { X = new double?(), Y = new double?(), Z = new double?() },
                            Gyro = new { X = new double?(), Y = new double?(), Z = new double?() },
                            BatteryVoltage = new double?()
                        };
                        var data = JsonConvert.DeserializeAnonymousType(incomingdata, definition);
                        Console.WriteLine(data);
                        //defaultDataset data = JsonSerializer.Deserialize<defaultDataset>(incomingdata);
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
                var pos = data.GetType().GetProperty(gpsPropName).GetValue(data);
                if (data.GetType().GetProperty(comPropName) != null && data.GetType().GetProperty(comPropName).GetValue(data) != null)
                {
                    updateMarker((string)data.GetType().GetProperty(comPropName).GetValue(data), (double)pos.GetType().GetProperty(gpsLatPropName).GetValue(pos), (double)pos.GetType().GetProperty(gpsLonPropName).GetValue(pos));
                }
                else
                {
                    updateMarker("unknown", (double)pos.GetType().GetProperty(gpsLatPropName).GetValue(pos), (double)pos.GetType().GetProperty(gpsLonPropName).GetValue(pos));
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
        //CLEAR UI ITEMS
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
    }
}
