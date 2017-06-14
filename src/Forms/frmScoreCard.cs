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
    public partial class frmScoreCard : Form
    {
        public frmScoreCard()
        {
            InitializeComponent();
        }

        private void frmScoreCard_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
