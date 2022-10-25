using System;
using System.Globalization;
using System.Windows.Forms;

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
        public string comPropName = "ComputerName";
        public string gpsPropName = "GPS";
        public string gpsLatPropName = "Latitude";
        public string gpsLonPropName = "Longitude";
        public string timePropName = "Time";
        
        public MainForm()
        {
            WindowState = FormWindowState.Maximized;
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