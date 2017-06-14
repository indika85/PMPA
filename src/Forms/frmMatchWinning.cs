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
    public partial class frmMatchWinning : Form
    {
        public frmMatchWinning()
        {
            InitializeComponent();
        }

        private void frmMatchWinning_Load(object sender, EventArgs e)
        {
            cmbTeams.Items.Add(clsMatch.currentMatch.team1.country.countryName);
            cmbTeams.Items.Add(clsMatch.currentMatch.team2.country.countryName);

            cmbTeams.SelectedIndex = 0;
        }

        private void btnEndMatch_Click(object sender, EventArgs e)
        {
            int winningTeamId = 0;
            if (cmbTeams.SelectedItem.ToString() == clsMatch.currentMatch.team1.country.countryName)
            {
                winningTeamId = clsMatch.currentMatch.team1.country.countryId;
            }
            else
            {
                winningTeamId = clsMatch.currentMatch.team2.country.countryId;
            }
            clsMatch.setWinningTeam(clsMatch.currentMatch.matchID, winningTeamId, txtComments.Text);
            Close();
        }
    }
}
