using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Data;

namespace PMPA.Classes
{
    class clsMaps
    {
        public int ballId { get; set; }
        public Point batsmanPos { get; set; }
        public Point pitchPos { get; set; }
        public Point feildingPos { get; set; }
        public string fileName { get; set; }

        public clsMaps(int ballid, Point batsmanpos, Point pitchpos,Point feildingpos,string filename)
        {
            ballId = ballid;
            batsmanPos = batsmanpos;
            pitchPos = pitchpos;
            feildingPos = feildingpos;
            fileName = filename;
        }
        public clsMaps() { }

        public static List<clsMaps> getMap(string DBPath, int playerID)
        {
            SqlCeConnection con = connection.getConnection(DBPath);
            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblMaps WHERE tblMaps.ballId IN (SELECT tblBalls.ballId FROM tblBalls WHERE tblBalls.batsmanId=@p1)", con);
            com.Parameters.AddWithValue("@p1", playerID);

            List<clsMaps> map = new List<clsMaps>();

            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblMaps");
            ad.Fill(ds, "tblMaps");

            foreach (DataRow r in ds.Tables["tblMaps"].Rows)
            {
                int ballId = Convert.ToInt32(r[0].ToString());
                Point batsmanPos = new Point(Convert.ToInt32(r[1].ToString()), Convert.ToInt32(r[2].ToString()));
                Point pitchPos = new Point(Convert.ToInt32(r[3].ToString()), Convert.ToInt32(r[4].ToString()));
                Point fieldPos = new Point(Convert.ToInt32(r[5].ToString()), Convert.ToInt32(r[6].ToString()));
                string videoPath = r[7].ToString();

                map.Add(new clsMaps(ballId, batsmanPos, pitchPos, fieldPos, videoPath));
            }

            return map;
        }

        /// <summary>
        /// Adds the map to the table
        /// </summary>
        /// <param name="map"></param>
        public static void AddMaps(clsMaps map)
        {

            string quaery = "INSERT INTO [tblMaps] VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";


            SqlCeCommand com = new SqlCeCommand();
            com.Connection = connection.CON_WORKING;

            com.CommandText = quaery;

            com.Parameters.AddWithValue("@p1", map.ballId);
            com.Parameters.AddWithValue("@p2", map.batsmanPos.X);
            com.Parameters.AddWithValue("@p3", map.batsmanPos.Y);
            com.Parameters.AddWithValue("@p4", map.pitchPos.X);
            com.Parameters.AddWithValue("@p5", map.pitchPos.Y);
            com.Parameters.AddWithValue("@p6", map.feildingPos.X);
            com.Parameters.AddWithValue("@p7", map.feildingPos.Y);
            com.Parameters.AddWithValue("@p8", map.fileName);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
            }
            com.Dispose();
        }

        internal static clsMaps getCountryName(int ballId)
        {

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblMaps WHERE ballId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", ballId);

            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblMaps");
            ad.Fill(ds, "tblMaps");

            Point bt = new Point(Convert.ToInt32(ds.Tables["tblMaps"].Rows[0][1]), Convert.ToInt32(ds.Tables["tblMaps"].Rows[0][2]));
            Point pt = new Point(Convert.ToInt32(ds.Tables["tblMaps"].Rows[0][3]), Convert.ToInt32(ds.Tables["tblMaps"].Rows[0][4]));
            Point fl = new Point(Convert.ToInt32(ds.Tables["tblMaps"].Rows[0][5]), Convert.ToInt32(ds.Tables["tblMaps"].Rows[0][6]));
            string fnmame = ds.Tables["tblMaps"].Rows[0][7].ToString();

            return new clsMaps(ballId, bt, pt, fl, fnmame);

        }
    }
}
