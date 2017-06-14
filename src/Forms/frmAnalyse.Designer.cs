namespace PMPA.Forms
{
    partial class frmAnalyse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalyse));
            this.grpBallPosition = new System.Windows.Forms.GroupBox();
            this.pbPitch = new System.Windows.Forms.PictureBox();
            this.pbGround = new System.Windows.Forms.PictureBox();
            this.pbBatsmanLeft = new System.Windows.Forms.PictureBox();
            this.pbBatsmanRight = new System.Windows.Forms.PictureBox();
            this.lstMatches = new System.Windows.Forms.ListBox();
            this.lstCountries = new System.Windows.Forms.ListBox();
            this.lstBatsman = new System.Windows.Forms.ListBox();
            this.btnLoadPlayers = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLoadMatches = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbNorun = new System.Windows.Forms.RadioButton();
            this.rb4s = new System.Windows.Forms.RadioButton();
            this.rb6s = new System.Windows.Forms.RadioButton();
            this.rbWicket = new System.Windows.Forms.RadioButton();
            this.lstVideoFiles = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAutoPlaySelected = new System.Windows.Forms.CheckBox();
            this.chkAutoPlayAll = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblEcon = new System.Windows.Forms.Label();
            this.lbl50s = new System.Windows.Forms.Label();
            this.lbl100s = new System.Windows.Forms.Label();
            this.lblSR = new System.Windows.Forms.Label();
            this.lblBallsFaced = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBallPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBatsmanLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBatsmanRight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBallPosition
            // 
            this.grpBallPosition.Controls.Add(this.pbPitch);
            this.grpBallPosition.Controls.Add(this.pbGround);
            this.grpBallPosition.Controls.Add(this.pbBatsmanLeft);
            this.grpBallPosition.Controls.Add(this.pbBatsmanRight);
            this.grpBallPosition.Location = new System.Drawing.Point(373, 163);
            this.grpBallPosition.Name = "grpBallPosition";
            this.grpBallPosition.Size = new System.Drawing.Size(294, 336);
            this.grpBallPosition.TabIndex = 15;
            this.grpBallPosition.TabStop = false;
            this.grpBallPosition.Text = "Ball position information";
            // 
            // pbPitch
            // 
            this.pbPitch.Image = global::PMPA.Properties.Resources.pitch;
            this.pbPitch.Location = new System.Drawing.Point(11, 20);
            this.pbPitch.Name = "pbPitch";
            this.pbPitch.Size = new System.Drawing.Size(100, 169);
            this.pbPitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPitch.TabIndex = 11;
            this.pbPitch.TabStop = false;
            this.pbPitch.Click += new System.EventHandler(this.pbPitch_Click);
            // 
            // pbGround
            // 
            this.pbGround.Image = global::PMPA.Properties.Resources.Ground_top_view;
            this.pbGround.Location = new System.Drawing.Point(117, 20);
            this.pbGround.Name = "pbGround";
            this.pbGround.Size = new System.Drawing.Size(170, 170);
            this.pbGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGround.TabIndex = 1;
            this.pbGround.TabStop = false;
            // 
            // pbBatsmanLeft
            // 
            this.pbBatsmanLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBatsmanLeft.Image = global::PMPA.Properties.Resources.batsman_left_handed;
            this.pbBatsmanLeft.Location = new System.Drawing.Point(11, 195);
            this.pbBatsmanLeft.Name = "pbBatsmanLeft";
            this.pbBatsmanLeft.Size = new System.Drawing.Size(135, 135);
            this.pbBatsmanLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBatsmanLeft.TabIndex = 5;
            this.pbBatsmanLeft.TabStop = false;
            // 
            // pbBatsmanRight
            // 
            this.pbBatsmanRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBatsmanRight.Image = global::PMPA.Properties.Resources.batsman_right_handed;
            this.pbBatsmanRight.Location = new System.Drawing.Point(151, 195);
            this.pbBatsmanRight.Name = "pbBatsmanRight";
            this.pbBatsmanRight.Size = new System.Drawing.Size(135, 135);
            this.pbBatsmanRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBatsmanRight.TabIndex = 6;
            this.pbBatsmanRight.TabStop = false;
            // 
            // lstMatches
            // 
            this.lstMatches.FormattingEnabled = true;
            this.lstMatches.Location = new System.Drawing.Point(6, 343);
            this.lstMatches.Name = "lstMatches";
            this.lstMatches.Size = new System.Drawing.Size(161, 134);
            this.lstMatches.TabIndex = 16;
            this.lstMatches.SelectedIndexChanged += new System.EventHandler(this.lstMatches_SelectedIndexChanged);
            // 
            // lstCountries
            // 
            this.lstCountries.FormattingEnabled = true;
            this.lstCountries.Location = new System.Drawing.Point(6, 23);
            this.lstCountries.Name = "lstCountries";
            this.lstCountries.Size = new System.Drawing.Size(161, 82);
            this.lstCountries.TabIndex = 17;
            this.lstCountries.SelectedIndexChanged += new System.EventHandler(this.lstCountries_SelectedIndexChanged);
            // 
            // lstBatsman
            // 
            this.lstBatsman.FormattingEnabled = true;
            this.lstBatsman.Location = new System.Drawing.Point(6, 3);
            this.lstBatsman.Name = "lstBatsman";
            this.lstBatsman.Size = new System.Drawing.Size(140, 121);
            this.lstBatsman.TabIndex = 18;
            this.lstBatsman.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // btnLoadPlayers
            // 
            this.btnLoadPlayers.Location = new System.Drawing.Point(7, 112);
            this.btnLoadPlayers.Name = "btnLoadPlayers";
            this.btnLoadPlayers.Size = new System.Drawing.Size(124, 23);
            this.btnLoadPlayers.TabIndex = 19;
            this.btnLoadPlayers.Text = "Load players";
            this.btnLoadPlayers.UseVisualStyleBackColor = true;
            this.btnLoadPlayers.Click += new System.EventHandler(this.btnLoadPlayers_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.btnLoadMatches);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lstMatches);
            this.groupBox1.Controls.Add(this.btnLoadPlayers);
            this.groupBox1.Controls.Add(this.lstCountries);
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 489);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 141);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(160, 162);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstBatsman);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(152, 136);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Batsman";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(152, 136);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bowler";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PMPA.Properties.Resources.Arrow_down;
            this.pictureBox2.Location = new System.Drawing.Point(139, 308);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // btnLoadMatches
            // 
            this.btnLoadMatches.Location = new System.Drawing.Point(7, 309);
            this.btnLoadMatches.Name = "btnLoadMatches";
            this.btnLoadMatches.Size = new System.Drawing.Size(124, 23);
            this.btnLoadMatches.TabIndex = 22;
            this.btnLoadMatches.Text = "Load Matches";
            this.btnLoadMatches.UseVisualStyleBackColor = true;
            this.btnLoadMatches.Click += new System.EventHandler(this.btnLoadMatches_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PMPA.Properties.Resources.Arrow_down;
            this.pictureBox1.Location = new System.Drawing.Point(139, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Controls.Add(this.rbNorun);
            this.groupBox2.Controls.Add(this.rb4s);
            this.groupBox2.Controls.Add(this.rb6s);
            this.groupBox2.Controls.Add(this.rbWicket);
            this.groupBox2.Location = new System.Drawing.Point(373, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 142);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // rbAll
            // 
            this.rbAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(11, 18);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(104, 21);
            this.rbAll.TabIndex = 4;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All videos";
            this.rbAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbNorun
            // 
            this.rbNorun.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbNorun.Location = new System.Drawing.Point(11, 64);
            this.rbNorun.Name = "rbNorun";
            this.rbNorun.Size = new System.Drawing.Size(104, 21);
            this.rbNorun.TabIndex = 3;
            this.rbNorun.Text = "No runs";
            this.rbNorun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbNorun.UseVisualStyleBackColor = true;
            this.rbNorun.CheckedChanged += new System.EventHandler(this.rbNorun_CheckedChanged);
            // 
            // rb4s
            // 
            this.rb4s.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb4s.Location = new System.Drawing.Point(11, 110);
            this.rb4s.Name = "rb4s";
            this.rb4s.Size = new System.Drawing.Size(104, 21);
            this.rb4s.TabIndex = 2;
            this.rb4s.Text = "4s";
            this.rb4s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb4s.UseVisualStyleBackColor = true;
            this.rb4s.CheckedChanged += new System.EventHandler(this.rb4s_CheckedChanged);
            // 
            // rb6s
            // 
            this.rb6s.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb6s.Location = new System.Drawing.Point(11, 87);
            this.rb6s.Name = "rb6s";
            this.rb6s.Size = new System.Drawing.Size(104, 21);
            this.rb6s.TabIndex = 1;
            this.rb6s.Text = "6s";
            this.rb6s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb6s.UseVisualStyleBackColor = true;
            this.rb6s.CheckedChanged += new System.EventHandler(this.rb6s_CheckedChanged);
            // 
            // rbWicket
            // 
            this.rbWicket.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbWicket.Location = new System.Drawing.Point(11, 41);
            this.rbWicket.Name = "rbWicket";
            this.rbWicket.Size = new System.Drawing.Size(104, 21);
            this.rbWicket.TabIndex = 0;
            this.rbWicket.Text = "Wicket";
            this.rbWicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbWicket.UseVisualStyleBackColor = true;
            // 
            // lstVideoFiles
            // 
            this.lstVideoFiles.FormattingEnabled = true;
            this.lstVideoFiles.HorizontalScrollbar = true;
            this.lstVideoFiles.Location = new System.Drawing.Point(190, 33);
            this.lstVideoFiles.Name = "lstVideoFiles";
            this.lstVideoFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstVideoFiles.Size = new System.Drawing.Size(177, 459);
            this.lstVideoFiles.TabIndex = 22;
            this.lstVideoFiles.SelectedIndexChanged += new System.EventHandler(this.lstVideoFiles_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAutoPlaySelected);
            this.groupBox3.Controls.Add(this.chkAutoPlayAll);
            this.groupBox3.Location = new System.Drawing.Point(503, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 142);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Play options";
            // 
            // chkAutoPlaySelected
            // 
            this.chkAutoPlaySelected.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutoPlaySelected.Location = new System.Drawing.Point(6, 19);
            this.chkAutoPlaySelected.Name = "chkAutoPlaySelected";
            this.chkAutoPlaySelected.Size = new System.Drawing.Size(150, 24);
            this.chkAutoPlaySelected.TabIndex = 1;
            this.chkAutoPlaySelected.Text = "Auto play selected";
            this.chkAutoPlaySelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAutoPlaySelected.UseVisualStyleBackColor = true;
            // 
            // chkAutoPlayAll
            // 
            this.chkAutoPlayAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutoPlayAll.Location = new System.Drawing.Point(6, 46);
            this.chkAutoPlayAll.Name = "chkAutoPlayAll";
            this.chkAutoPlayAll.Size = new System.Drawing.Size(150, 24);
            this.chkAutoPlayAll.TabIndex = 0;
            this.chkAutoPlayAll.Text = "Auto play all";
            this.chkAutoPlayAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAutoPlayAll.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axVLCPlugin21);
            this.panel1.Location = new System.Drawing.Point(674, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 335);
            this.panel1.TabIndex = 24;
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(0, 0);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(379, 335);
            this.axVLCPlugin21.TabIndex = 0;
            this.axVLCPlugin21.MediaPlayerEndReached += new System.EventHandler(this.axVLCPlugin21_MediaPlayerEndReached);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblEcon);
            this.groupBox4.Controls.Add(this.lbl50s);
            this.groupBox4.Controls.Add(this.lbl100s);
            this.groupBox4.Controls.Add(this.lblSR);
            this.groupBox4.Controls.Add(this.lblBallsFaced);
            this.groupBox4.Controls.Add(this.lblScore);
            this.groupBox4.Controls.Add(this.lblMatch);
            this.groupBox4.Controls.Add(this.lblName);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(674, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(379, 134);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Player Information";
            // 
            // lblEcon
            // 
            this.lblEcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEcon.Location = new System.Drawing.Point(290, 105);
            this.lblEcon.Name = "lblEcon";
            this.lblEcon.Size = new System.Drawing.Size(83, 23);
            this.lblEcon.TabIndex = 30;
            this.lblEcon.Text = "NA";
            // 
            // lbl50s
            // 
            this.lbl50s.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl50s.Location = new System.Drawing.Point(290, 76);
            this.lbl50s.Name = "lbl50s";
            this.lbl50s.Size = new System.Drawing.Size(83, 23);
            this.lbl50s.TabIndex = 29;
            this.lbl50s.Text = "NA";
            // 
            // lbl100s
            // 
            this.lbl100s.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl100s.Location = new System.Drawing.Point(290, 47);
            this.lbl100s.Name = "lbl100s";
            this.lbl100s.Size = new System.Drawing.Size(83, 23);
            this.lbl100s.TabIndex = 28;
            this.lbl100s.Text = "NA";
            // 
            // lblSR
            // 
            this.lblSR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSR.Location = new System.Drawing.Point(290, 18);
            this.lblSR.Name = "lblSR";
            this.lblSR.Size = new System.Drawing.Size(83, 23);
            this.lblSR.TabIndex = 27;
            // 
            // lblBallsFaced
            // 
            this.lblBallsFaced.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBallsFaced.Location = new System.Drawing.Point(82, 105);
            this.lblBallsFaced.Name = "lblBallsFaced";
            this.lblBallsFaced.Size = new System.Drawing.Size(160, 23);
            this.lblBallsFaced.TabIndex = 11;
            // 
            // lblScore
            // 
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblScore.Location = new System.Drawing.Point(82, 77);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(160, 23);
            this.lblScore.TabIndex = 10;
            // 
            // lblMatch
            // 
            this.lblMatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMatch.Location = new System.Drawing.Point(82, 47);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(160, 23);
            this.lblMatch.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Location = new System.Drawing.Point(82, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(160, 23);
            this.lblName.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Econ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "50s:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "100s:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "RS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Balls faced:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Score:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Match:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1063, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1048, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 542);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lstVideoFiles);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBallPosition);
            this.Name = "frmAnalyse";
            this.Text = "Analyse Video";
            this.Load += new System.EventHandler(this.frmAnalyse_Load);
            this.grpBallPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBatsmanLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBatsmanRight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBallPosition;
        private System.Windows.Forms.PictureBox pbPitch;
        private System.Windows.Forms.PictureBox pbGround;
        private System.Windows.Forms.PictureBox pbBatsmanLeft;
        private System.Windows.Forms.PictureBox pbBatsmanRight;
        private System.Windows.Forms.ListBox lstMatches;
        private System.Windows.Forms.ListBox lstCountries;
        private System.Windows.Forms.ListBox lstBatsman;
        private System.Windows.Forms.Button btnLoadPlayers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLoadMatches;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstVideoFiles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAutoPlayAll;
        private System.Windows.Forms.CheckBox chkAutoPlaySelected;
        private System.Windows.Forms.RadioButton rbWicket;
        private System.Windows.Forms.RadioButton rbNorun;
        private System.Windows.Forms.RadioButton rb4s;
        private System.Windows.Forms.RadioButton rb6s;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEcon;
        private System.Windows.Forms.Label lbl50s;
        private System.Windows.Forms.Label lbl100s;
        private System.Windows.Forms.Label lblSR;
        private System.Windows.Forms.Label lblBallsFaced;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}