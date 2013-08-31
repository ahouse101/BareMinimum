using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BareMinimum
{
    public class Section : ItemContainer, IItem, INotifyPropertyChanged
    {
		private decimal weight;

		public bool AutoWeighted { get; set; }
        // Sections can't be marked, yet, but the TreeListView control runs slowly if the property you set in AspectName isn't present.
		public bool Marked { get { return false; } }
		public string Notes { get; set; }

		public object Parent { get; set; }
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
				NotifyPropertyChanged();
			}
		}

		public string PointsPossible
		{
			get { return ""; }
		}

		public string PointsNeeded
		{
			get { return ""; }
		}

		public Section(object parent)
			: this(parent, "Untitled Section")
		{ }

        public Section(object parent, string name)
        {
			AutoWeighted = true;
			Parent = parent;
			if (parent is Scenario)
				Level = 0;
			else
				Level = ((Section)parent).Level + 1;
            Name = name;
            ItemType = ItemType.None;
			Items = new List<IItem>();
        }

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}