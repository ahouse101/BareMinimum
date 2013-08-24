using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public class Scenario
    {
        private string name;
        private List<Item> items = new List<Item>();

        public string Name { get { return name; } set { name = value; } }
        public List<Item> Items { get { return items; } set { items = value; } }
        
        public double Target { get; set; }
        public ItemType ItemType { get; set; }

        public string Average 
        { 
            // TODO: Implement average calculation
            get { return "n/a"; }
        }
    }
}