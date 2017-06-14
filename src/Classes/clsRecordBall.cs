using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Drawing;

namespace PMPA.Classes
{
    class clsRecordBall:clsRecordOver
    {

        public Point pitchLocation { get; set; }
        public Point stumpLocation { get; set; }
        public Point feildingLocation { get; set; }

        public int batsmanId{ get; set;}
        public int ballID { get; set; }

        public int runs { get; set; }
        public int extras { get; set; }
        public int runTypeId { get; set; }
        public clsShot shot { get; set; }
        public int ballTypeId { get; set; }

        public string videoName { get; set; }
        public clsRecordOver over { get; set; }


        public clsRecordBall()
        {
            feildingLocation = new Point(0, 0);
            pitchLocation = new Point(0, 0);
            stumpLocation = new Point(0, 0);
        }



        internal static int addBall(clsRecordBall ball)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblBalls VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", connection.CON_WORKING);
            com.Parameters.AddWithValue("@p1", ball.ballID);
            com.Parameters.AddWithValue("@p2", ball.overId);
            com.Parameters.AddWithValue("@p3", ball.runs);
            com.Parameters.AddWithValue("@p4", ball.extras);
            com.Parameters.AddWithValue("@p5", ball.batsmanId);
            com.Parameters.AddWithValue("@p6", ball.runTypeId);
            com.Parameters.AddWithValue("@p7", ball.shot.shotId);
            com.Parameters.AddWithValue("@p8", ball.ballTypeId);

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
