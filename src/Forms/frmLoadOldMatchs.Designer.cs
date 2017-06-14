namespace PMPA.Forms
{
    partial class frmLoadOldMatchs
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
            this.btnBrows = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadConutries = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.lblLoadMatchDate = new System.Windows.Forms.Button();
            this.cmbTeam1 = new System.Windows.Forms.ComboBox();
            this.cmbTema2 = new System.Windows.Forms.ComboBox();
            this.txtMatchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbMatchType = new System.Windows.Forms.ComboBox();
            this.rbTeam1FirstBatting = new System.Windows.Forms.RadioButton();
            this.rbTeam2FirstBatting = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.btnBallByBall = new System.Windows.Forms.Button();
            this.chkMatchWon = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrows
            // 
            this.btnBrows.Location = new System.Drawing.Point(128, 19);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(75, 23);
            this.btnBrows.TabIndex = 0;
            this.btnBrows.Text = "Brows";
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // lblPath
            // 
            this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPath.Location = new System.Drawing.Point(6, 46);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(259, 23);
            this.lblPath.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadConutries
            // 
            this.btnLoadConutries.Enabled = false;
            this.btnLoadConutries.Location = new System.Drawing.Point(6, 80);
            this.btnLoadConutries.Name = "btnLoadConutries";
            this.btnLoadConutries.Size = new System.Drawing.Size(75, 48);
            this.btnLoadConutries.TabIndex = 2;
            this.btnLoadConutries.Text = "Countries";
            this.btnLoadConutries.UseVisualStyleBackColor = true;
            this.btnLoadConutries.Click += new System.EventHandler(this.btnLoadConutries_Click);
            // 
            // btnPlayers
            // 
            this.btnPlayers.Enabled = false;
            this.btnPlayers.Location = new System.Drawing.Point(190, 80);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(75, 48);
            this.btnPlayers.TabIndex = 3;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // lblLoadMatchDate
            // 
            this.lblLoadMatchDate.Location = new System.Drawing.Point(10, 345);
            this.lblLoadMatchDate.Name = "lblLoadMatchDate";
            this.lblLoadMatchDate.Size = new System.Drawing.Size(272, 49);
            this.lblLoadMatchDate.TabIndex = 4;
            this.lblLoadMatchDate.Text = "Load Match Data";
            this.lblLoadMatchDate.UseVisualStyleBackColor = true;
            this.lblLoadMatchDate.Click += new System.EventHandler(this.lblLoadMatchDate_Click);
            // 
            // cmbTeam1
            // 
            this.cmbTeam1.FormattingEnabled = true;
            this.cmbTeam1.Location = new System.Drawing.Point(12, 168);
            this.cmbTeam1.Name = "cmbTeam1";
            this.cmbTeam1.Size = new System.Drawing.Size(121, 21);
            this.cmbTeam1.TabIndex = 5;
            this.cmbTeam1.SelectedIndexChanged += new System.EventHandler(this.cmbTeam1_SelectedIndexChanged);
            // 
            // cmbTema2
            // 
            this.cmbTema2.FormattingEnabled = true;
            this.cmbTema2.Location = new System.Drawing.Point(161, 168);
            this.cmbTema2.Name = "cmbTema2";
            this.cmbTema2.Size = new System.Drawing.Size(121, 21);
            this.cmbTema2.TabIndex = 6;
            this.cmbTema2.SelectedIndexChanged += new System.EventHandler(this.cmbTema2_SelectedIndexChanged);
            // 
            // txtMatchName
            // 
            this.txtMatchName.Location = new System.Drawing.Point(73, 252);
            this.txtMatchName.Name = "txtMatchName";
            this.txtMatchName.Size = new System.Drawing.Size(209, 20);
            this.txtMatchName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vs.";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(73, 278);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // cmbMatchType
            // 
            this.cmbMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatchType.FormattingEnabled = true;
            this.cmbMatchType.Items.AddRange(new object[] {
            "ODI",
            "T20"});
            this.cmbMatchType.Location = new System.Drawing.Point(73, 304);
            this.cmbMatchType.Name = "cmbMatchType";
            this.cmbMatchType.Size = new System.Drawing.Size(209, 21);
            this.cmbMatchType.TabIndex = 10;
            // 
            // rbTeam1FirstBatting
            // 
            this.rbTeam1FirstBatting.AutoSize = true;
            this.rbTeam1FirstBatting.Location = new System.Drawing.Point(10, 195);
            this.rbTeam1FirstBatting.Name = "rbTeam1FirstBatting";
            this.rbTeam1FirstBatting.Size = new System.Drawing.Size(77, 17);
            this.rbTeam1FirstBatting.TabIndex = 11;
            this.rbTeam1FirstBatting.TabStop = true;
            this.rbTeam1FirstBatting.Text = "1St Batting";
            this.rbTeam1FirstBatting.UseVisualStyleBackColor = true;
            // 
            // rbTeam2FirstBatting
            // 
            this.rbTeam2FirstBatting.AutoSize = true;
            this.rbTeam2FirstBatting.Location = new System.Drawing.Point(176, 195);
            this.rbTeam2FirstBatting.Name = "rbTeam2FirstBatting";
            this.rbTeam2FirstBatting.Size = new System.Drawing.Size(77, 17);
            this.rbTeam2FirstBatting.TabIndex = 12;
            this.rbTeam2FirstBatting.TabStop = true;
            this.rbTeam2FirstBatting.Text = "1St Batting";
            this.rbTeam2FirstBatting.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnBrows);
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Controls.Add(this.btnLoadConutries);
            this.groupBox1.Controls.Add(this.btnPlayers);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 134);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load data";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Access DB file path...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Team 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Team 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Match name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Match date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Match type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInfo);
            this.groupBox2.Location = new System.Drawing.Point(288, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 327);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(6, 19);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(260, 294);
            this.txtInfo.TabIndex = 21;
            this.txtInfo.Text = "";
            // 
            // btnBallByBall
            // 
            this.btnBallByBall.Enabled = false;
            this.btnBallByBall.Location = new System.Drawing.Point(289, 345);
            this.btnBallByBall.Name = "btnBallByBall";
            this.btnBallByBall.Size = new System.Drawing.Size(271, 49);
            this.btnBallByBall.TabIndex = 20;
            this.btnBallByBall.Text = "Load individual ball data";
            this.btnBallByBall.UseVisualStyleBackColor = true;
            this.btnBallByBall.Click += new System.EventHandler(this.btnBallByBall_Click);
            // 
            // chkMatchWon
            // 
            this.chkMatchWon.AutoSize = true;
            this.chkMatchWon.Location = new System.Drawing.Point(12, 218);
            this.chkMatchWon.Name = "chkMatchWon";
            this.chkMatchWon.Size = new System.Drawing.Size(128, 17);
            this.chkMatchWon.TabIndex = 21;
            this.chkMatchWon.Text = "Match won by team 1";
            this.chkMatchWon.UseVisualStyleBackColor = true;
            // 
            // frmLoadOldMatchs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 406);
            this.Controls.Add(this.chkMatchWon);
            this.Controls.Add(this.btnBallByBall);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbTeam2FirstBatting);
            this.Controls.Add(this.rbTeam1FirstBatting);
            this.Controls.Add(this.cmbMatchType);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatchName);
            this.Controls.Add(this.cmbTema2);
            this.Controls.Add(this.cmbTeam1);
            this.Controls.Add(this.lblLoadMatchDate);
            this.Name = "frmLoadOldMatchs";
            this.Text = "Load old match data";
            this.Load += new System.EventHandler(this.frmLoadOldMatchs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrows;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadConutries;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button lblLoadMatchDate;
        private System.Windows.Forms.ComboBox cmbTeam1;
        private System.Windows.Forms.ComboBox cmbTema2;
        private System.Windows.Forms.TextBox txtMatchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbMatchType;
        private System.Windows.Forms.RadioButton rbTeam1FirstBatting;
        private System.Windows.Forms.RadioButton rbTeam2FirstBatting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBallByBall;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.CheckBox chkMatchWon;
    }
}