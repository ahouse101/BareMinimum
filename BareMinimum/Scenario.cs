using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Scenario : ItemContainer
    {
        public double Target { get; set; }
        
		public Scenario()
		{
			Name = "Untitled";
			Items = new List<Item>();
		}
    }
}