using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace PMPA.Classes
{
    class clsWicket
    {

        public int ballId{get; set;}
        public int batsmanId { get; set; }
        public int wicketTypeId { get; set; }
        public int totalRuns{get; set;}
        public byte gotOut { get; set; }

        public clsWicket()
        {

        }
        public clsWicket(int ballID, int batsmanID, int wktTypeID, int totalruns, byte isOut)
        {
            ballId = ballID;
            batsmanId = batsmanID;
            wicketTypeId = wktTypeID;
            totalRuns = totalruns;
            gotOut = isOut;
        }

        internal static int addWicket(clsWicket wicket)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblWickets VALUES(@p1,@p2,@p3,@p4,@p5)", connection.CON_WORKING);
            com.Parameters.AddWithValue("@p1", wicket.ballId);
            com.Parameters.AddWithValue("@p2", wicket.batsmanId);
            com.Parameters.AddWithValue("@p3", wicket.totalRuns);
            com.Parameters.AddWithValue("@p4", wicket.wicketTypeId);
            com.Parameters.AddWithValue("@p5", wicket.gotOut);
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

        //internal static int getWicketTypeID(string wicketType)
        //{
        //    int style = -1;
        //    SqlCeCommand com = new SqlCeCommand("SELECT ID FROM tblBattingShots WHERE Name=@p1", connection.CON);
        //    com.Parameters.AddWithValue("@p1", wicketType);
        //    try
        //    {
        //        int.TryParse(com.ExecuteScalar().ToString(), out style);
        //    }
        //    catch { }
        //    return style;
        //}
    }
}
