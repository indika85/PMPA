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
    public partial class frmPlayer : Form
    {
        public frmPlayer()
        {
            InitializeComponent();
        }

        private void frmPlayer_Load(object sender, EventArgs e)
        {
            fillCountryList();
            fillBowlingStyle();
            cmbBattingHand.SelectedIndex = 0;
            txtPlayerID.Text = clsPlayer.getNextPlayerId().ToString();
            //fillplayerDetailsGrid();
        }

        //private void fillplayerDetailsGrid()
        //{
        //    List<clsBowlingStyle> styles = clsBowlingStyle.getAllStyles();
        //    foreach (clsBowlingStyle style in styles)
        //    {
        //        cmbBowlingStyle.Items.Add(style.styleName);
        //    }
        //    cmbBowlingStyle.SelectedIndex = 0;
        //}

        private void fillBowlingStyle()
        {
            cmbBowlingStyle.Items.Clear();
            List<clsBowlingStyle> styles = clsBowlingStyle.getAllStyles();
            foreach (clsBowlingStyle style in styles)
            {
                cmbBowlingStyle.Items.Add(style.styleName);
            }
            cmbBowlingStyle.SelectedIndex = 0;
        }

        private void fillCountryList()
        {
            cmbCountry.Items.Clear();
            List<clsCountry> countrylist = clsCountry.getAllCountries();
            foreach (clsCountry country in countrylist)
            {
                cmbCountry.Items.Add(country.countryName);
            }
            cmbCountry.SelectedIndex = 0;
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex >= 0)
                fillDataGrid(cmbCountry.SelectedItem.ToString());
        }

        private void fillDataGrid(string countryName)
        {
            //dataGridView1.SelectAll();
            //foreach (DataGridViewRow r in dataGridView1.Rows)
            //{
            //    dataGridView1.Rows.Remove(r);
            //}
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows.RemoveAt(i);
            //}
            //if (dataGridView1.Rows.Count == 1)
            //    dataGridView1.Rows.RemoveAt(0);
            dataGridView1.Rows.Clear();
            int countryCode = clsCountry.getCountryCode(countryName);
            List<clsPlayer> players = clsPlayer.getPlayersOfCountry(countryCode);

            foreach (clsPlayer player in players)
            {
                dataGridView1.Rows.Add(player.playerId, player.fName, player.lName, player.dob.ToShortDateString(), player.country, player.battingHand, player.bowlingStyle);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataValidated())
            {
                if (btnAdd.Text == "Add")
                {
                    if (clsPlayer.addPlayer(new clsPlayer(Convert.ToInt32(txtPlayerID.Text), txtFirstName.Text, txtLastName.Text, dateTimePicker1.Value, cmbCountry.SelectedItem.ToString(), Convert.ToChar(cmbBattingHand.SelectedItem.ToString()), cmbBowlingStyle.SelectedItem.ToString())) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Player was added sucessfully");
                        setForNextRecord();
                    }
                }
                else
                {
                    //Update data
                    if (clsPlayer.updatePlayer(new clsPlayer(Convert.ToInt32(txtPlayerID.Text), txtFirstName.Text, txtLastName.Text, dateTimePicker1.Value, cmbCountry.SelectedItem.ToString(), Convert.ToChar(cmbBattingHand.SelectedItem.ToString()), cmbBowlingStyle.SelectedItem.ToString())) > 0)
                    {
                        clsMessages.showMessage(clsMessages.msgType.information, "Player was updated sucessfully");
                        setForNextRecord();
                    }

                }
            }
        }

        private void setForNextRecord()
        {
            txtPlayerID.Text = clsPlayer.getNextPlayerId().ToString();
            fillDataGrid(cmbCountry.SelectedItem.ToString());
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
            btnAdd.Text = "Add";
        }

        private bool dataValidated()
        {

            if (txtFirstName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.error,"First name cannot be blank");
                txtFirstName.Focus();
                return false;
            }
            else if (txtLastName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Last name cannot be blank");
                txtLastName.Focus();
                return false;
            }
            else if (cmbBattingHand.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Please select a batting hand to continue");
                cmbBattingHand.Focus();
                return false;
            }
            else if (cmbBowlingStyle.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Please select a bowling style to continue");
                cmbBowlingStyle.Focus();
                return false;
            }
            else if ((DateTime.Today.Year - dateTimePicker1.Value.Year) < 18)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "The DOB you entered seems to be invalid. Please check and try again");
                dateTimePicker1.Focus();
                return false;
            }
           
            int playerId=clsPlayer.getPlayerId(txtFirstName.Text, txtLastName.Text, clsCountry.getCountryCode(cmbCountry.SelectedItem.ToString()));
            if (playerId > 0 && btnAdd.Text == "Add")
            {
                //Used if adding player
                clsMessages.showMessage(clsMessages.msgType.error, "The player name already exsists in the database");
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return false;
            }
            
            if (playerId > 0 && playerId != Convert.ToInt32(txtPlayerID.Text))
            {
                //Used if updating player
                clsMessages.showMessage(clsMessages.msgType.error, "The player name already exsists in the database");
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return false;
            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No recrd is selected to. Please select the row you wan to edit and continue");
            }
            else
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];

                txtPlayerID.Text = r.Cells[0].EditedFormattedValue.ToString();//Player ID
                txtFirstName.Text = r.Cells[1].EditedFormattedValue.ToString();//First Name
                txtLastName.Text=r.Cells[2].EditedFormattedValue.ToString();//Last Name
                dateTimePicker1.Value=Convert.ToDateTime(r.Cells[3].EditedFormattedValue.ToString());//DOB
                cmbCountry.SelectedItem = r.Cells[4].EditedFormattedValue;//Country
                cmbBattingHand.SelectedItem = r.Cells[5].EditedFormattedValue;//Batting
                cmbBowlingStyle.SelectedItem = r.Cells[6].EditedFormattedValue;//Bowling

                btnAdd.Text = "Update";
            }
        }
    }
}
