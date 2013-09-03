using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BareMinimumCore
{
    public class Scenario : ItemContainer, INotifyPropertyChanged
    {
		private decimal target;

        public decimal Target 
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
				NotifyPropertyChanged();
			}
		}

		public Scenario(decimal target)
			: this(target, "Untitled")
		{ }

		public Scenario(string name)
			: this(90, name)
		{ }

		public Scenario(decimal target, string name)
			: this(target, name, new List<IItem>(), ItemType.None)
		{ }

		public Scenario(decimal target, string name, List<IItem> items, ItemType itemType)
		{
			this.target = target;
			this.Name = name;
			this.Items = items;
			this.ItemType = itemType;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}