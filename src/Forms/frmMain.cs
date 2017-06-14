using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMPA.Classes;
using PMPA.Forms;

namespace PMPA
{
    public partial class frmMain : Form
    {
        public static frmMain mainForm;
        public frmMain()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!connection.createConnection())
            {
                Application.Exit();
            }
            clsFormCreater.openForm(new frmLogin());
            setDisplayScreens();
        }

        private void setDisplayScreens()
        {
            if (clsUser.currentUser.userrole == clsUser.userRole.NORMAL_USER)
            {
                //Display only viewing screens
                matchToolStripMenuItem.Visible = false;
                locationsToolStripMenuItem.Visible = false;
                playerToolStripMenuItem.Visible = false;
                otherToolStripMenuItem.Visible = false;
            }
            else if (clsUser.currentUser.userrole == clsUser.userRole.SYSTEM_USER)
            {
                matchToolStripMenuItem.Visible = true;
                locationsToolStripMenuItem.Visible = false;
                playerToolStripMenuItem.Visible = false;
                otherToolStripMenuItem.Visible = false;
            }
            else if (clsUser.currentUser.userrole == clsUser.userRole.ADMINISTRATIVE_USER)
            {
                matchToolStripMenuItem.Visible = true;
                locationsToolStripMenuItem.Visible = true;
                playerToolStripMenuItem.Visible = true;
                otherToolStripMenuItem.Visible = true;
            }
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmCountry());
        }

        private void groundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmGround());
        }

        private void creatNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmPlayer());
        }

        private void bowllingTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmBallType());
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmCreateMatch());
        }

        private void shotTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmShots());
        }

        private void matchTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmMatchType());
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmUser());
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmAnalyse());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool okTogo = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (Form f in frmMain.mainForm.MdiChildren)
                {
                    if (f.Name == "frmCaptureVideo")
                    {
                        if (clsMessages.showMessage(clsMessages.msgType.question, "The capture windoe is open. This window needs to be closed inorder to load the match. Do you wwant to continue?") == DialogResult.Yes)
                        {
                            f.Close();
                            break;
                        }
                        else
                        {
                            okTogo = false;
                            break;
                        }
                    }
                }
                if (okTogo)
                {
                    string path = openFileDialog1.FileName;
                    //MessageBox.Show(path);
                    new clsLoadSavedMatch(path);
                }
            }
        }

        private void groToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmRptGround());
        }

        private void loadPreviousDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormCreater.openForm(new frmLoadOldMatchs());
        }

        private void countryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRptCountry fr = new frmRptCountry();
            fr.MdiParent = this;
            fr.Show();
        }

        private void playerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRptPlayerScore fr = new frmRptPlayerScore();
            fr.MdiParent = this;
            fr.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to logout? \n All opned windows will be closed.") == DialogResult.Yes)
            {
                foreach (Form f in frmMain.mainForm.MdiChildren)
                {
                    f.Close();
                    
                }
                clsFormCreater.openForm(new frmLogin());
                setDisplayScreens();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to exit the application?") == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void matchToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
