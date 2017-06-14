using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsBallType
    {
        public clsBallType(){}
        public clsBallType(int ballTypeId, string ballTypeName)
        {
            _ballTypeID = ballTypeId;
            _ballTypeName = ballTypeName;
        }
        private int _ballTypeID;
        private string _ballTypeName;

        public int ballTypeId
        {
            get { return _ballTypeID; }
        }
        public string ballTypeName
        {
            get { return _ballTypeName; }
        }

        public static List<clsBallType> getAllBallTypes()
        {
            List<clsBallType> ballTypes = new List<clsBallType>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblBallType",connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblBallType");
            ad.Fill(ds, "tblBallType");

            foreach (DataRow r in ds.Tables["tblBallType"].Rows)
            {
                ballTypes.Add(new clsBallType(Convert.ToInt32(r[0].ToString()), r[1].ToString()));
            }

            return ballTypes;
        }
    }
}
