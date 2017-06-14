using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMPA.Classes;
using System.Data.SqlServerCe;

namespace PMPA.Forms
{
    public partial class frmRptPlayerScore : Form
    {
        public frmRptPlayerScore()
        {
            InitializeComponent();
        }

        private void frmRptPlayerScore_Load(object sender, EventArgs e)
        {

            foreach (clsCountry country in clsCountry.getAllCountries())
            {
                cmbCountry.Items.Add(country.countryName);
            }
            //this.reportViewer1.RefreshReport();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = cmbCountry.SelectedIndex + 1;
            cmbPlayer.Items.Clear();

            foreach (clsPlayer player in clsPlayer.getPlayersOfCountry(countryId))
            {
                cmbPlayer.Items.Add(player.fName + " " + player.lName + " (" + player.playerId.ToString() + ")");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbPlayer.SelectedIndex < 0 || cmbCountry.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select player to continue");
                return;
            }
            tblPlayerScoresBindingSource.DataSource = null;
            tblPlayerScoresBindingSource.DataMember = null;
            dsPlayerScores.Tables["tblPlayerScores"].Rows.Clear();

            reportViewer1.RefreshReport();

            int playerId = getPlayerId();

            SqlCeCommand com1 = new SqlCeCommand("SELECT savePath, team2CountryId, matchDate, team1CountryId FROM tblMatch", connection.CON);
            SqlCeDataAdapter ad1 = new SqlCeDataAdapter(com1);
            DataSet ds1 = new DataSet("tblMatch");
            ad1.Fill(ds1, "tblMatch");

            int rowCount = 0;
            foreach (DataRow r in ds1.Tables["tblMatch"].Rows)
            {
                //MessageBox.Show("Inside loop");
                SqlCeConnection con_temp = connection.getConnection(r[0].ToString());
                SqlCeCommand com2 = new SqlCeCommand("SELECT batsmanId AS PlayerName, SUM(runs) AS Score, COUNT(batsmanId) AS Balls FROM tblBalls WHERE batsmanId=@p1 GROUP BY batsmanId ", con_temp);
                com2.Parameters.AddWithValue("@p1", playerId);
                SqlCeDataAdapter ad2 = new SqlCeDataAdapter(com2);
                DataSet ds2 = new DataSet("tblScores");
                ad2.Fill(ds2, "tblScores");
                try
                {
                    if (ds2.Tables["tblScores"].Rows.Count <= 0) break;

                    DataRow r2 = ds2.Tables["tblScores"].Rows[0];

                    int playedAgainstCountryId = Convert.ToInt32(r[1].ToString());
                    string playedAgainst = clsCountry.getCountryName(playedAgainstCountryId);
                    if (cmbCountry.SelectedItem.ToString() == playedAgainst)
                    {
                        playedAgainstCountryId = Convert.ToInt32(r[3].ToString());
                        playedAgainst = clsCountry.getCountryName(playedAgainstCountryId);
                    }

                    DateTime matchDate = Convert.ToDateTime(r[2].ToString());

                    double score = Convert.ToDouble(r2[1].ToString())*1.0;
                    double balls = Convert.ToDouble(r2[2].ToString())*1.0;
                    double SR = (score / balls) * 100.00;
                    SR = Math.Round(SR, 2);

                    dsPlayerScores.Tables["tblPlayerScores"].Rows.Add();
                    dsPlayerScores.Tables["tblPlayerScores"].Rows[rowCount][0] = cmbPlayer.SelectedItem.ToString();
                    dsPlayerScores.Tables["tblPlayerScores"].Rows[rowCount][1] = playedAgainst;
                    dsPlayerScores.Tables["tblPlayerScores"].Rows[rowCount][2] = score.ToString();
                    dsPlayerScores.Tables["tblPlayerScores"].Rows[rowCount][3] = SR.ToString();
                    dsPlayerScores.Tables["tblPlayerScores"].Rows[rowCount][4] = matchDate.ToShortDateString();
                }
                catch(Exception ex)
                {
                    clsMessages.showMessage(clsMessages.msgType.error, "No records were found for the selected player.\n"+ex.Message);
                    return;
                }
                //dsPlayerScores.Tables["tblPlayerScores"].Rows.Add();
                //dsPlayerScores.Tables["tblPlayerScores"].Rows.Add();
                //dsPlayerScores.Tables["tblPlayerScores"].Rows.Add();
                
                rowCount++;
                //MessageBox.Show(rowCount.ToString());
            }


            tblPlayerScoresBindingSource.DataSource = dsPlayerScores;
            tblPlayerScoresBindingSource.DataMember = "tblPlayerScores";

            reportViewer1.RefreshReport();
        }

        private int getPlayerId()
        {
            int playerId = -1;

            string player = cmbPlayer.SelectedItem.ToString();
            string code = player.Substring(player.IndexOf("(")+1, player.IndexOf(")") - player.IndexOf("(")-1);

            //MessageBox.Show(code);
            playerId = Convert.ToInt32(code);
            return playerId;
        }

    }
}
