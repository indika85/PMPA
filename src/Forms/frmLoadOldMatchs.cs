using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using PMPA.Classes;

namespace PMPA.Forms
{
    public partial class frmLoadOldMatchs : Form
    {
        public frmLoadOldMatchs()
        {
            InitializeComponent();
        }
        string conStringAcc;
        OleDbConnection conACCESS;

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblPath.Text = openFileDialog1.FileName;
                conStringAcc = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + lblPath.Text + "; Persist Security Info=False;";
                conACCESS = new OleDbConnection(conStringAcc);
                try
                {
                    conACCESS.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                btnLoadConutries.Enabled = true;
                btnPlayers.Enabled = true;
                setTeams();
                setDate();
            }

        }

        private void setDate()
        {
            OleDbCommand com = new OleDbCommand("SELECT [StartDateTime] FROM Matches", conACCESS);
            try
            {
                dateTimePicker1.Value = Convert.ToDateTime(com.ExecuteScalar());
            }
            catch { }
        }

        private void setTeams()
        {
            OleDbCommand com = new OleDbCommand("SELECT [Name] FROM Teams", conACCESS);
            OleDbDataAdapter ad = new OleDbDataAdapter(com);
            DataSet ds = new DataSet("Teams");
            ad.Fill(ds, "Teams");
            int i=1;
            foreach (DataRow r in ds.Tables["Teams"].Rows)
            {
                try
                {
                    if (i == 1)
                    {
                        cmbTeam1.SelectedItem = r[0];
                    }
                    else
                    {
                        cmbTema2.SelectedItem = r[0];
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    clsMessages.showMessage(clsMessages.msgType.error, "Error setting team names. \n\n" + ex.Message);
                }
            }
        }
        private void loadCountries()
        {
            OleDbCommand comAcc = new OleDbCommand("SELECT * FROM Countries", conACCESS);
            OleDbDataAdapter adACC = new OleDbDataAdapter(comAcc);
            DataSet dsACC = new DataSet("Countries");
            adACC.Fill(dsACC, "Countries");


            foreach (DataRow rACC in dsACC.Tables["Countries"].Rows)
            {
                int countryId = clsCountry.getNextCountryCode();
                string countryName = rACC[2].ToString();
                if (clsCountry.getCountryCode(countryName) <= 0)
                {
                    clsCountry.addCountry(new clsCountry(countryId, countryName));
                }
                //MessageBox.Show(countryId.ToString() + "  " + countryName);
            }
            clsMessages.showMessage(clsMessages.msgType.information, "Countries were added");
        }

        private void btnLoadConutries_Click(object sender, EventArgs e)
        {
            loadCountries();
        }

        private void frmLoadOldMatchs_Load(object sender, EventArgs e)
        {
            foreach (clsCountry country in clsCountry.getAllCountries())
            {
                cmbTeam1.Items.Add(country.countryName);
                cmbTema2.Items.Add(country.countryName);
            }
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            loadPlayers();
        }

        private void loadPlayers()
        {
            OleDbCommand comAcc = new OleDbCommand("SELECT Countries.Name, Players.FirstName, Players.LastName, Players.RightHandedBatsmanYN, Players.RightHandedBowlerYN FROM (Countries INNER JOIN Teams ON Countries.ID = Teams.CountryID) INNER JOIN Players ON (Teams.ID = Players.CurrentTeamID)", conACCESS);

            OleDbDataAdapter adAc = new OleDbDataAdapter(comAcc);
            DataSet dsAc = new DataSet("players");
            adAc.Fill(dsAc, "players");

            foreach (DataRow rAc in dsAc.Tables["players"].Rows)
            {
                int playerId = clsPlayer.getNextPlayerId();
                string countryName=rAc[0].ToString();
                int countryCode = clsCountry.getCountryCode(countryName);
                string fName = rAc[1].ToString();
                string lName = rAc[2].ToString();
                char battingHand = 'L';
                if (Convert.ToBoolean(rAc[3].ToString()))
                {
                    battingHand = 'R';
                }
                string bowlingStyle = clsBowlingStyle.getBowlingStyle(new Random().Next(0, 7));
                if (countryCode <= 0)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "No country found for" + rAc[0].ToString());
                    return;
                }
                if (clsPlayer.getPlayerId(fName, lName, countryCode) < 0)
                {
                    //If player does not exist ad  player.
                    clsPlayer.addPlayer(new clsPlayer(playerId, fName, lName, getRandomDate(), countryName, battingHand, bowlingStyle));
                }
            }

            clsMessages.showMessage(clsMessages.msgType.information, "Players were added");


        }
        private DateTime getRandomDate()
        {

            DateTime start = new DateTime(1975, 1, 1);
            Random gen = new Random();

            int range = (new DateTime(1995, 1, 1) - start).Days;
            return start.AddDays(gen.Next(range));

        }

        private void lblLoadMatchDate_Click(object sender, EventArgs e)
        {
            //Create match and the databse
            string path = "";
            saveFileDialog1.FileName = txtMatchName.Text+".sdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }
            if (!rbTeam1FirstBatting.Checked && !rbTeam2FirstBatting.Checked)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select the first batting team to continue.");
                return;
            }
            //show infor
            txtInfo.Text = "Save path: "+path + "\n\n";

            
            //Import data
            //Get the two team names.
            string team1Name="", team2Name = "";
            OleDbCommand comAc = new OleDbCommand("SELECT Teams.CountryID, Countries.Name, Teams.ID FROM Countries INNER JOIN Teams ON Countries.ID = Teams.CountryID", conACCESS);
            OleDbDataAdapter adACC = new OleDbDataAdapter(comAc);
            DataSet dsAC = new DataSet("countries");
            adACC.Fill(dsAC, "countries");
            team1Name = dsAC.Tables["countries"].Rows[0][1].ToString();
            team2Name = dsAC.Tables["countries"].Rows[1][1].ToString();

            int team1RefID=Convert.ToInt32(dsAC.Tables["countries"].Rows[0][2].ToString());
            int team2RefID = Convert.ToInt32(dsAC.Tables["countries"].Rows[1][2].ToString());

            //Indormation for creating a match
            int matchId = clsMatch.getNextMatchId();
            string matchName = txtMatchName.Text;
            DateTime matchDate = dateTimePicker1.Value;
            clsMatchTypes matchType = new clsMatchTypes(clsMatchTypes.getMatchTypeID(cmbMatchType.SelectedItem.ToString()),cmbMatchType.SelectedItem.ToString());
            
            comAc = new OleDbCommand("SELECT Countries.Name FROM Countries INNER JOIN Venues ON Countries.ID = Venues.CountryID", conACCESS);
            string countryNamePlayed = "";
            try
            {
                countryNamePlayed = comAc.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
            }
            clsCountry countryPlayed = new clsCountry(clsCountry.getCountryCode(countryNamePlayed),countryNamePlayed);

            comAc = new OleDbCommand("SELECT [Name] FROM Venues", conACCESS);
            string venueName = comAc.ExecuteScalar().ToString();

            //Check if venue is in database
            if (clsGround.getGroundCode(venueName) <= 0)
            {
                int venueCode=clsGround.getNextGroundCode();
                int endId=clsEnds.getNextEndID();
                clsGround.addGround(new clsGround(venueCode, venueName,30000,countryPlayed.countryId,new clsEnds(endId,"Scoreboard End",venueCode),new clsEnds(endId+1,"Pavillion End",venueCode)));

            }
            clsGround groundPlayed = clsGround.getGround(venueName);
            //Show info
            txtInfo.Text += "Ground played in: " + groundPlayed.stadiumName + "\n\n";
            txtInfo.Text += "Venue played: " + venueName + "\n\n";
            txtInfo.Text += "Match name: " + matchName + "\n\n";
            txtInfo.Text += "Team 1: " + team1Name + "\n\n";
            txtInfo.Text += "Team 1: " + team2Name + "\n\n";
            txtInfo.Text += "-----------------------\n\n";

            //Get team 1 and 2
            string playerFName = "", platerLName = "";

            List<clsPlayer> team1 = new List<clsPlayer>();
            List<clsPlayer> team2 = new List<clsPlayer>();

            comAc = new OleDbCommand("SELECT CurrentTeamID, FirstName, LastName FROM Players", conACCESS);
            adACC = new OleDbDataAdapter(comAc);
            dsAC = new DataSet("Players");
            adACC.Fill(dsAC, "Players");

            //Show info
            txtInfo.Text += "Players added..." + "\n\n";

            foreach (DataRow rAC in dsAC.Tables["Players"].Rows)
            {
                int currentTeamID = Convert.ToInt32(rAC[0].ToString());
                string currentTeam = "";
                OleDbCommand comCurrentTeam = new OleDbCommand("SELECT [Name] FROM Teams WHERE ID=@p1", conACCESS);
                comCurrentTeam.Parameters.AddWithValue("@p1", currentTeamID);
                currentTeam = comCurrentTeam.ExecuteScalar().ToString();

                playerFName = rAC[1].ToString();
                platerLName = rAC[2].ToString();

                if (currentTeam == team1Name)
                {
                    team1.Add(clsPlayer.getPlayer(clsPlayer.getPlayerId(playerFName,platerLName,clsCountry.getCountryCode(team1Name))));
                }
                else
                {
                    team2.Add(clsPlayer.getPlayer(clsPlayer.getPlayerId(playerFName, platerLName, clsCountry.getCountryCode(team2Name))));
                }

                //Display the data added.
                txtInfo.Text += playerFName + " " + platerLName + "\n\n";
            }

            OleDbCommand comCaptain1 = new OleDbCommand("SELECT CaptainID FROM MatchTeams WHERE TeamID=@p1", conACCESS);
            comCaptain1.Parameters.AddWithValue("@p1", team1RefID);
            OleDbCommand comCaptain2 = new OleDbCommand("SELECT CaptainID FROM MatchTeams WHERE TeamID=@p1", conACCESS);
            comCaptain2.Parameters.AddWithValue("@p1", team2RefID);
            int captain1Id = 0;
            int captain2Id = 0;

            try
            {
                captain1Id = clsImportBallbyBall.mapPlayer(Convert.ToInt32(comCaptain1.ExecuteScalar().ToString()),conACCESS);
                captain2Id = clsImportBallbyBall.mapPlayer(Convert.ToInt32(comCaptain2.ExecuteScalar().ToString()), conACCESS);
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error retrieving team capain IDs\n\n"+ex.Message);
            }

            List<clsTeams> squard = new List<clsTeams>();
            squard.Add(new clsTeams(clsCountry.getCountry(team1Name),team1,captain1Id,0,0));
            squard.Add(new clsTeams(clsCountry.getCountry(team2Name), team2, captain2Id, 0, 0));

            string firstBatting="";
            if(rbTeam1FirstBatting.Checked)
                firstBatting=cmbTeam1.SelectedItem.ToString();
            else if(rbTeam2FirstBatting.Checked)
                firstBatting=cmbTema2.SelectedItem.ToString();

            new clsMatch(matchId, matchName, matchType, matchDate, path, countryPlayed, groundPlayed, squard, cmbTeam1.SelectedItem.ToString(), firstBatting);
            
            SqlCeConnection conSQL = connection.creatDatabase(path, true);

            //Create tables in the match database
            clsCreateTables.createTables(conSQL);
            //connection.CON_WORKING = conSQL;

            //Creates the match in the main database
            clsMatch.creatMatch();
            if (chkMatchWon.Checked)
            {
                clsMatch.setWinningTeam(matchId, squard[0].country.countryId, "");
            }
            else
            {
                clsMatch.setWinningTeam(matchId, squard[1].country.countryId, "");
            }
            
            clsCreateTables.AddTeam(clsMatch.currentMatch.team1.players, clsMatch.currentMatch.matchID);
            clsCreateTables.AddTeam(clsMatch.currentMatch.team2.players, clsMatch.currentMatch.matchID);

            lblLoadMatchDate.Enabled = false;
            btnBallByBall.Enabled = true;
            clsMessages.showMessage(clsMessages.msgType.information, "Match data was Imported successfully");
        }

        private void cmbTeam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMatchName.Text = cmbTeam1.SelectedItem.ToString() + " vs ";
        }

        private void cmbTema2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMatchName.Text += cmbTema2.SelectedItem.ToString();
        }

        private void btnBallByBall_Click(object sender, EventArgs e)
        {
            clsImportBallbyBall.importBall(conACCESS,lblPath.Text);
            clsMessages.showMessage(clsMessages.msgType.information, "Match data imported successfully");
        }

    }
}
