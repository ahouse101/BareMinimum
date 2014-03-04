using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace BareMinimumCore
{
	[JsonObject(MemberSerialization.OptIn)]
    public class Grade : IItem, INotifyPropertyChanged
    {
		[JsonProperty]
		private bool marked;
		[JsonProperty]
		private bool isExtraCredit;
		[JsonProperty]
		private decimal? pointsEarned;
		[JsonProperty]
		private decimal pointsPossible;
		[JsonProperty]
		private ItemContainer parent;
		[JsonProperty]
		private int level;
		[JsonProperty]
		private decimal weight;
		[JsonProperty]
		private string name;
		[JsonProperty]
		private string notes;

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

		public bool IsExtraCredit
		{
			get
			{
				return isExtraCredit;
			}
			set
			{
				isExtraCredit = value;
				NotifyPropertyChanged("IsExtraCredit");
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

		public decimal Weight
		{
			get
			{
				return weight;
			}
			set
			{
				weight = value;
				NotifyPropertyChanged("Weight");
			}
		}

		public string Name 
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public string Notes
		{
			get
			{
				return notes;
			}
			set
			{
				notes = value;
				NotifyPropertyChanged("Notes");
			}
		}

		public decimal? PointsNeeded { get; set; }
		public decimal OverallWeight { get; set; }

		public ItemContainer Parent
		{
			get
			{
				return parent;
			}
		}

		public int Level
		{
			get
			{
				return level;
			}
		}

		public decimal GetPercent()
		{
			if (PointsEarned == null)
				return 0;
			else
				return (decimal)PointsEarned / PointsPossible * 100;
		}

		public ItemFlags Flags
		{
			get
			{
				if (isExtraCredit)
					return ItemFlags.ExtraCredit;
				else
					return ItemFlags.None;
			}
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
			this.parent = parent;
			if (parent is Scenario)
				level = 0;
			else
				level = ((Section)parent).Level + 1;
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