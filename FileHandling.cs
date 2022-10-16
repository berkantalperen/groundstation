using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace groundstation
{
    partial class MainForm
    {
        //FILE SETTINGS
        private void init_file()
        {
            if (!Directory.Exists(docsFilePath))
            {
                Directory.CreateDirectory(docsFilePath);
            }
            docsItem.Text = $"Documents folder: \"{docsFilePath}\"";
            newLogFile();
        }
        public string logFilePath()
        {
            if (!Directory.Exists(docsFilePath + "\\Logs"))
            {
                Directory.CreateDirectory(docsFilePath + "\\Logs");
            }
            return $"{docsFilePath}\\Logs\\{logFileName}.csv";
        }
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
            docsOpen_Click(sender, e);
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
    }
}
