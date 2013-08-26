using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public interface Item
    {
		string Name { get; set; }
        string Weight { get; set; }
        string PointsEarned { get; set; }
        string PointsPossible { get; set; }
        string PointsNeeded { get; set; }
        string Notes { get; set; }
    }
}