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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            cmbUserRole.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (dataValidated())
            {
                clsUser.userRole r = (clsUser.userRole)cmbUserRole.SelectedIndex + 1;
                
                clsUser.addUser(txtUserName.Text, txtPWD.Text, r);
                clsMessages.showMessage(clsMessages.msgType.information, "User added successfully");
                txtPWD.Clear();
                txtPWD2.Clear();
                txtUserName.Clear();
                txtUserName.Focus();
            }
        }

        private bool dataValidated()
        {
            bool ok = true;
            if (txtUserName.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Username cannot be blank");
                txtUserName.Focus();
                ok = false;
            }
            else if (txtPWD.Text == "" || txtPWD2.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Passwprd fields cannot be blank");
                txtPWD.Focus();
                ok = false;
            }
            else if (txtPWD.Text != txtPWD2.Text)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Two passowrds do not match");
                txtPWD2.Focus();
                ok = false;
            }
            else if (clsUser.checkUsername(txtUserName.Text) == 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "The entered username already exsists");
                ok = false;
                txtUserName.SelectAll();
                txtUserName.Focus();
            }
            return ok;
        }
    }
}
