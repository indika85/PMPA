using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMPA.Classes;
//using Microsoft.ReportingServices.ReportRendering;

namespace PMPA.Forms
{
    public partial class frmAnalyse : Form
    {
        public frmAnalyse()
        {
            InitializeComponent();
        }
        Image GROUND, PITCH;
        Image BATSMANLEFT, BATSMANRIGHT;

        int CURRENT_VIDEO_INDEX = 0;

        /// <summary>
        /// Stores the matches played by the selected player
        /// </summary>
        List<clsMatch> CURRENT_MATCHES = new List<clsMatch>();
        /// <summary>
        /// Stores all the matches in the database
        /// </summary>
        List<clsMatch> ALL_MATCHES = new List<clsMatch>();
        /// <summary>
        /// Stores the players of the selected country
        /// </summary>
        List<clsPlayer> PLAYERS_LOADED = new List<clsPlayer>();
        /// <summary>
        /// Stores maps of all shorts/balls of the current selected match of the selected player
        /// </summary>
        List<clsMaps> CURRENT_MAPS = new List<clsMaps>();
        /// <summary>
        /// Stores all balls played by the selected player
        /// </summary>
        List<clsRecordBall> CURRENT_BALLS = new List<clsRecordBall>();

        private void frmAnalyse_Load(object sender, EventArgs e)
        {
            foreach (clsCountry country in clsCountry.getAllCountries())
            {
                lstCountries.Items.Add(country.countryName);
            }

            //Load all matches in the DB
            foreach (clsMatch match in clsMatch.getAllMatches())
            {
                ALL_MATCHES.Add(match);
            }

            GROUND = pbGround.Image;
            BATSMANLEFT = pbBatsmanLeft.Image;
            BATSMANRIGHT = pbBatsmanRight.Image;
            PITCH = pbPitch.Image;
            
        }

        private void btnLoadPlayers_Click(object sender, EventArgs e)
        {
            loadPlayers();
        }

        private void loadPlayers()
        {
            if (lstCountries.SelectedItems.Count <= 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a country to load players");
                return;
            }
            int countryId = clsCountry.getCountryCode(lstCountries.SelectedItem.ToString());

            lstBatsman.Items.Clear();
            PLAYERS_LOADED.Clear();
            foreach (clsPlayer player in clsPlayer.getPlayersOfCountry(countryId))
            {
                lstBatsman.Items.Add(player.fName + " " + player.lName + " -" + player.playerId);
                PLAYERS_LOADED.Add(player);
            }
        }

        private void btnLoadMatches_Click(object sender, EventArgs e)
        {
            if (lstBatsman.SelectedItems.Count <= 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a player to load the matches");
                return;
            }

            loadMatches();   
        }
        private void loadMatches()
        {
            string playerName = lstBatsman.SelectedItem.ToString();
            playerName = playerName.Substring(0, playerName.IndexOf("-") - 1);
            //MessageBox.Show(playerName);
            int playerId = getplayer(playerName).playerId;
            lstMatches.Items.Clear();
            CURRENT_MATCHES.Clear();
            foreach (clsMatch match in ALL_MATCHES)
            {
                //ALL_MATCHES.Add(match);
                if (clsMatch.getMatchId(connection.getConnection(match.savePath), playerId) >= 0)
                {
                    lstMatches.Items.Add(match.matchName+"-"+match.matchID);
                    CURRENT_MATCHES.Add(match);
                }
                
            }
        }

        private clsPlayer getplayer(string playerName)
        {
            clsPlayer id = new clsPlayer();

            foreach (clsPlayer player in PLAYERS_LOADED)
            {
                if (player.fName + " " + player.lName == playerName)
                {
                    id = player;
                    break;
                }
            }

            return id;
        }

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMatches.SelectedItems.Count > 0)
            {
                loadVideoFilePath();
            }
        }

        private void loadVideoFilePath()
        {
            lstVideoFiles.Items.Clear();
            string playerName = lstBatsman.SelectedItem.ToString();
            playerName = playerName.Substring(0, playerName.IndexOf("-") - 1);
            int playeId = getplayer(playerName).playerId;

            lstVideoFiles.Items.Clear();
            CURRENT_MAPS.Clear();

            //string matchName = lstMatches.SelectedItem.ToString();
            

            foreach (clsMatch match in CURRENT_MATCHES)
            {
                foreach (string matchName in lstMatches.SelectedItems)
                {
                    int matchId = Convert.ToInt32(matchName.Substring(matchName.IndexOf("-") + 1, matchName.Length - matchName.IndexOf("-") - 1));
                    //MessageBox.Show(matchId.ToString());

                    if (match.matchID == matchId)
                    {
                        foreach (clsMaps map in clsMaps.getMap(match.savePath, playeId))
                        {
                            string filePath = match.savePath.Substring(0, match.savePath.LastIndexOf(@"\") + 1) + map.fileName;// +".wmv";
                            lstVideoFiles.Items.Add(filePath);
                            map.fileName = filePath;
                            CURRENT_MAPS.Add(map);
                        }
                    }
                }

            }
        }

        private void lstVideoFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkAutoPlaySelected.Checked)
            {
                playVideo(true);
            }
            drawFieldingPosition();
            drawPitchPosition();

            string playerName = lstBatsman.SelectedItem.ToString();
            playerName = playerName.Substring(0, playerName.IndexOf("-") - 1);

            if (getplayer(playerName).battingHand == 'R')
            {
                drawBatsmanRightPosition();
            }
            else if (getplayer(playerName).battingHand == 'L')
            {
                drawBatsmanLeftPosition();
            }
        }
        #region drawing 
        private void drawBatsmanLeftPosition()
        {
            Image i = new Bitmap(BATSMANLEFT, pbBatsmanLeft.Width, pbBatsmanLeft.Height);
            Graphics g = Graphics.FromImage(i);

            foreach (string names in lstVideoFiles.SelectedItems)
            {
                foreach (clsMaps map in CURRENT_MAPS)
                {
                    if (map.fileName == names)
                    {
                        g.FillEllipse(Brushes.Red, map.batsmanPos.X - 3, map.batsmanPos.Y - 3, 6, 6);
                    }

                }
            }

            pbBatsmanLeft.Image = i;
            pbBatsmanLeft.Invalidate();
            g.Dispose();
        }
        private void drawBatsmanRightPosition()
        {
            Image i = new Bitmap(BATSMANRIGHT, pbBatsmanRight.Width, pbBatsmanRight.Height);
            Graphics g = Graphics.FromImage(i);

            foreach (string names in lstVideoFiles.SelectedItems)
            {
                foreach (clsMaps map in CURRENT_MAPS)
                {
                    if (map.fileName == names)
                    {
                        g.FillEllipse(Brushes.Red, map.batsmanPos.X - 3, map.batsmanPos.Y - 3, 6, 6);
                    }

                }
            }
            

            pbBatsmanRight.Image = i;
            pbBatsmanRight.Invalidate();
            g.Dispose();
        }
        private void drawPitchPosition()
        {
            Image i = new Bitmap(PITCH, pbPitch.Width, pbPitch.Height);
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(Brushes.Yellow, 2);

            foreach (string names in lstVideoFiles.SelectedItems)
            {
                foreach (clsMaps map in CURRENT_MAPS)
                {
                    if (map.fileName == names)
                    {
                        g.FillEllipse(Brushes.Red, map.pitchPos.X - 4, map.pitchPos.Y - 4, 8, 8);
                    }
                }
            }


            pbPitch.Image = i;
            pbPitch.Invalidate();
            g.Dispose();
        }

        private void drawFieldingPosition()
        {
            Image i = new Bitmap(GROUND, pbGround.Width, pbGround.Height);

            i = new Bitmap(GROUND, pbGround.Width, pbGround.Height);

            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(Brushes.Yellow, 2);

            foreach (string names in lstVideoFiles.SelectedItems)
            {
                foreach (clsMaps map in CURRENT_MAPS)
                {
                    if (map.fileName == names)
                    {
                        g.DrawLine(p, new Point(pbGround.ClientRectangle.Width / 2, pbGround.ClientRectangle.Height / 2), map.feildingPos);
                        g.FillEllipse(Brushes.Red, map.feildingPos.X - 2, map.feildingPos.Y - 2, 4, 4);
                        break;
                    }
                }
            }

            pbGround.Image = i;
            pbGround.Invalidate();
            g.Dispose();
        }
        #endregion
        private void playVideo(bool playSelected)
        {
            if (lstVideoFiles.SelectedItems.Count > 0)
            {
                axVLCPlugin21.playlist.stop();
                axVLCPlugin21.playlist.items.clear();
                foreach (string URI in lstVideoFiles.SelectedItems)
                {
                    axVLCPlugin21.playlist.add("file:///" + URI, AXVLC.VLCPlaylistMode.VLCPlayListAppendAndGo, null);
                }
                //string uri = lstVideoFiles.SelectedItem.ToString();

                
                axVLCPlugin21.playlist.play();
                CURRENT_VIDEO_INDEX = 0;
                setPlayerDetails();
            }
            
        }

        private void setPlayerDetails()
        {
            lblName.Text = lstBatsman.SelectedItem.ToString();

            if (lstVideoFiles.SelectedIndex < 0) return;

            string videoPath = lstVideoFiles.SelectedItems[CURRENT_VIDEO_INDEX].ToString();
            toolStripStatusLabel1.Text = "Currently playing video: "+videoPath;

            if (lstMatches.SelectedIndex < 0) return;

            string matchName = lstMatches.SelectedItem.ToString();
            lblMatch.Text = matchName;

            int playerId=getSelectedPlayerID();
            int matchId = 0;

            double score = clsPlayer.getScore(playerId, matchId);
            double ballsfaced = clsPlayer.getBallsFaced(playerId, matchId);
            lblScore.Text = score.ToString();
            lblBallsFaced.Text = ballsfaced.ToString();

            double SR = (score / ballsfaced) * 100.0;
            SR = Math.Round(SR, 2);
            lblSR.Text = SR.ToString();

            //Get 100s
            
            CURRENT_VIDEO_INDEX++;
        }

        private int getSelectedPlayerID()
        {
            int playerId = -1;

            if (lstBatsman.SelectedItems.Count > 0)
            {
                string player = lstBatsman.SelectedItem.ToString();
                playerId = Convert.ToInt32(player.Substring(player.IndexOf("-") + 1, player.Length - player.IndexOf("-") - 1));
            }

            return playerId;
        }

        private void pbPitch_Click(object sender, EventArgs e)
        {

        }

        private void axVLCPlugin21_MediaPlayerEndReached(object sender, EventArgs e)
        {
            //MessageBox.Show("End reached");
            setPlayerDetails();
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBatsman.SelectedItems.Count <= 0)
            {
                clsMessages.showMessage(clsMessages.msgType.exclamation, "Please select a player to load the matches");
                return;
            }

            loadMatches(); 
        }

        private void lstCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPlayers();
        }

        private void rbNorun_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string matchName in lstMatches.SelectedItems)
            {
                int matchId = Convert.ToInt32(matchName.Substring(matchName.IndexOf("-") + 1, matchName.Length - matchName.IndexOf("-") - 1));
                loadNumberOfRunsVideos(matchId, 0);
            }
        }

        private void rb4s_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string matchName in lstMatches.SelectedItems)
            {
                int matchId = Convert.ToInt32(matchName.Substring(matchName.IndexOf("-") + 1, matchName.Length - matchName.IndexOf("-") - 1));
                loadNumberOfRunsVideos(matchId,4);
            }
        }

        private void rb6s_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string matchName in lstMatches.SelectedItems)
            {
                int matchId = Convert.ToInt32(matchName.Substring(matchName.IndexOf("-") + 1, matchName.Length - matchName.IndexOf("-") - 1));
                loadNumberOfRunsVideos(matchId, 6);
            }
        }
        private void loadNumberOfRunsVideos(int matchId, int numberOfRunsToGet)
        {
            lstVideoFiles.Items.Clear();
            string playerName = lstBatsman.SelectedItem.ToString();
            playerName = playerName.Substring(0, playerName.IndexOf("-") - 1);
            int playeId = getplayer(playerName).playerId;

            CURRENT_MAPS.Clear();

            foreach (clsMatch match in CURRENT_MATCHES)
            {
                if (match.matchID == matchId)
                {
                    foreach (clsRecordBall ball in clsPlayer.getNumberOfNRunss(playeId, numberOfRunsToGet, connection.getConnection(match.savePath)))
                    {
                        foreach (clsMaps map in clsMaps.getMap(match.savePath, playeId))
                        {
                            if (map.ballId == ball.ballID)
                            {
                                string filePath = match.savePath.Substring(0, match.savePath.LastIndexOf(@"\") + 1) + map.fileName;
                                lstVideoFiles.Items.Add(filePath);
                                map.fileName = filePath;
                                CURRENT_MAPS.Add(map);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (lstMatches.SelectedItems.Count > 0)
            {
                loadVideoFilePath();
            }
        }
    }
}
