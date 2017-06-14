using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace PMPA.Classes
{
    class clsCountry
    {
        public clsCountry(){}
        public clsCountry(int countryId, string countryName)
        {
            _countryID = countryId;
            _countryName = countryName;
        }
        private int _countryID;
        private string _countryName;

        public int countryId
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
        public string countryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }

        public static List<clsCountry> getAllCountries()
        {
            List<clsCountry> countryList = new List<clsCountry>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblCountry",connection.CON);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblCountry");
            ad.Fill(ds,"tblCountry");

            foreach (DataRow r in ds.Tables["tblCountry"].Rows)
            {
                countryList.Add(new clsCountry(Convert.ToInt32(r[0]), r[1].ToString()));
            }

            return countryList;
        }

        internal static int getNextCountryCode()
        {
            int code=0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(countryId)+1 FROM tblCountry", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code); 
            com.Dispose();
            return code;
        }

        internal static clsCountry getCountry(string countryName)
        {
            clsCountry country;
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT countryId FROM tblCountry WHERE CountryName=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", countryName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
            }
            catch (NullReferenceException)
            {

            }
            //com.Dispose();
            country = new clsCountry(code, countryName);
            return country;

        }

        internal static int getCountryCode(string countryName)
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT countryId FROM tblCountry WHERE CountryName=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", countryName);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
            }
            catch(NullReferenceException)
            {
                
            }
            //com.Dispose();
            return code;
            
        }
        /// <summary>
        /// Insert a country in to the database anr returns the affected row count (which should be one if successfully inserted.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        internal static int addCountry(clsCountry country)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblCountry VALUES(@p1,@p2)", connection.CON);
            com.Parameters.AddWithValue("@p1", country.countryId);
            com.Parameters.AddWithValue("@p2", country.countryName);
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

        internal static int updateCountry(int countryId, string countryName)
        {
            int result = 0;

            SqlCeCommand com = new SqlCeCommand("UPDATE tblCountry set countryName=@p1 WHERE countryId=@p2", connection.CON);
            com.Parameters.AddWithValue("@p1", countryName);
            com.Parameters.AddWithValue("@p2", countryId);
            result = com.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// Returns the corresponding country name
        /// </summary>
        /// <param name="countryCode">country code where you want to the name</param>
        /// <returns>country name</returns>
        internal static string getCountryName(int countryCode)
        {
            string countryName = "";

            SqlCeCommand com = new SqlCeCommand("SELECT CountryName FROM tblCountry WHERE countryId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", countryCode);

            countryName = com.ExecuteScalar().ToString();
            com.Dispose();

            return countryName;
        }
    }
}
