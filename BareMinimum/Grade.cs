using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BareMinimum
{
    public class Grade : Item
    {
        private string pointsEarned;
		private string pointsPossible;

		public string PointsEarned
		{
			get
			{
				return pointsEarned;
			}
			set
			{
				pointsEarned = new String(value.Where(Char.IsDigit).ToArray());
			}
		}

		public string PointsPossible
		{
			get
			{
				return pointsPossible;
			}
			set
			{
				pointsPossible = new String(value.Where(Char.IsDigit).ToArray());
			}
		}

		public string PointsNeeded { get; set; }
		public bool Marked { get; set; } 
		public string Notes { get; set; }
		public double? Weight { get; set; }
		public string Name { get; set; }
		public double OverallWeight { get; set; }

		public object Parent { get; set; }
		public int Level { get; set; }

        public Grade(object parent) : this(parent, "Untitled Grade")
        {
            PointsNeeded = "50";
            PointsPossible = "100";
        }

        public Grade(object parent, string name)
        {
			if (parent is Scenario)
				Level = 0;
			else
				Level = ((Section)parent).Level + 1;
            Name = name;
			Marked = false;
			Parent = parent;
        }
    }
}