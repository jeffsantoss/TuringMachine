using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculdade___Linguagens_Formais_e_Autômatos
{
    class Transition
    {
        public char stateOrigin;
        public char stateDestination { get; set; }
        public char Direction { get; set; } 
        public char elementRead { get; set; }
        public char elementWrite { get; set; }

        public Transition(char eR, char orig, char dest, char eW,char dir)
        {
            this.stateOrigin = orig;
            this.elementRead = eR;
            this.elementWrite = eW;
            this.stateDestination = dest;
            this.Direction = dir;
        }
        public Transition() { }
        public String getTransitionString()
        {
            String transitionString = "";

            transitionString = elementRead + stateOrigin.ToString() + elementWrite + stateDestination;

            return transitionString;
        }
        public String getTransitionStringDefault()
        {
            String transitionString = "";

            transitionString =  " δ: " + "(" +elementRead+ " , " +stateOrigin.ToString() + ") -> (" + elementWrite + " , " + stateDestination + ", " + Direction + ") \n";

            return transitionString;
        }
    }
}
