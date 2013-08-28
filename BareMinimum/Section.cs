using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Section : ItemContainer, Item
    {
		public double? Weight { get; set; }
        // Sections can't be marked, yet, but the TreeListView that I'm using runs very slowly if there is no CheckedAspect property present.
		public bool Marked { get { return false; } }
		public string Notes { get; set; }

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


        public Section() : this("Untitled Section")
        {
        }

        public Section(string name)
        {
            Name = name;
            ItemType = ItemType.None;
			Items = new List<Item>();
        }
    }
}