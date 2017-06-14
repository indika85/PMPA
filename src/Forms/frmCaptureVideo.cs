using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectX.Capture;
using DShowNET;
using PMPA.Classes;

namespace PMPA.Forms
{
    public partial class frmCaptureVideo : Form
    {
        //--------Program parameters-------
        int RUNS = 0;//In the current ball
        int EXTRAS = 0;//In the current ball
        int OVERS = 0;

        /// <summary>
        /// Ball number in an over
        /// </summary>
        int BALLS = 0;
        int BOWLING_END = 0;

        /// <summary>
        /// Total number of overs in the match
        /// </summary>
        int MAX_OVERS = 0;
        int MAX_NO_OF_OVERS_PER_BOWLER = 10;

        Color ACTIVECOLOR = Color.LightGreen;
        Color DEACTIVECOLOR = Color.MistyRose;

        Color PICFRAM_ACTIVE = Color.Red;
        Color PICFRAM_INACTIVE = Color.Gray;

        bool END_OF_OVER = false;

        int SCORE = 0;
        int WICKETS = 0;

        int RUNTYPE = 0;

        /// <summary>
        /// Unique ball ID
        /// </summary>
        int BALL_NUMBER = 0;

        string MATCHNAME = "";
        string FILENAME = "";

        DateTime DATE;

        Point PITCHPOSITION;
        Point STUMPPOSITION;
        Point FEILDINGPOSITION;
        //Point STUMP2 = new Point(118, 141);
        Image GROUND, PITCH;
        Image BATSMANLEFT, BATSMANRIGHT;
        //public static clsMatch MATCH;

        Batsman batsman1;
        Batsman batsman2;
        Batsman currentBatsman;
        List<Batsman> BATSMEN_OUT = new List<Batsman>();
        
        Bowler bowler1;
        Bowler bowler2;
        Bowler currentBowler;
        List<Bowler> BOWLERS_CURRENTLY_UNILIZED = new List<Bowler>();

        clsTeams battingTeam;
        clsTeams bowlingTeam;

        clsRecordOver over=null;

        //public frmCaptureVideo(clsMatch match)
        //{
        //    InitializeComponent();
        //}
        public frmCaptureVideo()
        {
            InitializeComponent();

            DATE = DateTime.Today;
            //MATCH = this;
        }

        private void frmCaptureVideo_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + clsMatch.currentMatch.currentSquards[0].country.countryName + " vs " + clsMatch.currentMatch.currentSquards[1].country.countryName;
            
            clsCapture.initialiseFilters();
            clsCapture.setPreviewPanel(pnl_videoPreview);

            MATCHNAME = clsMatch.currentMatch.matchName;

            //Set the maximum overs in the match
            if (clsMatch.currentMatch.matchType.matchTypeName == "ODI")
            {
                MAX_OVERS = 50;
            }
            else
            {
                MAX_OVERS = 20;
            }

            GROUND = pbGround.Image;
            BATSMANLEFT = pbBatsmanLeft.Image;
            BATSMANRIGHT = pbBatsmanRight.Image;
            PITCH = pbPitch.Image;
            STUMPPOSITION = new Point(pbGround.ClientRectangle.Width / 2, pbGround.ClientRectangle.Height / 2);

            int i = 0;
            foreach (Filter device in clsCapture.getCaptureDevices())
            {
                cmbCaptureDevices.Items.Add(i.ToString() + ". " + device.Name);
                i++;
            }
            i = 0;
            foreach (Filter encorder in clsCapture.getEncorders())
            {
                cmbEncorders.Items.Add(i.ToString() + ". " + encorder.Name);
                i++;
            }

            loadComponentsWithData();

        }

        #region Loading components with initial data
        private void loadComponentsWithData()
        {
            //Creates the database
            connection.creatDatabase(clsMatch.currentMatch.savePath);
            
            //Creating the tables
            clsCreateTables.createTables(connection.CON_WORKING);

            //Inserting the teams into the tables
            clsCreateTables.AddTeam(clsMatch.currentMatch.team1.players, clsMatch.currentMatch.matchID);
            clsCreateTables.AddTeam(clsMatch.currentMatch.team2.players, clsMatch.currentMatch.matchID);

            //setting the batting and the bowling team
            if (clsMatch.currentMatch.team1.isBatting)
            {
                battingTeam = clsMatch.currentMatch.team1;
                bowlingTeam = clsMatch.currentMatch.team2;
            }
            else if (clsMatch.currentMatch.team2.isBatting)
            {
                battingTeam = clsMatch.currentMatch.team2;
                bowlingTeam = clsMatch.currentMatch.team1;
            }


            foreach (clsBallType ballType in clsBallType.getAllBallTypes())
            {
                lstBallType.Items.Add(ballType.ballTypeName);
            }

            foreach (clsShot shotType in clsShot.getShotTypes())
            {
                lstShotType.Items.Add(shotType.shotName);
            }

            foreach (clsPlayer batsman in battingTeam.players)
            {
                lstBattingTeam.Items.Add(batsman.fName+" "+batsman.lName);
            } 
            
            foreach (clsPlayer feilder in bowlingTeam.players)
            {
                lstFeildingTeam.Items.Add(feilder.fName + " " + feilder.lName);
            }

            //Sets default 2 batsmen
            if (lstBattingTeam.Items.Count > 2)
            {
                txtBatsman1.Text = lstBattingTeam.Items[0].ToString();
                txtBatsman2.Text = lstBattingTeam.Items[1].ToString();
            }

            //Sets the initial batting country
            lblBattingCountry.Text = clsMatch.currentMatch.firstBatting;

            //set the two bowling ends
            cmbBowlingEnd.Items.Add(clsMatch.currentMatch.groundPlayed.end1.endName);
            cmbBowlingEnd.Items.Add(clsMatch.currentMatch.groundPlayed.end2.endName);
            cmbBowlingEnd.SelectedIndex = 0;

        }
#endregion

        #region setting the RUNS variable accouring to checked ckeckboxes
        private void rbRuns1_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 1;
        }

        private void rbRuns2_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 2;
        }

        private void rbRuns3_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 3;
        }

        private void rbRuns4_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 4;
        }

        private void rbRuns5_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 5;
        }

        private void rbRuns6_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 6;
        }

        private void rbRuns0_CheckedChanged(object sender, EventArgs e)
        {
            RUNS = 0;
        }
        #endregion
        private void cmbCaptureDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

            int deviceNumber = int.Parse(cmbCaptureDevices.SelectedItem.ToString().Substring(0, 1));
            clsCapture.preview(deviceNumber);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!dataValidated(false))
                return;

            startCapturingProcess();
            
        }

        private bool dataValidated(bool isSavingToDisk)
        {
            if (cmbCaptureDevices.SelectedIndex < 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a recording device to proceed");
                cmbCaptureDevices.Focus();
                return false;
            }
            if (txtBatsman1.Text == "" || txtBatsman2.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select batsmen to proceed");
                return false;
            }
            if (txtBowler1Name.Text == "" || txtBowler2Name.Text == "")
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select bowlers to proceed");
                return false;
            }
            if (isSavingToDisk)
            {
                if (lstBallType.SelectedIndex < 0)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a delivery type to proceed");
                    lstBallType.Focus();
                    return false;
                }
                if (lstShotType.SelectedIndex < 0)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a shot type to proceed");
                    lstShotType.Focus();
                    return false;
                }
            }

            return true;
        }

        private void startCapturingProcess()
        {

            //Setting the current batsman
            if (rbBatsman1.Checked)
                currentBatsman = batsman1;
            else if (rbBatsman2.Checked)
                currentBatsman = batsman2;

            //Setting the current bowler
            if (rbBowler1.Checked)
                currentBowler = bowler1;
            else if (rbBowler2.Checked)
                currentBowler = bowler2;



            //Enable the runs and extras group boxes
            grpRuns.Enabled = true;
            grpExtras.Enabled = true;
            grpBallPosition.Enabled = true;
            grpRunType.Enabled = true;

            FILENAME = getFileName();
            BALL_NUMBER += 1;

            //MessageBox.Show(FILENAME);

            clsCapture.setSaveFileName(FILENAME);
            clsCapture.startCapture();

            //Dissable the start capture button and enable the record button
            btnCapture.Enabled = false;
            btnRecord.Enabled = true;

            //Set picture fram colors
            if (currentBatsman.battingHand == 'L')//Make panel 1 Active
            {
                splitContainer1.Panel1.BackColor = PICFRAM_ACTIVE;
                splitContainer1.Panel2.BackColor = PICFRAM_INACTIVE;

                splitContainer1.Panel1.Enabled = true;
                splitContainer1.Panel2.Enabled = false;
            }
            else if (currentBatsman.battingHand == 'R')// Make panal 2 Active
            {
                splitContainer1.Panel2.BackColor = PICFRAM_ACTIVE;
                splitContainer1.Panel1.BackColor = PICFRAM_INACTIVE;

                splitContainer1.Panel2.Enabled = true;
                splitContainer1.Panel1.Enabled = false;
            }

        }

        private void resetValues()
        {
            RUNS = 0;
            EXTRAS = 0;
            chkWicket.Checked = false;
            rbNormalRuns.Checked = true;
            rbEx0.Checked = true;
            rbRuns0.Checked = true;

            pbPitch.Image = PITCH;
            pbGround.Image = GROUND;
            pbBatsmanLeft.Image = BATSMANLEFT;
            pbBatsmanRight.Image = BATSMANRIGHT;

            lstBallType.SelectedIndex = 3;

            splitContainer1.Panel2.BackColor = PICFRAM_INACTIVE;
            splitContainer1.Panel1.BackColor = PICFRAM_INACTIVE;
        }

        private void updateScores()
        {
            
            //----------------------Updating batsman details.--------------------------

            //Batsman 1 update
            if (rbBatsman1.Checked)
            {
                batsman1.runs += RUNS;

                //Check if the ball is a valid ball. 3 is the legal ball in the database
                if (lstBallType.SelectedIndex == 3)
                {
                    batsman1.balls += 1;
                    txtBatsman1Balls.Text = batsman1.balls.ToString();
                }
                txtBatsman1Runs.Text = batsman1.runs.ToString();

                //Check for 4s and 6s
                if (rbFours.Checked)
                {
                    txtBatsman1_4s.Text = (Convert.ToInt32(txtBatsman1_4s.Text) + 1).ToString();
                }
                else if (rbSixes.Checked)
                {
                    txtBatsman1_6s.Text = (Convert.ToInt32(txtBatsman1_6s.Text) + 1).ToString();
                }
            }
            //Batsman 2 update
            else if (rbBatsman2.Checked)
            {
                batsman2.runs += RUNS;

                //Check if the ball is a valid ball
                if (lstBallType.SelectedIndex == 3)
                {
                    batsman2.balls += 1;
                    txtBatsman2Balls.Text = batsman2.balls.ToString();
                }
                txtBatsman2Runs.Text = batsman2.runs.ToString();

                //Check for 4s and 6s
                if (rbFours.Checked)
                {
                    txtBatsman2_4s.Text = (Convert.ToInt32(txtBatsman2_4s.Text) + 1).ToString();
                }
                else if (rbSixes.Checked)
                {
                    txtBatsman2_6s.Text = (Convert.ToInt32(txtBatsman2_6s.Text) + 1).ToString();
                }
            }
            shiftBatsmen();

            //-------------------------Updating bowlers details---------------------------

            //Check if the ball is a lega ball
            if (lstBallType.SelectedIndex == 3)
            {
                BALLS += 1;
            }
            else if (lstBallType.SelectedIndex == 0)//0= Wide ball
            {
                currentBowler.wides += 1;
            }
            else if (lstBallType.SelectedIndex == 1)//1= No ball
            {
                currentBowler.noBalls += 1;
            }
            else if (lstBallType.SelectedIndex == 2)//2= Deadball
            {
                //Do nothing
            }
            //If bowler 1 is selected update his details

            if (END_OF_OVER)
            {
                BALLS = 0;
                END_OF_OVER = false;
            }
            if (rbBowler1.Checked)
            {
                txtbowler1Overs.Text = OVERS.ToString() + "." + BALLS.ToString();
                txtbowler1Runs.Text = (Convert.ToInt32(txtbowler1Runs.Text) + RUNS).ToString();
                if (chkWicket.Checked)
                {
                    txtbowler1Wickets.Text = (Convert.ToInt32(txtbowler1Wickets.Text) + 1).ToString();
                }
            }
            else if (rbBowler2.Checked)
            {
                //If bowler 2 is selected update bowler 2's details
                txtbowler2Overs.Text = OVERS.ToString() + "." + BALLS.ToString();
                txtbowler2Runs.Text = (Convert.ToInt32(txtbowler2Runs.Text) + RUNS).ToString();
                if (chkWicket.Checked)
                {
                    txtbowler2Wickets.Text = (Convert.ToInt32(txtbowler2Wickets.Text) + 1).ToString();
                }
            }

            //Update the scores of the batsmen/ bowlers and other scores

            SCORE += RUNS + EXTRAS;
            lblScore.Text = SCORE.ToString() + "/" + WICKETS.ToString();

            //If it is a legal ball
            if (lstBallType.SelectedIndex == 3)
            {
                lblOvers.Text = "In " + OVERS.ToString() + "." + BALLS.ToString() + " Overs";
                //BALLS += 1;

            }

        }
        /// <summary>
        /// Shift batsmen according to the runs scored.
        /// </summary>
        private void shiftBatsmen()
        {
            if (RUNS % 2 == 0)
            {
                //If it is a even number no need to interchange batsmen
            }
            else
            {
                if (rbBatsman1.Checked)
                {
                    rbBatsman1.Checked = false;
                    rbBatsman2.Checked = true;
                }
                else if (rbBatsman2.Checked)
                {
                    rbBatsman2.Checked = false;
                    rbBatsman1.Checked = true;
                }

            }
        }

        private string getFileName()
        {
            //Increment the ball number by one and generate the file name
            return MATCHNAME+"-"+DATE.Day.ToString()+"-"+DATE.Month.ToString()+"-"+DATE.Year.ToString()+"_"+ BALL_NUMBER.ToString()+".wmv";
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (!dataValidated(true))
                return;
            
            clsCapture.stopCapture();//This will save the video
            startRecordProcess();

        }

        private void startRecordProcess()
        {
            //Create new ball
            clsRecordBall ball = new clsRecordBall();
            ball.runs = RUNS;
            ball.batsmanId = currentBatsman.playerId;
            ball.bowlerId = currentBowler.playerId;
            ball.pitchLocation = PITCHPOSITION;
            ball.stumpLocation = STUMPPOSITION;
            ball.feildingLocation = FEILDINGPOSITION;
            ball.videoName = FILENAME;
            ball.ballID = BALL_NUMBER;
            ball.extras = EXTRAS;
            ball.overId = OVERS;

            ball.runTypeId = RUNTYPE;
            ball.shot =new clsShot( clsShot.getShotID(lstShotType.SelectedItem.ToString()),lstShotType.SelectedItem.ToString());
            ball.ballTypeId = lstBallType.SelectedIndex + 1;

            //Recording the ball
            if (clsRecordBall.addBall(ball) <= 0)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "There was an error adding ball details.");
            }
            
            
            
            //Create a new Over
            if (over == null)
            {
                creatOver();
            }

            //Ending the over
            if (BALLS >= 5)
            {
                if (OVERS >= MAX_OVERS)
                {
                    if (clsMessages.showMessage(clsMessages.msgType.question, "The maximum number of overs have been bowled. Do you want to switch the session and change teams.") == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        switchSession();
                        btnSwitchSession.Enabled = false;
                    }
                    return;
                }
                OVERS += 1;
                clsMessages.showMessage(clsMessages.msgType.information, "Ending over " + OVERS.ToString());
                
                //Rotating the bowlers
                if (rbBowler1.Checked)
                {
                    try
                    {
                        txtbowler1Overs.Text = (Convert.ToInt32(txtbowler1Overs.Text) + 1).ToString();

                    }
                    catch { }
                    rbBowler1.Checked = false;
                    rbBowler2.Checked = true;
                }
                else if (rbBowler2.Checked)
                {
                    try
                    {
                        //txtbowler2Overs.Text = (Convert.ToInt32(txtbowler2Overs.Text) + 1).ToString();
                    }
                    catch { }

                    rbBowler1.Checked = true;
                    rbBowler2.Checked = false;
                }
                BALLS = 0;// Sets the current over balls to 0 so the new over can start.
                END_OF_OVER = true;

                creatOver();
                switchBowlingEnds();
            }

            //If it is a wicket
            if (chkWicket.Checked)
            {
                //chkWicket.Checked = false;

                //Recor the wicket in the table
                clsWicket wkt = new clsWicket(BALL_NUMBER, currentBatsman.playerId, 0, currentBatsman.runs, 1);
                clsWicket.addWicket(wkt);

                WICKETS++;

                BATSMEN_OUT.Add(currentBatsman);

                //Clear the out batsmans details
                if (batsman1.playerId == currentBatsman.playerId)
                {
                    txtBatsman1.Clear();
                    txtBatsman1.Focus();
                    txtBatsman1_4s.Text = "0";
                    txtBatsman1_6s.Text = "0";
                    txtBatsman1Balls.Text = "0";
                    txtBatsman1Runs.Text = "0";
                    txtBatsman1SR.Text = "0";
                }
                else if (batsman2.playerId == currentBatsman.playerId)
                {
                    txtBatsman2.Clear();
                    txtBatsman2.Focus();
                    txtBatsman2_4s.Text = "0";
                    txtBatsman2_6s.Text = "0";
                    txtBatsman2Balls.Text = "0";
                    txtBatsman2Runs.Text = "0";
                    txtBatsman2SR.Text = "0";
                }
                if (WICKETS >= 10)
                {
                    if (clsMessages.showMessage(clsMessages.msgType.question, "The number of wickets has reached 10. \nDo you want to switch the session and continue?") == DialogResult.Yes)
                    {
                        switchSession();
                        btnSwitchSession.Enabled = false;
                    }
                    else
                    {
                        return;
                    }
                }
                clsMessages.showMessage(clsMessages.msgType.information, "Please select the new batsman to continue");
            }

            //Enable the start capture button and Dissable the record button
            btnCapture.Enabled = true;
            btnRecord.Enabled = false;


            //Enable the runs and extras group boxes
            grpRuns.Enabled = false;
            grpExtras.Enabled = false;
            grpBallPosition.Enabled = false;
            grpRunType.Enabled = false;

            clsMaps.AddMaps(new clsMaps(BALL_NUMBER, STUMPPOSITION, PITCHPOSITION, FEILDINGPOSITION, FILENAME));

            if (!chkWicket.Checked)
            {
                updateScores();
                
            }
            resetValues();
            chkWicket.Checked = false;
        }

        private void switchSession()
        {
            //Code to switch the session
            if (clsMatch.currentMatch.team1.isBatting)
            {
                clsMatch.currentMatch.team1.isBatting = false;
                clsMatch.currentMatch.team2.isBatting = true;

                lblBattingCountry.Text = clsMatch.currentMatch.team2.country.countryName;
            }
            else
            {
                clsMatch.currentMatch.team1.isBatting = true;
                clsMatch.currentMatch.team2.isBatting = false;
            }
            //-----------------Record data to the database-------------------------

            //-----------------Changing batting and feilding lists--------------
            List<string> tempBatting = new List<string>();
            foreach (string batsman in lstBattingTeam.Items)
            {
                tempBatting.Add(batsman);
            }

            List<string> tempBowler = new List<string>();
            foreach (string bowler in lstFeildingTeam.Items)
            {
                tempBowler.Add(bowler);
            }
            lstFeildingTeam.Items.Clear();
            lstBattingTeam.Items.Clear();
            foreach (string batlsman in tempBatting)
            {
                lstFeildingTeam.Items.Add(batlsman);
            }
            foreach (string bowler in tempBowler)
            {
                lstBattingTeam.Items.Add(bowler);
            }

            //----------------Reset the lists------------------------------------
            BOWLERS_CURRENTLY_UNILIZED.Clear();
            BATSMEN_OUT.Clear();

            //------------------------------------------------------------------
            
            //---------Set two batsman and reset txt fields-----------------------
            txtBatsman1.Text = lstBattingTeam.Items[0].ToString();
            txtBatsman2.Text = lstBattingTeam.Items[1].ToString();



            txtBowler1Name.Text = "";
            txtBowler2Name.Text = "";

            txtBatsman1_4s.Text = "0";
            txtBatsman1_6s.Text = "0";
            txtBatsman1Balls.Text = "0";
            txtBatsman1Runs.Text = "0";
            txtBatsman1SR.Text = "0";

            txtBatsman2_4s.Text = "0";
            txtBatsman2_6s.Text = "0";
            txtBatsman2Balls.Text = "0";
            txtBatsman2Runs.Text = "0";
            txtBatsman2SR.Text = "0";

            txtbowler1ER.Text = "0";
            txtbowler1Maidn.Text = "0";
            txtbowler1Overs.Text = "0";
            txtbowler1Runs.Text = "0";
            txtbowler1Wickets.Text = "0";

            txtbowler2ER.Text = "0";
            txtbowler2Maidn.Text = "0";
            txtbowler2Overs.Text = "0";
            txtbowler2Runs.Text = "0";
            txtbowler2Wickets.Text = "0";

            WICKETS = 0;
            //---------------------------------------------------------------------

        }

        private void switchBowlingEnds()
        {
            if (cmbBowlingEnd.SelectedIndex == 0)
            {
                cmbBowlingEnd.SelectedIndex = 1;
            }
            else if (cmbBowlingEnd.SelectedIndex == 1)
            {
                cmbBowlingEnd.SelectedIndex = 0;
            }
        }

        //Creats a new over and updates the database
        private void creatOver()
        {
            over = new clsRecordOver();
            over.overId = OVERS;
            over.bowlerId = currentBowler.playerId;
            over.endId = BOWLING_END;
            clsRecordOver.addOver(over);
        }

        private void setNewBatsman()
        {
            
            if (lstBattingTeam.SelectedItems.Count > 0)
            {
                string batsman = lstBattingTeam.SelectedItem.ToString();
                
                //Check if the batsman in already out. Comparing the list
                foreach (Batsman bt in BATSMEN_OUT)
                {
                    if (bt.fName + " " + bt.lName == batsman)
                    {
                        clsMessages.showMessage(clsMessages.msgType.exclamation, "The selected matsman has already played and is out.");
                        return;
                    }
                }


                if (txtBatsman1.Text == batsman || txtBatsman2.Text == batsman)
                {
                    clsMessages.showMessage(clsMessages.msgType.exclamation, batsman + " is already selected");
                    return;
                }
                if (rbBatsman1.Checked)
                {
                    if (txtBatsman1.Text == "")
                    {
                        txtBatsman1.Text = batsman;
                    }
                    else
                    {
                        if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to replace " + txtBatsman1.Text + " with " + " " + batsman) == DialogResult.Yes)
                        {
                            txtBatsman1.Text = batsman;
                        }
                    }
                }
                else if (rbBatsman2.Checked)
                {
                    if (txtBatsman2.Text == "")
                    {
                        txtBatsman2.Text = batsman;
                    }
                    else
                    {
                        if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to replace " + txtBatsman2.Text + " with " + " " + batsman) == DialogResult.Yes)
                        {
                            txtBatsman2.Text = batsman;
                        }
                    }
                }
            }
            else
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No batsman was selected");
            }
        }

        private void cmbEncorders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int encorderNo = int.Parse(cmbEncorders.SelectedItem.ToString().Substring(0, 1));
            clsCapture.setEncorder(encorderNo);
        }

        #region Picture boxes and drawings
        private void pbBatsmanLeft_Click(object sender, EventArgs e)
        {
            STUMPPOSITION = pbBatsmanLeft.PointToClient(MousePosition);
            Image i = new Bitmap(BATSMANLEFT, pbBatsmanLeft.Width, pbBatsmanLeft.Height);
            Graphics g = Graphics.FromImage(i);

            g.FillEllipse(Brushes.Red, STUMPPOSITION.X - 3, STUMPPOSITION.Y - 3, 6, 6);

            pbBatsmanLeft.Image = i;
            pbBatsmanLeft.Invalidate();
            g.Dispose();
        }

        private void pbBatsmanRight_Click(object sender, EventArgs e)
        {
            STUMPPOSITION = pbBatsmanRight.PointToClient(MousePosition);
            Image i = new Bitmap(BATSMANRIGHT, pbBatsmanRight.Width, pbBatsmanRight.Height);
            Graphics g = Graphics.FromImage(i);

            g.FillEllipse(Brushes.Red, STUMPPOSITION.X - 3, STUMPPOSITION.Y - 3, 6, 6);

            pbBatsmanRight.Image = i;
            pbBatsmanRight.Invalidate();
            g.Dispose();
        }



        private void pbGround_Click(object sender, EventArgs e)
        {
            FEILDINGPOSITION = pbGround.PointToClient(MousePosition);
            Image i = new Bitmap(GROUND, pbGround.Width, pbGround.Height);
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(Brushes.Yellow, 2);

            g.DrawLine(p, new Point(pbGround.ClientRectangle.Width/2,pbGround.ClientRectangle.Height/2), FEILDINGPOSITION);
            g.FillEllipse(Brushes.Red, FEILDINGPOSITION.X - 2, FEILDINGPOSITION.Y - 2, 4, 4);

            pbGround.Image = i;
            pbGround.Invalidate();
            g.Dispose();
        }

        private void pbPitch_Click(object sender, EventArgs e)
        {
            PITCHPOSITION = pbPitch.PointToClient(MousePosition);
            Image i = new Bitmap(PITCH, pbPitch.Width, pbPitch.Height);
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(Brushes.Yellow, 2);

            g.FillEllipse(Brushes.Red, PITCHPOSITION.X - 4, PITCHPOSITION.Y - 4, 8, 8);

            pbPitch.Image = i;
            pbPitch.Invalidate();
            g.Dispose();

        }
        #endregion


        #region Auto catculated numbers in the score card
        private void txtBatsman1Balls_TextChanged(object sender, EventArgs e)
        {
            if (txtBatsman1Balls.Text == "0") return;

            //Calculating Strick Rate
            double sr=0.0d;
            try
            {
                sr = (double.Parse(txtBatsman1Runs.Text) / double.Parse(txtBatsman1Balls.Text)) * 100.00;
                batsman1.balls += Convert.ToInt32(txtBatsman1Balls.Text);

            }
            catch { }
            txtBatsman1SR.Text = sr.ToString("n2");

        }

        private void txtBatsman2Balls_TextChanged(object sender, EventArgs e)
        {
            if (txtBatsman2Balls.Text == "0") return;

            double sr = 0.0d;
            try
            {
                sr = (double.Parse(txtBatsman2Runs.Text) / double.Parse(txtBatsman2Balls.Text)) * 100.00;
                batsman1.balls += Convert.ToInt32(txtBatsman2Balls.Text);
            }
            catch { }
            txtBatsman2SR.Text = sr.ToString("n2");
        }


        private void bowler1Overs_TextChanged(object sender, EventArgs e)
        {
            double er = 0.0d;
            double ovr = ((double.Parse(txtbowler1Overs.Text.Substring(0, txtbowler1Overs.Text.IndexOf(".") + 1))) * 6) + BALLS;
            try
            {
                er = double.Parse(txtbowler1Runs.Text) / ovr;
            }
            catch { }
            txtbowler1ER.Text = er.ToString("n2");
        }

        private void txtbowler1Runs_TextChanged(object sender, EventArgs e)
        {
            double er = 0.0d;
            double ovr=((double.Parse(txtbowler1Overs.Text.Substring(0,txtbowler1Overs.Text.IndexOf(".")+1)))*6)+BALLS;
            try
            {
                er = double.Parse(txtbowler1Runs.Text) / ovr;
            }
            catch { }
            txtbowler1ER.Text = er.ToString("n2");
        }

        private void txtbowler2Overs_TextChanged(object sender, EventArgs e)
        {
            double er = 0.0d;
            double ovr = ((double.Parse(txtbowler2Overs.Text.Substring(0, txtbowler2Overs.Text.IndexOf(".") + 1))) * 6) + BALLS;
            try
            {
                er = double.Parse(txtbowler2Runs.Text) / ovr;
            }
            catch { }
            txtbowler2ER.Text = er.ToString("n2");
        }

        private void txtbowler2Runs_TextChanged(object sender, EventArgs e)
        {
            double er = 0.0d;
            double ovr = ((double.Parse(txtbowler2Overs.Text.Substring(0, txtbowler2Overs.Text.IndexOf(".") + 1))) * 6) + BALLS;
            try
            {
                er = double.Parse(txtbowler2Runs.Text) / ovr;
            }
            catch { }
            txtbowler2ER.Text = er.ToString("n2");
        }
        #endregion


        private void btnSetOpeningBatsman_Click(object sender, EventArgs e)
        {
            setNewBatsman();
        }


        #region setting EXTRAS according to the checked checkedboxes
        private void rbEx0_CheckedChanged(object sender, EventArgs e)
        {
            EXTRAS = 0;
        }

        private void rbEx1_CheckedChanged(object sender, EventArgs e)
        {
            EXTRAS = 1;
        }

        private void rbEx2_CheckedChanged(object sender, EventArgs e)
        {
            EXTRAS = 2;
        }

        private void rbEx3_CheckedChanged(object sender, EventArgs e)
        {
            EXTRAS = 3;
        }

        private void rbEx4_CheckedChanged(object sender, EventArgs e)
        {
            EXTRAS = 4;
        }

        private void rbEx5_CheckedChanged(object sender, EventArgs e)
        {
            EXTRAS = 5;
        }
        #endregion

        #region setting the initial bowlers
        private void btnSetOpeningBowler_Click(object sender, EventArgs e)
        {
            //Check if a bowler is selected
            if (lstFeildingTeam.SelectedItems.Count > 0)
            {
                string bowlerName = lstFeildingTeam.SelectedItem.ToString();
                //Check if the bowler fields are already empty
                if (txtBowler1Name.Text == bowlerName || txtBowler2Name.Text == bowlerName)
                {
                    //If the bowler is already selected. Ignore abd below steps.
                    clsMessages.showMessage(clsMessages.msgType.exclamation, bowlerName + " is already selected");
                    return;
                }

                //Check if the bowler in below the maximum overs per bowler limit
                foreach (Bowler b in BOWLERS_CURRENTLY_UNILIZED)
                {
                    if (bowlerName == b.fName + " " + b.lName)
                    {
                        if (b.overs >= MAX_NO_OF_OVERS_PER_BOWLER)
                        {
                            clsMessages.showMessage(clsMessages.msgType.exclamation, bowlerName + " has reached the maximum number of overs allowed.");
                            return;
                        }
                    }
                }


                if (rbBowler1.Checked)
                {
                    if (txtBowler1Name.Text == "")
                    {
                        txtBowler1Name.Text = bowlerName;//This will trigger the txt change event and run the code. and assign the current bowlers accordingly
                        
                        if (txtBowler2Name.Text == "")
                        {
                            //Automaticall forcus to the next bowler field
                            rbBowler2.Checked = true;
                            rbBowler1.Checked = false;
                            txtBowler2Name.Focus();
                        }
                        return;
                    }
                    
                    if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to replace " + txtBowler1Name.Text + " with " + " " + bowlerName) == DialogResult.Yes && txtBowler1Name.Text != "")
                    {
                        txtBowler1Name.Text = bowlerName;
                    }
                }
                else if (rbBowler2.Checked)
                {
                    if (txtBowler2Name.Text == "")
                    {
                        txtBowler2Name.Text = bowlerName;
                        if (txtBowler1Name.Text == "")
                        {
                            //Automaticall forcus to the next bowler field
                            rbBowler1.Checked = true;
                            rbBowler2.Checked = false;
                            txtBowler1Name.Focus();
                        }
                        return;
                    }
                    if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to replace " + txtBowler2Name.Text + " with " + " " + bowlerName) == DialogResult.Yes && txtBowler2Name.Text != "")
                    {
                        txtBowler2Name.Text = bowlerName;
                    }
                }
            }
            else
            {
                //If there are no bowler selected from the list. Stop!
                clsMessages.showMessage(clsMessages.msgType.exclamation, "No bowler was selected");
            }
        }
        #endregion

        #region setting the bowlers and the batsmen in the text change event of the text boxes
        private void txtBowler1Name_TextChanged(object sender, EventArgs e)
        {
            if (txtBowler1Name.Text == "") return;

            string bowlerame = txtBowler1Name.Text;
            foreach (clsPlayer player in bowlingTeam.players)
            {
                if (bowlerame == player.fName + " " + player.lName)
                {
                    bowler1 = new Bowler();

                    bowler1.battingHand = player.battingHand;
                    bowler1.bowlingStyle = player.bowlingStyle;
                    bowler1.country = player.country;
                    bowler1.dob = player.dob;
                    bowler1.fName = player.fName;
                    bowler1.lName = player.lName;
                    bowler1.playerId = player.playerId;

                    //Check if the bowler if in the currently utilised bowlers list
                    insertBowlerToTheList(bowler1);

                    break;
                }
            }
            if (rbBatsman1.Checked)
                currentBowler = bowler1;
        }

        private void insertBowlerToTheList(Bowler bb)
        {
            bool found = false;
            foreach (Bowler b in BOWLERS_CURRENTLY_UNILIZED)
            {
                if (b.playerId == bb.playerId)
                {
                    found = true;
                    break;
                }
            }
            if(!found)
                BOWLERS_CURRENTLY_UNILIZED.Add(bowler1);
        }

        private void txtBowler2Name_TextChanged(object sender, EventArgs e)
        {
            if (txtBowler2Name.Text == "") return;

            string bowlerame = txtBowler2Name.Text;
            foreach (clsPlayer player in bowlingTeam.players)
            {
                if (bowlerame == player.fName + " " + player.lName)
                {
                    bowler2 = new Bowler();

                    bowler2.battingHand = player.battingHand;
                    bowler2.bowlingStyle = player.bowlingStyle;
                    bowler2.country = player.country;
                    bowler2.dob = player.dob;
                    bowler2.fName = player.fName;
                    bowler2.lName = player.lName;
                    bowler2.playerId = player.playerId;

                    insertBowlerToTheList(bowler2);

                    break;
                }
            }
            if (rbBatsman2.Checked)
                currentBowler = bowler2;
        }

        private void txtBatsman1_TextChanged(object sender, EventArgs e)
        {
            if (txtBatsman1.Text == "") return;

            string batsmanname = txtBatsman1.Text;
            foreach (clsPlayer player in battingTeam.players)
            {
                if (batsmanname == player.fName + " " + player.lName)
                {
                    batsman1 = new Batsman();

                    batsman1.battingHand = player.battingHand;
                    batsman1.bowlingStyle = player.bowlingStyle;
                    batsman1.country = player.country;
                    batsman1.dob = player.dob;
                    batsman1.fName = player.fName;
                    batsman1.lName = player.lName;
                    batsman1.playerId = player.playerId;

                    break;
                }
            }
        }

        private void txtBatsman2_TextChanged(object sender, EventArgs e)
        {
            if (txtBatsman2.Text == "") return;

            string batsmanname = txtBatsman2.Text;
            foreach (clsPlayer player in battingTeam.players)
            {
                if (batsmanname == player.fName + " " + player.lName)
                {
                    batsman2 = new Batsman();
                    
                    batsman2.battingHand = player.battingHand;
                    batsman2.bowlingStyle = player.bowlingStyle;
                    batsman2.country = player.country;
                    batsman2.dob = player.dob;
                    batsman2.fName = player.fName;
                    batsman2.lName = player.lName;
                    batsman2.playerId = player.playerId;
                    break;
                }
            }
        }
        #endregion

        #region setting the run type
        private void rbFours_CheckedChanged(object sender, EventArgs e)
        {
            RUNTYPE = 1;
            rbRuns4.Checked = true;
        }

        private void rbNormalRuns_CheckedChanged(object sender, EventArgs e)
        {
            RUNTYPE = 0;
        }

        private void brSixes_CheckedChanged(object sender, EventArgs e)
        {
            RUNTYPE = 2;
            rbRuns6.Checked = true;
        }

        private void rbByes_CheckedChanged(object sender, EventArgs e)
        {
            RUNTYPE = 3;
        }

        private void rbLegByes_CheckedChanged(object sender, EventArgs e)
        {
            RUNTYPE = 4;
        }
        #endregion

        private void rbBatsman1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBatsman1.Checked)
            {
                currentBatsman = batsman1;

                txtBatsman1.BackColor = ACTIVECOLOR;
                txtBatsman1_4s.BackColor = ACTIVECOLOR;
                txtBatsman1_6s.BackColor = ACTIVECOLOR;
                txtBatsman1Balls.BackColor = ACTIVECOLOR;
                txtBatsman1Runs.BackColor = ACTIVECOLOR;
                txtBatsman1SR.BackColor = ACTIVECOLOR;

                txtBatsman2.BackColor = DEACTIVECOLOR;
                txtBatsman2_4s.BackColor = DEACTIVECOLOR;
                txtBatsman2_6s.BackColor = DEACTIVECOLOR;
                txtBatsman2Balls.BackColor = DEACTIVECOLOR;
                txtBatsman2Runs.BackColor = DEACTIVECOLOR;
                txtBatsman2SR.BackColor = DEACTIVECOLOR;
            }
            else
            {
                currentBatsman = batsman2;

                txtBatsman1.BackColor = DEACTIVECOLOR;
                txtBatsman1_4s.BackColor = DEACTIVECOLOR;
                txtBatsman1_6s.BackColor = DEACTIVECOLOR;
                txtBatsman1Balls.BackColor = DEACTIVECOLOR;
                txtBatsman1Runs.BackColor = DEACTIVECOLOR;
                txtBatsman1SR.BackColor = DEACTIVECOLOR;

                txtBatsman2.BackColor = ACTIVECOLOR;
                txtBatsman2_4s.BackColor = ACTIVECOLOR;
                txtBatsman2_6s.BackColor = ACTIVECOLOR;
                txtBatsman2Balls.BackColor = ACTIVECOLOR;
                txtBatsman2Runs.BackColor = ACTIVECOLOR;
                txtBatsman2SR.BackColor = ACTIVECOLOR;
            }
        }

        private void rbBowler1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBowler1.Checked)
            {
                currentBowler = bowler1;

                txtbowler1ER.BackColor = ACTIVECOLOR;
                txtbowler1Maidn.BackColor = ACTIVECOLOR;
                txtBowler1Name.BackColor = ACTIVECOLOR;
                txtbowler1Overs.BackColor = ACTIVECOLOR;
                txtbowler1Runs.BackColor = ACTIVECOLOR;
                txtbowler1Wickets.BackColor = ACTIVECOLOR;

                txtbowler2ER.BackColor = DEACTIVECOLOR;
                txtbowler2Maidn.BackColor = DEACTIVECOLOR;
                txtBowler2Name.BackColor = DEACTIVECOLOR;
                txtbowler2Overs.BackColor = DEACTIVECOLOR;
                txtbowler2Runs.BackColor = DEACTIVECOLOR;
                txtbowler2Wickets.BackColor = DEACTIVECOLOR;
            }
            else
            {
                currentBowler = bowler2;

                txtbowler1ER.BackColor = DEACTIVECOLOR;
                txtbowler1Maidn.BackColor = DEACTIVECOLOR;
                txtBowler1Name.BackColor = DEACTIVECOLOR;
                txtbowler1Overs.BackColor = DEACTIVECOLOR;
                txtbowler1Runs.BackColor = DEACTIVECOLOR;
                txtbowler1Wickets.BackColor = DEACTIVECOLOR;

                txtbowler2ER.BackColor = ACTIVECOLOR;
                txtbowler2Maidn.BackColor = ACTIVECOLOR;
                txtBowler2Name.BackColor = ACTIVECOLOR;
                txtbowler2Overs.BackColor = ACTIVECOLOR;
                txtbowler2Runs.BackColor = ACTIVECOLOR;
                txtbowler2Wickets.BackColor = ACTIVECOLOR;
            }
        }

        private void cmbBowlingEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBowlingEnd.SelectedIndex == 0)
            {
                BOWLING_END = clsMatch.currentMatch.groundPlayed.end1.endId;
            }
            else
            {
                BOWLING_END = clsMatch.currentMatch.groundPlayed.end2.endId;
            }
        }

        private void rbBowler2_CheckedChanged(object sender, EventArgs e)
        {
            //This is set in rbBowler1_CheckedChanged event.
        }

        private void txtBatsman1Runs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                batsman1.runs += Convert.ToInt32(txtBatsman1Runs.Text);
            }
            catch { }
        }

        private void txtBatsman2Runs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                batsman2.runs += Convert.ToInt32(txtBatsman2Runs.Text);
            }
            catch { }
        }

        private void txtBatsman1_4s_TextChanged(object sender, EventArgs e)
        {
            try
            {
                batsman1.fours += Convert.ToInt32(txtBatsman1_4s.Text);
            }
            catch { }
        }

        private void txtBatsman2_4s_TextChanged(object sender, EventArgs e)
        {
            try
            {
                batsman2.fours += Convert.ToInt32(txtBatsman2_4s.Text);
            }
            catch { }
        }

        private void txtBatsman1_6s_TextChanged(object sender, EventArgs e)
        {
            try
            {
                batsman1.fours += Convert.ToInt32(txtBatsman1_6s.Text);
            }
            catch { }
        }

        private void txtBatsman2_6s_TextChanged(object sender, EventArgs e)
        {
            try
            {
                batsman2.fours += Convert.ToInt32(txtBatsman2_4s.Text);
            }
            catch { }
        }

        private void rbBowler1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void rbBowler2_Validating(object sender, CancelEventArgs e)
        {
            //if (rbBowler2.Checked) return;
            //Check if it is in a middle of an over
            if (BALLS > 0 && BALLS < 6)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "The over in not yet complete.");
                //e.Cancel = true;
            }
        }

        private void btnSwitchSession_Click(object sender, EventArgs e)
        {
            if (OVERS < MAX_OVERS)
            {
                if (clsMessages.showMessage(clsMessages.msgType.question, "Number of overs are not completed. Are you sure that you want to change sessions?") == DialogResult.Yes)
                {
                    switchSession();
                    btnSwitchSession.Enabled = false;
                }
            }
        }

        private void rbBowler1_Validating_1(object sender, CancelEventArgs e)
        {
            //if (rbBowler1.Checked) return;
            //Check if it is in a middle of an over
            if (BALLS > 0 && BALLS < 6)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "The over in not yet complete.");
                //e.Cancel = true;
            }
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            if (clsMessages.showMessage(clsMessages.msgType.question, "Are you sure you want to end the session?") == DialogResult.Yes)
            {
                new frmMatchWinning().ShowDialog();
                clsMessages.showMessage(clsMessages.msgType.information, "Match was saved successfully\n this window will close now");
                Close();
            }
        }

        private void lstBallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBallType=lstBallType.SelectedItem.ToString();
            if (selectedBallType == "Wide" || selectedBallType == "No ball")
            {
                rbEx1.Checked = true;
            }
            else
            {
                rbEx0.Checked = true;
            }
        }
    }
}
