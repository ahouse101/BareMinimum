﻿using System.Collections.Generic;

namespace BareMinimumCore
{
    public static class Calculations
    {
		public static void CalculateNeeded(Scenario scenario)
		{
			List<Grade> gradesForCalculation = GetGradesForCalculation(scenario);
			List<Grade> markedGrades = GetMarkedGrades(gradesForCalculation);

			if (markedGrades.Count < 1)
				return;

			scenario.CalculateGradeWeights();
			CalculateModifiedSectionWeight(scenario);
			CalculateOverallGradeWeights(gradesForCalculation);

			decimal markedPercent = 0;
			foreach (Grade grade in markedGrades)
				markedPercent += grade.OverallWeight;
			decimal currentGradeWithMarked = GetAverageForCalculation(gradesForCalculation);
			decimal distance = scenario.Target - currentGradeWithMarked;
			decimal needed = (distance / markedPercent) * 100;
			foreach (Grade grade in markedGrades)
				grade.PointsNeeded = (needed / 100) * grade.PointsPossible;
		}

		public static void CalculateOverallGradeWeights(List<Grade> gradeList)
		{
			foreach (Grade grade in gradeList)
			{
				grade.OverallWeight = grade.Weight;
				if (grade.Level > 0)
				{
					Section parent = (Section)grade.Parent;
					grade.OverallWeight *= parent.ModifiedWeight / 100;

					for (int level = grade.Level; level > 1; level--)
					{
						parent = (Section)parent.Parent;
						grade.OverallWeight *= parent.ModifiedWeight / 100;
					}
				}
			}
		}

		public static void CalculateModifiedSectionWeight(ItemContainer container)
		{
			if (container.Items.Count < 1)
				return;

			if (container.ItemType == ItemType.Section)
			{
				decimal nonEmptyWeight = 0;
				foreach (Section section in container.Items)
					if (GetGradesForCalculation(section).Count > 0)
						nonEmptyWeight += section.Weight;
				if (nonEmptyWeight != 0)
				{;
					foreach (Section section in container.Items)
						section.ModifiedWeight = section.Weight / (nonEmptyWeight / 100);
				}
				else
				{
					foreach (Section section in container.Items)
						section.ModifiedWeight = 0;
				}

				foreach (Section section in container.Items)
					CalculateModifiedSectionWeight(section);
			}
		}

		public static decimal GetAverageForCalculation(List<Grade> gradeList)
		{
			decimal points = 0;
			decimal total = 0;
			foreach (Grade grade in gradeList)
			{
				if (grade.IsExtraCredit)
					points += (decimal)grade.PointsEarned * (grade.OverallWeight);
				else
				{
					if (grade.Marked)
						points += 0;
					else
						points += grade.GetPercent() * (grade.OverallWeight / 100);

					total += grade.OverallWeight;
				}
			}
			return points / total * 100;
		}

		public static List<Grade> GetGradesForCalculation(ItemContainer container)
		{
			List<Grade> gradesForCalculation = new List<Grade>();
			foreach (Grade grade in container.GetGrades())
				if (grade.PointsEarned != null || grade.Marked)
					gradesForCalculation.Add(grade);
			return gradesForCalculation;
		}

		public static List<Grade> GetMarkedGrades(ItemContainer container)
		{
			return GetMarkedGrades(container.GetGrades());
		}

		public static List<Grade> GetMarkedGrades(List<Grade> gradeList)
		{
			List<Grade> markedGrades = new List<Grade>();
			foreach (Grade grade in gradeList)
				if (grade.Marked)
					markedGrades.Add(grade);
			return markedGrades;
		}

		// Overload for GetLetterGrade that accepts point values rather than a percentage.
		public static string GetLetterGrade(decimal pointsEarned, decimal pointsPossible, GradeRounding roundingStyle)
		{
			decimal percent = pointsEarned / pointsPossible * 100M;
			return GetLetterGrade(percent, roundingStyle);
		}

		// Finds the string representation of a percentage grade with the standard 5-letter Victorian system.
		public static string GetLetterGrade(decimal percent, GradeRounding roundingStyle)
		{
			int grade;
			switch (roundingStyle)
			{
				case GradeRounding.Standard:
					grade = (int)decimal.Round(percent, System.MidpointRounding.AwayFromZero);
					break;
				case GradeRounding.Ceiling:
					grade = (int)decimal.Ceiling(percent);
					break;
				case GradeRounding.Floor:
				default:
					grade = (int)decimal.Floor(percent);
					break;
			}

			string letter;
			if (grade >= 90)		letter = "A";
			else if (grade >= 80)	letter = "B";
			else if (grade >= 70)	letter = "C";
			else if (grade >= 60)	letter = "D";
			else					letter = "F";

			return letter;
		}
    }
}