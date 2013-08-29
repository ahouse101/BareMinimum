using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public interface Item
    {
		// Properties for display:
		string Name { get; set; }
        double? Weight { get; set; }
        string PointsEarned { get; set; }
        string PointsPossible { get; set; }
        string PointsNeeded { get; set; }
        string Notes { get; set; }

		// Non-display properties:
		object Parent { get; set; }
		int Level { get; set; }
    }
}