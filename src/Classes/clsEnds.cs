using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsEnds
    {
        public clsEnds(int endID, string endName,int stadiumId)
        {
            _endId = endID;
            _endName = endName;
            _stadiumId = stadiumId;
            //creatNewEnds();
        }
        private int _endId;
        private string _endName;
        private int _stadiumId;

        public int endId
        {
            get { return _endId; }
        }

        public string endName
        {
            get { return _endName; }
        }

        public int stadiumId
        {
            get { return _stadiumId; }
        }
        private bool creatNewEnds()
        {
            SqlCeCommand com1 = new SqlCeCommand("INSERT INTO tblEnds VALUES (@p1, @p2, @p3)",connection.CON);
            com1.Parameters.AddWithValue("@p1", _endId);
            com1.Parameters.AddWithValue("@p2", _endName);
            com1.Parameters.AddWithValue("@p3", _stadiumId);

            if (com1.ExecuteNonQuery() < 1)
            {
                return false;
            }

            return true;
        }
        internal static int getNextEndID()
        {
            int endId = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(endId)+1 FROM tblEnds",connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out endId);
            return endId;
        }
        /// <summary>
        /// Returns the End ID associated with the end name. If no record is found it returns 0
        /// </summary>
        /// <param name="endName">Name of the end</param>
        /// <returns>End ID</returns>
        public static int getEndId(string endName)
        {
            int endId = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT endId FROM tblEnds WHERE endName=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", endName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out endId);
            }
            catch { }
            return endId;
        }
        /// <summary>
        /// Returns the End ID associated with the end name and the Stadium. If no record is found it returns 0
        /// </summary>
        /// <param name="endName">End Name</param>
        /// <param name="groundId">Stadium Name</param>
        /// <returns>End ID</returns>
        public static int getEndId(string endName,int groundId)
        {
            int endId = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT endId FROM tblEnds WHERE endName=@p1 AND stadiumId=@p2", connection.CON);
            com.Parameters.AddWithValue("@p1", endName);
            com.Parameters.AddWithValue("@p2", groundId);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out endId);
            }
            catch { }
            return endId;
        }
        /// <summary>
        /// Returns the two ends belonging to the ground ID
        /// </summary>
        /// <param name="groundId">The Ground ID</param>
        /// <returns>List of two ends</returns>
        internal static List<clsEnds> getEndsByGroundId(int groundId)
        {
            List<clsEnds> ends = new List<clsEnds>();
            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblEnds WHERE stadiumId=@p1",connection.CON);
            com.Parameters.AddWithValue("@p1", groundId);

            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblEnds");
            ad.Fill(ds, "tblEnds");

            foreach (DataRow r in ds.Tables["tblEnds"].Rows)
            {
                ends.Add(new clsEnds(Convert.ToInt32(r[0].ToString()), r[1].ToString(),Convert.ToInt32(r[2].ToString())));
            }


            return ends;
        }
    }
}
