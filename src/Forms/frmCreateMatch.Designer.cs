namespace PMPA.Forms
{
    partial class frmCreateMatch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            this.btnCreateMatch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.cmbMatchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSquad2Number = new System.Windows.Forms.Label();
            this.cmbSquad2WC = new System.Windows.Forms.ComboBox();
            this.cmbSquad2VCapt = new System.Windows.Forms.ComboBox();
            this.cmbSquad2Capt = new System.Windows.Forms.ComboBox();
            this.btnRemovePlayerCountry2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddPlayerCountry2 = new System.Windows.Forms.Button();
            this.lstCountry2Squard = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstCountry2Players = new System.Windows.Forms.ListBox();
            this.cmbCountry2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMatchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSquad1Number = new System.Windows.Forms.Label();
            this.cmbSquad1WC = new System.Windows.Forms.ComboBox();
            this.cmbSquad1VCapt = new System.Windows.Forms.ComboBox();
            this.cmbSquad1Capt = new System.Windows.Forms.ComboBox();
            this.btnRemovePlayerCountry1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddPlayerCountry1 = new System.Windows.Forms.Button();
            this.lstCountry1Squard = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstCountry1Players = new System.Windows.Forms.ListBox();
            this.cmbCountry1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbVenue);
            this.groupBox1.Controls.Add(this.btnCreateMatch);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbCountry);
            this.groupBox1.Controls.Add(this.cmbMatchType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtMatchName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 507);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Match details";
            // 
            // cmbVenue
            // 
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(339, 473);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(187, 21);
            this.cmbVenue.TabIndex = 20;
            // 
            // btnCreateMatch
            // 
            this.btnCreateMatch.Location = new System.Drawing.Point(726, 441);
            this.btnCreateMatch.Name = "btnCreateMatch";
            this.btnCreateMatch.Size = new System.Drawing.Size(172, 58);
            this.btnCreateMatch.TabIndex = 22;
            this.btnCreateMatch.Text = "Create Match";
            this.btnCreateMatch.UseVisualStyleBackColor = true;
            this.btnCreateMatch.Click += new System.EventHandler(this.btnCreateMatch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(290, 476);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Venue :";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(88, 473);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(187, 21);
            this.cmbCountry.TabIndex = 19;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // cmbMatchType
            // 
            this.cmbMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatchType.FormattingEnabled = true;
            this.cmbMatchType.Location = new System.Drawing.Point(616, 473);
            this.cmbMatchType.Name = "cmbMatchType";
            this.cmbMatchType.Size = new System.Drawing.Size(78, 21);
            this.cmbMatchType.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Country:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(546, 477);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Match Type:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(547, 441);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(590, 438);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(103, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lblSquad2Number);
            this.groupBox3.Controls.Add(this.cmbSquad2WC);
            this.groupBox3.Controls.Add(this.cmbSquad2VCapt);
            this.groupBox3.Controls.Add(this.cmbSquad2Capt);
            this.groupBox3.Controls.Add(this.btnRemovePlayerCountry2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnAddPlayerCountry2);
            this.groupBox3.Controls.Add(this.lstCountry2Squard);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lstCountry2Players);
            this.groupBox3.Controls.Add(this.cmbCountry2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(463, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 382);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Team 2";
            // 
            // lblSquad2Number
            // 
            this.lblSquad2Number.AutoSize = true;
            this.lblSquad2Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSquad2Number.Location = new System.Drawing.Point(380, 16);
            this.lblSquad2Number.Name = "lblSquad2Number";
            this.lblSquad2Number.Size = new System.Drawing.Size(55, 37);
            this.lblSquad2Number.TabIndex = 18;
            this.lblSquad2Number.Text = "00";
            // 
            // cmbSquad2WC
            // 
            this.cmbSquad2WC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad2WC.FormattingEnabled = true;
            this.cmbSquad2WC.Location = new System.Drawing.Point(263, 336);
            this.cmbSquad2WC.Name = "cmbSquad2WC";
            this.cmbSquad2WC.Size = new System.Drawing.Size(172, 21);
            this.cmbSquad2WC.TabIndex = 17;
            // 
            // cmbSquad2VCapt
            // 
            this.cmbSquad2VCapt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad2VCapt.FormattingEnabled = true;
            this.cmbSquad2VCapt.Location = new System.Drawing.Point(263, 287);
            this.cmbSquad2VCapt.Name = "cmbSquad2VCapt";
            this.cmbSquad2VCapt.Size = new System.Drawing.Size(172, 21);
            this.cmbSquad2VCapt.TabIndex = 16;
            // 
            // cmbSquad2Capt
            // 
            this.cmbSquad2Capt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad2Capt.FormattingEnabled = true;
            this.cmbSquad2Capt.Location = new System.Drawing.Point(263, 240);
            this.cmbSquad2Capt.Name = "cmbSquad2Capt";
            this.cmbSquad2Capt.Size = new System.Drawing.Size(172, 21);
            this.cmbSquad2Capt.TabIndex = 15;
            // 
            // btnRemovePlayerCountry2
            // 
            this.btnRemovePlayerCountry2.Location = new System.Drawing.Point(195, 179);
            this.btnRemovePlayerCountry2.Name = "btnRemovePlayerCountry2";
            this.btnRemovePlayerCountry2.Size = new System.Drawing.Size(61, 40);
            this.btnRemovePlayerCountry2.TabIndex = 12;
            this.btnRemovePlayerCountry2.Text = "<<";
            this.toolTip1.SetToolTip(this.btnRemovePlayerCountry2, "Removes the selected player from the current squad");
            this.btnRemovePlayerCountry2.UseVisualStyleBackColor = true;
            this.btnRemovePlayerCountry2.Click += new System.EventHandler(this.btnRemovePlayerCountry2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Current Squad";
            // 
            // btnAddPlayerCountry2
            // 
            this.btnAddPlayerCountry2.Location = new System.Drawing.Point(194, 127);
            this.btnAddPlayerCountry2.Name = "btnAddPlayerCountry2";
            this.btnAddPlayerCountry2.Size = new System.Drawing.Size(61, 40);
            this.btnAddPlayerCountry2.TabIndex = 11;
            this.btnAddPlayerCountry2.Text = ">>";
            this.toolTip1.SetToolTip(this.btnAddPlayerCountry2, "Adds selected player to the current squad");
            this.btnAddPlayerCountry2.UseVisualStyleBackColor = true;
            this.btnAddPlayerCountry2.Click += new System.EventHandler(this.btnAddPlayerCountry2_Click);
            // 
            // lstCountry2Squard
            // 
            this.lstCountry2Squard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstCountry2Squard.FormattingEnabled = true;
            this.lstCountry2Squard.Location = new System.Drawing.Point(263, 67);
            this.lstCountry2Squard.Name = "lstCountry2Squard";
            this.lstCountry2Squard.Size = new System.Drawing.Size(172, 160);
            this.lstCountry2Squard.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Players";
            // 
            // lstCountry2Players
            // 
            this.lstCountry2Players.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lstCountry2Players.FormattingEnabled = true;
            this.lstCountry2Players.Location = new System.Drawing.Point(15, 67);
            this.lstCountry2Players.Name = "lstCountry2Players";
            this.lstCountry2Players.Size = new System.Drawing.Size(172, 290);
            this.lstCountry2Players.TabIndex = 10;
            // 
            // cmbCountry2
            // 
            this.cmbCountry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry2.FormattingEnabled = true;
            this.cmbCountry2.Location = new System.Drawing.Point(77, 19);
            this.cmbCountry2.Name = "cmbCountry2";
            this.cmbCountry2.Size = new System.Drawing.Size(258, 21);
            this.cmbCountry2.TabIndex = 9;
            this.cmbCountry2.SelectedIndexChanged += new System.EventHandler(this.cmbCountry2_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Country 2:";
            // 
            // txtMatchName
            // 
            this.txtMatchName.Location = new System.Drawing.Point(88, 438);
            this.txtMatchName.Name = "txtMatchName";
            this.txtMatchName.Size = new System.Drawing.Size(438, 20);
            this.txtMatchName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Match Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblSquad1Number);
            this.groupBox2.Controls.Add(this.cmbSquad1WC);
            this.groupBox2.Controls.Add(this.cmbSquad1VCapt);
            this.groupBox2.Controls.Add(this.cmbSquad1Capt);
            this.groupBox2.Controls.Add(this.btnRemovePlayerCountry1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAddPlayerCountry1);
            this.groupBox2.Controls.Add(this.lstCountry1Squard);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lstCountry1Players);
            this.groupBox2.Controls.Add(this.cmbCountry1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(11, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 382);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Team 1";
            // 
            // lblSquad1Number
            // 
            this.lblSquad1Number.AutoSize = true;
            this.lblSquad1Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSquad1Number.Location = new System.Drawing.Point(380, 16);
            this.lblSquad1Number.Name = "lblSquad1Number";
            this.lblSquad1Number.Size = new System.Drawing.Size(55, 37);
            this.lblSquad1Number.TabIndex = 17;
            this.lblSquad1Number.Text = "00";
            // 
            // cmbSquad1WC
            // 
            this.cmbSquad1WC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad1WC.FormattingEnabled = true;
            this.cmbSquad1WC.Location = new System.Drawing.Point(263, 336);
            this.cmbSquad1WC.Name = "cmbSquad1WC";
            this.cmbSquad1WC.Size = new System.Drawing.Size(172, 21);
            this.cmbSquad1WC.TabIndex = 16;
            // 
            // cmbSquad1VCapt
            // 
            this.cmbSquad1VCapt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad1VCapt.FormattingEnabled = true;
            this.cmbSquad1VCapt.Location = new System.Drawing.Point(263, 287);
            this.cmbSquad1VCapt.Name = "cmbSquad1VCapt";
            this.cmbSquad1VCapt.Size = new System.Drawing.Size(172, 21);
            this.cmbSquad1VCapt.TabIndex = 15;
            // 
            // cmbSquad1Capt
            // 
            this.cmbSquad1Capt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad1Capt.FormattingEnabled = true;
            this.cmbSquad1Capt.Location = new System.Drawing.Point(263, 240);
            this.cmbSquad1Capt.Name = "cmbSquad1Capt";
            this.cmbSquad1Capt.Size = new System.Drawing.Size(172, 21);
            this.cmbSquad1Capt.TabIndex = 14;
            // 
            // btnRemovePlayerCountry1
            // 
            this.btnRemovePlayerCountry1.Location = new System.Drawing.Point(195, 179);
            this.btnRemovePlayerCountry1.Name = "btnRemovePlayerCountry1";
            this.btnRemovePlayerCountry1.Size = new System.Drawing.Size(61, 40);
            this.btnRemovePlayerCountry1.TabIndex = 4;
            this.btnRemovePlayerCountry1.Text = "<<";
            this.toolTip1.SetToolTip(this.btnRemovePlayerCountry1, "Removes the selected player from the current squad");
            this.btnRemovePlayerCountry1.UseVisualStyleBackColor = true;
            this.btnRemovePlayerCountry1.Click += new System.EventHandler(this.btnRemovePlayerCountry1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Current Squad";
            // 
            // btnAddPlayerCountry1
            // 
            this.btnAddPlayerCountry1.Location = new System.Drawing.Point(194, 127);
            this.btnAddPlayerCountry1.Name = "btnAddPlayerCountry1";
            this.btnAddPlayerCountry1.Size = new System.Drawing.Size(61, 40);
            this.btnAddPlayerCountry1.TabIndex = 3;
            this.btnAddPlayerCountry1.Text = ">>";
            this.toolTip1.SetToolTip(this.btnAddPlayerCountry1, "Adds selected player to the current squad");
            this.btnAddPlayerCountry1.UseVisualStyleBackColor = true;
            this.btnAddPlayerCountry1.Click += new System.EventHandler(this.btnAddPlayerCountry1_Click);
            // 
            // lstCountry1Squard
            // 
            this.lstCountry1Squard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstCountry1Squard.FormattingEnabled = true;
            this.lstCountry1Squard.Location = new System.Drawing.Point(263, 67);
            this.lstCountry1Squard.Name = "lstCountry1Squard";
            this.lstCountry1Squard.Size = new System.Drawing.Size(172, 160);
            this.lstCountry1Squard.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Players";
            // 
            // lstCountry1Players
            // 
            this.lstCountry1Players.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lstCountry1Players.FormattingEnabled = true;
            this.lstCountry1Players.Location = new System.Drawing.Point(15, 67);
            this.lstCountry1Players.Name = "lstCountry1Players";
            this.lstCountry1Players.Size = new System.Drawing.Size(172, 290);
            this.lstCountry1Players.TabIndex = 2;
            // 
            // cmbCountry1
            // 
            this.cmbCountry1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry1.FormattingEnabled = true;
            this.cmbCountry1.Location = new System.Drawing.Point(77, 19);
            this.cmbCountry1.Name = "cmbCountry1";
            this.cmbCountry1.Size = new System.Drawing.Size(258, 21);
            this.cmbCountry1.TabIndex = 1;
            this.cmbCountry1.SelectedIndexChanged += new System.EventHandler(this.cmbCountry1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Country 1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "VS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter match details to create a new match";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sdf";
            this.saveFileDialog1.Filter = "\"sdf files (.sdf)|*.sdf\"";
            this.saveFileDialog1.Title = "Location where the match will be saved";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(213, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Captain";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 290);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Vice Captain";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(230, 339);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "WC";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(230, 339);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "WC";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(192, 290);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Vice Captain";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(213, 243);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Captain";
            // 
            // frmCreateMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 527);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCreateMatch";
            this.Text = "Create match";
            this.Load += new System.EventHandler(this.frmCreateMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateMatch;
        private System.Windows.Forms.ComboBox cmbCountry1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstCountry1Players;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstCountry1Squard;
        private System.Windows.Forms.Button btnAddPlayerCountry1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemovePlayerCountry1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemovePlayerCountry2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddPlayerCountry2;
        private System.Windows.Forms.ListBox lstCountry2Squard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstCountry2Players;
        private System.Windows.Forms.ComboBox cmbCountry2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMatchType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbVenue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbSquad2WC;
        private System.Windows.Forms.ComboBox cmbSquad2VCapt;
        private System.Windows.Forms.ComboBox cmbSquad2Capt;
        private System.Windows.Forms.ComboBox cmbSquad1WC;
        private System.Windows.Forms.ComboBox cmbSquad1VCapt;
        private System.Windows.Forms.ComboBox cmbSquad1Capt;
        private System.Windows.Forms.Label lblSquad2Number;
        private System.Windows.Forms.Label lblSquad1Number;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}