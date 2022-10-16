using CsvHelper;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System;

namespace groundstation
{
    partial class MainForm
    {
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
    }
}