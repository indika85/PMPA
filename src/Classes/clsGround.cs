using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsGround
    {
        public clsGround() { }
        public clsGround(int stadiumId,string stadiumName,int capacity,int countryId,clsEnds end1, clsEnds end2)
        {
            _stadiumId = stadiumId;
            _stadiumName = stadiumName;
            _capacity = capacity;
            _countryId = countryId;
            _end1 = end1;
            _end2 = end2;
        }

        private int _stadiumId;
        private int _countryId;
        private string _stadiumName;
        private int _capacity;
        private clsEnds _end1;
        private clsEnds _end2;

        private static clsGround _currentStadium=null;

        public int stadiumId
        {
            get { return _stadiumId; }
        }
        public int countryId
        {
            get { return _countryId; }
        }
        public string stadiumName
        {
            get { return _stadiumName; }
        }
        public int capacity
        {
            get { return _capacity; }
        }
        public clsGround curretntStadium
        {
            get { return _currentStadium; }
        }
        public clsEnds end1
        {
            get { return _end1; }
        }
        public clsEnds end2
        {
            get { return _end2; }
        }

        internal static int getNextGroundCode()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(stadiumId)+1 FROM tblStadium", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code);
            com.Dispose();
            return code;
        }

        internal static List<clsGround> getAllGrounds()
        {
            List<clsGround> groundList = new List<clsGround>();

            List<clsEnds> ends;
            int groundId = 0;

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblStadium", connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblStadium");
            ad.Fill(ds, "tblStadium");

            foreach (DataRow r in ds.Tables["tblStadium"].Rows)
            {
                groundId = Convert.ToInt32(r[0]);
                ends = clsEnds.getEndsByGroundId(groundId);
                groundList.Add(new clsGround(groundId, r[1].ToString(),Convert.ToInt32(r[2]),Convert.ToInt32(r[3]),ends[0],ends[1])) ;
            }

            return groundList;
        }
        /// <summary>
        /// Returns all grounds belonging to a particular counrty.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        internal static List<clsGround> getAllGrounds(int countryId)
        {
            List<clsGround> groundList = new List<clsGround>();

            List<clsEnds> ends;
            int groundId = 0;

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblStadium WHERE countryId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", countryId);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblStadium");
            ad.Fill(ds, "tblStadium");

            foreach (DataRow r in ds.Tables["tblStadium"].Rows)
            {
                groundId = Convert.ToInt32(r[0]);
                ends = clsEnds.getEndsByGroundId(groundId);
                groundList.Add(new clsGround(groundId, r[1].ToString(), Convert.ToInt32(r[2]), Convert.ToInt32(r[3]), ends[0], ends[1]));
            }

            return groundList;
        }

        internal static clsGround getGround(int countryCode)
        {
            clsGround ground;

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblStadium WHERE stadiumId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", countryCode);

            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblStadium");
            ad.Fill(ds, "tblStadium");
            DataRow r = ds.Tables["tblStadium"].Rows[0];

            List<clsEnds> ends;
            ends = clsEnds.getEndsByGroundId(Convert.ToInt32(r[0].ToString()));

            ground = new clsGround(Convert.ToInt32(r[0].ToString()), r[1].ToString(), Convert.ToInt32(r[2]), Convert.ToInt32(r[3]), ends[0], ends[1]);
            return ground;
        }


        internal static clsGround getGround(string groundName)
        {
            clsGround ground;

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblStadium WHERE stadiumName=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", groundName);

            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblStadium");
            ad.Fill(ds, "tblStadium");
            DataRow r = ds.Tables["tblStadium"].Rows[0];

            List<clsEnds> ends;
            ends = clsEnds.getEndsByGroundId(Convert.ToInt32(r[0].ToString()));

            ground = new clsGround(Convert.ToInt32(r[0].ToString()), r[1].ToString(), Convert.ToInt32(r[2]), Convert.ToInt32(r[3]), ends[0], ends[1]);
            return ground;
        }
        /// <summary>
        /// returns the corresponding ground code for the given name. If no record is found, returns 0
        /// </summary>
        /// <param name="groundName">Ground name</param>
        /// <returns>ground Id</returns>
        internal static int getGroundCode(string groundName)
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT stadiumId FROM tblStadium WHERE stadiumName=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", groundName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
            }
            catch (NullReferenceException)
            {

            }
            com.Dispose();
            return code;
        }

        internal static int addGround(clsGround ground)
        {
            int results = 0;
            SqlCeTransaction trans;
            trans=connection.CON.BeginTransaction();
            SqlCeCommand com = new SqlCeCommand();
            com.Connection = connection.CON;
            
            try
            {
                com.CommandText = "INSERT INTO tblStadium VALUES(@p1,@p2,@p3,@p4)";
                com.Parameters.AddWithValue("@p1", ground.stadiumId);
                com.Parameters.AddWithValue("@p2", ground.stadiumName);
                com.Parameters.AddWithValue("@p3", ground.capacity);
                com.Parameters.AddWithValue("@p4", ground.countryId);
                results += com.ExecuteNonQuery();

                com.CommandText = "INSERT INTO tblEnds VALUES(@e11,@e12,@e13)";
                com.Parameters.AddWithValue("e11", ground.end1.endId);
                com.Parameters.AddWithValue("@e12", ground.end1.endName);
                com.Parameters.AddWithValue("@e13", ground.stadiumId);
                results += com.ExecuteNonQuery();

                com.CommandText = "INSERT INTO tblEnds VALUES(@e21,@e22,@e23)";
                com.Parameters.AddWithValue("e21", ground.end2.endId);
                com.Parameters.AddWithValue("@e22", ground.end2.endName);
                com.Parameters.AddWithValue("@e23", ground.stadiumId);
                results += com.ExecuteNonQuery();

                trans.Commit();

            }
            catch (Exception e)
            {
                clsMessages.showMessage(clsMessages.msgType.error, e.Message);
                try
                {
                    trans.Rollback();
                }
                catch (Exception etr)
                {
                    clsMessages.showMessage(clsMessages.msgType.error, etr.Message);
                }
            }
            return results;
        }
        /// <summary>
        /// Updates ground information. Returns 3 if all tables were updated sucessfully.
        /// </summary>
        /// <param name="ground">Ground</param>
        /// <returns>Returns the number of records updated. Should be 3</returns>
        internal static int updateGroundInfo(clsGround ground)
        {
            int result = 0;

            SqlCeTransaction trans = connection.CON.BeginTransaction();
            SqlCeCommand com = new SqlCeCommand();
            com.Connection = connection.CON;
            com.Transaction = trans;

            try
            {
                com.CommandText = "UPDATE tblStadium SET stadiumName=@p1,capacity=@p2,countryId=@p3 WHERE stadiumId=@p4";
                com.Parameters.AddWithValue("@p1", ground.stadiumName);
                com.Parameters.AddWithValue("@p2", ground.capacity);
                com.Parameters.AddWithValue("@p3", ground.countryId);
                com.Parameters.AddWithValue("@p4", ground.stadiumId);
                result += com.ExecuteNonQuery();

                com.CommandText = "UPDATE tblEnds SET endName=@pe1 WHERE endId=@pe2";
                com.Parameters.AddWithValue("@pe1", ground.end1.endName);
                com.Parameters.AddWithValue("@pe2", ground.end1.endId);
                result += com.ExecuteNonQuery();

                com.CommandText = "UPDATE tblEnds SET endName=@pe11 WHERE endId=@pe12";
                com.Parameters.AddWithValue("@pe11", ground.end2.endName);
                com.Parameters.AddWithValue("@pe12", ground.end2.endId);
                result += com.ExecuteNonQuery();

                trans.Commit();
                return result;
            }
            catch (Exception e)
            {
                try
                {
                    clsMessages.showMessage(clsMessages.msgType.error, e.Message);
                    trans.Rollback();
                }
                catch (Exception ext)
                {
                    clsMessages.showMessage(clsMessages.msgType.error, ext.Message);
                }
            }

            return result;
        }
        internal List<clsEnds> getTwoEnds()
        {
            List<clsEnds> ends = new List<clsEnds>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblEnds WHERE stadiumId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", curretntStadium._stadiumId);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblEnds");
            ad.Fill(ds, "tblEnds");

            foreach (DataRow r in ds.Tables["tblEnds"].Rows)
            {
                ends.Add(new clsEnds(Convert.ToInt32(r[0]), r[1].ToString(), _currentStadium._stadiumId));
            }

            return ends;
        }
    }
}
