using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BareMinimum
{
	public abstract class ItemContainer
	{
		public ItemType ItemType { get; set; }
		public List<IItem> Items { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public List<Grade> MarkedGrades
		{
			get
			{
				List<Grade> list = new List<Grade>();
				if (ItemType == ItemType.Grade)
				{
					foreach (Grade grade in Items)
						if (grade.Marked)
							list.Add(grade);
				}
				else if (ItemType == ItemType.Section)
				{
					foreach (Section section in Items)
						list.AddRange(section.MarkedGrades);
				}
				return list;
			}
		}

		[JsonIgnore]
		public decimal? PointsEarned
		{
			get
			{
				return GetAverage(true, false, false);
			}
		}

		public decimal? GetAverage(bool includeMarked, bool treatEmptyAsZero, bool treatMarkedForCalculation)
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
					if (section.GetAverage(includeMarked, treatEmptyAsZero, treatMarkedForCalculation) != null)
					{
						average += (decimal)section.GetAverage(includeMarked, treatEmptyAsZero, treatMarkedForCalculation) * ((decimal)section.Weight / 100);
						nonEmptyWeight += section.Weight;
					}
					else
					{
						if (!includeMarked && section.MarkedGrades.Count > 0)
						{
							nonEmptyWeight += section.Weight;
						}
						numEmpty++;
					}
				}
				if (numEmpty == Items.Count)
					return null;
				else
				{
					if (!treatEmptyAsZero)
						average *= (100 / nonEmptyWeight);
					return average;
				}
			}
			else if (ItemType == ItemType.Grade)
			{
				decimal total = 0;
				decimal points = 0;
				int numEmpty = 0;
				foreach (Grade grade in Items)
				{
					if (includeMarked)
					{
						if (grade.PointsEarned != null)
						{
							total += grade.PointsPossible;
							points += (decimal)grade.PointsEarned;
						}
						else
							numEmpty++;
					}
					else
					{
						if (!grade.Marked && grade.PointsEarned != null)
						{
							total += grade.PointsPossible;
							points += (decimal)grade.PointsEarned;
						}
						else if (grade.Marked && treatMarkedForCalculation)
						{
							total += grade.PointsPossible;
							points += grade.PointsPossible;
						}
						else
							numEmpty++;
					}
				}
				if (numEmpty == Items.Count)
					return null;
				else
					return (points / total * 100);
			}
			else
				return null;
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
					total += (decimal)grade.PointsPossible;
				foreach (Grade grade in Items)
					grade.Weight = ((decimal)grade.PointsPossible / total * 100);
			}
		}

		public void CalculateAutoSectionWeights()
		{
			if (ItemType == ItemType.Section)
			{
				int autoWeightedSectionsCount = 0;
				foreach (Section section in Items)
					if (section.AutoWeighted)
						autoWeightedSectionsCount++;
				
				foreach (Section section in Items)
				{
					section.Weight = 100M / autoWeightedSectionsCount;
					section.CalculateAutoSectionWeights();
				}
			}
		}
	}
}
