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
		private bool marked;

		public bool Marked 
		{
			get
			{
				return marked;
			}
			set
			{
				marked = value;
				if (value == false)
					PointsNeeded = null;
				NotifyPropertyChanged();
			}
		}

		public decimal? PointsEarned { get; set; }
		public decimal? PointsNeeded { get; set; }
		public decimal PointsPossible { get; set; }
		public decimal Weight { get; set; }
		public decimal OverallWeight { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }

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
			PointsPossible = 100;
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