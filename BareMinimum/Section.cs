using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Section : ItemContainer, Item
    {
		public decimal Weight { get; set; }
		public bool EvenWeighted { get; set; }
        // Sections can't be marked, yet, but the TreeListView that I'm using runs very slowly if there is no CheckedAspect property present.
		public bool Marked { get { return false; } }
		public string Notes { get; set; }

		public object Parent { get; set; }
		public int Level { get; set; }

        public string PointsPossible 
        {
            get
            {
                return "";
            }
			set
			{ }
        }

		public string PointsNeeded
		{
			get { return ""; }
			set { }
		}

		public Section(object parent)
			: this(parent, "Untitled Section")
		{ }

        public Section(object parent, string name)
        {
			EvenWeighted = true;
			Parent = parent;
			if (parent is Scenario)
				Level = 0;
			else
				Level = ((Section)parent).Level + 1;
            Name = name;
            ItemType = ItemType.None;
			Items = new List<Item>();
        }
    }
}