namespace PMPA.Forms
{
    partial class frmMatchWinning
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
            this.cmbTeams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEndMatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbTeams
            // 
            this.cmbTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeams.FormattingEnabled = true;
            this.cmbTeams.Location = new System.Drawing.Point(86, 21);
            this.cmbTeams.Name = "cmbTeams";
            this.cmbTeams.Size = new System.Drawing.Size(121, 21);
            this.cmbTeams.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Match won by:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(6, 72);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(419, 107);
            this.txtComments.TabIndex = 2;
            this.txtComments.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comments:";
            // 
            // btnEndMatch
            // 
            this.btnEndMatch.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnEndMatch.Location = new System.Drawing.Point(350, 185);
            this.btnEndMatch.Name = "btnEndMatch";
            this.btnEndMatch.Size = new System.Drawing.Size(75, 23);
            this.btnEndMatch.TabIndex = 4;
            this.btnEndMatch.Text = "End match";
            this.btnEndMatch.UseVisualStyleBackColor = true;
            this.btnEndMatch.Click += new System.EventHandler(this.btnEndMatch_Click);
            // 
            // frmMatchWinning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 218);
            this.Controls.Add(this.btnEndMatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTeams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMatchWinning";
            this.Text = "Match Winning";
            this.Load += new System.EventHandler(this.frmMatchWinning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEndMatch;
    }
}