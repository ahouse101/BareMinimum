using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BareMinimum
{
	public abstract class ItemContainer
	{
		public ItemType ItemType { get; set; }
		public List<Item> Items { get; set; }
		public string Name { get; set; }

		public string PointsEarned
		{
			get
			{
				if (Items.Count < 1)
					return "n/a";
				if (ItemType == ItemType.Section)
				{
					double average = 0.0;
					int numEmpty = 0;
					foreach (Section section in Items)
					{
						if (section.PointsEarned != "n/a" && section.PointsEarned != "Error" && !String.IsNullOrWhiteSpace(section.PointsEarned))
							average += Double.Parse(section.PointsEarned.Replace("%", "")) * (double)section.Weight;
						else
							numEmpty++;
					}
					if (numEmpty == Items.Count)
						return "n/a";
					else
						return average.ToString("0.##") + "%";
				}
				else if (ItemType == ItemType.Grade)
				{
					double total = 0.0;
					double points = 0.0;
					int numEmpty = 0;
					foreach (Grade grade in Items)
					{
						if (!String.IsNullOrWhiteSpace(grade.PointsEarned))
						{
							total += Double.Parse(grade.PointsPossible);
							points += Double.Parse(grade.PointsEarned);
						}
						else
							numEmpty++;
					}
					if (numEmpty == Items.Count)
						return "n/a";
					else
						return (points / total * 100).ToString("0.##") + "%";
				}
				else
					return "Error";
			}
			set { }
		}

		public void CalculateGradeWeights()
		{
			if (ItemType == ItemType.Section)
			{
				foreach (Section section in Items)
					section.CalculateGradeWeights();
			}
			else if  (ItemType == ItemType.Grade)
			{
				double total = 0.0;
				foreach (Grade grade in Items)
					total += Double.Parse(grade.PointsPossible);
				foreach (Grade grade in Items)
					grade.Weight = (Double.Parse(grade.PointsPossible) / total * 100);
			}
		}
	}
}
