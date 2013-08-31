using System;
using System.Collections.Generic;
using System.Text;

namespace BareMinimum
{
    public interface IItem
    {
		// Properties for display:
		string Name { get; set; }
        string Notes { get; set; }
		
		// Non-display properties:
		object Parent { get; set; }
		int Level { get; set; }
    }
}