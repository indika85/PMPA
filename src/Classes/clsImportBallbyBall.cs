using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace PMPA.Classes
{
    class clsImportBallbyBall
    {
        static OleDbConnection CON = new OleDbConnection();
        static string DatabasePath = "";
        public static void importBall(OleDbConnection con, string DBPath)
        {
            CON = con;
            DatabasePath = DBPath;
            OleDbCommand comOver = new OleDbCommand("SELECT ID FROM Overs",con);
            OleDbDataAdapter adOver = new OleDbDataAdapter(comOver);
            DataSet dsOver = new DataSet("Over");
            adOver.Fill(dsOver, "Over");
            int overId = 0;

            //OleDbCommand comBall;


            int endId = 8;

            foreach (DataRow rOver in dsOver.Tables["Over"].Rows)
            {
                OleDbCommand comBall = new OleDbCommand();
                comBall.Connection = con;

                overId = Convert.ToInt32(rOver[0].ToString());
                //string commandText = "SELECT [ID], [OverID], [BowlerID], [BatsmanID], [BallType], [BatEndType], [PitchingType], [Runs], [Extras], [HowOutType], [Distance], [Angle], [AngleTypeID], [WhoOutID], [BattingStrokeTypeID], [BowlingDeliveryTypeID], [HowOutType], [WhoOutID], [Angle], [Distance] FROM Balls WHERE [OverID]=@p1";
                string commandText = "SELECT [ID], [OverID], [BowlerID], [BatsmanID], [BallType], [BatEndType], [PitchingType], [Runs], [Extras], [HowOutType], [Distance], [Angle], [AngleTypeID], [WhoOutID], [HowOutType], [WhoOutID], [Angle], [Distance] FROM Balls WHERE [OverID]=@p1";
                comBall.CommandText = commandText;
                comBall.Parameters.AddWithValue("@p1", overId);
                //MessageBox.Show(overId.ToString());
                //------ Get the bowler ID-------------------

                OleDbCommand comBwlerId = new OleDbCommand("SELECT BowlerID FROM Balls WHERE OverID=@p1", con);
                comBwlerId.Parameters.AddWithValue("@p1", overId);
                int bowlerd = 0;

                try
                {
                    bowlerd = Convert.ToInt32(comBwlerId.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
                    return;
                }

                //-------------------------------------------
                //-----------Create over in the tables-------
                clsRecordOver over = new clsRecordOver();
                int overId1 = clsRecordOver.getNextOver();
                over.overId = overId1;
                over.bowlerId = bowlerd;

                if (overId % 2 == 0)
                    endId = 8;
                else
                    endId = 4;
                over.endId = endId;
                clsRecordOver.addOver(over);
                //MessageBox.Show(endId.ToString());
                //-------------------------------------------

                OleDbDataAdapter adBall = new OleDbDataAdapter(comBall);
                DataSet dsBall = new DataSet("Ball");
                try
                {
                    adBall.Fill(dsBall, "Ball");
                }
                catch (Exception ex)
                {
                    clsMessages.showMessage(clsMessages.msgType.error, "Error filling 'Ball' dada adapter.\n"+ex.Message);
                }

                foreach (DataRow rBall in dsBall.Tables["Ball"].Rows)
                {
                    clsRecordBall ball = new clsRecordBall();
                    try
                    {
                        ball.ballID = Convert.ToInt32(rBall[0].ToString());
                        ball.overId = overId1;
                        ball.runs = Convert.ToInt32(rBall[7].ToString());
                        ball.extras = Convert.ToInt32(rBall[8].ToString());
                        ball.batsmanId = mapPlayer(Convert.ToInt32(rBall[3].ToString()), con);
                        ball.runTypeId = 3;
                        ball.shot = clsShot.getShot(1);
                        ball.ballTypeId = mapBallType(Convert.ToInt32(rBall[4].ToString()));

                        clsRecordBall.addBall(ball);

                        //Check if it is a wicket
                        int isWicket = Convert.ToInt32(rBall["HowOutType"].ToString());
                        if (isWicket > 1 && isWicket < 18)
                        {
                            //MessageBox.Show("Wicket: "+isWicket.ToString());
                            int outBatsman = Convert.ToInt32(rBall["WhoOutID"]);
                            int totalRuns = getTotalRuns(outBatsman, con);
                            clsWicket wicket = new clsWicket(ball.ballID, outBatsman, 0, totalRuns, 1);
                            clsWicket.addWicket(wicket);
                        }

                        //--------record maps---------------------
                        int angle = Convert.ToInt32(rBall["Angle"].ToString());
                        float distance = float.Parse(rBall["Distance"].ToString());
                        recordPositions(angle, distance * 100, ball.ballID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

        }

        private static void recordPositions(int angle, float distance, int ballId)
        {
            int midPoint = 85;//Width and Height of the picturebox is 170
            int x_fielding = (int)Math.Round(midPoint + distance * Math.Sin(angle));
            int y_fielding = (int)Math.Round(midPoint + distance * Math.Cos(angle));

            Point fieldingPos = new Point(x_fielding, y_fielding);
            string fileName = getFileName(ballId);
            clsMaps map = new clsMaps(ballId, getRandomBatPos(), getRandomPitchPos(), fieldingPos, fileName);
            clsMaps.AddMaps(map);
        }

        private static string getFileName(int ballId)
        {
            string fileName = "";

            OleDbCommand com = new OleDbCommand("SELECT FileName FROM Videos WHERE BallID=@p1", CON);
            com.Parameters.AddWithValue("@p1", ballId);

            //fileName = DatabasePath.Substring(0, DatabasePath.LastIndexOf("\\") + 1);
            fileName = com.ExecuteScalar().ToString();

            //MessageBox.Show(fileName);

            return fileName;
        }
        private static Point getRandomBatPos()
        {
            int randX = new Random(DateTime.Now.Millisecond).Next(50, 85);
            int randY = new Random(DateTime.Now.Millisecond).Next(30, 75);
            return new Point(randX,randY);
        }
        private static Point getRandomPitchPos()
        {
            int randX = new Random(DateTime.Now.Millisecond).Next(30, 65);
            int randY = new Random(DateTime.Now.Millisecond).Next(35, 70);
            return new Point(randX, randY);
        }

        private static int getTotalRuns(int outBatsman,OleDbConnection con)
        {
            int totalRuns=0;
            OleDbCommand com = new OleDbCommand("SELECT SUM(Runs) FROM Balls WHERE BatsmanID=@p1", con);
            try
            {
                com.Parameters.AddWithValue("@p1", outBatsman);
                int.TryParse(com.ExecuteScalar().ToString(), out totalRuns);
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "Error getting total runs"+ex.Message);
            }
            return totalRuns;
        }

        private static int mapBallType(int ballTypeId)
        {
            int ballType = 4;

            switch (ballTypeId)
            {
                case 2:
                    ballType=4;//Legal ball -> Legal ball
                    break;

                case 3:
                    ballType = 4;//Byes -> Legal ball
                    break;

                case 4:
                    ballType = 4;//Leg Byes -> Legal ball
                    break;

                case 5:
                    ballType = 2;//No ball -> No ball
                    break;

                case 6:
                    ballType = 2;//No ball -> No ball
                    break;

                case 7:
                    ballType = 1;//Wide ball -> Wide ball
                    break;
            }

            return ballType;
        }

        private static int mapBattingShot(int battingShot)
        {
            int batShot = 4;

            switch (battingShot)
            {
                case 1:
                    batShot = 22;//Play and miss -> Play and miss
                    break;
                case 2:
                    batShot = 21;//Edge -> Edge
                    break;
                case 3:
                    batShot = 4;//Leave ball -> Leave
                    break;
                case 4:
                    batShot = 3;//Lofted shot -> hook
                    break;
                case 5:
                    batShot = 11;//Back foot ->
                    break;
                case 6:
                    batShot = 9;//Front foot ->
                    break;
            }

            return batShot;
        }

        public static int mapPlayer(int playerId,OleDbConnection con)
        {
            int player = 0;

            OleDbCommand com1 = new OleDbCommand("SELECT FirstName, lastName FROM Players WHERE ID=@p1",con);
            com1.Parameters.AddWithValue("@p1", playerId);
            OleDbDataAdapter ad = new OleDbDataAdapter(com1);
            DataSet ds = new DataSet("Players");
            ad.Fill(ds, "Players");

            DataRow r = ds.Tables["Players"].Rows[0];

            string playerFname = r[0].ToString();
            string playerLname = r[1].ToString();

            //Get Country Name
            OleDbCommand com2 = new OleDbCommand("SELECT CurrentTeamID FROM Players WHERE ID=@p1", con);
            com2.Parameters.AddWithValue("@p1", playerId);
            int currentTeamID=Convert.ToInt32(com2.ExecuteScalar().ToString());

            OleDbCommand com3 = new OleDbCommand("SELECT [Name] FROM Teams WHERE ID=@p1", con);
            com3.Parameters.AddWithValue("@p1", currentTeamID);

            string countryName ="";
            try
            {
                countryName = com3.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                clsMessages.showMessage(clsMessages.msgType.error, ex.Message);
            }

            player = clsPlayer.getPlayerId(playerFname, playerLname, clsCountry.getCountryCode(countryName));

            return player;
        }
    }
    
}
