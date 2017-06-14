using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMPA
{
    public class Bowler:clsPlayer
    {
        public Bowler()
        {
            overs = 0;
            maidens = 0;
            runs = 0;
            wickets = 0;
            noBalls = 0;
        }

        public int overs { get; set; }
        public int maidens { get; set; }
        public int runs { get; set; }
        public int wickets { get; set; }
        public int wides{get;set;}
        public int noBalls{get;set;}
    }
}
