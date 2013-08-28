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

        public Grade() : this("Untitled Grade")
        {
            PointsNeeded = "50";
            PointsPossible = "100";
        }

        public Grade(string name)
        {
            Name = name;
			Marked = false;
        }
    }
}