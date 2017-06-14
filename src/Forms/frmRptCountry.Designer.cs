namespace PMPA.Forms
{
    partial class frmRptCountry
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dsCountriesAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCountriesAll = new PMPA.dsCountriesAll();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbCountry2 = new System.Windows.Forms.ComboBox();
            this.cmbCountry1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsCountriesAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCountriesAll)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsCountriesAllBindingSource
            // 
            this.dsCountriesAllBindingSource.DataSource = this.dsCountriesAll;
            this.dsCountriesAllBindingSource.Position = 0;
            // 
            // dsCountriesAll
            // 
            this.dsCountriesAll.DataSetName = "dsCountriesAll";
            this.dsCountriesAll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbCountry2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCountry1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(797, 555);
            this.splitContainer1.SplitterDistance = 73;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmbCountry2
            // 
            this.cmbCountry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry2.FormattingEnabled = true;
            this.cmbCountry2.Items.AddRange(new object[] {
            "*"});
            this.cmbCountry2.Location = new System.Drawing.Point(231, 27);
            this.cmbCountry2.Name = "cmbCountry2";
            this.cmbCountry2.Size = new System.Drawing.Size(177, 21);
            this.cmbCountry2.TabIndex = 3;
            // 
            // cmbCountry1
            // 
            this.cmbCountry1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry1.FormattingEnabled = true;
            this.cmbCountry1.Location = new System.Drawing.Point(21, 27);
            this.cmbCountry1.Name = "cmbCountry1";
            this.cmbCountry1.Size = new System.Drawing.Size(177, 21);
            this.cmbCountry1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(710, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VS";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsCountriesAll_tblCountriesAll";
            reportDataSource1.Value = this.dsCountriesAllBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PMPA.rptCountriesAll.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(797, 478);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // frmRptCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 555);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRptCountry";
            this.Text = "Country win/lose report";
            this.Load += new System.EventHandler(this.frmRptCountry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCountriesAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCountriesAll)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cmbCountry1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCountry2;
        private System.Windows.Forms.BindingSource dsCountriesAllBindingSource;
        private dsCountriesAll dsCountriesAll;
    }
}