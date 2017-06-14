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
    public partial class frmCreateMatch : Form
    {
        public static string tossWonby = "", firstBattinh = "";
        public frmCreateMatch()
        {
            InitializeComponent();
        }

        private void frmCreateMatch_Load(object sender, EventArgs e)
        {
            loadCountrySet();
            loadMatchTypes();

            dateTimePicker1.Value = DateTime.Now;

            //filltestData();
        }

        private void filltestData()
        {
            cmbCountry1.SelectedIndex=1;
            cmbCountry2.SelectedIndex = 4;

            for (int i = 0; i < 11; i++)
            {
                lstCountry1Squard.Items.Add(lstCountry1Players.Items[i]);
                lstCountry2Squard.Items.Add(lstCountry2Players.Items[i]);
                cmbSquad1Capt.Items.Add(lstCountry2Players.Items[i]);
                cmbSquad1VCapt.Items.Add(lstCountry2Players.Items[i]);
                cmbSquad1WC.Items.Add(lstCountry2Players.Items[i]);
                cmbSquad2Capt.Items.Add(lstCountry2Players.Items[i]);
                cmbSquad2VCapt.Items.Add(lstCountry2Players.Items[i]);
                cmbSquad2WC.Items.Add(lstCountry2Players.Items[i]);

            }

            cmbSquad1Capt.SelectedIndex = 0;
            cmbSquad1VCapt.SelectedIndex = 1;
            cmbSquad1WC.SelectedIndex = 3;

            cmbSquad2Capt.SelectedIndex = 0;
            cmbSquad2VCapt.SelectedIndex = 2;
            cmbSquad2WC.SelectedIndex = 2;

            cmbCountry.SelectedIndex = 0;
            cmbVenue.SelectedIndex = 0;
        }

        private void loadMatchTypes()
        {
            cmbMatchType.Items.Clear();

            List<clsMatchTypes> matchTypes = clsMatchTypes.getMatchTypes();
            foreach (clsMatchTypes matchType in matchTypes)
            {
                cmbMatchType.Items.Add(matchType.matchTypeName);
            }

            if (cmbMatchType.Items.Count > 0)
                cmbMatchType.SelectedIndex = 0;
        }

        private void loadCountrySet()
        {
            cmbCountry.Items.Clear();
            cmbCountry1.Items.Clear();
            cmbCountry2.Items.Clear();

            cmbCountry.Items.Add("--Select--");
            cmbCountry1.Items.Add("--Select--");
            cmbCountry2.Items.Add("--Select--");

            List<clsCountry> countryList = clsCountry.getAllCountries();
            foreach (clsCountry country in countryList)
            {
                cmbCountry.Items.Add(country.countryName);
                cmbCountry1.Items.Add(country.countryName);
                cmbCountry2.Items.Add(country.countryName);
            }
            cmbCountry.SelectedIndex = cmbCountry1.SelectedIndex = cmbCountry2.SelectedIndex = 0;
        }

        private void cmbCountry2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry2.SelectedIndex > 0)
            {
                if (cmbCountry2.SelectedIndex == cmbCountry1.SelectedIndex)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "Both countries cannot be the same");
                    cmbCountry2.SelectedIndex = 0;
                }
                else
                {
                    lstCountry2Players.Items.Clear();
                    lstCountry2Squard.Items.Clear();
                    List<clsPlayer> players = clsPlayer.getPlayersOfCountry(clsCountry.getCountryCode(cmbCountry2.SelectedItem.ToString()));
                    foreach (clsPlayer player in players)
                    {
                        lstCountry2Players.Items.Add(player.fName + " " + player.lName);
                    }
                    dissableTeamControls(2, false);

                    predictName();
                }
            }
            else
            {
                dissableTeamControls(2,true);
            }
        }

        private void predictName()
        {
            txtMatchName.Text = cmbCountry1.SelectedItem.ToString() + " vs " + cmbCountry2.SelectedItem.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamNumber">Team Number to enable/ Dissable (1 or 2)</param>
        /// <param name="dissable">true to dissable</param>
        private void dissableTeamControls(int teamNumber, bool dissable)
        {
            if (teamNumber == 1)
            {

                btnAddPlayerCountry1.Enabled = !dissable;
                btnRemovePlayerCountry1.Enabled = !dissable;

            }
            else if (teamNumber == 2)
            {
                btnAddPlayerCountry2.Enabled = !dissable;
                btnRemovePlayerCountry2.Enabled = !dissable;
            }
        }

        private void cmbCountry1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry1.SelectedIndex > 0)
            {
                if (cmbCountry2.SelectedIndex == cmbCountry1.SelectedIndex)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "Both countries cannot be the same");
                    cmbCountry1.SelectedIndex = 0;
                }
                else
                {
                    lstCountry1Players.Items.Clear();
                    lstCountry1Squard.Items.Clear();
                    List<clsPlayer> players = clsPlayer.getPlayersOfCountry(clsCountry.getCountryCode(cmbCountry1.SelectedItem.ToString()));
                    foreach (clsPlayer player in players)
                    {
                        lstCountry1Players.Items.Add(player.fName + " " + player.lName);
                    }
                    dissableTeamControls(1, false);

                    predictName();
                }
            }
            else
            {
                dissableTeamControls(1, true);
            }
        }

        private void btnAddPlayerCountry1_Click(object sender, EventArgs e)
        {
            
            
            if (lstCountry1Players.SelectedIndex >= 0)
            {
                lstCountry1Squard.Items.Add(lstCountry1Players.SelectedItem);
                cmbSquad1Capt.Items.Add(lstCountry1Players.SelectedItem);
                cmbSquad1VCapt.Items.Add(lstCountry1Players.SelectedItem);
                cmbSquad1WC.Items.Add(lstCountry1Players.SelectedItem);


                lstCountry1Players.Items.Remove(lstCountry1Players.SelectedItem);
                if(lstCountry1Players.Items.Count>0)
                    lstCountry1Players.SelectedIndex = 0;

                lblSquad1Number.Text = lstCountry1Squard.Items.Count.ToString();
            }
            else
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a player to add");
            }
        }

        private void btnRemovePlayerCountry1_Click(object sender, EventArgs e)
        {
            
            
            if (lstCountry1Squard.SelectedIndex >= 0)
            {
                lstCountry1Players.Items.Add(lstCountry1Squard.SelectedItem);

                cmbSquad1Capt.Items.Remove(lstCountry1Squard.SelectedItem);
                cmbSquad1VCapt.Items.Remove(lstCountry1Squard.SelectedItem);
                cmbSquad1WC.Items.Remove(lstCountry1Squard.SelectedItem);
                lstCountry1Squard.Items.Remove(lstCountry1Squard.SelectedItem);

                lblSquad1Number.Text = lstCountry1Squard.Items.Count.ToString();

            }
            else
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a player to remove");
            }
        }

        private void btnAddPlayerCountry2_Click(object sender, EventArgs e)
        {
            if (lstCountry2Players.SelectedIndex >= 0)
            {
                lstCountry2Squard.Items.Add(lstCountry2Players.SelectedItem);
                cmbSquad2Capt.Items.Add(lstCountry2Players.SelectedItem);
                cmbSquad2VCapt.Items.Add(lstCountry2Players.SelectedItem);
                cmbSquad2WC.Items.Add(lstCountry2Players.SelectedItem);


                lstCountry2Players.Items.Remove(lstCountry2Players.SelectedItem);
                if(lstCountry2Players.Items.Count>0)
                    lstCountry2Players.SelectedIndex = 0;

                lblSquad2Number.Text = lstCountry2Squard.Items.Count.ToString();
            }
            else
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a player to add");
            }
        }

        private void btnRemovePlayerCountry2_Click(object sender, EventArgs e)
        {
            if (lstCountry2Squard.SelectedIndex >= 0)
            {
                lstCountry2Players.Items.Add(lstCountry2Squard.SelectedItem);

                cmbSquad2Capt.Items.Remove(lstCountry2Squard.SelectedItem);
                cmbSquad2VCapt.Items.Remove(lstCountry2Squard.SelectedItem);
                cmbSquad2WC.Items.Remove(lstCountry2Squard.SelectedItem);
                lstCountry2Squard.Items.Remove(lstCountry2Squard.SelectedItem);

                lblSquad2Number.Text = lstCountry2Squard.Items.Count.ToString();
            }
            else
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a player to remove");
            }
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex > 0)
            {
                fillVenues(cmbCountry.SelectedItem.ToString());
            }
        }

        private void fillVenues(string p)
        {
            cmbVenue.Items.Clear();
            List<clsGround> venues = clsGround.getAllGrounds(clsCountry.getCountryCode(cmbCountry.SelectedItem.ToString()));
            foreach (clsGround venue in venues)
            {
                cmbVenue.Items.Add(venue.stadiumName);
            }
        }

        private void btnCreateMatch_Click(object sender, EventArgs e)
        {
            if (dataValidated())
            {
                new frmToss(cmbCountry1.SelectedItem.ToString(), cmbCountry2.SelectedItem.ToString()).ShowDialog();
                saveFileDialog1.FileName = txtMatchName.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string fileName = saveFileDialog1.FileName;

                List<clsTeams> teams = new List<clsTeams>();
                List<clsPlayer> squad1 = new List<clsPlayer>();
                List<clsPlayer> squad2 = new List<clsPlayer>();

                int captain = 0, viceCaptain = 0, wicketKeeper = 0;

                string fName, lName = "";

                //Adding the squad for the team 1
                int countryId = clsCountry.getCountryCode(cmbCountry1.SelectedItem.ToString());

                foreach (string player in lstCountry1Squard.Items)
                {
                    //Splits the name in to two
                    fName = extractPlayerFName(player);
                    lName = extractPlayerLName(player);

                    squad1.Add(clsPlayer.getPlayer(clsPlayer.getPlayerId(fName, lName, countryId)));
                }


                captain = clsPlayer.getPlayerId(extractPlayerFName(cmbSquad1Capt.SelectedItem.ToString()), extractPlayerLName(cmbSquad1Capt.SelectedItem.ToString()), countryId);
                viceCaptain = clsPlayer.getPlayerId(extractPlayerFName(cmbSquad1VCapt.SelectedItem.ToString()), extractPlayerLName(cmbSquad1VCapt.SelectedItem.ToString()), countryId);
                wicketKeeper = clsPlayer.getPlayerId(extractPlayerFName(cmbSquad1WC.SelectedItem.ToString()), extractPlayerLName(cmbSquad1WC.SelectedItem.ToString()), countryId);

                teams.Add(new clsTeams(clsCountry.getCountry(cmbCountry1.SelectedItem.ToString()), squad1, captain, viceCaptain, wicketKeeper));

                //Adding the squad for the team 2
                countryId = clsCountry.getCountryCode(cmbCountry2.SelectedItem.ToString());
                foreach (string player in lstCountry2Squard.Items)
                {
                    //Splits the name in to two
                    fName = extractPlayerFName(player);
                    lName = extractPlayerLName(player);

                    squad2.Add(clsPlayer.getPlayer(clsPlayer.getPlayerId(fName.Trim(), lName.Trim(), countryId)));
                }

                captain = clsPlayer.getPlayerId(extractPlayerFName(cmbSquad2Capt.SelectedItem.ToString()), extractPlayerLName(cmbSquad2Capt.SelectedItem.ToString()), countryId);
                viceCaptain = clsPlayer.getPlayerId(extractPlayerFName(cmbSquad2VCapt.SelectedItem.ToString()), extractPlayerLName(cmbSquad2VCapt.SelectedItem.ToString()), countryId);
                wicketKeeper = clsPlayer.getPlayerId(extractPlayerFName(cmbSquad2WC.SelectedItem.ToString()), extractPlayerLName(cmbSquad2WC.SelectedItem.ToString()), countryId);

                teams.Add(new clsTeams(clsCountry.getCountry(cmbCountry2.SelectedItem.ToString()), squad2, captain, viceCaptain, wicketKeeper));


                clsMatchTypes matchType = new clsMatchTypes(clsMatchTypes.getMatchTypeID(cmbMatchType.SelectedItem.ToString()), cmbMatchType.SelectedItem.ToString());

                int matchId = clsMatch.getNextMatchId();

                //Creates the main math object
                new clsMatch(matchId, txtMatchName.Text,matchType, dateTimePicker1.Value, fileName, clsCountry.getCountry(cmbCountry.SelectedItem.ToString()), clsGround.getGround(cmbVenue.SelectedItem.ToString()), teams, tossWonby, firstBattinh);

                //Set the isBatting flag
                if (firstBattinh == clsMatch.currentMatch.team1.country.countryName)
                {
                    clsMatch.currentMatch.team1.isBatting = true;
                    clsMatch.currentMatch.team2.isBatting = false;
                }
                else
                {
                    clsMatch.currentMatch.team1.isBatting = false;
                    clsMatch.currentMatch.team2.isBatting = true;
                }
                
                //Writes data to the databse
                clsMatch.creatMatch();

                clsFormCreater.openForm(new frmCaptureVideo());
                
                
                //Close();

            }


        }

        private string extractPlayerLName(string player)
        {
            int indexOfSpace = player.IndexOf(" ");
            string fName=player.Substring(0, indexOfSpace);
            return player.Substring(indexOfSpace, player.Length - fName.Length).Trim(' ');
        }

        private string extractPlayerFName(string player)
        {
            int indexOfSpace = player.IndexOf(" ");
            return player.Substring(0, indexOfSpace).Trim(' ');
        }

        private bool dataValidated()
        {
            if (lstCountry1Squard.Items.Count != 11)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Number of players should be 11 in squad 1");
                return false;
            }
            if (lstCountry2Squard.Items.Count != 11)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Number of players should be 11 in squad 2");
                return false;
            }
            if (cmbSquad1Capt.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the captain of the team 1");
                cmbSquad1Capt.Focus();
                return false;
            }
            if (cmbSquad1VCapt.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the vice captain of the team 1");
                cmbSquad1VCapt.Focus();
                return false;
            }
            if (cmbSquad1WC.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the Wicket Keeper of the team 1");
                cmbSquad1WC.Focus();
                return false;
            }

            if (cmbSquad2Capt.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the captain of the team 2");
                cmbSquad2Capt.Focus();
                return false;
            }
            if (cmbSquad2VCapt.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the vice captain of the team 2");
                cmbSquad2VCapt.Focus();
                return false;
            }
            if (cmbSquad2WC.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the Wicket Keeper of the team 2");
                cmbSquad2WC.Focus();
                return false;
            }

            if (txtMatchName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Match name connot be blank");
                txtMatchName.Focus();
                return false;
            }

            if (cmbCountry.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the country where the match is being played");
                cmbCountry.Focus();
                return false;
            }
            if (cmbVenue.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the venue where the match is being played");
                cmbVenue.Focus();
                return false;
            }
            if (cmbMatchType.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the match type");
                cmbMatchType.Focus();
                return false;
            }
            
            return true;
        }


    }
}
