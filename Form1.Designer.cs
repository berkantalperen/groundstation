namespace groundstation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea29 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea30 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea31 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea32 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataTableBox = new System.Windows.Forms.GroupBox();
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
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.intervalSelect = new System.Windows.Forms.ComboBox();
            this.simBtn = new System.Windows.Forms.Button();
            this.dataSimWorker = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.dataTableBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camPicture)).BeginInit();
            this.cameraBox.SuspendLayout();
            this.graphicsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.serialBox.SuspendLayout();
            this.fileBox.SuspendLayout();
            this.simBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea29.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea29);
            this.chart1.Location = new System.Drawing.Point(12, 30);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(482, 272);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // dataTableBox
            // 
            this.dataTableBox.Controls.Add(this.treeView);
            this.dataTableBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTableBox.Location = new System.Drawing.Point(36, 24);
            this.dataTableBox.Name = "dataTableBox";
            this.dataTableBox.Size = new System.Drawing.Size(320, 598);
            this.dataTableBox.TabIndex = 1;
            this.dataTableBox.TabStop = false;
            this.dataTableBox.Text = "Data Table";
            // 
            // treeView
            // 
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
            this.graphicsBox.Controls.Add(this.chart3);
            this.graphicsBox.Controls.Add(this.chart4);
            this.graphicsBox.Controls.Add(this.chart2);
            this.graphicsBox.Controls.Add(this.chart1);
            this.graphicsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsBox.Location = new System.Drawing.Point(368, 24);
            this.graphicsBox.Name = "graphicsBox";
            this.graphicsBox.Size = new System.Drawing.Size(1000, 598);
            this.graphicsBox.TabIndex = 10;
            this.graphicsBox.TabStop = false;
            this.graphicsBox.Text = "Graphics";
            // 
            // chart3
            // 
            chartArea30.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea30);
            this.chart3.Location = new System.Drawing.Point(506, 314);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(482, 272);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // chart4
            // 
            chartArea31.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea31);
            this.chart4.Location = new System.Drawing.Point(12, 314);
            this.chart4.Name = "chart4";
            this.chart4.Size = new System.Drawing.Size(482, 272);
            this.chart4.TabIndex = 2;
            this.chart4.Text = "chart4";
            // 
            // chart2
            // 
            chartArea32.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea32);
            this.chart2.Location = new System.Drawing.Point(506, 30);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(482, 272);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
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
            this.baudSelect.Text = "57600";
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
            this.fileBox.Text = "File Location";
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
            this.simBox.Controls.Add(this.label2);
            this.simBox.Controls.Add(this.label1);
            this.simBox.Controls.Add(this.comboBox2);
            this.simBox.Controls.Add(this.intervalSelect);
            this.simBox.Controls.Add(this.simBtn);
            this.simBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simBox.Location = new System.Drawing.Point(36, 836);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(320, 140);
            this.simBox.TabIndex = 12;
            this.simBox.TabStop = false;
            this.simBox.Text = "Data Simulation";
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
            this.simBtn.Location = new System.Drawing.Point(248, 52);
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
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(593, 676);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label3);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.dataTableBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.camPicture)).EndInit();
            this.cameraBox.ResumeLayout(false);
            this.graphicsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.serialBox.ResumeLayout(false);
            this.serialBox.PerformLayout();
            this.fileBox.ResumeLayout(false);
            this.simBox.ResumeLayout(false);
            this.simBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}

