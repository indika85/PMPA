using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace PMPA.Classes
{
    class clsRecordOver
    {
        public int ballNumber { get; set; }
        public int overId { get; set; }
        public int bowlerId { get; set; }
        public int endId { get; set; }

        public clsRecordOver()
        {
            ballNumber = 1;
        }

        internal static int getNextOver()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(overId)+1 FROM tblOver", connection.CON_WORKING);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
            }
            catch (Exception e)
            {
                clsMessages.showMessage(clsMessages.msgType.error, e.Message+"\n Returning value 0");
            }
            com.Dispose();
            return code;
        }

        internal static int addOver(clsRecordOver over)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblOver VALUES(@p1,@p2,@p3)", connection.CON_WORKING);
            com.Parameters.AddWithValue("@p1", over.overId);
            com.Parameters.AddWithValue("@p2", over.bowlerId);
            com.Parameters.AddWithValue("@p3", over.endId);
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
    }
}
