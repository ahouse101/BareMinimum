using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BareMinimumCore
{
    public class Grade : IItem, INotifyPropertyChanged
    {
		private bool marked;
		private decimal? pointsEarned;
		private decimal pointsPossible;

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
				NotifyPropertyChanged("Marked");
			}
		}

		public decimal? PointsEarned
		{
			get
			{
				return pointsEarned;
			}
			set
			{
				pointsEarned = value;
				NotifyPropertyChanged("PointsEarned");
			}
		}

		public decimal PointsPossible
		{
			get
			{
				return pointsPossible;
			}
			set
			{
				pointsPossible = value;
				NotifyPropertyChanged("PointsPossible");
			}
		}

		public decimal? PointsNeeded { get; set; }
		public decimal Weight { get; set; }
		public decimal OverallWeight { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }

		public ItemContainer Parent { get; set; }
		public int Level { get; set; }

		public decimal GetPercent()
		{
			if (PointsEarned == null)
				return 0;
			else
				return (decimal)PointsEarned / PointsPossible * 100;
		}

		[JsonConstructor]
		private Grade() { }

		public Grade(ItemContainer parent)
			: this(parent, "Untitled Grade")
		{ }

		public Grade(ItemContainer parent, string name)
			: this(parent, name, 100, null, null, false, "")
		{ }

		public Grade(ItemContainer parent, string name, decimal pointsPossible, decimal? pointsEarned, decimal? pointsNeeded, bool marked, string notes)
		{
			this.Parent = parent;
			if (parent is Scenario)
				Level = 0;
			else
				Level = ((Section)parent).Level + 1;
			this.Name = name;
			this.pointsPossible = pointsPossible;
			this.pointsEarned = pointsEarned;
			this.PointsNeeded = pointsNeeded;
			this.marked = marked;
			this.Notes = notes;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(String propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}