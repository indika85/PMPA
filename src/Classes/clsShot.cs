using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsShot
    {
        public clsShot() { }
        public clsShot(int shotId, string shotName)
        {
            _shotID = shotId;
            _shotName = shotName;
        }
        private int _shotID;
        private string _shotName;

        public int shotId
        {
            get { return _shotID; }
        }
        public string shotName
        {
            get { return _shotName; }
        }

        public static List<clsShot> getShotTypes()
        {
            List<clsShot> ShotTypes = new List<clsShot>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblBattingShots", connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblBattingShots");
            ad.Fill(ds, "tblBattingShots");

            foreach (DataRow r in ds.Tables["tblBattingShots"].Rows)
            {
                ShotTypes.Add(new clsShot(Convert.ToInt32(r[0].ToString()), r[1].ToString()));
            }

            return ShotTypes;
        }
        internal static clsShot getShot(int shotId)
        {
            clsShot shot = new clsShot();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblBattingShots WHERE ID=@p1", connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            com.Parameters.AddWithValue("@p1", shotId);
            DataSet ds = new DataSet("tblBattingShots");
            ad.Fill(ds, "tblBattingShots");

            DataRow r = ds.Tables["tblBattingShots"].Rows[0];
            shot._shotID=Convert.ToInt32(r[0].ToString());
            shot._shotName = r[1].ToString();

            return shot;
        }
        internal static int getNextShotCode()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(ID)+1 FROM tblBattingShots", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code);
            com.Dispose();
            return code;
        }

        internal static string getShotName(int shotId)
        {
            string style = "";
            SqlCeCommand com = new SqlCeCommand("SELECT Name FROM tblBattingShots WHERE ID=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", shotId);
            style = com.ExecuteScalar().ToString();
            return style;
        }

        internal static int getShotID(string shotName)
        {
            int style = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT ID FROM tblBattingShots WHERE Name=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", shotName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out style);
            }
            catch { }
            return style;
        }

        internal static int addShot(clsShot shot)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblBattingShots VALUES(@p1,@p2)", connection.CON);
            com.Parameters.AddWithValue("@p1", shot.shotId);
            com.Parameters.AddWithValue("@p2", shot.shotName);
            try
            {
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                clsMessages.showMessage(clsMessages.msgType.error, e.Message);
            }
            return 0;
        }

        internal static int udpdateShot(clsShot shot)
        {
            int result = 0;

            SqlCeCommand com = new SqlCeCommand("UPDATE tblBattingShots set Name=@p2 WHERE ID=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", shot.shotId);
            com.Parameters.AddWithValue("@p2", shot.shotName);
            result = com.ExecuteNonQuery();
            return result;
        }


        internal static int getShotCode(string shotName)
        {
            int style = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT ID FROM tblBattingShots WHERE Name=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", shotName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out style);
            }
            catch { }
            return style;
        }
    }
}
