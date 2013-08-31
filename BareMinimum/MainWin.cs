using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Microsoft.VisualBasic;

namespace BareMinimum
{
    public partial class MainWin : Form
	{
		#region Properties and Fields

		private TextOverlay emptyOverlay = new TextOverlay();
		private Font controlFont;

        public Scenario SelectedScenario
        {
            get
            {
                return (Scenario)ScenarioList.SelectedObject;
            }
        }
		public Scenario ScenarioToReselect { get; set; } // When a user attempts a deselect on the ScenarioList, this property allows BareMinimum to role back to the previous selection.

		#endregion

		#region Constructor and Delegates

		public MainWin()
        {
            InitializeComponent();
			controlFont = ScenarioTree.Font;

            // Set up the TreeListView for display:
            ScenarioTree.CanExpandGetter = CanExpand;
            ScenarioTree.ChildrenGetter = GetChildren;

			// Set the AspectToStringConverters for the ScenarioList:
			ScenarioAverageColumn.AspectToStringConverter = ConvertScenarioAverageToString;
			ItemNeededColumn.AspectToStringConverter = ConvertPointsNeededToString;

			// Set the RenderDelegates for the ScenarioTree:
			ItemWeightColumn.RendererDelegate = RenderItemWeight;
			ItemEarnedColumn.RendererDelegate = RenderItemEarned;

			// Set the AspectPutters for the ScenarioTree:
			ItemWeightColumn.AspectPutter = PutWeight;
			ItemEarnedColumn.AspectPutter = PutPointsEarned;
			ItemPossibleColumn.AspectPutter = PutPointsPossible;
			ScenarioTargetColumn.AspectPutter = PutTarget;
			
			// Customize the overlay for an empty list for both ObjectListViews:
            emptyOverlay.Alignment = ContentAlignment.TopCenter;
            emptyOverlay.BackColor = Color.Transparent;
            emptyOverlay.BorderWidth = 0.0F;
            emptyOverlay.TextColor = Color.Black;
            emptyOverlay.Font = ScenarioTree.Font;
			emptyOverlay.Text = "Add a scenario to get started.";
            ScenarioList.EmptyListMsgOverlay = emptyOverlay;
            ScenarioTree.EmptyListMsgOverlay = emptyOverlay;

			// Customize the decoration for the selected item:
			RowBorderDecoration selectedDecoration = new RowBorderDecoration(); 
			selectedDecoration.BorderPen = new Pen(Color.FromArgb(128, Color.Black), 1); 
			selectedDecoration.BoundsPadding = new Size(-1, -1);
			selectedDecoration.FillBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0));
			selectedDecoration.CornerRounding = 0f;
			ScenarioTree.SelectedRowDecoration = selectedDecoration;

			// Customize the decoration for the hot item:
			RowBorderDecoration hotItemDecoration = new RowBorderDecoration();
			hotItemDecoration.BorderPen = new Pen(Color.FromArgb(75, Color.Black), 1);
			hotItemDecoration.BoundsPadding = new Size(-1, -1);
			hotItemDecoration.FillBrush = new SolidBrush(Color.FromArgb(10, 0, 0, 0));
			hotItemDecoration.CornerRounding = 0f;
			ScenarioTree.HotItemStyle.Decoration = hotItemDecoration;

            // Set the drop down:
            CalculationTypeComboBox.SelectedItem = "Even";
        }

        // Delegate that tells the ScenarioTree when it can expand an item:
        private bool CanExpand(object item)
        {
            if (item is Section)
            {
                if (((Section)item).Items.Count < 1)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        // Delegate that returns the children of a given item to the ScenarioTree:
        private ArrayList GetChildren(object item)
        {
            if (item is Section)
                return new ArrayList(((Section)item).Items);
            else
                return new ArrayList();
        }

		// AspectToStringConverter for ScenarioAverageColumn
		private string ConvertScenarioAverageToString(object x)
		{
			decimal? average = (decimal?)x;
			if (average != null)
				return ((decimal)average).ToString("0.##") + "%";
			else
				return "n/a";
		}

		// AspectToStringConverter for ItemNeededColumn
		private string ConvertPointsNeededToString(object x)
		{
			decimal? needed = (decimal?)x;
			if (needed != null)
				return ((decimal)needed).ToString("0.00");
			else
				return "";
		}

		// RendererDelegate for ItemWeightColumn
		private bool RenderItemWeight(EventArgs e, Graphics g, Rectangle r, object model)
		{
			if (model is Section)
			{
				Section section = (Section)model;
				if (section.AutoWeighted)
					DrawTextInCell(g, r, "Auto");
				else
					DrawTextInCell(g, r, (section.Weight.ToString("0.##") + "%"));
			}
			else
				g.FillRectangle(Brushes.White, r);
			return true;
		}

		// RendererDelegate for ItemEarnedColumn
		private bool RenderItemEarned(EventArgs e, Graphics g, Rectangle r, object model)
		{
			if (model is Section)
			{
				Section section = (Section)model;
				if (section.PointsEarned == null)
					DrawTextInCell(g, r, "n/a");
				else
					DrawTextInCell(g, r, ((decimal)section.PointsEarned).ToString("0.##") + "%");
			}
			else // model is Grade
			{
				Grade grade = (Grade)model;
				if (grade.PointsEarned == null)
					g.FillRectangle(Brushes.White, r);
				else
					DrawTextInCell(g, r, ((decimal)grade.PointsEarned).ToString("0.##"));
			}
			return true;
		}

		private void PutWeight(object x, object value)
		{
			Section section = (Section)x;
			decimal newValue;
			if (Decimal.TryParse(value.ToString(), out newValue))
			{
				section.AutoWeighted = false;
				section.Weight = newValue;
			}
			else
			{
				section.AutoWeighted = true;
				SelectedScenario.CalculateAutoSectionWeights();
			}
		}

		private void PutPointsEarned(object x, object value)
		{
			Grade grade = (Grade)x;
			decimal newValue;
			if (Decimal.TryParse(value.ToString(), out newValue))
				grade.PointsEarned = newValue;
			else
				grade.PointsEarned = null;
		}

		private void PutPointsPossible(object x, object value)
		{
			Grade grade = (Grade)x;
			decimal newValue;
			if (Decimal.TryParse(value.ToString(), out newValue))
				grade.PointsPossible = newValue;
		}

		private void PutTarget(object x, object value)
		{
			Scenario scenario = (Scenario)x;
			decimal newValue;
			if (Decimal.TryParse(value.ToString(), out newValue))
				scenario.Target = newValue;
		}

		private void DrawTextInCell(Graphics g, Rectangle r, String text)
		{
			// Fill backgroud:
			g.FillRectangle(Brushes.White, r);
			
			// Create the StringFormat:
			StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
			format.LineAlignment = StringAlignment.Center;
			format.Alignment = StringAlignment.Near;
			format.Trimming = StringTrimming.EllipsisCharacter;

			// Draw the text:
			g.DrawString(text, controlFont, Brushes.Black, r, format);
		}

		#endregion

		#region Data Methods

		private void CalculateNeeded()
        {
            // Note: this calculation is for the "Even" mode.
			if (SelectedScenario.MarkedGrades.Count < 1)
				return;

			if (SelectedScenario.PointsEarned == null)
			{
				foreach (Grade grade in SelectedScenario.MarkedGrades)
					grade.PointsNeeded = SelectedScenario.Target;
			}
			else
			{
				CalculateOverallGradeWeights();

				decimal markedPercent = 0;
				foreach (Grade grade in SelectedScenario.MarkedGrades)
					markedPercent += grade.OverallWeight;
				decimal current = (decimal)SelectedScenario.PointsEarned * ((100 - markedPercent) / 100);
				decimal distance = SelectedScenario.Target - current;
				decimal needed = (distance / markedPercent) * 100;
				foreach (Grade grade in SelectedScenario.MarkedGrades)
					grade.PointsNeeded = needed;
			}
			ScenarioTree.RefreshObjects(SelectedScenario.MarkedGrades);
        }

		private void CalculateOverallGradeWeights()
		{
			SelectedScenario.CalculateGradeWeights();
			if (SelectedScenario.ItemType == ItemType.Grade)
			{
				foreach (Grade grade in SelectedScenario.Items)
				{
					grade.OverallWeight = grade.Weight;
				}
			}
			else if (SelectedScenario.ItemType == ItemType.Section)
			{
				foreach (Section section in SelectedScenario.Items)
				{
					CalculateOverallGradeWeights(section);
				}
			}
		}

		private void CalculateOverallGradeWeights(Section section)
		{
			if (section.ItemType == ItemType.Grade)
			{
				foreach (Grade grade in section.Items)
				{
					Section parent = section;
					decimal modifier = parent.Weight / 100;
					for (int level = grade.Level; level > parent.Level+1; level--)
					{
						parent = (Section)parent.Parent;
						modifier *= parent.Weight / 100;
					}
					grade.OverallWeight = grade.Weight * modifier;
				}
			}
			else if (section.ItemType == ItemType.Section)
			{
				foreach (Section subSection in section.Items)
				{
					CalculateOverallGradeWeights(subSection);
				}
			}
		}

        private void DeleteScenario(Scenario scenario)
        {
			int index = ScenarioList.SelectedIndex;
            ScenarioList.RemoveObject(scenario);
			if (ScenarioList.Items.Count < 1)
			{
				AddGradeButton.Enabled = false;
				AddSectionButton.Enabled = false;
				ScenarioTitleLabel.Text = "No Scenario Selected";
				DeleteScenarioButton.Enabled = false;
				DeleteItemButton.Enabled = false;
				emptyOverlay.Text = "Add a scenario to get started.";
				ScenarioTree.Refresh(); // Changing the emptyOverlay won't trigger a redraw for the ScenarioTree, we want a redraw anyway.
			}
			else
			{
				if (index != 0)
					ScenarioList.SelectedIndex = index - 1;
				else
					ScenarioList.SelectedIndex = 0;
			}
        }

        private void DeleteItem()
        {
            if (SelectedScenario != null && ScenarioTree.SelectedObject != null)
            {
                IItem item = (IItem)ScenarioTree.SelectedObject;
                Section parent = (Section)ScenarioTree.GetParent(item);
                DeleteItem(item, parent);
            }
        }

        private void DeleteItem(IItem item, Section parent)
        {
            if (parent == null) // The item is a top level item (root).
            {
                SelectedScenario.Items.Remove(item);
                ScenarioTree.RemoveObject(item);
            }
            else
            {
                parent.Items.Remove(item);
                ScenarioTree.RefreshObject(parent);
            }
            if (ScenarioTree.Items.Count < 1)
            {
                AddGradeButton.Enabled = true;
                AddSectionButton.Enabled = true;
                SelectedScenario.ItemType = ItemType.None;
                DeleteScenarioButton.Enabled = false;
            }
			ScenarioList.RefreshObject(SelectedScenario);
        }

		#endregion

		#region Event Handlers

		private void AddScenarioButton_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Type a name for the new scenario.", "New Scenario", "Untitled");
            Scenario newScenario = new Scenario(name);
            ScenarioList.AddObject(newScenario);
            ScenarioList.SelectObject(newScenario);
            emptyOverlay.Text = "Add some items to this scenario.";
            DeleteScenarioButton.Enabled = true;
        }

        private void AddSectionButton_Click(object sender, EventArgs e)
        {
            // Determine if the scenario or a section is selected, and act accordingly:
            if (ScenarioTree.SelectedObject == null)
            {
                // Add a new Grade to the Scenario:
                SelectedScenario.ItemType = ItemType.Section;
				Section newSection = new Section(SelectedScenario);
				newSection.PropertyChanged += Section_PropertyChanged;
                SelectedScenario.Items.Add(newSection);
                ScenarioTree.SetObjects(SelectedScenario.Items);
            }
            else
            {
                Section container = ((Section)ScenarioTree.SelectedObject);
                container.ItemType = ItemType.Section;
				Section newSection = new Section(container);
				newSection.PropertyChanged += Section_PropertyChanged;
                container.Items.Add(newSection);
                ScenarioTree.RefreshObject(container);
                if (!ScenarioTree.IsExpanded(container))
                    ScenarioTree.Expand(container);
            }
			SelectedScenario.CalculateAutoSectionWeights();
            AddGradeButton.Enabled = false;
        }

        private void AddGradeButton_Click(object sender, EventArgs e)
        {
            // Determine if the scenario or a section is selected, and act accordingly:
            if (ScenarioTree.SelectedObject == null)
            {
                Scenario container = SelectedScenario;
                // Add a new Grade to the Scenario:
                container.ItemType = ItemType.Grade;
				Grade newGrade = new Grade(SelectedScenario);
				newGrade.PropertyChanged += Grade_PropertyChanged;
                container.Items.Add(newGrade);
                ScenarioTree.SetObjects(SelectedScenario.Items);
            }
            else
            {
                Section container = ((Section)ScenarioTree.SelectedObject);
                container.ItemType = ItemType.Grade;
				Grade newGrade = new Grade(container);
				newGrade.PropertyChanged += Grade_PropertyChanged;
				container.Items.Add(newGrade);
                ScenarioTree.RefreshObject(container);
                if (!ScenarioTree.IsExpanded(container))
                    ScenarioTree.Expand(container);
            }
            AddSectionButton.Enabled = false;
        }

        private void DeleteScenarioButton_Click(object sender, EventArgs e)
        {
            DeleteScenario(SelectedScenario);
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void ScenarioList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (SelectedScenario != null)
                {
                    DeleteScenario(SelectedScenario);
                }
            }
        }

        private void ScenarioList_SelectionChanged(object sender, EventArgs e)
        {
            if (ScenarioList.Items.Count > 0)
            {
                // If the user clicks off of an item, but the list isn't empty, ignore it.
				if (SelectedScenario != null)
				{
					if (ScenarioToReselect != null)
						ScenarioToReselect.PropertyChanged -= Scenario_PropertyChanged;
					SelectedScenario.PropertyChanged += Scenario_PropertyChanged;
					ScenarioTree.SetObjects(SelectedScenario.Items);
					switch (SelectedScenario.ItemType)
					{
						case ItemType.None:
							AddGradeButton.Enabled = true;
							AddSectionButton.Enabled = true;
							break;
						case ItemType.Section:
							AddGradeButton.Enabled = false;
							AddSectionButton.Enabled = true;
							break;
						case ItemType.Grade:
							AddGradeButton.Enabled = true;
							AddSectionButton.Enabled = false;
							break;
						default:
							break;
					}
					ScenarioTitleLabel.Text = SelectedScenario.Name;
					ScenarioToReselect = SelectedScenario;
				}
				else
				{
					ScenarioList.SelectObject(ScenarioToReselect);
				}
            }
        }

		private void ScenarioTree_FormatRow(object sender, FormatRowEventArgs e)
		{
			RowBorderDecoration background = new RowBorderDecoration();
			background.BorderPen = null;
			background.CornerRounding = 0F;
			background.BoundsPadding = new Size(0, -1);
			if (e.Model is Section)
			{
				background.FillBrush = new SolidBrush(Color.FromArgb(50, 0, 150, 255));
			}
			else if (e.Model is Grade)
			{
				background.FillBrush = new SolidBrush(Color.FromArgb(50, 0, 190, 0));
			}
			e.Item.Decoration = background;
		}

        private void ScenarioTree_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Model is Section)
            {
				CellBorderDecoration background = new CellBorderDecoration();
				background.FillBrush = Brushes.White;
                background.BorderPen = null;
                background.CornerRounding = 0F;
                background.BoundsPadding = new Size(0, -1);
                CellBorderDecoration highlight= new CellBorderDecoration();
				highlight.FillBrush = new SolidBrush(Color.FromArgb(50, 0, 150, 255));
                highlight.BorderPen = null;
                highlight.CornerRounding = 0F;
                highlight.BoundsPadding = new Size(0, -1);
                e.SubItem.Decorations.Add(background);
				e.SubItem.Decorations.Add(highlight);
            }
            else
            {
                e.SubItem.Decorations.Clear();
            }
        }

        private void ScenarioTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteItem();
            }
        }

        private void ScenarioTree_SelectionChanged(object sender, EventArgs e)
        {
            if (ScenarioTree.SelectedObject == null) // Tree is empty, the Scenario is either empty or there are no Scenarios.
            {
                if (SelectedScenario != null) // Make sure we actually have a Scenario in the tree.
                {
                    switch (SelectedScenario.ItemType)
                    {
                        case ItemType.None:
                            AddSectionButton.Enabled = true;
                            AddGradeButton.Enabled = true;
                            break;
                        case ItemType.Section:
                            AddSectionButton.Enabled = true;
                            AddGradeButton.Enabled = false;
                            break;
                        case ItemType.Grade:
                            AddSectionButton.Enabled = false;
                            AddGradeButton.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
                DeleteItemButton.Enabled = false;
            }
            else if (ScenarioTree.SelectedObject is Section)
            {
                switch (((Section)ScenarioTree.SelectedObject).ItemType)
                {
                    case ItemType.None:
                        AddSectionButton.Enabled = true;
                        AddGradeButton.Enabled = true;
                        break;
                    case ItemType.Section:
                        AddSectionButton.Enabled = true;
                        AddGradeButton.Enabled = false;
                        break;
                    case ItemType.Grade:
                        AddSectionButton.Enabled = false;
                        AddGradeButton.Enabled = true;
                        break;
                    default:
                        break;
                }
                DeleteItemButton.Enabled = true;
            }
            else
            {
                AddSectionButton.Enabled = false;
                AddGradeButton.Enabled = false;
                DeleteItemButton.Enabled = true;
            }
        }

        private void ScenarioTree_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.RowObject is Section)
            {
                switch (e.Column.Index)
                {
                    case 2:
                    case 3:
                    case 5:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
            else if (e.RowObject is Grade)
            {
                switch (e.Column.Index)
                {
                    case 1:
                    case 5:
                        // ((Grade)e.RowObject).Marked = !((Grade)e.RowObject).Marked;
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
		}

		private void Section_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Weight")
			{
				CalculateNeeded();
				ScenarioList.RefreshObject(SelectedScenario);
			}
		}

		private void Grade_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Marked":
				case "PointsEarned":
				case "PointsPossible":
					CalculateNeeded();
					ScenarioList.RefreshObject(SelectedScenario);
					break;
				default:
					break;
			}
		}

		private void Scenario_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Name":
					ScenarioTitleLabel.Text = SelectedScenario.Name;
					break;
				case "Target":
					CalculateNeeded();
					break;
				default:
					break;
			}
		}

		#endregion
	}
}