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
            if (!Directory.Exists(DocsFilePath))
            {
                Directory.CreateDirectory(DocsFilePath);
            }
            docsItem.Text = $"Documents folder: \"{DocsFilePath}\"";
            NewLogFile();
        }
        public string LogFilePath()
        {
            if (!Directory.Exists(DocsFilePath + "\\Logs"))
            {
                Directory.CreateDirectory(DocsFilePath + "\\Logs");
            }
            return $"{DocsFilePath}\\Logs\\{LogFileName}.csv";
        }
        private void docsNew_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DocsFilePath = folderBrowserDialog.SelectedPath;
                docsItem.Text = $"Documents folder: \"{DocsFilePath}\"";
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
                Process.Start(DocsFilePath);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void docsCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(DocsFilePath);
        }
        private void NewLogFile()
        {
            LogFileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");
            logItem.Text = $"Log file name: \"{LogFileName}.csv\"";
        }
        private void logNew_Click(object sender, EventArgs e)
        {
            NewLogFile();
        }
        private void logOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(LogFilePath());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void logCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(LogFilePath());
        }
    }
}
