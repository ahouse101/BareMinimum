using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BareMinimum
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

		public Scenario()
			: this(90, "Untitled")
		{ }

		public Scenario(decimal target, string name)
		{
			this.target = target;
			Name = name;
			Items = new List<IItem>();
			ItemType = ItemType.None;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}