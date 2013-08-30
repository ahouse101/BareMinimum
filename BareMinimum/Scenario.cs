using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Scenario : ItemContainer
    {
        public decimal Target { get; set; }

		public Scenario(decimal target)
			: this(target, "Untitled")
		{ }

		public Scenario(string name)
			: this(90, name)
		{ }

		public Scenario()
			: this(90, "Untitled")
		{ }

		public Scenario(decimal target, string name)
		{
			Target = target;
			Name = name;
			Items = new List<Item>();
			ItemType = ItemType.None;
		}
    }
}