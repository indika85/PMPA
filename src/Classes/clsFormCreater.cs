using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMPA.Classes
{
    class clsFormCreater
    {
        public static void openForm(Form fm)
        {
            foreach (Form f in frmMain.mainForm.MdiChildren)
            {
                if (f.Name == fm.Name)
                {
                    f.Focus();
                    f.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            if (fm.Name == "frmLogin")
                fm.ShowDialog();
            else
            {
                fm.MdiParent = frmMain.mainForm;
                fm.MaximizeBox = false;
                fm.FormBorderStyle = FormBorderStyle.FixedSingle;
                fm.StartPosition = FormStartPosition.CenterParent;
                fm.Show();
            }
        }
    }
}
