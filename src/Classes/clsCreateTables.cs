using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace PMPA.Classes
{
    class clsCreateTables
    {
        public static void createTables(SqlCeConnection connectioinOfTheDatabase)
        {
            SqlCeCommand com = new SqlCeCommand();
            com.Connection = connectioinOfTheDatabase;

            string quaery = @"CREATE TABLE [tblTeam]
(
   [playerId] INT,
   [countryId] INT,
   [matchId] INT
)";

            com.CommandText = quaery;
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error creating tables in the database.\n" + ex.Message);
            }

            quaery = @"CREATE TABLE [tblMaps]
(
   [ballId] INT,
   [batsmanX] INT,
   [batsmanY] INT,
   [pitchX] INT,
   [pitchY] INT,
   [groundX] INT,
   [groundY] INT,
   [videoName] NVARCHAR(150)
)";


            com.CommandText = quaery;
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error creating tables in the database.\n" + ex.Message);
            }

            quaery = @"CREATE TABLE [tblOver]
(
   [overId] INT NOT NULL,
   [playerId] INT,
   [endId] INT
)";


            com.CommandText = quaery;
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error creating tables in the database.\n" + ex.Message);
            }

            quaery = @"CREATE TABLE [tblBalls]
(
   [ballId] INT NOT NULL,
   [overId] INT NOT NULL,
   [runs] INT NOT NULL DEFAULT 0,
   [extras] INT NOT NULL DEFAULT 0,
   [batsmanId] INT,
   [runTypeId] INT,
   [shotId] INT,
   [ballTypeId] INT
)";


            com.CommandText = quaery;

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error creating tables in the database.\n" + ex.Message);
            }
            quaery = @"CREATE TABLE [tblWickets]
(
   [ballId] INT NOT NULL,
   [batsmanId] INT,
   [totalRuns] INT,
   [wicketTypeId] INT,
   [gotOut] BIT
)";


            com.CommandText = quaery;
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error creating tables in the database.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Adds the teams to the created table (tblTeam)
        /// </summary>
        /// <param name="team">The team to add</param>
        /// <param name="matchId">The current match ID</param>
        public static void AddTeam(List<clsPlayer> team, int matchId)
        {
            int countryId = clsCountry.getCountryCode(team[0].country);

            SqlCeCommand com;

            string quaery = "INSERT INTO [tblTeam] VALUES(@p1, @p2, @p3)";

            foreach (clsPlayer player in team)
            {

                com = new SqlCeCommand();
                com.Connection = connection.CON_WORKING;

                com.CommandText = quaery;

                com.Parameters.AddWithValue("@p1", player.playerId);
                com.Parameters.AddWithValue("@p2", countryId);
                com.Parameters.AddWithValue("@p3", matchId);

                com.ExecuteNonQuery();

                com.Dispose();
            }
        }

        /// <summary>
        /// Creats the match
        /// </summary>
        /// <param name="match">The match object to be created</param>
        /// <param name="userId">The user ID of the user who is logged in to the system.</param>
        /// <returns></returns>
        //public static int AddMatch(clsMatch match, int userId)
        //{
        //    int matchId = getNextMatchId();


        //    string quaery = "INSERT INTO [tblMatch] VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)";


        //    SqlCeCommand com = new SqlCeCommand();
        //    com.Connection = connection.CON;

        //    com.CommandText = quaery;

        //    com.Parameters.AddWithValue("@p1", matchId);
        //    com.Parameters.AddWithValue("@p2", match.matchName);
        //    com.Parameters.AddWithValue("@p3", match.matchDate);
        //    com.Parameters.AddWithValue("@p4", match.countryPlayed.countryId);
        //    com.Parameters.AddWithValue("@p5", match.groundPlayed.countryId);
        //    com.Parameters.AddWithValue("@p6", match.team1.country.countryId);
        //    com.Parameters.AddWithValue("@p7", match.team2.country.countryId);
        //    com.Parameters.AddWithValue("@p8", match.matchType.matchTypeId);
        //    com.Parameters.AddWithValue("@p9", userId);
        //    com.Parameters.AddWithValue("@p10", match.savePath);

        //    com.ExecuteNonQuery();

        //    com.Dispose();
        //    return matchId;
        //}

        //public static int getNextMatchId()
        //{
        //    int matchId = 0;

        //    SqlCeCommand com = new SqlCeCommand("SELECT MAX(matchId)+1 FROM tblMatch", connection.CON);
        //    int.TryParse(com.ExecuteScalar().ToString(), out matchId);
        //    com.Dispose();

        //    return matchId;
        //}

    }
}
