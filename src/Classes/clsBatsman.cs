using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMPA
{
    public class Batsman:clsPlayer
    {
        public Batsman()
        {
            gotOut = false;
            runs = 0;
            fours = 0;
            sixes = 0;
            balls = 0;
        }
        public int runs { get; set; }
        public int balls { get; set; }
        public int fours { get; set; }
        public int sixes { get; set; }
        public bool gotOut { get; set; }
        
       
    }
}
