﻿namespace groundstation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataTableBox = new System.Windows.Forms.GroupBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.clearTreeBtn = new System.Windows.Forms.Button();
            this.packetLabel = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.camPicture = new System.Windows.Forms.PictureBox();
            this.cameraBox = new System.Windows.Forms.GroupBox();
            this.recBtn = new System.Windows.Forms.Button();
            this.ssBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.camSelect = new System.Windows.Forms.ComboBox();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.graphicsBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialBox = new System.Windows.Forms.GroupBox();
            this.sendLineBtn = new System.Windows.Forms.Button();
            this.serialText = new System.Windows.Forms.RichTextBox();
            this.sendFileBtn = new System.Windows.Forms.Button();
            this.serialProg = new System.Windows.Forms.ProgressBar();
            this.portLabel = new System.Windows.Forms.Label();
            this.portSelect = new System.Windows.Forms.ComboBox();
            this.baudSelect = new System.Windows.Forms.ComboBox();
            this.serialBtn = new System.Windows.Forms.Button();
            this.portOpenCloseWorker = new System.ComponentModel.BackgroundWorker();
            this.fileBox = new System.Windows.Forms.GroupBox();
            this.fileText = new System.Windows.Forms.RichTextBox();
            this.fileBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSenderWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.simBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.intervalSelect = new System.Windows.Forms.ComboBox();
            this.simBtn = new System.Windows.Forms.Button();
            this.dataSimWorker = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.button3 = new System.Windows.Forms.Button();
            this.dataTableBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camPicture)).BeginInit();
            this.cameraBox.SuspendLayout();
            this.graphicsBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.serialBox.SuspendLayout();
            this.fileBox.SuspendLayout();
            this.simBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // dataTableBox
            // 
            this.dataTableBox.Controls.Add(this.delayLabel);
            this.dataTableBox.Controls.Add(this.clearTreeBtn);
            this.dataTableBox.Controls.Add(this.packetLabel);
            this.dataTableBox.Controls.Add(this.treeView);
            this.dataTableBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTableBox.Location = new System.Drawing.Point(36, 24);
            this.dataTableBox.Name = "dataTableBox";
            this.dataTableBox.Size = new System.Drawing.Size(320, 598);
            this.dataTableBox.TabIndex = 1;
            this.dataTableBox.TabStop = false;
            this.dataTableBox.Text = "Data Table";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.BackColor = System.Drawing.Color.White;
            this.delayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayLabel.Location = new System.Drawing.Point(24, 564);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.delayLabel.Size = new System.Drawing.Size(91, 13);
            this.delayLabel.TabIndex = 17;
            this.delayLabel.Text = "Avg delay (ms):    ";
            // 
            // clearTreeBtn
            // 
            this.clearTreeBtn.BackColor = System.Drawing.Color.White;
            this.clearTreeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clearTreeBtn.BackgroundImage")));
            this.clearTreeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearTreeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearTreeBtn.FlatAppearance.BorderSize = 0;
            this.clearTreeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearTreeBtn.Location = new System.Drawing.Point(274, 32);
            this.clearTreeBtn.Name = "clearTreeBtn";
            this.clearTreeBtn.Size = new System.Drawing.Size(32, 32);
            this.clearTreeBtn.TabIndex = 16;
            this.clearTreeBtn.UseVisualStyleBackColor = false;
            this.clearTreeBtn.Click += new System.EventHandler(this.clearTreeBtn_Click);
            // 
            // packetLabel
            // 
            this.packetLabel.AutoSize = true;
            this.packetLabel.BackColor = System.Drawing.Color.White;
            this.packetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packetLabel.Location = new System.Drawing.Point(24, 551);
            this.packetLabel.Name = "packetLabel";
            this.packetLabel.Size = new System.Drawing.Size(101, 13);
            this.packetLabel.TabIndex = 1;
            this.packetLabel.Text = "Packet count (S/F):";
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(12, 30);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(296, 556);
            this.treeView.TabIndex = 0;
            // 
            // camPicture
            // 
            this.camPicture.Location = new System.Drawing.Point(12, 30);
            this.camPicture.Name = "camPicture";
            this.camPicture.Size = new System.Drawing.Size(480, 270);
            this.camPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.camPicture.TabIndex = 3;
            this.camPicture.TabStop = false;
            // 
            // cameraBox
            // 
            this.cameraBox.Controls.Add(this.button3);
            this.cameraBox.Controls.Add(this.recBtn);
            this.cameraBox.Controls.Add(this.ssBtn);
            this.cameraBox.Controls.Add(this.playBtn);
            this.cameraBox.Controls.Add(this.camSelect);
            this.cameraBox.Controls.Add(this.pauseBtn);
            this.cameraBox.Controls.Add(this.camPicture);
            this.cameraBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraBox.Location = new System.Drawing.Point(1380, 24);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(504, 356);
            this.cameraBox.TabIndex = 4;
            this.cameraBox.TabStop = false;
            this.cameraBox.Text = "Camera";
            // 
            // recBtn
            // 
            this.recBtn.BackColor = System.Drawing.Color.Transparent;
            this.recBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recBtn.BackgroundImage")));
            this.recBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recBtn.FlatAppearance.BorderSize = 0;
            this.recBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recBtn.Location = new System.Drawing.Point(432, 312);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(32, 32);
            this.recBtn.TabIndex = 9;
            this.recBtn.UseVisualStyleBackColor = false;
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // ssBtn
            // 
            this.ssBtn.BackColor = System.Drawing.Color.Transparent;
            this.ssBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ssBtn.BackgroundImage")));
            this.ssBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ssBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ssBtn.FlatAppearance.BorderSize = 0;
            this.ssBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ssBtn.Location = new System.Drawing.Point(388, 312);
            this.ssBtn.Name = "ssBtn";
            this.ssBtn.Size = new System.Drawing.Size(32, 32);
            this.ssBtn.TabIndex = 8;
            this.ssBtn.UseVisualStyleBackColor = false;
            this.ssBtn.Click += new System.EventHandler(this.ssBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.BackColor = System.Drawing.Color.Transparent;
            this.playBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playBtn.BackgroundImage")));
            this.playBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playBtn.FlatAppearance.BorderSize = 0;
            this.playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playBtn.Location = new System.Drawing.Point(40, 312);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(32, 32);
            this.playBtn.TabIndex = 7;
            this.playBtn.UseVisualStyleBackColor = false;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // camSelect
            // 
            this.camSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camSelect.FormattingEnabled = true;
            this.camSelect.Items.AddRange(new object[] {
            "Select capturing device"});
            this.camSelect.Location = new System.Drawing.Point(129, 312);
            this.camSelect.Name = "camSelect";
            this.camSelect.Size = new System.Drawing.Size(248, 32);
            this.camSelect.TabIndex = 6;
            this.camSelect.DropDown += new System.EventHandler(this.camSelect_DropDown);
            // 
            // pauseBtn
            // 
            this.pauseBtn.BackColor = System.Drawing.Color.Transparent;
            this.pauseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pauseBtn.BackgroundImage")));
            this.pauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pauseBtn.FlatAppearance.BorderSize = 0;
            this.pauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseBtn.Location = new System.Drawing.Point(84, 312);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(32, 32);
            this.pauseBtn.TabIndex = 4;
            this.pauseBtn.UseVisualStyleBackColor = false;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.BackgroundImage")));
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Location = new System.Drawing.Point(1870, 1030);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(50, 50);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // graphicsBox
            // 
            this.graphicsBox.Controls.Add(this.flowLayoutPanel);
            this.graphicsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsBox.Location = new System.Drawing.Point(368, 24);
            this.graphicsBox.Name = "graphicsBox";
            this.graphicsBox.Size = new System.Drawing.Size(1000, 598);
            this.graphicsBox.TabIndex = 10;
            this.graphicsBox.TabStop = false;
            this.graphicsBox.Text = "Graphics";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.chart1);
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 30);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(977, 568);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(480, 272);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // serialBox
            // 
            this.serialBox.Controls.Add(this.sendLineBtn);
            this.serialBox.Controls.Add(this.serialText);
            this.serialBox.Controls.Add(this.sendFileBtn);
            this.serialBox.Controls.Add(this.serialProg);
            this.serialBox.Controls.Add(this.portLabel);
            this.serialBox.Controls.Add(this.portSelect);
            this.serialBox.Controls.Add(this.baudSelect);
            this.serialBox.Controls.Add(this.serialBtn);
            this.serialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialBox.Location = new System.Drawing.Point(36, 628);
            this.serialBox.Name = "serialBox";
            this.serialBox.Size = new System.Drawing.Size(320, 202);
            this.serialBox.TabIndex = 2;
            this.serialBox.TabStop = false;
            this.serialBox.Text = "Serial Communication Control";
            // 
            // sendLineBtn
            // 
            this.sendLineBtn.BackColor = System.Drawing.Color.Transparent;
            this.sendLineBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendLineBtn.BackgroundImage")));
            this.sendLineBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendLineBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendLineBtn.Enabled = false;
            this.sendLineBtn.FlatAppearance.BorderSize = 0;
            this.sendLineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendLineBtn.Location = new System.Drawing.Point(232, 135);
            this.sendLineBtn.Name = "sendLineBtn";
            this.sendLineBtn.Size = new System.Drawing.Size(32, 32);
            this.sendLineBtn.TabIndex = 15;
            this.sendLineBtn.UseVisualStyleBackColor = false;
            this.sendLineBtn.Click += new System.EventHandler(this.sendLineBtn_Click);
            // 
            // serialText
            // 
            this.serialText.Enabled = false;
            this.serialText.Location = new System.Drawing.Point(12, 136);
            this.serialText.Name = "serialText";
            this.serialText.Size = new System.Drawing.Size(208, 32);
            this.serialText.TabIndex = 14;
            this.serialText.Text = "";
            this.serialText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialText_KeyPress);
            // 
            // sendFileBtn
            // 
            this.sendFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.sendFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendFileBtn.BackgroundImage")));
            this.sendFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendFileBtn.Enabled = false;
            this.sendFileBtn.FlatAppearance.BorderSize = 0;
            this.sendFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendFileBtn.Location = new System.Drawing.Point(276, 136);
            this.sendFileBtn.Name = "sendFileBtn";
            this.sendFileBtn.Size = new System.Drawing.Size(32, 32);
            this.sendFileBtn.TabIndex = 12;
            this.sendFileBtn.UseVisualStyleBackColor = false;
            this.sendFileBtn.Click += new System.EventHandler(this.sendFileBtn_Click);
            // 
            // serialProg
            // 
            this.serialProg.Location = new System.Drawing.Point(12, 180);
            this.serialProg.Maximum = 1000000;
            this.serialProg.Name = "serialProg";
            this.serialProg.Size = new System.Drawing.Size(296, 10);
            this.serialProg.TabIndex = 13;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.ForeColor = System.Drawing.Color.Red;
            this.portLabel.Location = new System.Drawing.Point(141, 86);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(167, 24);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port Status: Closed";
            // 
            // portSelect
            // 
            this.portSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portSelect.FormattingEnabled = true;
            this.portSelect.Location = new System.Drawing.Point(12, 30);
            this.portSelect.Name = "portSelect";
            this.portSelect.Size = new System.Drawing.Size(142, 32);
            this.portSelect.TabIndex = 2;
            this.portSelect.DropDown += new System.EventHandler(this.portSelect_DropDown);
            // 
            // baudSelect
            // 
            this.baudSelect.FormattingEnabled = true;
            this.baudSelect.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "230400",
            "250000",
            "500000",
            "1000000",
            "2000000"});
            this.baudSelect.Location = new System.Drawing.Point(166, 30);
            this.baudSelect.Name = "baudSelect";
            this.baudSelect.Size = new System.Drawing.Size(142, 32);
            this.baudSelect.TabIndex = 1;
            this.baudSelect.Text = "9600";
            this.baudSelect.SelectedIndexChanged += new System.EventHandler(this.baudSelect_SelectedIndexChanged);
            // 
            // serialBtn
            // 
            this.serialBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serialBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialBtn.Location = new System.Drawing.Point(12, 74);
            this.serialBtn.Name = "serialBtn";
            this.serialBtn.Size = new System.Drawing.Size(110, 50);
            this.serialBtn.TabIndex = 0;
            this.serialBtn.Text = "Open Port";
            this.serialBtn.UseVisualStyleBackColor = true;
            this.serialBtn.Click += new System.EventHandler(this.serialBtn_Click);
            // 
            // portOpenCloseWorker
            // 
            this.portOpenCloseWorker.WorkerReportsProgress = true;
            this.portOpenCloseWorker.WorkerSupportsCancellation = true;
            this.portOpenCloseWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.portOpenCloseWorker_DoWork);
            this.portOpenCloseWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.portOpenCloseWorker_RunWorkerCompleted);
            // 
            // fileBox
            // 
            this.fileBox.Controls.Add(this.fileText);
            this.fileBox.Controls.Add(this.fileBtn);
            this.fileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBox.Location = new System.Drawing.Point(36, 982);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(320, 74);
            this.fileBox.TabIndex = 4;
            this.fileBox.TabStop = false;
            this.fileBox.Text = "Log File Location";
            // 
            // fileText
            // 
            this.fileText.Location = new System.Drawing.Point(12, 30);
            this.fileText.Multiline = false;
            this.fileText.Name = "fileText";
            this.fileText.ReadOnly = true;
            this.fileText.Size = new System.Drawing.Size(252, 32);
            this.fileText.TabIndex = 11;
            this.fileText.Text = "GCSDocs\\";
            // 
            // fileBtn
            // 
            this.fileBtn.BackColor = System.Drawing.Color.Transparent;
            this.fileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fileBtn.BackgroundImage")));
            this.fileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileBtn.FlatAppearance.BorderSize = 0;
            this.fileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileBtn.Location = new System.Drawing.Point(276, 29);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(32, 32);
            this.fileBtn.TabIndex = 10;
            this.fileBtn.UseVisualStyleBackColor = false;
            this.fileBtn.Click += new System.EventHandler(this.fileBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            // 
            // fileSenderWorker
            // 
            this.fileSenderWorker.WorkerReportsProgress = true;
            this.fileSenderWorker.WorkerSupportsCancellation = true;
            this.fileSenderWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileSenderWorker_DoWork);
            this.fileSenderWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileSenderWorker_ProgressChanged);
            this.fileSenderWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileSenderWorker_RunWorkerCompleted);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Choose documents folder location...";
            // 
            // simBox
            // 
            this.simBox.Controls.Add(this.button1);
            this.simBox.Controls.Add(this.richTextBox1);
            this.simBox.Controls.Add(this.label2);
            this.simBox.Controls.Add(this.label1);
            this.simBox.Controls.Add(this.comboBox2);
            this.simBox.Controls.Add(this.intervalSelect);
            this.simBox.Controls.Add(this.simBtn);
            this.simBox.Enabled = false;
            this.simBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simBox.Location = new System.Drawing.Point(36, 836);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(320, 140);
            this.simBox.TabIndex = 12;
            this.simBox.TabStop = false;
            this.simBox.Text = "Data Simulation";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(270, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 99);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(252, 32);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "GCSDocs\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Interval:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Interval:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(92, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(85, 32);
            this.comboBox2.TabIndex = 18;
            // 
            // intervalSelect
            // 
            this.intervalSelect.FormattingEnabled = true;
            this.intervalSelect.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "750",
            "1000",
            "2000"});
            this.intervalSelect.Location = new System.Drawing.Point(92, 30);
            this.intervalSelect.Name = "intervalSelect";
            this.intervalSelect.Size = new System.Drawing.Size(85, 32);
            this.intervalSelect.TabIndex = 17;
            this.intervalSelect.Text = "200";
            // 
            // simBtn
            // 
            this.simBtn.BackColor = System.Drawing.Color.Transparent;
            this.simBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simBtn.BackgroundImage")));
            this.simBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simBtn.FlatAppearance.BorderSize = 0;
            this.simBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simBtn.Location = new System.Drawing.Point(232, 34);
            this.simBtn.Name = "simBtn";
            this.simBtn.Size = new System.Drawing.Size(48, 48);
            this.simBtn.TabIndex = 16;
            this.simBtn.UseVisualStyleBackColor = false;
            this.simBtn.Click += new System.EventHandler(this.simBtn_Click);
            // 
            // dataSimWorker
            // 
            this.dataSimWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dataSimWorker_DoWork);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1808, 1030);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.map);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1380, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 342);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = true;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(12, 30);
            this.map.Margin = new System.Windows.Forms.Padding(0);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 20;
            this.map.MinZoom = 10;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = false;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = false;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(480, 300);
            this.map.TabIndex = 1;
            this.map.Zoom = 15D;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(236, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.simBox);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.serialBox);
            this.Controls.Add(this.graphicsBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.cameraBox);
            this.Controls.Add(this.dataTableBox);
            this.Name = "Form1";
            this.Text = "Ground Station Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.dataTableBox.ResumeLayout(false);
            this.dataTableBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camPicture)).EndInit();
            this.cameraBox.ResumeLayout(false);
            this.graphicsBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.serialBox.ResumeLayout(false);
            this.serialBox.PerformLayout();
            this.fileBox.ResumeLayout(false);
            this.simBox.ResumeLayout(false);
            this.simBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox dataTableBox;
        private System.Windows.Forms.PictureBox camPicture;
        private System.Windows.Forms.GroupBox cameraBox;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.ComboBox camSelect;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button recBtn;
        private System.Windows.Forms.Button ssBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.GroupBox graphicsBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox serialBox;
        private System.Windows.Forms.ComboBox baudSelect;
        private System.Windows.Forms.Button serialBtn;
        private System.Windows.Forms.ComboBox portSelect;
        private System.ComponentModel.BackgroundWorker portOpenCloseWorker;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.GroupBox fileBox;
        private System.Windows.Forms.RichTextBox fileText;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker fileSenderWorker;
        private System.Windows.Forms.ProgressBar serialProg;
        private System.Windows.Forms.Button sendFileBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.RichTextBox serialText;
        private System.Windows.Forms.Button sendLineBtn;
        private System.Windows.Forms.GroupBox simBox;
        private System.Windows.Forms.ComboBox intervalSelect;
        private System.Windows.Forms.Button simBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker dataSimWorker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label packetLabel;
        private System.Windows.Forms.Button clearTreeBtn;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Button button3;
    }
}

