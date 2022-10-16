using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace groundstation
{
    partial class MainForm : Form
    {
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
    }
}
