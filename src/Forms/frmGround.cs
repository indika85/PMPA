using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMPA.Classes;

namespace PMPA.Forms
{
    public partial class frmGround : Form
    {
        public frmGround()
        {
            InitializeComponent();
        }

        private int end1IdBeforeEditing = 0;
        private int end2IdBeforeEditing = 0;

        private void frmGround_Load(object sender, EventArgs e)
        {
            fillCountrylist();
            setNextGroundCode();
            fillGroundList();
        }

        private void fillCountrylist()
        {
            cmbCountry.Items.Clear();
            List<clsCountry> countryList = clsCountry.getAllCountries();
            foreach (clsCountry country in countryList)
            {
                cmbCountry.Items.Add(country.countryName);
            }
            if (cmbCountry.Items.Count > 0)
                cmbCountry.SelectedIndex = 0;
        }
        private void setNextGroundCode()
        {
            txtGroundCode.Text = clsGround.getNextGroundCode().ToString();
        }
        private void fillGroundList()
        {
            dataGridView1.SelectAll();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.Rows.Remove(row);
            }

            List<clsGround> groundList = clsGround.getAllGrounds();
            foreach (clsGround ground in groundList)
            {
                dataGridView1.Rows.Add(ground.stadiumId, ground.stadiumName,ground.capacity,clsCountry.getCountryName(ground.countryId),ground.end1.endName,ground.end2.endName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataValidated())
            {
                int stadiumId=Convert.ToInt32(txtGroundCode.Text);
                if (btnAdd.Text == "Add")
                {
                    int endId=clsEnds.getNextEndID();
                    
                    if(clsGround.addGround(new clsGround(stadiumId,txtGroundName.Text,(Int32)numericUpDown1.Value,clsCountry.getCountryCode(cmbCountry.SelectedItem.ToString()),new clsEnds(endId,txtEnd1.Text,stadiumId),new clsEnds(endId+1,txtEnd2.Text,stadiumId)))>0)
                    {
                            clsMessages.showMessage(clsMessages.msgType.information, "Ground was added successfully");
                            fillGroundList();
                            setNextGroundCode();
                            txtGroundName.Focus();
                    }
                }
                else if (btnAdd.Text == "Update")
                {
                    if (clsGround.updateGroundInfo(new clsGround(Convert.ToInt32(txtGroundCode.Text), txtGroundName.Text, (Int32)numericUpDown1.Value, clsCountry.getCountryCode(cmbCountry.SelectedItem.ToString()), new clsEnds(end1IdBeforeEditing, txtEnd1.Text, stadiumId), new clsEnds(end2IdBeforeEditing, txtEnd2.Text, stadiumId))) > 2)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Ground detailes were updated sucessfully");
                        btnAdd.Text = "Add";
                        txtGroundCode.Text = clsGround.getNextGroundCode().ToString();
                        fillGroundList();
                        txtEnd1.Clear();
                        txtEnd2.Clear();
                        txtGroundName.Clear();
                        txtGroundName.Focus();
                    }
                }
            }
        }

        private bool dataValidated()
        {
            if (txtGroundName.Text.Trim() == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Ground name cannot be blank");
                txtGroundName.Focus();
                return false;
            }
            if (txtEnd1.Text.Trim() == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "There should be two ends in the ground");
                txtEnd1.Focus();
                return false;
            }
            if (txtEnd2.Text.Trim() == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "There should be two ends in the ground");
                txtEnd2.Focus();
                return false;
            }
            int groundId= clsGround.getGroundCode(txtGroundName.Text);
            if (groundId > 0 && btnAdd.Text == "Add")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation,"The ground Name already Exists");
                txtGroundName.Focus();
                txtGroundName.SelectAll();
                return false;
            }
            if (btnAdd.Text == "Update" && groundId > 0 && groundId != Convert.ToInt32(txtGroundCode.Text))
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Similar ground name already exists in the database. Please select a different name.");
                txtGroundName.Focus();
                txtGroundName.SelectAll();
                return false;
            }
            if (txtEnd1.Text==txtEnd2.Text)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "The two Ends cannot have the same name");
                txtEnd1.Focus();
                txtEnd1.SelectAll();
                return false;
            }
            
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (canbeEdited())
            {
                setDataForUpdate();
                end1IdBeforeEditing = clsEnds.getEndId(txtEnd1.Text);
                end2IdBeforeEditing = clsEnds.getEndId(txtEnd2.Text);
            }
        }
        private void setDataForUpdate()
        {
            txtGroundCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtGroundName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            cmbCountry.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value;
            txtEnd1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtEnd2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            btnAdd.Text = "Update";
        }

        private bool canbeEdited()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                return true;
            }
            else
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No data row is selected for editing");
                return true;
            }
        }
    }
}
