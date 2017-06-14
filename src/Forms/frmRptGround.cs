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
    public partial class frmRptGround : Form
    {
        public frmRptGround()
        {
            InitializeComponent();
        }

        private void frmRptGround_Load(object sender, EventArgs e)
        {
            foreach (clsCountry country in clsCountry.getAllCountries())
            {
                cmbCountry.Items.Add(country.countryName);
            }
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            tblGroundsBindingSource.DataSource = null;
            tblGroundsBindingSource.DataMember = null;
            dsGrounds.Tables["tblGrounds"].Rows.Clear();
            this.reportViewer1.RefreshReport();

            if (cmbGround.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No ground was selected");
                return;
            }
            int groundCode = clsGround.getGroundCode(cmbGround.SelectedItem.ToString());

            SqlCeCommand com1 = new SqlCeCommand("SELECT matchName, matchDate, matchWonBy, savePath FROM tblMatch WHERE groundId=@p1", connection.CON);
            com1.Parameters.AddWithValue("@p1", groundCode);

            SqlCeDataAdapter ad1 = new SqlCeDataAdapter(com1);
            DataSet ds = new DataSet("tblMatch");
            ad1.Fill(ds, "tblMatch");

            if (ds.Tables["tblMatch"].Rows.Count <= 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No match data for the selecred ground");
                return;
            }

            int rowCount = 0;
            foreach (DataRow r in ds.Tables["tblMatch"].Rows)
            {
                string groundName = cmbGround.SelectedItem.ToString();
                string matchName = r[0].ToString();
                DateTime date = Convert.ToDateTime(r[1].ToString());
                int winningTeamId = Convert.ToInt32(r[2].ToString());
                string winningTeam = clsCountry.getCountryName(winningTeamId);

                dsGrounds.Tables["tblGrounds"].Rows.Add();
                dsGrounds.Tables["tblGrounds"].Rows[rowCount][0] = groundName;
                dsGrounds.Tables["tblGrounds"].Rows[rowCount][1] = matchName;
                dsGrounds.Tables["tblGrounds"].Rows[rowCount][2] = date.ToShortDateString();
                dsGrounds.Tables["tblGrounds"].Rows[rowCount][3] = winningTeam;
                dsGrounds.Tables["tblGrounds"].Rows[rowCount][4] = "NA";

                rowCount++;
            }

            tblGroundsBindingSource.DataSource = dsGrounds;
            tblGroundsBindingSource.DataMember = "tblGrounds";

            this.reportViewer1.RefreshReport();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGround.Items.Clear();
            cmbGround.Text = "";
            if (cmbCountry.SelectedIndex < 0)
                return;

            int countryId = clsCountry.getCountryCode(cmbCountry.SelectedItem.ToString());
            foreach (clsGround ground in clsGround.getAllGrounds(countryId))
            {
                cmbGround.Items.Add(ground.stadiumName);
            }
        }
    }
}
