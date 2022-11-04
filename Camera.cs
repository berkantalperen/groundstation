using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using AForge.Video.DirectShow;

namespace groundstation
{
    partial class MainForm 
    {
        //CAMERA
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        bool _recording = false;
        private readonly VideoFileWriter _videoFileWriter = new VideoFileWriter();
        private const int VideoWidth = 1280;
        private const int VideoHeight = 720;

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            camPicture.Image = (Bitmap)eventArgs.Frame.Clone();
            if (_recording)
            {
                _videoFileWriter.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone());
            }
        }
        private void playBtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (FilterInfo device in _videoDevices)
                {
                    if (device.Name == camSelect.SelectedItem.ToString())
                    {
                        _videoSource = new VideoCaptureDevice(device.MonikerString);
                    }
                }
                _videoSource.NewFrame += VideoSource_NewFrame;
                if (!_videoSource.IsRunning)
                {
                    _videoSource.Start();
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
                _videoSource.SignalToStop();
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
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camSelect.Items.Clear();
            foreach (FilterInfo device in _videoDevices)
            {
                camSelect.Items.Add(device.Name);
            }
        }
        private void ssBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CheckDirectory();
                Bitmap bmp = (Bitmap)camPicture.Image;
                bmp.Save(DocsFilePath + $"\\Captured\\{DateTime.Now:ddMMyyyy_HHmmss}.bmp", bmp.RawFormat);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckDirectory()
        {
            if (!Directory.Exists(DocsFilePath + "\\Captured"))
            {
                Directory.CreateDirectory(DocsFilePath + "\\Captured");
            }
        }
        private void recBtn_Click(object sender, EventArgs e)
        {
            CheckDirectory();
            if (!_recording)
            {
                _videoFileWriter.Open(DocsFilePath + $"\\Captured\\{DateTime.Now:ddMMyyyy_HHmmss}.avi", VideoWidth, VideoHeight);
            }
            else
            {
                _videoFileWriter.Close();
            }
            _recording = !_recording;
        }
    }
}