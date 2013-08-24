using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Section : Item
    {
        private List<Item> items = new List<Item>();

        public override string PointsEarned { get; set; }
        public ItemType ItemType { get; set; }
        // Sections can't be marked, yet, but the TreeListView that I'm using runs very slowly if there is no CheckedAspect property present.
        public bool Marked { get { return false; } }

        public List<Item> Items { get { return items; } set { items = value; } }

        public override string PointsPossible 
        {
            get
            {
                return "100%";
            }
        }

        public Section() : this("Untitled Section")
        {
        }

        public Section(string name)
        {
            Name = name;
            ItemType = ItemType.None;
        }
    }
}