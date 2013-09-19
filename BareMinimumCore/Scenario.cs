using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BareMinimumCore
{
	[JsonObject(MemberSerialization.OptIn)]
    public class Scenario : ItemContainer, INotifyPropertyChanged
    {
		[JsonProperty]
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
				NotifyPropertyChanged("Target");
			}
		}

		[JsonConstructor]
		private Scenario() { }

		public Scenario(decimal target)
			: this(target, "Untitled")
		{ }

		public Scenario(string name)
			: this(90, name)
		{ }

		public Scenario(decimal target, string name)
			: this(target, name, new ObservableCollection<IItem>())
		{ }

		public Scenario(decimal target, string name, ObservableCollection<IItem> items)
		{
			this.target = target;
			base.name = name;
			base.items = items;
		}
    }
}