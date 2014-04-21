using BareMinimumCore;
using BrightIdeasSoftware;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BareMinimum
{
    public partial class MainWin : Form
	{
		#region Properties and Fields

		private string noScenariosText = "Add a scenario to get started.";
		private string scenarioEmptyText = "Add some items to this scenario.";

		private TextOverlay emptyOverlay = new TextOverlay();
		private Font controlFont;
		private string filePath;
		private OLVColumn listEditingColumn;
		private OLVColumn treeEditingColumn;
		private int listEditingRowIndex;
		private int treeEditingRowIndex;
		private object editingObject;
		private bool treeIsEditing = false;
		private bool listIsEditing = false;
		private bool fileIsSaved = true;
		private Scenario currentScenario;
		private List<OLVColumn> SectionNonEditableColumns = new List<OLVColumn>();
		private List<OLVColumn> GradeNonEditableColumns = new List<OLVColumn>();

		public bool FileIsSaved
		{
			get { return fileIsSaved; }
			set 
			{
				fileIsSaved = value;
				SetFileText();
			}
		}

		private string FilePath
		{
			get
			{
				return filePath;
			}
			set
			{
				filePath = value;
				SetFileText();
			}
		}

		public Scenario CurrentScenario
		{
			get
			{
				return currentScenario;
			}
			set
			{
				currentScenario = value;
				if (value == null)
				{
					AddGradeButton.Enabled = false;
					AddSectionButton.Enabled = false;
					ScenarioTitleLabel.Text = "No Scenario Selected";
					DeleteButton.Enabled = false;
					emptyOverlay.Text = "Add a scenario to get started.";
					ScenarioTree.SetObjects(null);
				}
				else
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
					DeleteButton.Enabled = true;
					ScenarioTitleLabel.Text = SelectedScenario.Name;
					LastScenario = SelectedScenario;
				}
				ScenarioList.RefreshObjects(new List<object>(ScenarioList.Objects.Cast<object>())); // This horrible hack is the only way to force the ScenarioList to refresh row decorations.
			}
		} // This refers to the Scenario actually "selected" in the interface, regardless of whether it is selected in the ScenarioList.

        public Scenario SelectedScenario
        {
            get
            {
                return (Scenario)ScenarioList.SelectedObject;
            }
        } // This read-only property is a shortcut to get the Scenario that is selected in the ScenarioList.
		public Scenario LastScenario { get; set; } // This property is used to remove events from deselected Scenarios.
		public JsonSerializerSettings JsonSettings { get; set; }

		#endregion

		#region Constructor and Overrides

		public MainWin()
        {
            InitializeComponent();
			MainSplit.SplitterWidth = 5; // If I set this in the designer, it messes up layout over time. 
			
			controlFont = ScenarioTree.Font;

			SectionNonEditableColumns.AddRange(new List<OLVColumn> { 
				ItemEarnedColumn,
				ItemPossibleColumn, 
				ItemNeededColumn,
				ItemMarkedColumn,
				ItemOptionsColumn
			});
			GradeNonEditableColumns.AddRange(new List<OLVColumn> { 
				ItemWeightColumn, 
				ItemNeededColumn,
				ItemMarkedColumn,
				ItemOptionsColumn
			});

			ScenarioList.PrimarySortColumn = ScenarioNameColumn;

            // Set up the TreeListView for display:
            ScenarioTree.CanExpandGetter = CanExpand;
            ScenarioTree.ChildrenGetter = GetChildren;

			// Set the AspectToStringConverters for the ScenarioList/ScenarioTree:
			ScenarioAverageColumn.AspectToStringConverter = ConvertGradeToString;

			// Set the AspectToStringFormats for the ScenarioList/ScenarioTree:
			string format = "{0:0.##}";
			ScenarioTargetColumn.AspectToStringFormat = format;
			ItemPossibleColumn.AspectToStringFormat = format;
			ItemEarnedColumn.AspectToStringFormat = format;
			ItemWeightColumn.AspectToStringFormat = format;

			// Set the RenderDelegates for the ScenarioTree:
			ItemNeededColumn.RendererDelegate = RenderItemNeeded;
			ItemWeightColumn.RendererDelegate = RenderItemWeight;
			ItemEarnedColumn.RendererDelegate = RenderItemEarned;
			ItemOptionsColumn.RendererDelegate = RenderItemOptions;

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
			emptyOverlay.Text = noScenariosText;
            ScenarioList.EmptyListMsgOverlay = emptyOverlay;
            ScenarioTree.EmptyListMsgOverlay = emptyOverlay;

			// Customize the decoration for the selected item:
			RowBorderDecoration selectedDecoration = new RowBorderDecoration(); 
			selectedDecoration.BorderPen = new Pen(Color.FromArgb(128, Color.Black), 1); 
			selectedDecoration.BoundsPadding = new Size(-1, -1);
			selectedDecoration.FillBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0));
			selectedDecoration.CornerRounding = 0f;
			ScenarioTree.SelectedRowDecoration = selectedDecoration;
			ScenarioList.SelectedRowDecoration = selectedDecoration;

			// Customize the decoration for the hot item:
			RowBorderDecoration hotItemDecoration = new RowBorderDecoration();
			hotItemDecoration.BorderPen = new Pen(Color.FromArgb(75, Color.Black), 1);
			hotItemDecoration.BoundsPadding = new Size(-1, -1);
			hotItemDecoration.FillBrush = new SolidBrush(Color.FromArgb(10, 0, 0, 0));
			hotItemDecoration.CornerRounding = 0f;
			ScenarioTree.HotItemStyle.Decoration = hotItemDecoration;
			ScenarioList.HotItemStyle.Decoration = hotItemDecoration;

            // Set the drop down:
            // CalculationTypeComboBox.SelectedItem = "Even";

			// Set up JsonSettings:
			JsonSettings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.All,
				TypeNameHandling = TypeNameHandling.All
			};
        }

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Control | Keys.O: // Shortcut for "Open File"
					OpenFile();
					return true;
				case Keys.Control | Keys.S: // Shortcut for "Save File"
					SaveFile();
					return true;
				case Keys.Control | Keys.N: // Shortcut for "New File"
					NewFile();
					return true;
				default:
					if (keyData.In(Keys.Up, Keys.Down, Keys.Tab, Keys.Shift | Keys.Tab)) // Navigation keys
					{
						if (listIsEditing)
						{
							ScenarioList_KeyDown(ScenarioList, new KeyEventArgs(keyData));
							return true;
						}
						else if (treeIsEditing)
						{
							ScenarioTree_KeyDown(ScenarioTree, new KeyEventArgs(keyData));
							return true;
						}
					}
					return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		#endregion

		#region Delegates

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

		// AspectToStringConverter for ItemNeededColumn and ScenarioAverageColumn.
		private string ConvertGradeToString(object x)
		{
			decimal? grade = (decimal?)x;
			if (grade != null)
			{
				string sGrade;
				string letter;
				if (grade >= 89.5M)
					letter = "A";
				else if (grade >= 79.5M)
					letter = "B";
				else if (grade >= 69.5M)
					letter = "C";
				else if (grade >= 59.5M)
					letter = "D";
				else
					letter = "F";
				sGrade = letter + " " + ((decimal)grade).ToString("(0.##)");
				return sGrade;
			}
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

		// RendererDelegate for ItemNeededColumn
		private bool RenderItemNeeded(EventArgs e, Graphics g, Rectangle r, object model)
		{
			if (model is Section)
			{
				g.FillRectangle(Brushes.White, r);
			}
			else if (model is Grade)
			{
				Grade grade = (Grade)model;
				if (grade.PointsNeeded == null)
					g.FillRectangle(Brushes.White, r);
				else
				{
					String gradeText = ((decimal)grade.PointsNeeded).ToString("0.##") +
						" (" + 
						Calculations.GetLetterGrade((decimal)grade.PointsNeeded, grade.PointsPossible, GradeRounding.Standard) + 
						" - " + 
						Math.Round((decimal)grade.PointsNeeded / grade.PointsPossible * 100) +
						"%)";
					DrawTextInCell(g, r, gradeText);
				}
			}
			return true;
		}

		// RendererDelegate for ItemOptionsColumn
		private bool RenderItemOptions(EventArgs e, Graphics g, Rectangle r, object model)
		{
			g.FillRectangle(Brushes.White, r);
			
			if (model is Grade)
			{
				Grade grade = (Grade)model;
				if (grade.IsExtraCredit)
				{
					g.DrawImageUnscaled(Properties.Resources.extracredit, r.X + 4, r.Y + 6); 
				}
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
				CurrentScenario.CalculateAutoSectionWeights();
			}
			else
			{
				section.AutoWeighted = true;
				CurrentScenario.CalculateAutoSectionWeights();
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
			bool extraCredit = value.ToString().ToLower().StartsWith("e");
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

		#endregion

		#region GUI Methods

		private void DrawTextInCell(Graphics g, Rectangle r, String text)
		{
			DrawTextInCell(g, r, text, Color.Black);
		}

		private void DrawTextInCell(Graphics g, Rectangle r, String text, Color color)
		{
			// Fill backgroud:
			g.FillRectangle(Brushes.White, r);
			
			// Create the StringFormat:
			StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
			format.LineAlignment = StringAlignment.Center;
			format.Alignment = StringAlignment.Near;
			format.Trimming = StringTrimming.EllipsisCharacter;

			// Draw the text:
			g.DrawString(text, controlFont, new SolidBrush(color), r, format);
		}

		private void SetFileText()
		{
			string text;
			if (String.IsNullOrWhiteSpace(filePath))
				text = "Unsaved File";
			else
				text = Path.GetFileName(filePath);
			if (!fileIsSaved)
				text += "*";
			FileLabel.Text = text;
		}

		#endregion

		#region Data Methods

		// Calls the Calculations class to actually do the "needed" calculation.
		private void CalculateNeeded()
		{
			Calculations.CalculateNeeded(CurrentScenario);
			ScenarioTree.RefreshObjects(CurrentScenario.GetGrades());
		}

        private void DeleteScenario(Scenario scenario)
        {
			int index = ScenarioList.SelectedIndex;
            ScenarioList.RemoveObject(scenario);
			if (ScenarioList.Items.Count < 1)
			{
				CurrentScenario = null;
			}
			else
			{
				if (index != 0)
					ScenarioList.SelectedIndex = index - 1;
				else
					ScenarioList.SelectedIndex = 0;
			}
			FileIsSaved = false;
        }

        private void DeleteItem()
        {
            if (CurrentScenario != null && ScenarioTree.SelectedObject != null)
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
                CurrentScenario.Items.Remove(item);
                ScenarioTree.RemoveObject(item);
				ScenarioTree_SelectionChanged(ScenarioTree, new EventArgs());
            }
            else
            {
                parent.Items.Remove(item);
                ScenarioTree.RefreshObject(parent);
				ScenarioTree_SelectionChanged(ScenarioTree, new EventArgs());
            }
			CurrentScenario.CalculateAutoSectionWeights();
			ScenarioList.RefreshObject(CurrentScenario);
			FileIsSaved = false;
        }

		private void RegisterEvents(List<Scenario> list)
		{
			foreach (Scenario scenario in list)
			{
				scenario.Items.CollectionChanged += Items_CollectionChanged;
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
			section.Items.CollectionChanged += Items_CollectionChanged;

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

		// This is called when the save button is pushed or a shortcut is used.
		private void SaveFile()
		{
			if (!String.IsNullOrWhiteSpace(FilePath))
				SaveFile(FilePath);
			else
				SaveFileAs();
		}

		// This is called when the file doesn't yet exist on disk.
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

		// The actual save method.
		private void SaveFile(string filePath)
		{
			InfoOverlay overlay = new InfoOverlay(this, new Label { Text = "Saving " + Path.GetFileName(filePath) + "..." }, false);
			try
			{
				string serialized = JsonConvert.SerializeObject(
					new List<Scenario>(ScenarioList.Objects.Cast<Scenario>()),
					Formatting.Indented,
					JsonSettings);
				File.WriteAllText(filePath, "1.1\n" + serialized);
				FileIsSaved = true;
			}
			catch (IOException e)
			{
				MessageBox.Show("I/O Error:\n" + e.Message);
			}
			catch (JsonSerializationException e)
			{
				MessageBox.Show("JSON Serialization Error:\n" + e.Message);
			}
			finally
			{
				overlay.Close(); 
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
			InfoOverlay overlay = new InfoOverlay(this, new Label { Text = "Opening " + Path.GetFileName(filePath) + "...", AutoSize = false, Width = 200 }, false);
			List<string> fileContents;
			try
			{
				fileContents = new List<string>(File.ReadAllLines(filePath));
			}
			catch (IOException e)
			{
				MessageBox.Show("I/O Error:\n" + e.Message);
				goto DoneOpening;
			}

			string versionText = fileContents[0];
			double version;
			if (Double.TryParse(versionText.Trim(), out version))
			{
				if (version > 1.1)
				{
					MessageBox.Show("This file is from a newer version of BareMinimum. Download the newest version of BareMinimum to open it.");
					goto DoneOpening;
				}
			}
			else
			{
				MessageBox.Show("This file is from an older version of BareMinimum and cannot be read.");
				goto DoneOpening;
			}
			fileContents.RemoveAt(0);
			string json = fileContents[0];
			fileContents.RemoveAt(0);
			foreach (string line in fileContents)
				json += "\n" + line;
			List<Scenario> list;

			try
			{
				list = JsonConvert.DeserializeObject<List<Scenario>>(json, JsonSettings);
			}
			catch (JsonSerializationException e)
			{
				MessageBox.Show("JSON Serialization Error:\n" + e.Message);
				goto DoneOpening;
			}

			foreach (Scenario scenario in list)
			{
				Calculations.CalculateNeeded(scenario);
			}
			RegisterEvents(list);
			ScenarioList.SetObjects(list);
			ScenarioList.SelectedIndex = 0;
			FilePath = filePath;
			FileIsSaved = true;

		DoneOpening:
			overlay.Close();
			return;
		}

		private void NewFile()
		{
			emptyOverlay.Text = noScenariosText;
			ScenarioTree.SetObjects(null);
			ScenarioList.ClearObjects();
			FilePath = null;
			FileIsSaved = true;
		}

		#endregion

		#region Editing Methods

		private void MoveTreeEditorUp()
		{
			if (treeIsEditing)
			{
				if (treeEditingRowIndex > 0)
				{
					if (!SectionNonEditableColumns.Contains(treeEditingColumn) && !GradeNonEditableColumns.Contains(treeEditingColumn))
					{
						ScenarioTree.FinishCellEdit();
						ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[treeEditingRowIndex - 1]), treeEditingColumn.DisplayIndex);
					}
					else if (!SectionNonEditableColumns.Contains(treeEditingColumn))
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
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[upIndex]), treeEditingColumn.DisplayIndex);
						}
					}
					else
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
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[upIndex]), treeEditingColumn.DisplayIndex);
						}
					}
				}
			}
		}

		private void MoveTreeEditorDown()
		{
			if (treeIsEditing)
			{
				if (treeEditingRowIndex < ScenarioTree.Items.Count - 1)
				{
					if (!SectionNonEditableColumns.Contains(treeEditingColumn) && !GradeNonEditableColumns.Contains(treeEditingColumn))
					{
						ScenarioTree.FinishCellEdit();
						ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[treeEditingRowIndex + 1]), treeEditingColumn.DisplayIndex);
					}
					else if (!SectionNonEditableColumns.Contains(treeEditingColumn))
					{
						int nextIndex = treeEditingRowIndex;
						int downIndex = 0;
						bool canMove = false;
						while (true)
						{
							nextIndex++;
							if (nextIndex < ScenarioTree.Items.Count - 1)
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
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[downIndex]), treeEditingColumn.DisplayIndex);
						}
					}
					else
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
							ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[downIndex]), treeEditingColumn.DisplayIndex);
						}
					}
				}
			}
		}

		private void MoveTreeEditorLeft()
		{
			if (treeIsEditing)
			{
				if (editingObject != null)
				{
					int currentIndex = treeEditingColumn.DisplayIndex;
					int newRowIndex = treeEditingRowIndex;
					Type objectType = editingObject.GetType();
				start:
					if (currentIndex == 0)
					{
						newRowIndex--;
						if (newRowIndex < 0)
							return; // We're in the first cell in the first row; there's nowhere to move left to. 
						currentIndex = ScenarioTree.ColumnsInDisplayOrder.Count;
						if (((OLVListItem)ScenarioTree.Items[newRowIndex]).RowObject is Grade)
 							objectType = typeof(Grade);
						else if (((OLVListItem)ScenarioTree.Items[newRowIndex]).RowObject is Section)
							objectType = typeof(Section);
					}
					int newColumnIndex;
					while (true)
					{
						OLVColumn potentialColumn = ScenarioTree.ColumnsInDisplayOrder[currentIndex - 1];
						List<OLVColumn> nonEditableColumns = SectionNonEditableColumns;
						if (objectType == typeof(Grade))
							nonEditableColumns = GradeNonEditableColumns;
						if (!nonEditableColumns.Contains(potentialColumn))
						{
							newColumnIndex = currentIndex - 1;
							break;
						}
						else
						{
							currentIndex--;
							if (currentIndex == 0)
								goto start;
						}
					}
					ScenarioTree.FinishCellEdit();
					ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[newRowIndex]), newColumnIndex);
				}
			}
		}
		
		private void MoveTreeEditorRight()
		{
			if (treeIsEditing)
			{
				if (editingObject != null)
				{
					int currentIndex = treeEditingColumn.DisplayIndex;
					int newRowIndex = treeEditingRowIndex;
					Type objectType = editingObject.GetType();
				start:
					if (currentIndex == ScenarioTree.ColumnsInDisplayOrder.Count - 1)
					{
						newRowIndex++;
						if (newRowIndex >= ScenarioTree.Items.Count)
							return; // We're in the last cell in the last row; there's nowhere to move right to. 
						currentIndex = -1;
						if (((OLVListItem)ScenarioTree.Items[newRowIndex]).RowObject is Grade)
							objectType = typeof(Grade);
						else if (((OLVListItem)ScenarioTree.Items[newRowIndex]).RowObject is Section)
							objectType = typeof(Section);
					}
					int newColumnIndex;
					while (true)
					{
						OLVColumn potentialColumn = ScenarioTree.ColumnsInDisplayOrder[currentIndex + 1];
						List<OLVColumn> nonEditableColumns = SectionNonEditableColumns;
						if (objectType == typeof(Grade))
							nonEditableColumns = GradeNonEditableColumns;
						if (!nonEditableColumns.Contains(potentialColumn))
						{
							newColumnIndex = currentIndex + 1;
							break;
						}
						else
						{
							currentIndex++;
							if (currentIndex == ScenarioTree.ColumnsInDisplayOrder.Count - 1)
								goto start;
						}
					}
					ScenarioTree.FinishCellEdit();
					ScenarioTree.StartCellEdit((OLVListItem)(ScenarioTree.Items[newRowIndex]), newColumnIndex);
				}
			}
		} 
		
		private void MoveListEditorUp()
		{
			if (listIsEditing)
			{
				if (listEditingRowIndex > 0)
				{
					ScenarioList.FinishCellEdit();
					ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex - 1]), listEditingColumn.Index);
				}
			}
		}

		private void MoveListEditorDown()
		{
			if (listIsEditing)
			{
				if (listEditingRowIndex < ScenarioList.Items.Count - 1)
				{
					ScenarioList.FinishCellEdit();
					ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex + 1]), listEditingColumn.Index);
				}
			}
		}

		private void MoveListEditorLeft()
		{
			if (listIsEditing)
			{
				if (listEditingColumn.DisplayIndex == 0)
				{
					if (listEditingRowIndex > 0)
					{
						ScenarioList.FinishCellEdit();
						ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex - 1]), ScenarioList.Columns.Count - 1);
					}
				}
				else if (listEditingColumn.DisplayIndex == ScenarioList.Columns.Count - 1)
				{
					ScenarioList.FinishCellEdit();
					ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex]), 0);
				}
			}
		}

		private void MoveListEditorRight()
		{
			if (listIsEditing)
			{
				if (listEditingColumn.DisplayIndex == 0)
				{
					ScenarioList.FinishCellEdit();
					ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex]), ScenarioList.Columns.Count - 1);
				}
				else if (listEditingColumn.DisplayIndex == ScenarioList.Columns.Count - 1)
				{
					if (listEditingRowIndex < ScenarioList.Items.Count - 1)
					{
						ScenarioList.FinishCellEdit();
						ScenarioList.StartCellEdit((OLVListItem)(ScenarioList.Items[listEditingRowIndex + 1]), 0);
					}
				}
			}
		}

		#endregion

		#region Event Handlers

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!FileIsSaved)
			{
				switch (MessageBox.Show("Save " + FileLabel.Text.TrimEnd('*') + "?", "Save File?", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						SaveFile();
						break;
					case DialogResult.No:
						// Nothing to do here.
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
					default:
						break;
				}
			}
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
            Scenario newScenario = new Scenario("Untitled");
            ScenarioList.AddObject(newScenario);
            ScenarioList.SelectObject(newScenario);
            emptyOverlay.Text = scenarioEmptyText;
            DeleteButton.Enabled = true;
			FileIsSaved = false;
        }

        private void AddSectionButton_Click(object sender, EventArgs e)
        {
            // Determine if the scenario or a section is selected, and act accordingly:
            if (ScenarioTree.SelectedObject == null)
            {
                // Add a new Section to the Scenario:
				Section newSection = new Section(CurrentScenario);
				newSection.PropertyChanged += Section_PropertyChanged;
                CurrentScenario.Items.Add(newSection);
                ScenarioTree.SetObjects(CurrentScenario.Items);
            }
            else
            {
                Section container = ((Section)ScenarioTree.SelectedObject);
				Section newSection = new Section(container);
				newSection.PropertyChanged += Section_PropertyChanged;
                container.Items.Add(newSection);
                ScenarioTree.RefreshObject(container);
                if (!ScenarioTree.IsExpanded(container))
                    ScenarioTree.Expand(container);
            }
			FileIsSaved = false;
			CurrentScenario.CalculateAutoSectionWeights();
            AddGradeButton.Enabled = false;
        }

        private void AddGradeButton_Click(object sender, EventArgs e)
        {
            // Determine if the scenario or a section is selected, and act accordingly:
            if (ScenarioTree.SelectedObject == null)
            {
                Scenario container = CurrentScenario;
                // Add a new Grade to the Scenario:
				Grade newGrade = new Grade(CurrentScenario);
				newGrade.PropertyChanged += Grade_PropertyChanged;
                container.Items.Add(newGrade);
                ScenarioTree.SetObjects(CurrentScenario.Items);
            }
            else
            {
                Section container = ((Section)ScenarioTree.SelectedObject);
				Grade newGrade = new Grade(container);
				newGrade.PropertyChanged += Grade_PropertyChanged;
				container.Items.Add(newGrade);
                ScenarioTree.RefreshObject(container);
                if (!ScenarioTree.IsExpanded(container))
                    ScenarioTree.Expand(container);
            }
			FileIsSaved = false;
            AddSectionButton.Enabled = false;
        }

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (ScenarioList.SelectedObject != null)
				DeleteScenario(SelectedScenario);
			else if (ScenarioTree.SelectedObject != null)
				DeleteItem();
		}

		private void ScenarioList_FormatRow(object sender, FormatRowEventArgs e)
		{
			if (e.Model == CurrentScenario)
			{
				RowBorderDecoration currentScenarioDecoration = new RowBorderDecoration();
				currentScenarioDecoration.BorderPen = null;
				currentScenarioDecoration.CornerRounding = 0F;
				currentScenarioDecoration.BoundsPadding = new Size(-1, -1);
				currentScenarioDecoration.FillBrush = new SolidBrush(Color.FromArgb(50, 0, 200, 200));
				e.Item.Decoration = currentScenarioDecoration;

				ImageDecoration arrowDecoration = new ImageDecoration(Properties.Resources.rightarrow, 256);
				e.Item.Decorations.Add(arrowDecoration);
			}
			else
			{
				e.Item.Decorations.Clear();
			}
		}

		private void ScenarioList_CellEditStarting(object sender, CellEditEventArgs e)
		{
			listEditingColumn = e.Column;
			listEditingRowIndex = e.ListViewItem.Index;
			listIsEditing = true;
			editingObject = e.RowObject;
		}

		private void ScenarioList_CellEditFinishing(object sender, CellEditEventArgs e)
		{
			listIsEditing = false;
		}

        private void ScenarioList_KeyDown(object sender, KeyEventArgs e)
        {
			switch (e.KeyData)
			{
				case Keys.Down:
					MoveListEditorDown();
					break;
				case Keys.Up:
					MoveListEditorUp();
					break;
				case Keys.Shift | Keys.Tab:
					MoveListEditorLeft();
					break;
				case Keys.Tab:
					MoveListEditorRight();
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
				if (SelectedScenario != null)
					CurrentScenario = SelectedScenario;
				else
					DeleteButton.Enabled = false;
			}
			else
			{
				CurrentScenario = null;
			}
        }

		private void ScenarioList_Leave(object sender, EventArgs e)
		{
			ScenarioList.SelectedItem = null;
			ScenarioList.Refresh();
			DeleteButton.Enabled = false;
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
			switch (e.KeyData)
			{
				case Keys.Down:
					MoveTreeEditorDown();
					break;
				case Keys.Up:
					MoveTreeEditorUp();
					break;
				case Keys.Shift | Keys.Tab:
					MoveTreeEditorLeft();
					break;
				case Keys.Tab:
					MoveTreeEditorRight();
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
                if (CurrentScenario != null) // Make sure we actually have a Scenario in the tree.
                {
                    switch (CurrentScenario.ItemType)
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
                DeleteButton.Enabled = false;
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
                DeleteButton.Enabled = true;
            }
            else
            {
                AddSectionButton.Enabled = false;
                AddGradeButton.Enabled = false;
                DeleteButton.Enabled = true;
            }
        }

        private void ScenarioTree_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
			treeEditingColumn = e.Column;
			treeEditingRowIndex = e.ListViewItem.Index;
			editingObject = e.RowObject;
			if (e.RowObject is Section)
			{
				if (SectionNonEditableColumns.Contains(e.Column))
					e.Cancel = true;
				if (e.Column == ItemOptionsColumn)
				{ }	// Currently, Sections have no options to set, so there's no editor for this.
			}
			else if (e.RowObject is Grade)
			{
				if (GradeNonEditableColumns.Contains(e.Column))
					e.Cancel = true;
				if (e.Column == ItemOptionsColumn)
				{
					Dictionary<string, bool> options = new Dictionary<string, bool>();
					options.Add("Extra Credit", ((Grade)e.RowObject).IsExtraCredit);
					ItemOptionsDialog optionsDialog = new ItemOptionsDialog(options);
					Dictionary<string, bool> results;
					if (optionsDialog.ShowDialog(out results) == DialogResult.OK)
					{
						bool extraCredit;
						results.TryGetValue("Extra Credit", out extraCredit);
						((Grade)e.RowObject).IsExtraCredit = extraCredit;
					}
				}
			}
            if (!e.Cancel)
				treeIsEditing = true;
		}

		private void ScenarioTree_CellEditFinishing(object sender, CellEditEventArgs e)
		{
			treeIsEditing = false;
		}

		private void ScenarioTree_Leave(object sender, EventArgs e)
		{
			ScenarioTree.SelectedItem = null;
			ScenarioTree.Refresh();
			DeleteButton.Enabled = false;
		}

		private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			FileIsSaved = false;
		}

		private void Section_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Weight")
			{
				CalculateNeeded();
				ScenarioList.RefreshObject(CurrentScenario);
				ScenarioTree.RefreshObjects(CurrentScenario.Items);
			}
			FileIsSaved = false;
		}

		private void Grade_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Marked":
				case "PointsEarned":
				case "PointsPossible":
					CalculateNeeded();
					ScenarioList.RefreshObject(CurrentScenario);
					break;
				default:
					break;
			}
			FileIsSaved = false;
		}

		private void Scenario_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Name":
					ScenarioTitleLabel.Text = CurrentScenario.Name;
					break;
				case "Target":
					CalculateNeeded();
					break;
				default:
					break;
			}
			FileIsSaved = false;
		}

		private void OnlineHelpMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://bareminimum.codeplex.com/documentation");
		}

		private void BugReportMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://bareminimum.codeplex.com/discussions");
		}

		private void aboutBareMinimumToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InfoOverlay about = new InfoOverlay(this, new AboutBox(), true);
		}

		#endregion
	}
}