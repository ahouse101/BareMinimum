using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BareMinimum
{
    public class Grade : Item, INotifyPropertyChanged
    {
        private string pointsEarned;
		private string pointsPossible;
		private bool marked;

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

		public bool Marked 
		{
			get
			{
				return marked;
			}
			set
			{
				marked = value;
				NotifyPropertyChanged();
			}
		}

		public string PointsNeeded { get; set; } 
		public string Notes { get; set; }
		public double? Weight { get; set; }
		public string Name { get; set; }
		public double OverallWeight { get; set; }

		public object Parent { get; set; }
		public int Level { get; set; }

		public Grade(object parent)
			: this(parent, "Untitled Grade")
		{ }

        public Grade(object parent, string name)
        {
			if (parent is Scenario)
				Level = 0;
			else
				Level = ((Section)parent).Level + 1;
            Name = name;
			PointsPossible = "100";
			marked = false;
			Parent = parent;
        }

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}