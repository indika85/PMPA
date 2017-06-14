using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMPA.Classes;

namespace PMPA
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure that you want to exit the application ?") == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtValidated())
            {
                int userId=clsUser.checkUsernameAndPassword(txtUserName.Text, txtPassword.Text);
                if (userId>-1)
                {
                    new clsUser(txtUserName.Text,userId,clsUser.getUserRole(userId));
                    frmMain.mainForm.Text = "Welcome " + clsUser.currentUser.userName + " - " + frmMain.mainForm.Text;
                    //MessageBox.Show(clsUser.currentUser.userID.ToString());
                    Close();
                }
                else
                {
                    txtUserName.Focus();
                    txtUserName.Select();
                }
            }
        }

        private bool txtValidated()
        {
            if (txtUserName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please enter your username to continue");
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please enter your password to continue");
                txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
