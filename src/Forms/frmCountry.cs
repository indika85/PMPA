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
    public partial class frmCountry : Form
    {
        public frmCountry()
        {
            InitializeComponent();
        }

        private void frmCountry_Load(object sender, EventArgs e)
        {
            fillCountryList();
            setNextCountryCode();
        }

        private void setNextCountryCode()
        {
            txtCountryCode.Text = clsCountry.getNextCountryCode().ToString();
        }

        private void fillCountryList()
        {
            dataGridView1.SelectAll();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            
            List<clsCountry> countryList = clsCountry.getAllCountries();
            foreach (clsCountry country in countryList)
            {
                dataGridView1.Rows.Add(country.countryId,country.countryName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValidCountry(txtCountryName.Text))
            {
                if (btnAdd.Text == "Add")
                {
                    if (clsCountry.addCountry(new clsCountry(clsCountry.getNextCountryCode(), txtCountryName.Text)) == 1)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Country was added sucessfully");
                        fillCountryList();
                        setNextCountryCode();
                    }
                    else
                    {
                        clsMessages.showMessage(clsMessages.msgType.exclamation, "Country could not be added sucessfully");
                    }
                }
                else if (btnAdd.Text == "Update")
                {
                    if (clsCountry.updateCountry(Convert.ToInt32(txtCountryCode.Text), txtCountryName.Text) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Country details updated successfully");
                        fillCountryList();
                        txtCountryCode.Text = clsCountry.getNextCountryCode().ToString();
                        txtCountryName.Text = "";
                        txtCountryName.Focus();
                        btnAdd.Text = "Add";
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the country name already exsists in the database and if so returns false
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        private bool isValidCountry(string countryName)
        {

            if (countryName.Trim() == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please enter a country name to continue");
                txtCountryName.Focus();
                return false;
            }
            else
            {
                if (clsCountry.getCountryCode(countryName) > 0)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "The country name already exsists in the system");
                    txtCountryName.Focus();
                    txtCountryName.SelectAll();
                    return false;
                }
            }
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (canbeEdited())
            {
                setDataForUpdate();
            }
        }

        private void setDataForUpdate()
        {
           txtCountryCode.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           txtCountryName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
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
