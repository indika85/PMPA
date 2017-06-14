using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMPA.Classes;
using PMPA.Forms;
using System.Data.SqlServerCe;

namespace PMPA.Classes
{
    class clsLoadSavedMatch
    {
        public clsLoadSavedMatch(string path)
        {
            SqlCeConnection currentCon = connection.getConnection(path);
            SqlCeCommand com = new SqlCeCommand("SELECT matchId FROM tblTeam",currentCon);
            int matchId = 0;
            int.TryParse(com.ExecuteScalar().ToString(), out matchId);
            
            clsMatch match = new clsMatch();

            clsFormCreater.openForm(new frmCaptureVideo());
        }
    }
}
