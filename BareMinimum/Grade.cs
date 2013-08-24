using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Grade : Item
    {
        private bool marked = false;

        public override double Weight
        {
            // TODO: Implement weight calculation
            get
            {
                return 0.0;
            }
        }

        public bool Marked 
        {
            get
            {
                return marked;
            }
            set
            {
                marked = value; 
            }
        }

        public Grade() : this("Untitled Grade")
        {
            PointsNeeded = "50";
            PointsPossible = "100";
        }

        public Grade(string name)
        {
            Name = name;
        }
    }
}