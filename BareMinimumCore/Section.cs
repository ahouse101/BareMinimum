using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BareMinimumCore
{
	[JsonObject(MemberSerialization.OptIn)]
    public class Section : ItemContainer, IItem, INotifyPropertyChanged
    {
		[JsonProperty]
		private decimal weight;
		[JsonProperty]
		private string notes;
		[JsonProperty]
		private bool autoWeighted;
		[JsonProperty]
		private ItemContainer parent;
		[JsonProperty]
		private int level;

        // Sections can't be marked, yet, but the TreeListView control runs slowly if the property you set in AspectName isn't present.
		public bool Marked { get { return false; } }
		public decimal ModifiedWeight { get; set; } // This property allows the internal weight for calculation purposes to ignore empty sections.

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

		public bool AutoWeighted 
		{
			get
			{
				return autoWeighted;
			}
			set
			{
				autoWeighted = value;
				NotifyPropertyChanged("AutoWeighted");
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

		public string PointsPossible
		{
			get { return ""; }
		}

		public decimal? PointsNeeded
		{
			get { return null; }
		}

		public ItemFlags Flags
		{
			get { return ItemFlags.None; }
		}

		[JsonConstructor]
		private Section() { }

		public Section(ItemContainer parent)
			: this(parent, "Untitled Section")
		{ }

		public Section(ItemContainer parent, string name)
			: this(parent, name, true, 0, new ObservableCollection<IItem>(), "")
		{ }

		public Section(ItemContainer parent, string name, bool autoWeighted, decimal weight, ObservableCollection<IItem> items, string notes)
		{
			this.parent = parent;
			if (parent is Scenario)
				level = 0;
			else
				level = ((Section)parent).level + 1;
			this.name = name;
			this.weight = weight;
			this.autoWeighted = autoWeighted;
			this.items = items;
			this.notes = notes;
		}
    }
}