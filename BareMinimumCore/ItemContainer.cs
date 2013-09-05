using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BareMinimumCore
{
	public abstract class ItemContainer
	{
		public ItemType ItemType { get; set; }
		public List<IItem> Items { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public decimal? PointsEarned
		{
			get
			{
				if (Items.Count < 1)
					return null;
				if (ItemType == ItemType.Section)
				{
					decimal average = 0;
					int numEmpty = 0;
					decimal nonEmptyWeight = 0;
					foreach (Section section in Items)
					{
						if (section.PointsEarned != null)
						{
							average += (decimal)section.PointsEarned * ((decimal)section.Weight / 100);
							nonEmptyWeight += section.Weight / 100;
						}
						else
						{
							numEmpty++;
						}
					}
					if (numEmpty == Items.Count)
						return null;
					else
					{
						return average / nonEmptyWeight;
					}
				}
				else if (ItemType == ItemType.Grade)
				{
					decimal total = 0;
					decimal points = 0;
					int numEmpty = 0;
					foreach (Grade grade in Items)
					{
						if (grade.PointsEarned != null)
						{
							total += grade.PointsPossible;
							points += (decimal)grade.PointsEarned;
						}
						else
							numEmpty++;
					}
					if (numEmpty == Items.Count)
						return null;
					else
						return (points / total * 100);
				}
				else
					return null;
			}
		}

		public List<Grade> GetGrades()
		{
			List<Grade> list = new List<Grade>();
			if (ItemType == ItemType.Grade)
			{
				list.AddRange(Items.Cast<Grade>());
			}
			else if (ItemType == ItemType.Section)
			{
				foreach (Section section in Items)
					list.AddRange(section.GetGrades());
			}
			return list;
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
				decimal total = 0;
				foreach (Grade grade in Items)
					if (grade.PointsEarned != null || grade.Marked)
						total += (decimal)grade.PointsPossible;
				foreach (Grade grade in Items)
					if (total == 0)
						grade.Weight = 0;
					else
						grade.Weight = ((decimal)grade.PointsPossible / total * 100);
			}
		}

		public void CalculateAutoSectionWeights()
		{
			if (ItemType == ItemType.Section)
			{
				int autoWeightedSectionsCount = 0;
				decimal manualWeight = 0;
				foreach (Section section in Items)
					if (section.AutoWeighted)
						autoWeightedSectionsCount++;
					else
						manualWeight += section.Weight;

				if (autoWeightedSectionsCount != 0)
				{
					decimal autoWeight = (100M - manualWeight) / autoWeightedSectionsCount;
					foreach (Section section in Items)
					{
						if (section.AutoWeighted)
							section.Weight = autoWeight;
						section.CalculateAutoSectionWeights();
					}
				}
			}
		}
	}
}
