using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsBowlingStyle
    {
        public clsBowlingStyle(int styleCode, string styleName)
        {
            _styleCode = styleCode;
            _styleName = styleName;
        }
        private int _styleCode;
        private string _styleName;

        public int styleCode
        {
            get { return _styleCode; }
        }
        public string styleName
        {
            get { return _styleName; }
        }
        /// <summary>
        /// Returns all the bowling styles
        /// </summary>
        /// <returns></returns>
        public static List<clsBowlingStyle> getAllStyles()
        {
            List<clsBowlingStyle> styleList = new List<clsBowlingStyle>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblBowlingStyle",connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblBowlingStyle");
            ad.Fill(ds,"tblBowlingStyle");

            foreach (DataRow r in ds.Tables["tblBowlingStyle"].Rows)
            {
                styleList.Add(new clsBowlingStyle(Convert.ToInt32(r[0]), r[1].ToString()));
            }

            return styleList;
        }
        /// <summary>
        /// Returns the next Bowling style code
        /// </summary>
        /// <returns>Next available Bowling style code</returns>
        internal static int getNextBowlingStyleCode()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(styleId)+1 FROM tblBowlingStyle", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code);
            com.Dispose();
            return code;
        }

        internal static string getBowlingStyle(int styleId)
        {
            string style="";
            SqlCeCommand com = new SqlCeCommand("SELECT stylename FROM tblBowlingStyle WHERE styleId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", styleId);
            style = com.ExecuteScalar().ToString();
            return style;
        }
        internal static int getBowlingStyleCode(string styleName)
        {
            int style = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT styleId FROM tblBowlingStyle WHERE styleName=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", styleName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out style);
            }
            catch { }
            return style;
        }

        internal static int addBowlingStyle(clsBowlingStyle BowlingStyle)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblBowlingStyle VALUES(@p1,@p2)", connection.CON);
            com.Parameters.AddWithValue("@p1", BowlingStyle.styleCode);
            com.Parameters.AddWithValue("@p2", BowlingStyle.styleName);
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

        internal static int udpdateowlingStyle(clsBowlingStyle BowlingStyle)
        {
            int result = 0;

            SqlCeCommand com = new SqlCeCommand("UPDATE tblBowlingStyle set styleName=@p2 WHERE styleId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", BowlingStyle.styleCode);
            com.Parameters.AddWithValue("@p2", BowlingStyle.styleName);
            result = com.ExecuteNonQuery();
            return result;
        }
    }
}
