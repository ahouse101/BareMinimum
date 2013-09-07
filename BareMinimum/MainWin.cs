using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using BareMinimumCore;
using System.Diagnostics;

namespace BareMinimum
{
    public partial class MainWin : Form
	{
		#region Properties and Fields

		private TextOverlay emptyOverlay = new TextOverlay();
		private Font controlFont;
		private string filePath;
		private int listEditingColumnIndex;
		private int treeEditingColumnIndex;
		private int listEditingRowIndex;
		private int treeEditingRowIndex;

		private string FilePath
		{
			get
			{
				return filePath;
			}
			set
			{
				filePath = value;
				if (String.IsNullOrWhiteSpace(filePath))
					FileLabel.Text = "Unsaved File";
				else
					FileLabel.Text = Path.GetFileName(filePath);
			}
		}

        public Scenario SelectedScenario
        {
            get
            {
                return (Scenario)ScenarioList.SelectedObject;
            }
        }
		public Scenario LastScenario { get; set; } // When a user attempts a deselect on the ScenarioList, this property allows BareMinimum to role back to the previous selection.
		public JsonSerializerSettings JsonSettings { get; set; }

		#endregion

		#region Constructor and Delegates

		public MainWin()
        {
            InitializeComponent();
			MainSplit.SplitterWidth = 5; // If I set this in the designer, it messes up layout over time. 
			
			controlFont = ScenarioTree.Font;

            // Set up the TreeListView for display:
            ScenarioTree.CanExpandGetter = CanExpand;
            ScenarioTree.ChildrenGetter = GetChildren;

			// Set the AspectToStringConverters for the ScenarioList/ScenarioTree:
			ScenarioAverageColumn.AspectToStringConverter = ConvertScenarioAverageToString;
			ItemNeededColumn.AspectToStringConverter = ConvertPointsNeededToString;

			// Set the AspectToStringFormats for the ScenarioList/ScenarioTree:
			string format = "{0:0.##}";
			ScenarioTargetColumn.AspectToStringFormat = format;
			ItemPossibleColumn.AspectToStringFormat = format;
			ItemEarnedColumn.AspectToStringFormat = format;
			ItemWeightColumn.AspectToStringFormat = format;

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
            // CalculationTypeComboBox.SelectedItem = "Even";

			// Set up JsonSettings:
			JsonSettings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.All,
				TypeNameHandling = TypeNameHandling.All
			};
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
				return ((decimal)needed).ToString("0.##");
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
					DrawTextInCell(g, r, "Auto (" + section.Weight.ToString("0.##") + "%)");
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
				SelectedScenario.CalculateAutoSectionWeights();
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
			Calculations.CalculateNeeded(SelectedScenario);
			ScenarioTree.RefreshObjects(SelectedScenario.GetGrades());
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

		private void RegisterEvents(List<Scenario> list)
		{
			foreach (Scenario scenario in list)
			{
				if (scenario.Items.Count < 1)
					return;
				if (scenario.ItemType == ItemType.Section)
				{
					foreach (Section section in scenario.Items)
						RegisterEvents(section);
				}
				else if (scenario.ItemType == ItemType.Grade)
				{
					foreach (Grade grade in scenario.Items)
						RegisterEvents(grade);
				}
			}
		}

		private void RegisterEvents(Section section)
		{
			section.PropertyChanged += Section_PropertyChanged;
			
			if (section.Items.Count < 1)
				return;
			if (section.ItemType == ItemType.Section)
			{
				foreach (Section subSection in section.Items)
					RegisterEvents(subSection);
			}
			else if (section.ItemType == ItemType.Grade)
			{
				foreach (Grade grade in section.Items)
					RegisterEvents(grade);
			}
		}

		private void RegisterEvents(Grade grade)
		{
			grade.PropertyChanged += Grade_PropertyChanged;
		}

		#endregion

		#region File Methods

		private void SaveFile()
		{
			if (!String.IsNullOrWhiteSpace(FilePath))
				SaveFile(FilePath);
			else
				SaveFileAs();
		}

		private void SaveFileAs()
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.AddExtension = true;
			dialog.Title = "Save your list of scenarios...";
			dialog.Filter = "BareMinimum Files|*.bmin";
			dialog.DefaultExt = "bmin";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				FilePath = dialog.FileName;
				SaveFile(FilePath);
			}
		}

		private void SaveFile(string filePath)
		{
			try
			{
				string serialized = JsonConvert.SerializeObject(
					new List<Scenario>(ScenarioList.Objects.Cast<Scenario>()),
					Formatting.Indented,
					JsonSettings);
				File.WriteAllText(filePath, "BareMinimum File Format (Development)\n" + serialized);
			}
			catch (IOException e)
			{
				MessageBox.Show("I/O Error:\n" + e.Message);
			}
			catch (JsonSerializationException e)
			{
				MessageBox.Show("JSON Serialization Error:\n" + e.Message);
			}
		}

		private void OpenFile()
		{
			string path = "";
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.AddExtension = true;
			dialog.Title = "Open a list of scenarios...";
			dialog.Filter = "BareMinimum Files|*.bmin|All Files|*.*";
			dialog.DefaultExt = "bmin";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				path = dialog.FileName;
				OpenFile(path);
			}
		}

		private void OpenFile(string filePath)
		{
			try
			{
				List<string> fileContents = new List<string>(File.ReadAllLines(filePath));
				string versionText = fileContents[0];
				fileContents.RemoveAt(0);
				string json = fileContents[0];
				fileContents.RemoveAt(0);
				foreach (string line in fileContents)
					json += "\n" + line;
				List<Scenario> list = JsonConvert.DeserializeObject<List<Scenario>>(json, JsonSettings);
				RegisterEvents(list);
				ScenarioList.SetObjects(list);
				ScenarioList.SelectedIndex = 0;
				FilePath = filePath;
			}
			catch (IOException e)
			{
				MessageBox.Show("I/O Error:\n" + e.Message);
			}
			catch (JsonSerializationException e)
			{
				MessageBox.Show("JSON Serialization Error:\n" + e.Message);
			}
		}

		private void NewFile()
		{
			ScenarioTree.SetObjects(null);
			ScenarioList.ClearObjects();
			FilePath = null;
		}

		#endregion

		#region Editing Methods

		private void MoveTreeEditorUp()
		{
			switch (treeEditingColumnIndex)
			{
				case 0: // Name
				case 6: // Notes
					if (treeEditingRowIndex > 0)
					{
						ScenarioTree.FinishCellEdit();
						ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[treeEditingRowIndex - 1]), treeEditingColumnIndex);
					}
					break;
				case 1: // Weight
					if (treeEditingRowIndex > 0)
					{
						int nextIndex = treeEditingRowIndex;
						int upIndex = 0;
						bool canMove = false;
						while (true)
						{
							nextIndex--;
							if (nextIndex < 0)
								break;
							if (((OLVListItem)ScenarioTree.Items[nextIndex]).RowObject is Section)
							{
								upIndex = nextIndex;
								canMove = true;
								break;
							}
						}
						if (canMove)
						{
							ScenarioTree.FinishCellEdit();
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[upIndex]), treeEditingColumnIndex);
						}
					}
					break;
				case 2: // PointsEarned
				case 3: // PointsPossible
					if (treeEditingRowIndex > 0)
					{
						int nextIndex = treeEditingRowIndex;
						int upIndex = 0;
						bool canMove = false;
						while (true)
						{
							nextIndex--;
							if (nextIndex < 0)
								break;
							if (((OLVListItem)ScenarioTree.Items[nextIndex]).RowObject is Grade)
							{
								upIndex = nextIndex;
								canMove = true;
								break;
							}
						}
						if (canMove)
						{
							ScenarioTree.FinishCellEdit();
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[upIndex]), treeEditingColumnIndex);
						}
					}
					break;
				default:
					break;
			}
		}

		private void MoveTreeEditorDown()
		{
			switch (treeEditingColumnIndex)
			{
				case 0: // Name
				case 6: // Notes
					if (treeEditingRowIndex < ScenarioTree.Items.Count - 1)
					{
						ScenarioTree.FinishCellEdit();
						ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[treeEditingRowIndex + 1]), treeEditingColumnIndex);
					}
					break;
				case 1: // Weight
					if (treeEditingRowIndex < ScenarioTree.Items.Count - 1)
					{
						int nextIndex = treeEditingRowIndex;
						int downIndex = 0;
						bool canMove = false;
						while (true)
						{
							nextIndex++;
							if (nextIndex > ScenarioTree.Items.Count - 1)
								break;
							if (((OLVListItem)ScenarioTree.Items[nextIndex]).RowObject is Section)
							{
								downIndex = nextIndex;
								canMove = true;
								break;
							}
						}
						if (canMove)
						{
							ScenarioTree.FinishCellEdit();
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[downIndex]), treeEditingColumnIndex);
						}
					}
					break;
				case 2: // PointsEarned
				case 3: // PointsPossible
					if (treeEditingRowIndex < ScenarioTree.Items.Count - 1)
					{
						int nextIndex = treeEditingRowIndex;
						int downIndex = 0;
						bool canMove = false;
						while (true)
						{
							nextIndex++;
							if (nextIndex > ScenarioTree.Items.Count - 1)
								break;
							if (((OLVListItem)ScenarioTree.Items[nextIndex]).RowObject is Grade)
							{
								downIndex = nextIndex;
								canMove = true;
								break;
							}
						}
						if (canMove)
						{
							ScenarioTree.FinishCellEdit();
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[downIndex]), treeEditingColumnIndex);
						}
					}
					break;
				default:
					break;
			}
		}

		private void MoveListEditorUp()
		{
			if (listEditingRowIndex > 0)
			{
				ScenarioList.FinishCellEdit();
				ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex - 1]), listEditingColumnIndex);
			}
		}

		private void MoveListEditorDown()
		{
			if (listEditingRowIndex < ScenarioList.Items.Count - 1)
			{
				ScenarioList.FinishCellEdit();
				ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex + 1]), listEditingColumnIndex);
			}
		}

		#endregion

		#region Event Handlers

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (ScenarioList.IsCellEditing)
			{
				if (keyData.In(Keys.Up, Keys.Down))
				{
					ScenarioList_KeyDown(ScenarioList, new KeyEventArgs(keyData));
					return true;
				}
			}
			else if (ScenarioTree.IsCellEditing)
			{
				if (keyData.In(Keys.Up, Keys.Down))
				{
					ScenarioTree_KeyDown(ScenarioList, new KeyEventArgs(keyData));
					return true;
				}
			}
 			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void NewFileButton_Click(object sender, EventArgs e)
		{
			NewFile();
		}

		private void OpenFileButton_Click(object sender, EventArgs e)
		{
			OpenFile();
		}

		private void SaveFileButton_Click(object sender, EventArgs e)
		{
			SaveFile();
		}

		private void SaveAsFileButton_Click(object sender, EventArgs e)
		{
			SaveFileAs();
		}

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

		private void ScenarioList_CellEditStarting(object sender, CellEditEventArgs e)
		{
			listEditingColumnIndex = e.SubItemIndex;
			listEditingRowIndex = e.ListViewItem.Index;
		}

        private void ScenarioList_KeyDown(object sender, KeyEventArgs e)
        {
			switch (e.KeyCode)
			{
				case Keys.Down:
					MoveListEditorDown();
					break;
				case Keys.Up:
					MoveListEditorUp();
					break;
				case Keys.Delete:
					if (SelectedScenario != null)
					{
						DeleteScenario(SelectedScenario);
					}
					break;
				default:
					break;
			}
        }

        private void ScenarioList_SelectionChanged(object sender, EventArgs e)
        {
            if (ScenarioList.Items.Count > 0)
            {
                // If the user clicks off of an item, but the list isn't empty, ignore it.
				if (SelectedScenario != null)
				{
					if (LastScenario != null)
						LastScenario.PropertyChanged -= Scenario_PropertyChanged;
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
					LastScenario = SelectedScenario;
				}
				else
				{
					ScenarioList.SelectObject(LastScenario);
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
            if (e.Model is Section)
            {
				if (e.Column == ItemMarkedColumn)
				{
					CellBorderDecoration background = new CellBorderDecoration();
					background.FillBrush = Brushes.White;
					background.BorderPen = null;
					background.CornerRounding = 0F;
					background.BoundsPadding = new Size(0, -1);
					CellBorderDecoration highlight = new CellBorderDecoration();
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
            else if (e.Model is Grade)
            {
				e.SubItem.Decorations.Clear();
            }
        }

        private void ScenarioTree_KeyDown(object sender, KeyEventArgs e)
        {
			switch (e.KeyCode)
			{
				case Keys.Down:
					MoveTreeEditorDown();
					break;
				case Keys.Up:
					MoveTreeEditorUp();
					break;
				case Keys.Delete:
					DeleteItem();
					break;
				default:
					break;
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
			treeEditingColumnIndex = e.SubItemIndex;
			treeEditingRowIndex = e.ListViewItem.Index;
            if (e.RowObject is Section)
            {
                switch (e.Column.Index)
                {
                    case 2:
                    case 3:
					case 4:
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
					case 4:
                    case 5:
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
				ScenarioTree.RefreshObjects(SelectedScenario.Items);
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

		private void HelpToolbarButton_Click(object sender, EventArgs e)
		{
			Process.Start("http://bareminimum.codeplex.com/documentation");
		}

		#endregion
	}
}