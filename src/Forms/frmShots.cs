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
    public partial class frmShots : Form
    {
        public frmShots()
        {
            InitializeComponent();
        }

        private void frmShots_Load(object sender, EventArgs e)
        {
            fillStylesToGrid();
            setNextStyleCode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataValidated())
            {
                if (btnAdd.Text == "Add")
                {
                    if (clsShot.addShot(new clsShot(Convert.ToInt32(txtShotCode.Text),txtShotName.Text)) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "New Shot was added successfully");
                        setNextStyleCode();
                        txtShotName.Clear();
                        txtShotName.Focus();
                        fillStylesToGrid();
                    }
                    else
                    {
                        clsMessages.showMessage(clsMessages.msgType.exclamation, "There was an error inserting data into the system");
                    }
                }
                else
                {
                    if (clsShot.udpdateShot(new clsShot(Convert.ToInt32(txtShotCode.Text), txtShotName.Text)) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Bowling style was updated successfully");
                        setNextStyleCode();
                        txtShotName.Clear();
                        txtShotName.Focus();
                        btnAdd.Text = "Add";
                        fillStylesToGrid();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No data row is selected for editing");
            }
            else
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];
                txtShotCode.Text = r.Cells[0].EditedFormattedValue.ToString();
                txtShotName.Text = r.Cells[1].EditedFormattedValue.ToString();
                btnAdd.Text = "Edit";
            }
        }

        private void fillStylesToGrid()
        {
            dataGridView1.SelectAll();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            List<clsShot> shotsList = clsShot.getShotTypes();
            foreach (clsShot shot in shotsList)
            {
                dataGridView1.Rows.Add(shot.shotId, shot.shotName);
            }
        }

        private void setNextStyleCode()
        {

            txtShotCode.Text = clsShot.getNextShotCode().ToString();

        }
        private bool dataValidated()
        {
            if (txtShotName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Shot name cannot be blank");
                txtShotName.Focus();
                return false;
            }
            int code = clsShot.getShotCode(txtShotName.Text);
            if (btnAdd.Text == "Add" && code > 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Shot name already exsists in the database.");
                txtShotName.Focus();
                txtShotName.SelectAll();
                return false;
            }
            if (btnAdd.Text == "Edit" && code > 0 && Convert.ToInt32(txtShotCode.Text) != code)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Shot name already exsists in the database.");
                txtShotName.Focus();
                txtShotName.SelectAll();
                return false;
            }

            return true;
        }
    }
}
