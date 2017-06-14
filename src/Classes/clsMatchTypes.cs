using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsMatchTypes
    {
        public clsMatchTypes() { }

        public clsMatchTypes(int matchTypeId, string matchTypeName)
        {
            _matchTypeID = matchTypeId;
            _matchTypeName = matchTypeName;
        }
        private int _matchTypeID;
        private string _matchTypeName;

        public int matchTypeId
        {
            get { return _matchTypeID; }
        }
        public string matchTypeName
        {
            get { return _matchTypeName; }
        }

        public static clsMatchTypes getMatchType(int matchTypeId)
        {
            if (matchTypeId < 0)
                return null;
            
            clsMatchTypes mt = new clsMatchTypes();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblmatchType WHERE matchTypeId=@p1", connection.CON);
            com.Parameters.AddWithValue("p1", matchTypeId);

            DataSet ds = new DataSet("matchTypeId");
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            ad.Fill(ds, "matchTypeId");

            DataRow r = ds.Tables["matchTypeId"].Rows[0];

            return new clsMatchTypes(Convert.ToInt32(r[0].ToString()), r[1].ToString());
        }

        public static List<clsMatchTypes> getMatchTypes()
        {
            List<clsMatchTypes> matchTypes = new List<clsMatchTypes>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblmatchType", connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblmatchType");
            ad.Fill(ds, "tblmatchType");

            foreach (DataRow r in ds.Tables["tblmatchType"].Rows)
            {
                matchTypes.Add(new clsMatchTypes(Convert.ToInt32(r[0].ToString()), r[1].ToString()));
            }

            return matchTypes;
        }
        internal static int getNextMatchTypeCode()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(matchTypeId)+1 FROM tblmatchType", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code);
            com.Dispose();
            return code;
        }

        internal static string getMatchTypeName(int matchTypeId)
        {
            string style = "";
            SqlCeCommand com = new SqlCeCommand("SELECT Name FROM tblmatchType WHERE matchTypeId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", matchTypeId);
            style = com.ExecuteScalar().ToString();
            return style;
        }

        internal static int getMatchTypeID(string matchTypeName)
        {
            int typeId = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT matchTypeId FROM tblmatchType WHERE [Name]=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", matchTypeName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out typeId);
            }
            catch { }
            return typeId;
        }

        internal static int addMatchType(clsMatchTypes matchType)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblmatchType VALUES(@p1,@p2)", connection.CON);
            com.Parameters.AddWithValue("@p1", matchType.matchTypeId);
            com.Parameters.AddWithValue("@p2", matchType.matchTypeName);
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

        internal static int udpdateMatchType(clsMatchTypes matchtype)
        {
            int result = 0;

            SqlCeCommand com = new SqlCeCommand("UPDATE tblmatchType set Name=@p2 WHERE ID=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", matchtype.matchTypeId);
            com.Parameters.AddWithValue("@p2", matchtype.matchTypeName);
            result = com.ExecuteNonQuery();
            return result;
        }
    }
}
