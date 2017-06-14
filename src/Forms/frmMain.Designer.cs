namespace PMPA
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPreviousDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bowllingTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shotTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.countryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.locationsToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // matchToolStripMenuItem
            // 
            this.matchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.createToolStripMenuItem,
            this.loadPreviousDataToolStripMenuItem});
            this.matchToolStripMenuItem.Name = "matchToolStripMenuItem";
            this.matchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.matchToolStripMenuItem.Text = "Match";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createToolStripMenuItem.Text = "New";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // loadPreviousDataToolStripMenuItem
            // 
            this.loadPreviousDataToolStripMenuItem.Name = "loadPreviousDataToolStripMenuItem";
            this.loadPreviousDataToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.loadPreviousDataToolStripMenuItem.Text = "Load previous data";
            this.loadPreviousDataToolStripMenuItem.Click += new System.EventHandler(this.loadPreviousDataToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // locationsToolStripMenuItem
            // 
            this.locationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countryToolStripMenuItem,
            this.groundToolStripMenuItem});
            this.locationsToolStripMenuItem.Name = "locationsToolStripMenuItem";
            this.locationsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.locationsToolStripMenuItem.Text = "Locations";
            // 
            // countryToolStripMenuItem
            // 
            this.countryToolStripMenuItem.Name = "countryToolStripMenuItem";
            this.countryToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.countryToolStripMenuItem.Text = "Country...";
            this.countryToolStripMenuItem.Click += new System.EventHandler(this.countryToolStripMenuItem_Click);
            // 
            // groundToolStripMenuItem
            // 
            this.groundToolStripMenuItem.Name = "groundToolStripMenuItem";
            this.groundToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.groundToolStripMenuItem.Text = "Ground...";
            this.groundToolStripMenuItem.Click += new System.EventHandler(this.groundToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatNewToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.playerToolStripMenuItem.Text = "Player Profile";
            // 
            // creatNewToolStripMenuItem
            // 
            this.creatNewToolStripMenuItem.Name = "creatNewToolStripMenuItem";
            this.creatNewToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.creatNewToolStripMenuItem.Text = "Creat New/ Edit...";
            this.creatNewToolStripMenuItem.Click += new System.EventHandler(this.creatNewToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bowllingTypeToolStripMenuItem,
            this.shotTypeToolStripMenuItem,
            this.matchTypeToolStripMenuItem,
            this.userToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // bowllingTypeToolStripMenuItem
            // 
            this.bowllingTypeToolStripMenuItem.Name = "bowllingTypeToolStripMenuItem";
            this.bowllingTypeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.bowllingTypeToolStripMenuItem.Text = "Bowlling Type";
            this.bowllingTypeToolStripMenuItem.Click += new System.EventHandler(this.bowllingTypeToolStripMenuItem_Click);
            // 
            // shotTypeToolStripMenuItem
            // 
            this.shotTypeToolStripMenuItem.Name = "shotTypeToolStripMenuItem";
            this.shotTypeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.shotTypeToolStripMenuItem.Text = "Shot type";
            this.shotTypeToolStripMenuItem.Click += new System.EventHandler(this.shotTypeToolStripMenuItem_Click);
            // 
            // matchTypeToolStripMenuItem
            // 
            this.matchTypeToolStripMenuItem.Name = "matchTypeToolStripMenuItem";
            this.matchTypeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.matchTypeToolStripMenuItem.Text = "Match Type";
            this.matchTypeToolStripMenuItem.Click += new System.EventHandler(this.matchTypeToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.matchToolStripMenuItem1,
            this.playerToolStripMenuItem1,
            this.countryToolStripMenuItem1,
            this.groToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.reportsToolStripMenuItem.Text = "Reports 11";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videoToolStripMenuItem.Text = "Analyse Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // matchToolStripMenuItem1
            // 
            this.matchToolStripMenuItem1.Name = "matchToolStripMenuItem1";
            this.matchToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.matchToolStripMenuItem1.Text = "Match";
            this.matchToolStripMenuItem1.Visible = false;
            this.matchToolStripMenuItem1.Click += new System.EventHandler(this.matchToolStripMenuItem1_Click);
            // 
            // playerToolStripMenuItem1
            // 
            this.playerToolStripMenuItem1.Name = "playerToolStripMenuItem1";
            this.playerToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.playerToolStripMenuItem1.Text = "Player";
            this.playerToolStripMenuItem1.Click += new System.EventHandler(this.playerToolStripMenuItem1_Click);
            // 
            // countryToolStripMenuItem1
            // 
            this.countryToolStripMenuItem1.Name = "countryToolStripMenuItem1";
            this.countryToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.countryToolStripMenuItem1.Text = "Country";
            this.countryToolStripMenuItem1.Click += new System.EventHandler(this.countryToolStripMenuItem1_Click);
            // 
            // groToolStripMenuItem
            // 
            this.groToolStripMenuItem.Name = "groToolStripMenuItem";
            this.groToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.groToolStripMenuItem.Text = "Ground";
            this.groToolStripMenuItem.Click += new System.EventHandler(this.groToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.DefaultExt = "sdf";
            this.openFileDialog1.Filter = "\"Databse files (.sdf)|*.sdf|All Files (*.*)|*.*\"";
            this.openFileDialog1.Title = "Open saved match";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::PMPA.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(860, 481);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Player Management and Performance Analysis System for Sri Lanka cricket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bowllingTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shotTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem countryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem groToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPreviousDataToolStripMenuItem;
    }
}

