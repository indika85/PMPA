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
    public partial class frmRptCountry : Form
    {
        public frmRptCountry()
        {
            InitializeComponent();
        }

        private void reportDocument1_InitReport(object sender, EventArgs e)
        {

        }

        private void frmRptCountry_Load(object sender, EventArgs e)
        {
            loadCountries();
        }

        private void loadCountries()
        {
            foreach (clsCountry country in clsCountry.getAllCountries())
            {
                cmbCountry1.Items.Add(country.countryName);
                cmbCountry2.Items.Add(country.countryName);
            }

            cmbCountry1.SelectedIndex = 0;
            cmbCountry2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsCountriesAllBindingSource.DataSource = null;
            dsCountriesAllBindingSource.DataMember = null;
            reportViewer1.RefreshReport();
            dsCountriesAll.Tables["tblCountriesAll"].Rows.Clear();

            int country1 = clsCountry.getCountryCode(cmbCountry1.SelectedItem.ToString());
            int country2 = -1;
            if (cmbCountry2.SelectedIndex > 0)
            {
                country2 = clsCountry.getCountryCode(cmbCountry2.SelectedItem.ToString());
            }
            string query = "SELECT [team1CountryId] AS Country, [team1Captain] AS Captain, [team2CountryId] AS PlayedAgainst, [matchDate] AS Date, [matchWonBy] AS Resutls FROM tblMatch WHERE [team1CountryId]=@p1 AND [team2CountryId]=@p2";
            if (cmbCountry2.SelectedItem.ToString() == "*")
            {
                query = "SELECT [team1CountryId] AS Country, [team1Captain] AS Captain, [team2CountryId] AS PlayedAgainst, [matchDate] AS Date, [matchWonBy] AS Resutls FROM tblMatch WHERE [team1CountryId]=@p1 OR [team2CountryId]=@p1";
            }

            SqlCeCommand com = new SqlCeCommand(query, connection.CON);
            if (cmbCountry2.SelectedItem.ToString() == "*")
            {
                com.Parameters.AddWithValue("@p1", country1);
            }
            else
            {
                com.Parameters.AddWithValue("@p1", country1);
                com.Parameters.AddWithValue("@p2", country2);
            }
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            //DataSet ds = new DataSet("tblCountriesAll");
            
            ad.Fill(dsCountriesAll,"tblCountriesAll");

            //Replacing values
            for (int i = 0; i < dsCountriesAll.Tables["tblCountriesAll"].Rows.Count; i++)
            {
                try
                {
                    //string countryName = dsCountriesAll.Tables["tblCountriesAll"].Rows[i][0].ToString();

                    int captain = Convert.ToInt32(dsCountriesAll.Tables["tblCountriesAll"].Rows[i][1].ToString());
                    country1 = Convert.ToInt32(dsCountriesAll.Tables["tblCountriesAll"].Rows[i][0].ToString());
                    country2 = Convert.ToInt32(dsCountriesAll.Tables["tblCountriesAll"].Rows[i][2].ToString());
                    DateTime date = Convert.ToDateTime(dsCountriesAll.Tables["tblCountriesAll"].Rows[i][3].ToString());
                    int wonBy = Convert.ToInt32(dsCountriesAll.Tables["tblCountriesAll"].Rows[i][4].ToString());


                    dsCountriesAll.Tables["tblCountriesAll"].Rows[i][0] = clsCountry.getCountryName(country1);

                    clsPlayer player = clsPlayer.getPlayer(captain);
                    dsCountriesAll.Tables["tblCountriesAll"].Rows[i][1] = player.fName + " " + player.lName;
                    dsCountriesAll.Tables["tblCountriesAll"].Rows[i][2] = clsCountry.getCountryName(country2);
                    dsCountriesAll.Tables["tblCountriesAll"].Rows[i][3] = date.ToShortDateString();
                    dsCountriesAll.Tables["tblCountriesAll"].Rows[i][4] = clsCountry.getCountryName(wonBy) + " Won";

                }
                catch (Exception ex)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "No matches data found for selected countries.\n"+ex.Message);
                    return;
                }
            }

            dsCountriesAllBindingSource.DataSource = dsCountriesAll;
            dsCountriesAllBindingSource.DataMember = "tblCountriesAll";

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
