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
    public partial class frmBallType : Form
    {
        public frmBallType()
        {
            InitializeComponent();
        }

        private void frmBallType_Load(object sender, EventArgs e)
        {
            setNextStyleCode();
            fillStylesToGrid();
        }

        private void fillStylesToGrid()
        {
            dataGridView1.SelectAll();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            List<clsBowlingStyle> styleList = clsBowlingStyle.getAllStyles();
            foreach (clsBowlingStyle style in styleList)
            {
                dataGridView1.Rows.Add(style.styleCode,style.styleName);
            }
        }

        private void setNextStyleCode()
        {

            txtStyleCode.Text = PMPA.Classes.clsBowlingStyle.getNextBowlingStyleCode().ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataValidated())
            {
                if (btnAdd.Text == "Add")
                {
                    if (clsBowlingStyle.addBowlingStyle(new clsBowlingStyle(Convert.ToInt32(txtStyleCode.Text), txtStyleName.Text)) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "New bowling style was added successfully");
                        setNextStyleCode();
                        txtStyleName.Clear();
                        txtStyleName.Focus();
                        fillStylesToGrid();
                    }
                    else
                    {
                        clsMessages.showMessage(clsMessages.msgType.exclamation, "There was an error inserting data into the system");
                    }
                }
                else
                {
                    if (clsBowlingStyle.udpdateowlingStyle(new clsBowlingStyle(Convert.ToInt32(txtStyleCode.Text), txtStyleName.Text)) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Bowling style was updated successfully");
                        setNextStyleCode();
                        txtStyleName.Clear();
                        txtStyleName.Focus();
                        btnAdd.Text = "Add";
                        fillStylesToGrid();
                    }
                }
            }
        }


        private bool dataValidated()
        {
            if (txtStyleName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Bowling style name cannot be blank");
                txtStyleName.Focus();
                return false;
            }
            int code = clsBowlingStyle.getBowlingStyleCode(txtStyleName.Text);
            if (btnAdd.Text == "Add" && code>0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Bowling style name already exsists in the database.");
                txtStyleName.Focus();
                txtStyleName.SelectAll();
                return false;
            }
            if (btnAdd.Text == "Edit" && code>0 && Convert.ToInt32(txtStyleCode.Text)!=code)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Bowling style name already exsists in the database.");
                txtStyleName.Focus();
                txtStyleName.SelectAll();
                return false;
            }
            
            return true;
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
                txtStyleCode.Text = r.Cells[0].EditedFormattedValue.ToString();
                txtStyleName.Text = r.Cells[1].EditedFormattedValue.ToString();
                btnAdd.Text = "Edit";
            }
        }
    }
}
