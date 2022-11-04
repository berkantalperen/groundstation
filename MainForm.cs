using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace groundstation
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class MainForm : Form
    {
        //PRE-DEFINED VARIABLES
        public string DocsFilePath = "Docs";
        public string LogFileName = "undefined";
        public object[] CommandList = { "command1", "command2" };
        public string SimFilePath = "";
        readonly double[] _ortPos = { 39.89009702352859, 32.77991689326698 };
        public string ComPropName = "C";
        public string GpsPropName = "GPS";
        public string GpsLatPropName = "Lat";
        public string GpsLonPropName = "Lon";
        public string TimePropName = "Time";
        
        public MainForm()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            init_map();
            init_serial();
            init_file();
            timer1.Start();
        }

        //EXIT CONDITIONS
        private void exitBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you want to exit GCS?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.WaitForStop();
            }
            _videoFileWriter.Close();
        }

        private int _x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //chart1.Series[0].Points.AddXY(x, x ^ 2 *4);
            //chart2.Series[0].Points.AddXY(x, x ^ 2*3);
            //chart3.Series[0].Points.AddXY(x, x ^ 3);
            //chart4.Series[0].Points.AddXY(x, x ^ 5);
            //chart5.Series[0].Points.AddXY(x, Math.Sin(x));
            //chart6.Series[0].Points.AddXY(x, x ^ 2);
            //chart7.Series[0].Points.AddXY(x, x ^ 2);
            //chart8.Series[0].Points.AddXY(x, x ^ 2);
            //chart9.Series[0].Points.AddXY(x, x ^ 2);
            _x++;
        }
    }
}