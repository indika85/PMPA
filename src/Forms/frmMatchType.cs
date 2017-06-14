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
    public partial class frmMatchType : Form
    {
        public frmMatchType()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (canbeEdited())
            {
                setDataForUpdate();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValidMatchType(txtMatchTypeName.Text))
            {
                if (btnAdd.Text == "Add")
                {
                    if (clsMatchTypes.addMatchType(new clsMatchTypes(clsMatchTypes.getNextMatchTypeCode(),txtMatchTypeName.Text))==1)// (clsCountry.getNextCountryCode(), txtCountryName.Text)) == 1)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Match type was added sucessfully");
                        fillMatchTypeList();
                        setNextMatchID();
                    }
                    else
                    {
                        clsMessages.showMessage(clsMessages.msgType.exclamation, "Match type could not be added sucessfully");
                    }
                }
                else if (btnAdd.Text == "Update")
                {
                    if (clsMatchTypes.udpdateMatchType(new clsMatchTypes(Convert.ToInt32(txtMatchTypeId.Text),txtMatchTypeName.Text)) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Match type updated successfully");
                        fillMatchTypeList();
                        txtMatchTypeId.Text = clsMatchTypes.getNextMatchTypeCode().ToString();
                        txtMatchTypeName.Text = "";
                        txtMatchTypeName.Focus();
                        btnAdd.Text = "Add";
                    }
                }
            }
        }

        private void frmMatchType_Load(object sender, EventArgs e)
        {
            fillMatchTypeList();
            setNextMatchID();
        }

        private void setNextMatchID()
        {
            dataGridView1.SelectAll();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            List<clsMatchTypes> matchTypeList = clsMatchTypes.getMatchTypes();
            foreach (clsMatchTypes matchType in matchTypeList)
            {
                dataGridView1.Rows.Add(matchType.matchTypeId, matchType.matchTypeName);
            }
        }

        private void fillMatchTypeList()
        {
            txtMatchTypeId.Text = clsMatchTypes.getNextMatchTypeCode().ToString();
        }

        private bool isValidMatchType(string matchType)
        {

            if (matchType.Trim() == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please enter a match type to continue");
                txtMatchTypeName.Focus();
                return false;
            }
            else
            {
                if (clsCountry.getCountryCode(matchType) > 0)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "The match type already exsists in the system");
                    txtMatchTypeName .Focus();
                    txtMatchTypeName.SelectAll();
                    return false;
                }
            }
            return true;
        }
        private void setDataForUpdate()
        {
            txtMatchTypeId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtMatchTypeName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
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
