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
        public Scenario SelectedScenario
        {
            get
            {
                return (Scenario)ScenarioList.SelectedObject;
            }
        }

        public MainWin()
        {
            InitializeComponent();

            // Set up the TreeListView for display:
            ScenarioTree.CanExpandGetter = CanExpand;
            ScenarioTree.ChildrenGetter = GetChildren;

            // Customize the overlay for an empty list for both ObjectListViews:
            TextOverlay emptyOverlay = new TextOverlay();
            emptyOverlay.Alignment = ContentAlignment.TopCenter;
            emptyOverlay.BackColor = Color.Transparent;
            emptyOverlay.BorderWidth = 0.0F;
            emptyOverlay.TextColor = Color.Black;
            emptyOverlay.Font = ScenarioTree.Font;
            ScenarioList.EmptyListMsgOverlay = emptyOverlay;
            ScenarioTree.EmptyListMsgOverlay = emptyOverlay;

            // Set the drop down:
            CalculationTypeComboBox.SelectedItem = "Even";
        }

        // Delegate that tells the ScenarioTree when it can expand an item:
        public bool CanExpand(object item)
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
        public ArrayList GetChildren(object item)
        {
            if (item is Section)
                return new ArrayList(((Section)item).Items);
            else
                return new ArrayList();
        }

        private void DeleteScenario(Scenario scenario)
        {
            ScenarioList.RemoveObject(scenario);
            if (ScenarioList.Items.Count < 1)
            {
                AddGradeButton.Enabled = false;
                AddSectionButton.Enabled = false;
                ScenarioTitleLabel.Text = "No Scenario Selected";
                DeleteScenarioButton.Enabled = false;
                DeleteItemButton.Enabled = false;
            }
        }

        private void DeleteItem()
        {
            if (SelectedScenario != null && ScenarioTree.SelectedObject != null)
            {
                Item item = (Item)ScenarioTree.SelectedObject;
                Section parent = (Section)ScenarioTree.GetParent(item);
                DeleteItem(item, parent);
            }
        }

        private void DeleteItem(Item item, Section parent)
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
        }

        private void AddScenarioButton_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Type a name for the new scenario.", "New Scenario", "Untitled");
            Scenario scenario = new Scenario { Name = name, ItemType = ItemType.None };
            ScenarioList.AddObject(scenario);
            ScenarioList.SelectObject(scenario);
            ScenarioTree.EmptyListMsg = "Add some items to this scenario.";
            DeleteScenarioButton.Enabled = true;
        }

        private void AddSectionButton_Click(object sender, EventArgs e)
        {
            // Determine if the scenario or a section is selected, and act accordingly:
            if (ScenarioTree.SelectedObject == null)
            {
                // Add a new Grade to the Scenario:
                SelectedScenario.ItemType = ItemType.Section;
                SelectedScenario.Items.Add(new Section());
                ScenarioTree.SetObjects(SelectedScenario.Items);
            }
            else
            {
                Section container = ((Section)ScenarioTree.SelectedObject);
                container.ItemType = ItemType.Section;
                container.Items.Add(new Section());
                ScenarioTree.RefreshObject(container);
                if (!ScenarioTree.IsExpanded(container))
                    ScenarioTree.Expand(container);
            }
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
                container.Items.Add(new Grade());
                ScenarioTree.SetObjects(SelectedScenario.Items);
            }
            else
            {
                Section container = ((Section)ScenarioTree.SelectedObject);
                container.ItemType = ItemType.Grade;
                container.Items.Add(new Grade());
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
                }
            }
        }
        
        private void ScenarioTree_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Model is Section)
            {
                CellBorderDecoration fill = new CellBorderDecoration();
                fill.FillBrush = Brushes.White;
                fill.BorderPen = null;
                fill.CornerRounding = 0F;
                fill.BoundsPadding = new Size(0, -1);
                e.SubItem.Decoration = fill;
            }
            else
            {
                e.SubItem.Decoration = null;
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
                        //((Grade)e.RowObject).Marked = !((Grade)e.RowObject).Marked;
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}