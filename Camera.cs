using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using System.ComponentModel;
using System.Drawing.Imaging;
using CsvHelper;
using Accord.Math;
using GMap.NET.MapProviders;

namespace groundstation
{
    partial class MainForm : Form
    {
        //CAMERA
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        bool recording = false;
        private DateTime? firstFrameTime;
        VideoFileWriter writer = new VideoFileWriter();
        int width = 1280;
        int height = 720;

        private void camPicture_NewFrame(object sender, ref Bitmap bmp)
        {
            if (recording)
            {
                // create new video file
                // create a bitmap to save into the video file
                // write 1000 video frames
                if (firstFrameTime != null)
                {
                    writer.WriteVideoFrame(bmp, DateTime.Now - firstFrameTime.Value);
                }
                else
                {
                    writer.WriteVideoFrame(bmp);
                    firstFrameTime = DateTime.Now;
                }
            }
        }
        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            camPicture.Image = (Bitmap)eventArgs.Frame.Clone();
            if (recording)
            {
                if (firstFrameTime != null)
                {
                    writer.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone(), DateTime.Now - firstFrameTime.Value);
                }
                else
                {
                    writer.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone());
                    firstFrameTime = DateTime.Now;
                }
            }
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
                ssBtn.Enabled = true;
                recBtn.Enabled = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a capture device!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pauseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                videoSource.SignalToStop();
                camPicture.Image = null;
                camSelect.Enabled = true;
                playBtn.Enabled = true;
                pauseBtn.Enabled = false;
                ssBtn.Enabled = false;
                recBtn.Enabled = false;
            }
            catch (NullReferenceException)
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
                if (!Directory.Exists(docsFilePath + "\\Captured"))
                {
                    Directory.CreateDirectory(docsFilePath + "\\Captured");
                }
                Bitmap bmp = (Bitmap)camPicture.Image;
                bmp.Save(docsFilePath + $"\\Captured\\{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.bmp", bmp.RawFormat);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void recBtn_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                writer.Open(docsFilePath + $"\\Captured\\{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.avi", width, height);
            }
            else
            {
                writer.Close();
            }
            recording = !recording;
        }
    }
}
