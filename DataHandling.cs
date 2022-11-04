using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace groundstation
{
    partial class MainForm
    {
        private int _successCount = 0, _failCount = 0;
        private string _incomingData = string.Empty;
        private readonly Stopwatch _packetWatch = new Stopwatch();
        private long _totalDelay = 0, _avg = 0;
        private const int MaxDataPoints = 9999;

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.WriteLine($"datareceived at {DateTime.Now.Millisecond}");
            try
            {
                while (serialPort1.BytesToRead > 0)
                {
                    var newByte = (char)serialPort1.ReadByte();
                    if (newByte != '+')
                    {
                        _incomingData += newByte;
                        //Console.WriteLine($"{newbyte} is added to incomingdata={incomingdata}");
                    }
                    else
                    {
                        try
                        {
                            var definition = new
                            {
                                C = string.Empty,
                                T = string.Empty,
                                S = string.Empty,
                                Tmp = new long?(),
                                A = new double?(),
                                P = new double?(),
                                H = new double?(),
                                GPS = new { Lat = new double?(), Lon = new double?() },
                                //GPS = new { Lat = string.Empty, Lon = string.Empty },
                                Acc = new { X = new double?(), Y = new double?(), Z = new double?() },
                                Gyro = new { X = new double?(), Y = new double?(), Z = new double?() },
                                B = new double?()
                            };
                            var data = JsonConvert.DeserializeAnonymousType(_incomingData, definition);
                            BeginInvoke(new Action(() =>
                            {
                                ApplyToUi(data);
                                packetLabel.Text = $"Packet count (S/F): {++_successCount}/{_failCount} ({_packetWatch.ElapsedMilliseconds} ms)";
                                _totalDelay += _packetWatch.ElapsedMilliseconds;
                                _avg = (_totalDelay + _packetWatch.ElapsedMilliseconds) / _successCount;
                                delayLabel.Text = $"Avg delay: {_avg} ms";
                                if (_packetWatch.IsRunning)
                                {
                                    _packetWatch.Restart();
                                }
                                else
                                {
                                    _packetWatch.Start();
                                }
                            }));
                            loggerWorker.RunWorkerAsync(data);
                        }
                        catch (Exception)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                packetLabel.Text = $"Packet count (S/F): {_successCount}/{++_failCount}";
                            }));
                        }
                        //Console.WriteLine($"sequence completed with datastring: {incomingdata}");
                        _incomingData = string.Empty;
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
        private void ApplyToUi(object data)
        {
            MapFromObject(data);
            NodesFromObject(null, data);

            ChartsFromObject(data);
            treeView.ExpandAll();
        }
        private void NodesFromObject(TreeNode treeNode, object data)
        {
            // USE NULL PARAMETER FOR INITIAL CALL
            foreach (var propInfo in data.GetType().GetProperties())
            {
                if (propInfo.GetValue(data) == null) continue;
                if (treeNode == null)
                {
                    var comIndex = -2;
                    var s = propInfo.Name == ComPropName ? $"{propInfo.GetValue(data)}" : "(Unknown ID)";
                    if (!propInfo.GetValue(data).GetType().IsSerializable)
                    {
                        if (treeView.Nodes.ContainsKey(s))
                        {
                            comIndex = treeView.Nodes.IndexOfKey(s);
                            NodesFromObject(treeView.Nodes[comIndex], propInfo.GetValue(data));
                        }
                        else
                        {
                            treeView.Nodes.Add(s, s);
                            comIndex = treeView.Nodes.IndexOfKey(s);
                            NodesFromObject(treeView.Nodes[comIndex], propInfo.GetValue(data));
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
                    if (treeNode.Nodes.ContainsKey(propInfo.Name))
                    {
                        if (!propInfo.GetValue(data).GetType().IsSerializable)
                        {
                            NodesFromObject(treeNode.Nodes[treeNode.Nodes.IndexOfKey(propInfo.Name)], propInfo.GetValue(data));
                        }
                        else
                        {
                            treeNode.Nodes[treeNode.Nodes.IndexOfKey(propInfo.Name)].Text = $"{propInfo.Name}: {propInfo.GetValue(data)}";
                        }
                    }
                    else
                    {
                        if (!propInfo.GetValue(data).GetType().IsSerializable)

                        {
                            treeNode.Nodes.Add(propInfo.Name, propInfo.Name);
                            NodesFromObject(treeNode.Nodes[treeNode.Nodes.IndexOfKey(propInfo.Name)], propInfo.GetValue(data));
                        }
                        else
                        {
                            treeNode.Nodes.Add(propInfo.Name, $"{propInfo.Name}: {propInfo.GetValue(data)}");
                        }
                    }
                }
            }
        }
        private void ChartsFromObject(object data)
        {
            foreach (var propInfo in data.GetType().GetProperties())
            {
                if (propInfo.GetValue(data) == null) continue;
                if (IsDouble(propInfo.GetValue(data).ToString()))
                {
                    if (!flowLayoutPanel.Controls.ContainsKey($"{propInfo.Name}Chart"))
                    {
                        AddChart(propInfo.Name);
                    }
                    var relatedChart = (Chart)flowLayoutPanel.Controls.Find($"{propInfo.Name}Chart", false).First();
                    var s = data.GetType().GetProperty(ComPropName) != null && data.GetType().GetProperty(ComPropName)?.GetValue(data) != null ? $"{data.GetType().GetProperty(ComPropName)?.GetValue(data)}" : "UnknownID";
                    if (relatedChart.Series.IsUniqueName(s))
                    {
                        relatedChart.Series.Add(s);
                        relatedChart.Series[relatedChart.Series.IndexOf(s)].ChartType = SeriesChartType.FastLine;
                        relatedChart.Series[relatedChart.Series.IndexOf(s)].BorderWidth = 2;
                        //relatedChart.Series[relatedChart.Series.IndexOf(s)].MarkerStyle = MarkerStyle.Diamond;
                    }
                    if (relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.Count > MaxDataPoints)
                    {
                        relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.RemoveAt(0);
                        relatedChart.ChartAreas[0].RecalculateAxesScale();
                    }
                    relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.AddXY(_x, propInfo.GetValue(data));
                }
                else if (!propInfo.GetValue(data).GetType().IsSerializable)
                {
                    if (!flowLayoutPanel.Controls.ContainsKey($"{propInfo.Name}Chart"))
                    {
                        AddChart(propInfo.Name);
                    }
                    var relatedChart = (Chart)flowLayoutPanel.Controls.Find($"{propInfo.Name}Chart", false).First();
                    foreach (var propInfo2 in data.GetType().GetProperty(propInfo.Name)?.GetValue(data).GetType().GetProperties())
                    {
                        var s = data.GetType().GetProperty(ComPropName) != null && data.GetType().GetProperty(ComPropName)?.GetValue(data) != null ? $"{data.GetType().GetProperty(ComPropName)?.GetValue(data)} ({propInfo2.Name})" : "UnknownID";
                        if (relatedChart.Series.IsUniqueName(s))
                        {
                            relatedChart.Series.Add(s);
                            relatedChart.Series[relatedChart.Series.IndexOf(s)].ChartType = SeriesChartType.FastLine;
                            relatedChart.Series[relatedChart.Series.IndexOf(s)].BorderWidth = 2;
                            //relatedChart.Series[relatedChart.Series.IndexOf(s)].MarkerStyle = MarkerStyle.Diamond;
                        }
                        if (relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.Count > MaxDataPoints)
                        {
                            relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.RemoveAt(0);
                            relatedChart.ChartAreas[0].RecalculateAxesScale();
                        }
                        relatedChart.Series[relatedChart.Series.IndexOf(s)].Points.AddXY(_x, propInfo.GetValue(data).GetType().GetProperty(propInfo2.Name)?.GetValue(propInfo.GetValue(data)));
                    }
                }
            }
        }
        private void AddChart(string name)
        {
            var newChart = new Chart();
            var newChartArea = new ChartArea();
            newChart.ChartAreas.Add(newChartArea);
            newChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            newChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            newChart.Margin = new Padding(0);
            newChart.Location = new Point(0, 0);
            newChart.Size = new Size(479, 272);
            newChart.Name = $"{name}Chart";
            newChart.Text = $"{name}Chart";
            newChart.Titles.Add(name);
            var newLegend = new Legend();
            newLegend.Docking = Docking.Bottom;

            newChart.Legends.Add(newLegend);
            flowLayoutPanel.Controls.Add(newChart);
        }
        private bool IsDouble(string input)
        {
            return double.TryParse(input, out _);
        }
        //CLEAR UI ITEMS
        private void clearAll_Click(object sender, EventArgs e)
        {
            clearTreeView_Click(sender, e);
            clearCharts_Click(sender, e);
            clearGPS_Click(sender, e);
        }
        private void clearTreeView_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            _totalDelay = 0;
            _avg = 0;
            _successCount = 0;
            _failCount = 0;
            packetLabel.Text = $"Packet count (S/F): {_successCount}/{_failCount}";
            delayLabel.Text = $"Avg delay: {_avg} ms";
            _packetWatch.Reset();
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
