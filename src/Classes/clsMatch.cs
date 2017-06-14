using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMPA.Classes;
using System.Data.SqlServerCe;
using System.Data;

namespace PMPA.Classes
{
    class clsMatch
    {
        //public clsMatch() { }

        public static clsMatch currentMatch;

        public clsMatch(int matchid, string mName,clsMatchTypes type, DateTime mDate, string mPath, clsCountry country, clsGround ground, List<clsTeams> squad, string tossWon, string firstBat)
        {
            matchID = matchid;
            matchName = mName;
            matchType = type;
            matchDate=mDate;

            savePath = mPath;
            countryPlayed = country;
            groundPlayed = ground;
            currentSquards = squad;

            tossWonBy = tossWon;
            firstBatting = firstBat;

            team1 = squad[0];
            team2 = squad[1];

            //currentMatch = this;
            currentMatch = this;
             
        }
        public clsMatch(clsMatch mt)
        {
            currentMatch = mt;
        }
        public clsMatch()
        {

        }
        public static int creatMatch()
        {
            SqlCeCommand com = new SqlCeCommand("INSERT INTO tblMatch VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18)", connection.CON);
            com.Parameters.AddWithValue("@p1", currentMatch.matchID);
            com.Parameters.AddWithValue("@p2", currentMatch.matchName);
            com.Parameters.AddWithValue("@p3", currentMatch.matchDate);
            com.Parameters.AddWithValue("@p4", currentMatch.countryPlayed.countryId);
            com.Parameters.AddWithValue("@p5", currentMatch.groundPlayed.stadiumId);
            com.Parameters.AddWithValue("@p6", currentMatch.team1.country.countryId);
            com.Parameters.AddWithValue("@p7", currentMatch.team2.country.countryId);
            com.Parameters.AddWithValue("@p8", currentMatch.matchType.matchTypeId);
            com.Parameters.AddWithValue("@p9", clsUser.currentUser.userID);
            com.Parameters.AddWithValue("@p10", currentMatch.savePath);
            com.Parameters.AddWithValue("@p11", currentMatch.team1.captainId);
            com.Parameters.AddWithValue("@p12", currentMatch.team1.viceCaptainId);
            com.Parameters.AddWithValue("@p13", currentMatch.team1.wicketKeeperId);
            com.Parameters.AddWithValue("@p14", currentMatch.team2.captainId);
            com.Parameters.AddWithValue("@p15", currentMatch.team2.viceCaptainId);
            com.Parameters.AddWithValue("@p16", currentMatch.team2.wicketKeeperId);
            com.Parameters.AddWithValue("@p17", 0);//match won by
            com.Parameters.AddWithValue("@p18", "");// mach comments 
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
        public static void setWinningTeam(int matchId, int winningTeamId, string comments)
        {
            SqlCeCommand com = new SqlCeCommand("UPDATE tblMatch SET matchWonBy=@p1, comments=@p2 WHERE matchId=@p3", connection.CON);
            com.Parameters.AddWithValue("@p1", winningTeamId);
            com.Parameters.AddWithValue("@p2", comments);
            com.Parameters.AddWithValue("@p3", matchId);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error setting winning team." + ex.Message);
            }
        }

        public static int getNextMatchId()
        {
            int id = 0;

            SqlCeCommand com = new SqlCeCommand("SELECT MAX(matchId)+1 FROM tblMatch", connection.CON);
            int.TryParse(com.ExecuteScalar().ToString(), out id);
            com.Dispose();

            return id;
        }
        public static int getMatchId(SqlCeConnection con, int playerId)
        {
            int matchId = -1;

            SqlCeCommand com = new SqlCeCommand("SELECT matchId FROM tblTeam WHERE playerId=@p1", con);
            com.Parameters.AddWithValue("@p1", playerId);
            try
            {
                int.TryParse(com.ExecuteScalar().ToString(), out matchId);
            }
            catch { }
            return matchId;
        }
        public static string getSavePath(int matchId)
        {
            string path = "";
            SqlCeCommand com = new SqlCeCommand("SELECT savePath FROM tblMatch WHERE matchId=@p1", connection.CON);
            com.Parameters.AddWithValue("@p1", matchId);

            try
            {
                path = com.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Could not get save path for the match \n"+ex.Message);
            }
            return path;
        }

        public static List<clsMatch> getAllMatches()
        {
            List<clsMatch> matchList = new List<clsMatch>();

            SqlCeCommand com = new SqlCeCommand("SELECT * FROM tblMatch", connection.CON);
            DataSet ds = new DataSet("tblMatch");
            SqlCeDataAdapter ad = new SqlCeDataAdapter(com);
            ad.Fill(ds, "tblMatch");

            foreach (DataRow r in ds.Tables["tblMatch"].Rows)
            {
                string savePath = r[9].ToString();
                List<clsTeams> squard=new List<clsTeams>();
                clsTeams team1=new clsTeams();
                clsTeams team2=new clsTeams();

                int team1CountryId = Convert.ToInt32(r[5].ToString());
                int team2CountryId = Convert.ToInt32(r[6].ToString());



                team1.country = clsCountry.getCountry(clsCountry.getCountryName(team1CountryId));
                team2.country = clsCountry.getCountry(clsCountry.getCountryName(team2CountryId));
                SqlCeConnection con_temp = connection.getConnection(savePath);

                if (con_temp != null)
                {
                    SqlCeCommand com1 = new SqlCeCommand("SELECT playerId, countryId FROM tblTeam", con_temp);
                    DataSet ds1 = new DataSet("tblTeam");
                    SqlCeDataAdapter ad1 = new SqlCeDataAdapter(com1);
                    ad1.Fill(ds1, "tblTeam");

                    //Get the two teams // Inner loop
                    foreach (DataRow r1 in ds1.Tables["tblTeam"].Rows)
                    {
                        //If it is team 1 (Country 1)
                        if (Convert.ToInt32(r1[1].ToString()) == team1CountryId)
                        {
                            //clsPlayer pp=clsPlayer.getPlayer(Convert.ToInt32(r1[0].ToString()));
                            team1.players.Add(clsPlayer.getPlayer(Convert.ToInt32(r1[0].ToString())));
                        }
                        else
                        {
                            team2.players.Add(clsPlayer.getPlayer(Convert.ToInt32(r1[0].ToString())));
                        }
                    }

                    squard.Add(team1);
                    squard.Add(team2);

                    clsMatch mt = new clsMatch(Convert.ToInt32(r[0].ToString()),r[1].ToString(), clsMatchTypes.getMatchType(Convert.ToInt32(r[7].ToString())), Convert.ToDateTime(r[2].ToString()), r[9].ToString(), clsCountry.getCountry(clsCountry.getCountryName(Convert.ToInt32(r[3].ToString()))), clsGround.getGround(Convert.ToInt32(r[4].ToString())), squard, "toss won", "First bat");
                    matchList.Add(mt);
                }
            }



            com.Dispose();

            return matchList;
        }

        #region properties

        public DateTime matchDate { get; set; }

        public clsMatchTypes matchType{get;set;}
        /// <summary>
        /// Country where the match in being played
        /// </summary>
        public clsCountry countryPlayed { get; set; }

        /// <summary>
        /// Ground where the match in being played
        /// </summary>
        public clsGround groundPlayed { get; set; }

        /// <summary>
        /// Squards of the two countries
        /// </summary>
        public List<clsTeams> currentSquards { get; set; }

        /// <summary>
        /// Name of the match
        /// </summary>
        public string matchName { get; set; }

        /// <summary>
        /// Path where the video will be saved
        /// </summary>
        public string savePath { get; set; }

        /// <summary>
        /// Country won the toss
        /// </summary>
        public string tossWonBy { get; set; }

        /// <summary>
        /// Country first batting
        /// </summary>
        public string firstBatting { get; set; }

        public clsTeams team1 { get; set; }
        public clsTeams team2 { get; set; }

        public int matchID { get; set; }
#endregion


    }
}
