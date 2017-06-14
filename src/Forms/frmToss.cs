using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMPA.Forms
{
    public partial class frmToss : Form
    {
        public frmToss()
        {
            InitializeComponent();
        }
        public frmToss(string country1, string country2)
        {
            InitializeComponent();
            cmbFirstBatting.Items.Add(country1);
            cmbFirstBatting.Items.Add(country2);
            cmbFirstBatting.SelectedIndex = 0;

            cmbTossWonBy.Items.Add(country1);
            cmbTossWonBy.Items.Add(country2);
            cmbTossWonBy.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frmCreateMatch.tossWonby = cmbTossWonBy.SelectedItem.ToString();
            frmCreateMatch.firstBattinh = cmbFirstBatting.SelectedItem.ToString();

            Close();
        }
    }
}
