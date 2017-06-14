using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using PMPA.Classes;
using System.Data;

namespace PMPA
{
    public class clsPlayer
    {
#region Properties
        private int _playerId;
        private string _fName;
        private string _lName;
        private DateTime _dob;
        private string _country;
        private char _battingHand;
        private string _bowlingStyle;

        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        public string fName
        {
            get { return _fName; }
            set { _fName = value; }
        }
        public string lName
        {
            get { return _lName; }
            set { _lName = value; }
        }
        public DateTime dob
        {
            get { return _dob; }
            set { _dob = value; }
        }
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }
        public char battingHand
        {
            get { return _battingHand; }
            set { _battingHand = value; }
        }
        public string bowlingStyle
        {
            get { return _bowlingStyle; }
            set { _bowlingStyle = value; }
        }
#endregion
        public clsPlayer(int playerId, string fName, string lName, DateTime dob,string country,char battingHand,string bowlingStyle)
        {
            _playerId = playerId;
            _fName = fName;
            _lName = lName;
            _dob = dob;
            _country = country;
            _battingHand = battingHand;
            _bowlingStyle = bowlingStyle;
        }
        public clsPlayer()
        {

        }
        internal static int getHundreds(int playerId, SqlCeConnection con)
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT COUNT(playerId) FROM tblWickets WHERE totalRuns >= 100", con);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
                com.Dispose();
            }
            catch { }
            return code;
        }

        internal static int getFiftys(int playerId, SqlCeConnection con)
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT COUNT(playerId) FROM tblWickets WHERE totalRuns BETWEEN 50 AND 99", con);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
                com.Dispose();
            }
            catch { }
            return code;
        }

        internal static int getNextPlayerId()
        {
            int code = 0;
            SqlCeCommand com = new SqlCeCommand("SELECT MAX(playerId)+1 FROM tblPlayer", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out code);
            com.Dispose();
            return code;
        }
        internal static int getScore(int playerId, int matchId)
        {
            int score = -1;
            string  matchSavePath = clsMatch.getSavePath(matchId);
            SqlCeCommand com = new SqlCeCommand("SELECT SUM(runs) FROM tblBalls WHERE batsmanId=@p1", connection.getConnection(matchSavePath));
            com.Parameters.AddWithValue("@p1", playerId);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out score);
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Could not get the score for the selected player \n" +ex.Message);
            }
            return score;
        }

        internal static int getBallsFaced(int playerId, int matchId)
        {
            int ballsFaced = -1;
            string matchSavePath = clsMatch.getSavePath(matchId);
            SqlCeCommand com = new SqlCeCommand("SELECT COUNT(ballId) FROM tblBalls WHERE batsmanId=@p1", connection.getConnection(matchSavePath));
            com.Parameters.AddWithValue("@p1", playerId);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out ballsFaced);
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Could not get number of balls faced for the selected player \n" + ex.Message);
            }
            return ballsFaced;
        }
        internal static List<clsPlayer> getPlayersOfCountry(int countryCode)
        {
            List<clsPlayer> playerList=new List<clsPlayer>();
            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblPlayer WHERE countryId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", countryCode);

            DataSet ds = new DataSet("tblPlayer");
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);

            ad.Fill(ds, "tblPlayer");

            foreach (DataRow r in ds.Tables["tblPlayer"].Rows)
            {
                playerList.Add(new clsPlayer(Convert.ToInt32(r[0].ToString()),r[1].ToString(),r[2].ToString(),Convert.ToDateTime(r[3].ToString()),clsCountry.getCountryName(Convert.ToInt32(r[4].ToString())),Convert.ToChar(r[5].ToString()),clsBowlingStyle.getBowlingStyle(Convert.ToInt32(r[6].ToString()))));
            }

            return playerList;
        }

        internal static int getPlayerId(string fName, string lName, int countryId)
        {
            int code = -1;
            SqlCeCommand com = new SqlCeCommand("SELECT playerId FROM tblPlayer WHERE playerFName LIKE @p1 AND playerLName=@p2 AND countryId=@p3", connection.CON);
            com.Parameters.AddWithValue("@p1", fName.Trim().Substring(0,1)+"%");
            com.Parameters.AddWithValue("@p2", lName.Trim());
            com.Parameters.AddWithValue("@p3", countryId);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out code);
                com.Dispose();
            }
            catch (Exception e)
            {
                clsMessages.showMessage(clsMessages.msgType.error, e.Message);
            }
            return code;
        }
        internal static int addPlayer(clsPlayer player)
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblPlayer VALUES(@p1,@p2,@p3, @p4, @p5, @p6, @p7)", connection.CON);
            com.Parameters.AddWithValue("@p1", player.playerId);
            com.Parameters.AddWithValue("@p2", player.fName);
            com.Parameters.AddWithValue("@p3", player.lName);
            com.Parameters.AddWithValue("@p4", player.dob);
            com.Parameters.AddWithValue("@p5", clsCountry.getCountryCode(player.country));
            com.Parameters.AddWithValue("@p6", player.battingHand);
            com.Parameters.AddWithValue("@p7", clsBowlingStyle.getBowlingStyleCode(player.bowlingStyle));
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

        internal static int updatePlayer(clsPlayer player)
        {
            SqlCeCommand com1 = new SqlCeCommand("UPDATE tblPlayer SET playerFName=@p2, playerLName=@p3, DOB=@p4, countryId=@p5, battingHand=@p6, bowlingStyleId=@p7 WHERE playerID=@p1", connection.CON);
            com1.Parameters.AddWithValue("@p1", player.playerId);
            com1.Parameters.AddWithValue("@p2", player.fName);
            com1.Parameters.AddWithValue("@p3", player.lName);
            com1.Parameters.AddWithValue("@p4", player.dob);
            com1.Parameters.AddWithValue("@p5", clsCountry.getCountryCode(player.country));
            com1.Parameters.AddWithValue("@p6", player.battingHand);
            com1.Parameters.AddWithValue("@p7", clsBowlingStyle.getBowlingStyleCode(player.bowlingStyle));
            try
            {
                return com1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                clsMessages.showMessage(clsMessages.msgType.error, e.Message);
            }
            return 0;
        }

        internal static clsPlayer getPlayer(int playerId)
        {
            clsPlayer player=new clsPlayer();
            SqlCeCommand com=new SqlCeCommand("SELECT * FROM tblPlayer WHERE playerID=@P1",connection.CON);
            com.Parameters.AddWithValue("@p1", playerId);
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblPlayer");
            try
            {
                ad.Fill(ds, "tblPlayer");

                DataRow r = ds.Tables["tblPlayer"].Rows[0];

                player = new clsPlayer(Convert.ToInt32(r[0].ToString()), r[1].ToString(), r[2].ToString(), Convert.ToDateTime(r[3].ToString()), clsCountry.getCountryName(Convert.ToInt32(r[4].ToString())), Convert.ToChar(r[5].ToString()), clsBowlingStyle.getBowlingStyle(Convert.ToInt32(r[6].ToString())));
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
            }
            return player;
        }
        internal static List<clsRecordBall> getNumberOfNRunss(int playerId,int numberOfRunsToGet, SqlCeConnection con)
        {
            List<clsRecordBall> Balls = new List<clsRecordBall>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblBalls WHERE batsmanId=@p1 AND Runs=@p2", con);
            com.Parameters.AddWithValue("@p1",playerId);
            com.Parameters.AddWithValue("@p2", numberOfRunsToGet);

            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            DataSet ds = new DataSet("tblBalls");
            ad.Fill(ds, "tblBalls");
            foreach (DataRow r in ds.Tables["tblBalls"].Rows)
            {
                clsRecordBall ball = new clsRecordBall();
                ball.ballID = Convert.ToInt32(r["ballId"].ToString());
                ball.ballNumber = 0;
                ball.ballTypeId = Convert.ToInt32(r["ballTypeId"].ToString());
                ball.batsmanId = Convert.ToInt32(r["batsmanId"].ToString());
                //ball.bowlerId = Convert.ToInt32(r["batsmanId"].ToString());//
                //ball.endId = Convert.ToInt32(r["batsmanId"].ToString());//
                ball.extras = Convert.ToInt32(r["extras"].ToString());
                ball.runs = Convert.ToInt32(r["runs"].ToString());
                ball.runTypeId = Convert.ToInt32(r["runTypeId"].ToString()); 
                ball.shot=clsShot.getShot(Convert.ToInt32(r["shotId"].ToString()));

                Balls.Add(ball);
                
            }
            
            return Balls;
        }
    }
}
