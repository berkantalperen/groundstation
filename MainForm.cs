using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using CsvHelper;
using System.Globalization;
using Accord.Video.FFMPEG;

namespace groundstation
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class MainForm : Form
    {
        //PRE-DEFINED VARIABLES
        public string docsFilePath = "Docs";
        public string logFileName = "undefined";
        public string[] commandList = { "command1", "command2" };
        public string simFilePath = "";
        double[] ort_pos = { 39.89009702352859, 32.77991689326698 };
        public string comPropName = "C";
        public string gpsPropName = "GPS";
        public string timePropName = "T";
        
        public MainForm()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            init_map();
            init_serial();
            init_file();
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
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            writer.Close();

        }
    }
}