using System.Windows.Forms;

namespace groundstation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataTableBox = new System.Windows.Forms.GroupBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.packetLabel = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.camPicture = new System.Windows.Forms.PictureBox();
            this.cameraBox = new System.Windows.Forms.GroupBox();
            this.recBtn = new System.Windows.Forms.Button();
            this.ssBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.camSelect = new System.Windows.Forms.ComboBox();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.graphicsBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.portOpenCloseWorker = new System.ComponentModel.BackgroundWorker();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noGPSLabel = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.loggerWorker = new System.ComponentModel.BackgroundWorker();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.portSelect = new System.Windows.Forms.ToolStripComboBox();
            this.baudSelect = new System.Windows.Forms.ToolStripComboBox();
            this.serialBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.serialText = new System.Windows.Forms.ToolStripComboBox();
            this.sendLineBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.endingSelect = new System.Windows.Forms.ToolStripComboBox();
            this.sendFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.serialProg = new System.Windows.Forms.ToolStripProgressBar();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.docsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.docsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.logItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logNew = new System.Windows.Forms.ToolStripMenuItem();
            this.logPortOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.logCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.logOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTreeview = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCharts = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGPS = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTableBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camPicture)).BeginInit();
            this.cameraBox.SuspendLayout();
            this.graphicsBox.SuspendLayout();
            this.simBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // dataTableBox
            // 
            this.dataTableBox.Controls.Add(this.delayLabel);
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
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 30);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(976, 556);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // portOpenCloseWorker
            // 
            this.portOpenCloseWorker.WorkerReportsProgress = true;
            this.portOpenCloseWorker.WorkerSupportsCancellation = true;
            this.portOpenCloseWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.portOpenCloseWorker_DoWork);
            this.portOpenCloseWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.portOpenCloseWorker_RunWorkerCompleted);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noGPSLabel);
            this.groupBox1.Controls.Add(this.map);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1380, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 342);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // noGPSLabel
            // 
            this.noGPSLabel.AutoSize = true;
            this.noGPSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noGPSLabel.ForeColor = System.Drawing.Color.Red;
            this.noGPSLabel.Location = new System.Drawing.Point(106, 280);
            this.noGPSLabel.Name = "noGPSLabel";
            this.noGPSLabel.Size = new System.Drawing.Size(292, 37);
            this.noGPSLabel.TabIndex = 2;
            this.noGPSLabel.Text = "NO GPS SIGNAL!";
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
            // loggerWorker
            // 
            this.loggerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loggerWorker_DoWork);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portSelect,
            this.baudSelect,
            this.serialBtn,
            this.serialText,
            this.sendLineBtn,
            this.endingSelect,
            this.sendFileBtn,
            this.serialProg,
            this.exitBtn,
            this.settingsItem,
            this.toolStripSeparator2,
            this.clearItem});
            this.toolStrip.Location = new System.Drawing.Point(0, 991);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(1904, 50);
            this.toolStrip.TabIndex = 16;
            this.toolStrip.Text = "toolStrip";
            // 
            // portSelect
            // 
            this.portSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.portSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portSelect.Margin = new System.Windows.Forms.Padding(12, 0, 1, 0);
            this.portSelect.Name = "portSelect";
            this.portSelect.Size = new System.Drawing.Size(120, 50);
            this.portSelect.ToolTipText = "COM Port";
            this.portSelect.DropDown += new System.EventHandler(this.portSelect_DropDown);
            // 
            // baudSelect
            // 
            this.baudSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.baudSelect.Name = "baudSelect";
            this.baudSelect.Size = new System.Drawing.Size(90, 50);
            this.baudSelect.Text = "9600";
            this.baudSelect.SelectedIndexChanged += new System.EventHandler(this.baudSelect_SelectedIndexChanged);
            // 
            // serialBtn
            // 
            this.serialBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialBtn.ForeColor = System.Drawing.Color.Red;
            this.serialBtn.Margin = new System.Windows.Forms.Padding(6);
            this.serialBtn.Name = "serialBtn";
            this.serialBtn.Size = new System.Drawing.Size(99, 38);
            this.serialBtn.Text = "Open Port";
            this.serialBtn.Click += new System.EventHandler(this.serialBtn_Click);
            this.serialBtn.MouseLeave += new System.EventHandler(this.serialBtn_MouseLeave);
            this.serialBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.serialBtn_MouseMove);
            // 
            // serialText
            // 
            this.serialText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serialText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.serialText.Enabled = false;
            this.serialText.Name = "serialText";
            this.serialText.Size = new System.Drawing.Size(300, 50);
            this.serialText.Tag = "commandList";
            this.serialText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialText_KeyDown);
            // 
            // sendLineBtn
            // 
            this.sendLineBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sendLineBtn.Enabled = false;
            this.sendLineBtn.Image = ((System.Drawing.Image)(resources.GetObject("sendLineBtn.Image")));
            this.sendLineBtn.Margin = new System.Windows.Forms.Padding(6);
            this.sendLineBtn.Name = "sendLineBtn";
            this.sendLineBtn.Size = new System.Drawing.Size(73, 38);
            this.sendLineBtn.Text = "Send";
            this.sendLineBtn.Click += new System.EventHandler(this.sendLineBtn_Click);
            // 
            // endingSelect
            // 
            this.endingSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endingSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endingSelect.Items.AddRange(new object[] {
            "No line ending",
            "Newline",
            "Carriage return",
            "Both NL & CR"});
            this.endingSelect.Name = "endingSelect";
            this.endingSelect.Size = new System.Drawing.Size(121, 50);
            this.endingSelect.Text = "Newline";
            // 
            // sendFileBtn
            // 
            this.sendFileBtn.Enabled = false;
            this.sendFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("sendFileBtn.Image")));
            this.sendFileBtn.Margin = new System.Windows.Forms.Padding(6);
            this.sendFileBtn.Name = "sendFileBtn";
            this.sendFileBtn.Size = new System.Drawing.Size(122, 38);
            this.sendFileBtn.Text = "Transfer File";
            this.sendFileBtn.Click += new System.EventHandler(this.sendFileBtn_Click);
            // 
            // serialProg
            // 
            this.serialProg.AutoSize = false;
            this.serialProg.Maximum = 1000000;
            this.serialProg.Name = "serialProg";
            this.serialProg.Size = new System.Drawing.Size(100, 30);
            // 
            // exitBtn
            // 
            this.exitBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitBtn.AutoSize = false;
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Padding = new System.Windows.Forms.Padding(0);
            this.exitBtn.Size = new System.Drawing.Size(50, 50);
            this.exitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // settingsItem
            // 
            this.settingsItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docsItem,
            this.logItem});
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.Size = new System.Drawing.Size(78, 50);
            this.settingsItem.Text = "Settings";
            // 
            // docsItem
            // 
            this.docsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docsNew,
            this.docsCopy,
            this.docsOpen});
            this.docsItem.Name = "docsItem";
            this.docsItem.Size = new System.Drawing.Size(184, 26);
            this.docsItem.Text = "docsfolderpath";
            this.docsItem.Click += new System.EventHandler(this.docsItem_Click);
            // 
            // docsNew
            // 
            this.docsNew.Name = "docsNew";
            this.docsNew.Size = new System.Drawing.Size(238, 26);
            this.docsNew.Text = "Select new folder";
            this.docsNew.Click += new System.EventHandler(this.docsNew_Click);
            // 
            // docsCopy
            // 
            this.docsCopy.Name = "docsCopy";
            this.docsCopy.Size = new System.Drawing.Size(238, 26);
            this.docsCopy.Text = "Copy path to clipboard";
            this.docsCopy.Click += new System.EventHandler(this.docsCopy_Click);
            // 
            // docsOpen
            // 
            this.docsOpen.Name = "docsOpen";
            this.docsOpen.Size = new System.Drawing.Size(238, 26);
            this.docsOpen.Text = "Open in explorer";
            this.docsOpen.Click += new System.EventHandler(this.docsOpen_Click);
            // 
            // logItem
            // 
            this.logItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logNew,
            this.logPortOpen,
            this.logCopy,
            this.logOpen});
            this.logItem.Name = "logItem";
            this.logItem.Size = new System.Drawing.Size(184, 26);
            this.logItem.Text = "logfilepath";
            // 
            // logNew
            // 
            this.logNew.Name = "logNew";
            this.logNew.Size = new System.Drawing.Size(253, 26);
            this.logNew.Text = "New log file...";
            this.logNew.Click += new System.EventHandler(this.logNew_Click);
            // 
            // logPortOpen
            // 
            this.logPortOpen.Checked = true;
            this.logPortOpen.CheckOnClick = true;
            this.logPortOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logPortOpen.Name = "logPortOpen";
            this.logPortOpen.Size = new System.Drawing.Size(253, 26);
            this.logPortOpen.Text = "New file on port opening";
            // 
            // logCopy
            // 
            this.logCopy.Name = "logCopy";
            this.logCopy.Size = new System.Drawing.Size(253, 26);
            this.logCopy.Text = "Copy path to clipboard";
            this.logCopy.Click += new System.EventHandler(this.logCopy_Click);
            // 
            // logOpen
            // 
            this.logOpen.Name = "logOpen";
            this.logOpen.Size = new System.Drawing.Size(253, 26);
            this.logOpen.Text = "Open file";
            this.logOpen.Click += new System.EventHandler(this.logOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // clearItem
            // 
            this.clearItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clearItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAll,
            this.toolStripSeparator1,
            this.clearTreeview,
            this.clearCharts,
            this.clearGPS});
            this.clearItem.Name = "clearItem";
            this.clearItem.Size = new System.Drawing.Size(58, 50);
            this.clearItem.Text = "Clear";
            // 
            // clearAll
            // 
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(179, 26);
            this.clearAll.Text = "Clear all";
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // clearTreeview
            // 
            this.clearTreeview.Name = "clearTreeview";
            this.clearTreeview.Size = new System.Drawing.Size(179, 26);
            this.clearTreeview.Text = "Clear treeview";
            this.clearTreeview.Click += new System.EventHandler(this.clearTreeview_Click);
            // 
            // clearCharts
            // 
            this.clearCharts.Name = "clearCharts";
            this.clearCharts.Size = new System.Drawing.Size(179, 26);
            this.clearCharts.Text = "Clear charts";
            this.clearCharts.Click += new System.EventHandler(this.clearCharts_Click);
            // 
            // clearGPS
            // 
            this.clearGPS.Name = "clearGPS";
            this.clearGPS.Size = new System.Drawing.Size(179, 26);
            this.clearGPS.Text = "Clear GPS";
            this.clearGPS.Click += new System.EventHandler(this.clearGPS_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.simBox);
            this.Controls.Add(this.graphicsBox);
            this.Controls.Add(this.cameraBox);
            this.Controls.Add(this.dataTableBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Ground Station Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.dataTableBox.ResumeLayout(false);
            this.dataTableBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camPicture)).EndInit();
            this.cameraBox.ResumeLayout(false);
            this.graphicsBox.ResumeLayout(false);
            this.simBox.ResumeLayout(false);
            this.simBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.GroupBox graphicsBox;
        private System.Windows.Forms.TreeView treeView;
        private System.ComponentModel.BackgroundWorker portOpenCloseWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker fileSenderWorker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
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
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Label noGPSLabel;
        private System.ComponentModel.BackgroundWorker loggerWorker;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox portSelect;
        private System.Windows.Forms.ToolStripComboBox baudSelect;
        private System.Windows.Forms.ToolStripMenuItem serialBtn;
        private System.Windows.Forms.ToolStripMenuItem sendLineBtn;
        private System.Windows.Forms.ToolStripMenuItem sendFileBtn;
        private System.Windows.Forms.ToolStripComboBox endingSelect;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.ToolStripMenuItem settingsItem;
        private System.Windows.Forms.ToolStripProgressBar serialProg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearItem;
        private System.Windows.Forms.ToolStripMenuItem docsItem;
        private System.Windows.Forms.ToolStripMenuItem docsNew;
        private System.Windows.Forms.ToolStripMenuItem docsCopy;
        private System.Windows.Forms.ToolStripMenuItem docsOpen;
        private System.Windows.Forms.ToolStripMenuItem logItem;
        private System.Windows.Forms.ToolStripMenuItem logNew;
        private System.Windows.Forms.ToolStripMenuItem logPortOpen;
        private System.Windows.Forms.ToolStripMenuItem logCopy;
        private System.Windows.Forms.ToolStripMenuItem logOpen;
        private System.Windows.Forms.ToolStripMenuItem clearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearTreeview;
        private System.Windows.Forms.ToolStripMenuItem clearCharts;
        private System.Windows.Forms.ToolStripMenuItem clearGPS;
        private System.Windows.Forms.ToolStripComboBox serialText;
    }
}

