using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public abstract class Item
    {
        public string Name { get; set; }
        public virtual double Weight { get; set; }
        public virtual string PointsEarned { get; set; }
        public virtual string PointsPossible { get; set; }
        public string PointsNeeded { get; set; }
        public string Notes { get; set; }
    }
}