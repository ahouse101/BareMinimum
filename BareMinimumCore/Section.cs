using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BareMinimumCore
{
    public class Section : ItemContainer, IItem, INotifyPropertyChanged
    {
		private decimal weight;

		public bool AutoWeighted { get; set; }
        // Sections can't be marked, yet, but the TreeListView control runs slowly if the property you set in AspectName isn't present.
		[JsonIgnore]
		public bool Marked { get { return false; } }
		[JsonIgnore]
		public decimal ModifiedWeight { get; set; } // This property allows the internal weight for calculation purposes to ignore empty sections.

		public string Notes { get; set; }

		public ItemContainer Parent { get; set; }
		public int Level { get; set; }

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

		[JsonIgnore]
		public string PointsPossible
		{
			get { return ""; }
		}

		[JsonIgnore]
		public decimal? PointsNeeded
		{
			get { return null; }
		}

		[JsonConstructor]
		private Section() { }

		public Section(ItemContainer parent)
			: this(parent, "Untitled Section")
		{ }

		public Section(ItemContainer parent, string name)
			: this(parent, name, true, 0, ItemType.None, new List<IItem>(), "")
		{ }

		public Section(ItemContainer parent, string name, bool autoWeighted, decimal weight, ItemType itemType, List<IItem> items, string notes)
		{
			this.Parent = parent;
			if (parent is Scenario)
				Level = 0;
			else
				Level = ((Section)parent).Level + 1;
			this.Name = name;
			this.weight = weight;
			this.AutoWeighted = autoWeighted;
			this.ItemType = itemType;
			this.Items = items;
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