using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMPA.Classes
{
    class clsTeams
    {
        public clsTeams() { }

        public clsTeams(clsCountry country, List<clsPlayer> players, int captainId, int viceCaptainId, int wicketKeeperId)
        {
            _country = country;
            _players = players;
            _captainId = captainId;
            _viceCaptainId = viceCaptainId;
            _wicketKeeperId = wicketKeeperId;

       }
        private clsCountry _country;
        private List<clsPlayer> _players= new List<clsPlayer>();
        private int _score = 0;
        private int _captainId = 0;
        private int _viceCaptainId = 0;
        private int _wicketKeeperId = 0;

        public int captainId
        {
            get { return _captainId; }
            set { _captainId = value; }
        }
        public int viceCaptainId
        {
            get { return _viceCaptainId; }
            set { _viceCaptainId = value; }
        }
        public int wicketKeeperId
        {
            get { return _wicketKeeperId; }
            set { _wicketKeeperId = value; }
        }

        public clsCountry country
        {
            get{return _country;}
            set { _country = value; }
        }

        public List<clsPlayer> players
        {
            get {return _players; }
            set { _players = value; }
        }

        public int score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int wickets { get; set; }
        public bool isBatting { get; set; }
    }
}
