using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;

namespace PMPA.Classes
{
    class connection
    {
        public static SqlCeConnection CON;
        public static SqlCeConnection CON_WORKING;
        //public static int USERID = -1;
        //public static int USERROLE = 0;
        //public static clsUser CURRENT_USER;

        
        /// <summary>
        /// Creates the connection to the Database
        /// </summary>
        /// <returns></returns>
        public static bool createConnection()
        {
            try
            {
                CON = new SqlCeConnection(Properties.Settings.Default.PMPADBConnectionString);
                CON.Open();
                return true;
            }
            catch (Exception e)
            {
                clsMessages.showMessage(clsMessages.msgType.error, e.Message);
                return false;
            }
        }
        public static SqlCeConnection getConnection(string path)
        {
            string conString = "Data Source = " + path + "; Password =year1985";
            SqlCeConnection con_temp = new SqlCeConnection(conString);

            try
            {
                con_temp.Open();
            }
            catch { return null; }

            return con_temp;
        }
        
        public static bool creatDatabase(string path)
        {
            if (File.Exists(path))
            {
                if (clsMessages.showMessage(clsMessages.msgType.question, "The File name already exsists. Do you want to replace it with the new file ?") == DialogResult.No)
                {
                    return false;
                }
            }

            //File.Delete(path);
            string conString = "Data Source = " + path + "; Password =year1985";

            //MessageBox.Show(conString);

            SqlCeEngine en = new SqlCeEngine(conString);
            try
            {
                en.CreateDatabase();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
            }

            CON_WORKING = new SqlCeConnection(conString);
            CON_WORKING.Open();

            return true;
        }
        public static SqlCeConnection creatDatabase(string path, bool importingData)
        {
            if (File.Exists(path))
            {
                if (clsMessages.showMessage(clsMessages.msgType.question, "The File name already exsists. Do you want to replace it with the new file ?") == DialogResult.No)
                {
                    return null;
                }
            }

            //File.Delete(path);
            string conString = "Data Source = " + path + "; Password =1234";

            //MessageBox.Show(conString);

            SqlCeEngine en = new SqlCeEngine(conString);
            try
            {
                en.CreateDatabase();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
            }

            //SqlCeConnection conTemp=new SqlCeConnection(conString);
            //conTemp.Open();

            CON_WORKING = new SqlCeConnection(conString);
            CON_WORKING.Open();

            return CON_WORKING;

        }
    }
}
