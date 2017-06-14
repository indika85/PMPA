using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using PMPA.Classes;

namespace PMPA
{
    class clsUser
    {
        /// <summary>
        /// Creates the inittial user when login in to the system
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <param name="userRole"></param>
        public clsUser(string userName, int userId,userRole userRole)
        {
            _username = userName;
            _userID = userId;
            _role = userRole;
            _logintime = DateTime.Now;
            currentUser = this;
        }
        /// <summary>
        /// Create a new user object.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="userRole"></param>
        public static int addUser(string userName, string pwd, userRole userRole)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblUser VALUES(@p1,@p2,@p3,@p4)", connection.CON);
            com.Parameters.AddWithValue("@p1", getNextUserId());
            com.Parameters.AddWithValue("@p2", userName);
            com.Parameters.AddWithValue("@p3", pwd);
            com.Parameters.AddWithValue("@p4", userRole);
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
        /// <summary>
        /// Checks the username and the passwords
        /// </summary>
        /// <param name="usename">Username</param>
        /// <param name="pwd">Password</param>
        /// <returns></returns>
        internal static int checkUsernameAndPassword(string usename, string pwd)
        {
            int userId = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT userId FROM tblUser WHERE username=@p1 AND pwd=@p2", connection.CON);
            com.Parameters.AddWithValue("@p1", usename);
            com.Parameters.AddWithValue("@p2", pwd);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out userId);
            }
            catch (NullReferenceException)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Invalin Username or Password");
            }
            return userId;
        }
        internal static int checkUsername(string usename)
        {
            int userId = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT userId FROM tblUser WHERE username=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", usename);

            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out userId);
                userId = 0;
            }
            catch (NullReferenceException)
            {
                return userId;
            }
            return userId;
        }

        internal static clsUser.userRole getUserRole(int userId)
        {
            int role = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT role FROM tblUser WHERE userId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", userId);
            int.TryParse(com.ExecuteScalar().ToString(), out role);
            return (clsUser.userRole)role;
        }
        /// <summary>
        /// Types of system users
        /// </summary>
        public enum userRole : int
        {
            NORMAL_USER = 1,
            SYSTEM_USER = 2,
            ADMINISTRATIVE_USER = 3
        };
        private int _userID;
        private string _username;
        private DateTime _logintime;
        private userRole _role;
        public static clsUser currentUser;

        //public clsUser currentUser
        //{
        //    get { return _currentUser; }
        //    set { _currentUser = value; }
        //}
        internal static int getNextUserId()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(userID)+1 FROM tblUser", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code);
            com.Dispose();
            return code;
        }
        public int userID
        {
            get { return _userID; }
            set { _userID=value;}
        }

        public string userName
        {
            get { return _username; }
            set { _username = value; }
        }

        public DateTime loginTime
        {
            get { return _logintime; }
            set { _logintime = value; }
        }

        public userRole userrole
        {
            get { return _role; }
            set { _role = value; }
        }

        private int editUser(int userIdToBeEdited, string newUserName, string newPwd)
        {
            int result = 0;


            return result;
        }

    }
}
