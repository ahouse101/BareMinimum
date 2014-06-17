namespace BareMinimum
{
    partial class MainWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.MainSplit = new System.Windows.Forms.SplitContainer();
			this.ScenarioListLabel = new System.Windows.Forms.Label();
			this.ScenarioList = new BrightIdeasSoftware.ObjectListView();
			this.ScenarioNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ScenarioAverageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ScenarioTargetColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ScenarioTree = new BrightIdeasSoftware.TreeListView();
			this.ItemNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemWeightColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemEarnedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemPossibleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemMarkedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemNeededColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemOptionsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemNotesColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.FlagList = new System.Windows.Forms.ImageList(this.components);
			this.SelectedScenarioLabel = new System.Windows.Forms.Label();
			this.ScenarioTitleLabel = new System.Windows.Forms.Label();
			this.DataToolbar = new BareMinimum.ToolbarEx();
			this.AddScenarioButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.AddSectionButton = new System.Windows.Forms.ToolStripButton();
			this.AddGradeButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.DeleteButton = new System.Windows.Forms.ToolStripButton();
			this.FileToolbar = new BareMinimum.ToolbarEx();
			this.NewFileButton = new System.Windows.Forms.ToolStripButton();
			this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveFileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveAsFileButton = new System.Windows.Forms.ToolStripButton();
			this.FileLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.HelpToolbarButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.onlineHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bugReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutBareMinimumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
			this.MainSplit.Panel1.SuspendLayout();
			this.MainSplit.Panel2.SuspendLayout();
			this.MainSplit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScenarioList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ScenarioTree)).BeginInit();
			this.DataToolbar.SuspendLayout();
			this.FileToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainSplit
			// 
			this.MainSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.MainSplit.Location = new System.Drawing.Point(5, 55);
			this.MainSplit.Name = "MainSplit";
			// 
			// MainSplit.Panel1
			// 
			this.MainSplit.Panel1.Controls.Add(this.ScenarioListLabel);
			this.MainSplit.Panel1.Controls.Add(this.ScenarioList);
			this.MainSplit.Panel1MinSize = 150;
			// 
			// MainSplit.Panel2
			// 
			this.MainSplit.Panel2.Controls.Add(this.ScenarioTree);
			this.MainSplit.Panel2.Controls.Add(this.SelectedScenarioLabel);
			this.MainSplit.Panel2MinSize = 420;
			this.MainSplit.Size = new System.Drawing.Size(875, 500);
			this.MainSplit.SplitterDistance = 250;
			this.MainSplit.TabIndex = 2;
			// 
			// ScenarioListLabel
			// 
			this.ScenarioListLabel.AutoSize = true;
			this.ScenarioListLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScenarioListLabel.Location = new System.Drawing.Point(0, 0);
			this.ScenarioListLabel.Name = "ScenarioListLabel";
			this.ScenarioListLabel.Size = new System.Drawing.Size(74, 13);
			this.ScenarioListLabel.TabIndex = 1;
			this.ScenarioListLabel.Text = "Scenario List:";
			// 
			// ScenarioList
			// 
			this.ScenarioList.AllColumns.Add(this.ScenarioNameColumn);
			this.ScenarioList.AllColumns.Add(this.ScenarioAverageColumn);
			this.ScenarioList.AllColumns.Add(this.ScenarioTargetColumn);
			this.ScenarioList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ScenarioList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScenarioList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
			this.ScenarioList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScenarioNameColumn,
            this.ScenarioAverageColumn,
            this.ScenarioTargetColumn});
			this.ScenarioList.Cursor = System.Windows.Forms.Cursors.Default;
			this.ScenarioList.FullRowSelect = true;
			this.ScenarioList.HeaderUsesThemes = false;
			this.ScenarioList.Location = new System.Drawing.Point(0, 15);
			this.ScenarioList.MultiSelect = false;
			this.ScenarioList.Name = "ScenarioList";
			this.ScenarioList.OwnerDraw = true;
			this.ScenarioList.RowHeight = 25;
			this.ScenarioList.ShowCommandMenuOnRightClick = true;
			this.ScenarioList.ShowGroups = false;
			this.ScenarioList.Size = new System.Drawing.Size(250, 485);
			this.ScenarioList.TabIndex = 0;
			this.ScenarioList.UseCompatibleStateImageBehavior = false;
			this.ScenarioList.UseHotItem = true;
			this.ScenarioList.UseTranslucentHotItem = true;
			this.ScenarioList.UseTranslucentSelection = true;
			this.ScenarioList.View = System.Windows.Forms.View.Details;
			this.ScenarioList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioList_CellEditFinishing);
			this.ScenarioList.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioList_CellEditStarting);
			this.ScenarioList.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ScenarioList_FormatRow);
			this.ScenarioList.SelectionChanged += new System.EventHandler(this.ScenarioList_SelectionChanged);
			this.ScenarioList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScenarioList_KeyDown);
			this.ScenarioList.Leave += new System.EventHandler(this.ScenarioList_Leave);
			// 
			// ScenarioNameColumn
			// 
			this.ScenarioNameColumn.AspectName = "Name";
			this.ScenarioNameColumn.AutoCompleteEditor = false;
			this.ScenarioNameColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ScenarioNameColumn.Hideable = false;
			this.ScenarioNameColumn.MinimumWidth = 40;
			this.ScenarioNameColumn.Text = "Name";
			this.ScenarioNameColumn.Width = 115;
			// 
			// ScenarioAverageColumn
			// 
			this.ScenarioAverageColumn.AspectName = "PointsEarned";
			this.ScenarioAverageColumn.AspectToStringFormat = "";
			this.ScenarioAverageColumn.AutoCompleteEditor = false;
			this.ScenarioAverageColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ScenarioAverageColumn.IsEditable = false;
			this.ScenarioAverageColumn.Text = "Average";
			this.ScenarioAverageColumn.Width = 55;
			// 
			// ScenarioTargetColumn
			// 
			this.ScenarioTargetColumn.AspectName = "Target";
			this.ScenarioTargetColumn.AutoCompleteEditor = false;
			this.ScenarioTargetColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ScenarioTargetColumn.Text = "Target";
			this.ScenarioTargetColumn.Width = 50;
			// 
			// ScenarioTree
			// 
			this.ScenarioTree.AllColumns.Add(this.ItemNameColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemWeightColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemEarnedColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemPossibleColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemMarkedColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemNeededColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemOptionsColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemNotesColumn);
			this.ScenarioTree.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ScenarioTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScenarioTree.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
			this.ScenarioTree.CheckedAspectName = "";
			this.ScenarioTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemNameColumn,
            this.ItemWeightColumn,
            this.ItemEarnedColumn,
            this.ItemPossibleColumn,
            this.ItemMarkedColumn,
            this.ItemNeededColumn,
            this.ItemOptionsColumn,
            this.ItemNotesColumn});
			this.ScenarioTree.Cursor = System.Windows.Forms.Cursors.Default;
			this.ScenarioTree.FullRowSelect = true;
			this.ScenarioTree.GridLines = true;
			this.ScenarioTree.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ScenarioTree.HeaderUsesThemes = false;
			this.ScenarioTree.Location = new System.Drawing.Point(0, 15);
			this.ScenarioTree.MultiSelect = false;
			this.ScenarioTree.Name = "ScenarioTree";
			this.ScenarioTree.OwnerDraw = true;
			this.ScenarioTree.RowHeight = 25;
			this.ScenarioTree.ShowGroups = false;
			this.ScenarioTree.ShowImagesOnSubItems = true;
			this.ScenarioTree.Size = new System.Drawing.Size(621, 485);
			this.ScenarioTree.SmallImageList = this.FlagList;
			this.ScenarioTree.TabIndex = 3;
			this.ScenarioTree.UseCellFormatEvents = true;
			this.ScenarioTree.UseCompatibleStateImageBehavior = false;
			this.ScenarioTree.UseHotItem = true;
			this.ScenarioTree.UseSubItemCheckBoxes = true;
			this.ScenarioTree.UseTranslucentHotItem = true;
			this.ScenarioTree.UseTranslucentSelection = true;
			this.ScenarioTree.View = System.Windows.Forms.View.Details;
			this.ScenarioTree.VirtualMode = true;
			this.ScenarioTree.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioTree_CellEditFinishing);
			this.ScenarioTree.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioTree_CellEditStarting);
			this.ScenarioTree.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ScenarioTree_FormatCell);
			this.ScenarioTree.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ScenarioTree_FormatRow);
			this.ScenarioTree.SelectionChanged += new System.EventHandler(this.ScenarioTree_SelectionChanged);
			this.ScenarioTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScenarioTree_KeyDown);
			this.ScenarioTree.Leave += new System.EventHandler(this.ScenarioTree_Leave);
			// 
			// ItemNameColumn
			// 
			this.ItemNameColumn.AspectName = "Name";
			this.ItemNameColumn.AutoCompleteEditor = false;
			this.ItemNameColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemNameColumn.Text = "Name";
			this.ItemNameColumn.Width = 120;
			// 
			// ItemWeightColumn
			// 
			this.ItemWeightColumn.AspectName = "Weight";
			this.ItemWeightColumn.AspectToStringFormat = "";
			this.ItemWeightColumn.AutoCompleteEditor = false;
			this.ItemWeightColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemWeightColumn.Text = "Weight";
			this.ItemWeightColumn.Width = 80;
			// 
			// ItemEarnedColumn
			// 
			this.ItemEarnedColumn.AspectName = "PointsEarned";
			this.ItemEarnedColumn.AutoCompleteEditor = false;
			this.ItemEarnedColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemEarnedColumn.Text = "Earned";
			this.ItemEarnedColumn.Width = 50;
			// 
			// ItemPossibleColumn
			// 
			this.ItemPossibleColumn.AspectName = "PointsPossible";
			this.ItemPossibleColumn.AutoCompleteEditor = false;
			this.ItemPossibleColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemPossibleColumn.Text = "Possible";
			this.ItemPossibleColumn.Width = 55;
			// 
			// ItemMarkedColumn
			// 
			this.ItemMarkedColumn.AspectName = "Marked";
			this.ItemMarkedColumn.AutoCompleteEditor = false;
			this.ItemMarkedColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemMarkedColumn.CheckBoxes = true;
			this.ItemMarkedColumn.HeaderImageKey = "(none)";
			this.ItemMarkedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ItemMarkedColumn.Hideable = false;
			this.ItemMarkedColumn.MaximumWidth = 20;
			this.ItemMarkedColumn.MinimumWidth = 20;
			this.ItemMarkedColumn.Text = "";
			this.ItemMarkedColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ItemMarkedColumn.Width = 20;
			// 
			// ItemNeededColumn
			// 
			this.ItemNeededColumn.AspectName = "PointsNeeded";
			this.ItemNeededColumn.AspectToStringFormat = "";
			this.ItemNeededColumn.AutoCompleteEditor = false;
			this.ItemNeededColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemNeededColumn.Text = "Needed";
			this.ItemNeededColumn.Width = 85;
			// 
			// ItemOptionsColumn
			// 
			this.ItemOptionsColumn.AspectName = "";
			this.ItemOptionsColumn.Text = "Options";
			// 
			// ItemNotesColumn
			// 
			this.ItemNotesColumn.AspectName = "Notes";
			this.ItemNotesColumn.AutoCompleteEditor = false;
			this.ItemNotesColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.ItemNotesColumn.FillsFreeSpace = true;
			this.ItemNotesColumn.MinimumWidth = 50;
			this.ItemNotesColumn.Text = "Notes";
			this.ItemNotesColumn.Width = 50;
			// 
			// FlagList
			// 
			this.FlagList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FlagList.ImageStream")));
			this.FlagList.TransparentColor = System.Drawing.Color.Transparent;
			this.FlagList.Images.SetKeyName(0, "extracredit");
			// 
			// SelectedScenarioLabel
			// 
			this.SelectedScenarioLabel.AutoSize = true;
			this.SelectedScenarioLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SelectedScenarioLabel.Location = new System.Drawing.Point(0, 0);
			this.SelectedScenarioLabel.Name = "SelectedScenarioLabel";
			this.SelectedScenarioLabel.Size = new System.Drawing.Size(100, 13);
			this.SelectedScenarioLabel.TabIndex = 2;
			this.SelectedScenarioLabel.Text = "Selected Scenario:";
			// 
			// ScenarioTitleLabel
			// 
			this.ScenarioTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScenarioTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScenarioTitleLabel.Location = new System.Drawing.Point(0, 25);
			this.ScenarioTitleLabel.Name = "ScenarioTitleLabel";
			this.ScenarioTitleLabel.Size = new System.Drawing.Size(885, 30);
			this.ScenarioTitleLabel.TabIndex = 0;
			this.ScenarioTitleLabel.Text = "No Scenario Selected";
			this.ScenarioTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DataToolbar
			// 
			this.DataToolbar.ClickThrough = true;
			this.DataToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.DataToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.DataToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddScenarioButton,
            this.toolStripSeparator2,
            this.AddSectionButton,
            this.AddGradeButton,
            this.toolStripSeparator3,
            this.DeleteButton});
			this.DataToolbar.Location = new System.Drawing.Point(0, 560);
			this.DataToolbar.Name = "DataToolbar";
			this.DataToolbar.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
			this.DataToolbar.Size = new System.Drawing.Size(885, 25);
			this.DataToolbar.TabIndex = 3;
			// 
			// AddScenarioButton
			// 
			this.AddScenarioButton.AutoToolTip = false;
			this.AddScenarioButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddScenarioButton.Image = ((System.Drawing.Image)(resources.GetObject("AddScenarioButton.Image")));
			this.AddScenarioButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddScenarioButton.Name = "AddScenarioButton";
			this.AddScenarioButton.Size = new System.Drawing.Size(81, 20);
			this.AddScenarioButton.Text = "Add Scenario";
			this.AddScenarioButton.Click += new System.EventHandler(this.AddScenarioButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			// 
			// AddSectionButton
			// 
			this.AddSectionButton.AutoToolTip = false;
			this.AddSectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddSectionButton.Enabled = false;
			this.AddSectionButton.Image = ((System.Drawing.Image)(resources.GetObject("AddSectionButton.Image")));
			this.AddSectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddSectionButton.Name = "AddSectionButton";
			this.AddSectionButton.Size = new System.Drawing.Size(75, 20);
			this.AddSectionButton.Text = "Add Section";
			this.AddSectionButton.Click += new System.EventHandler(this.AddSectionButton_Click);
			// 
			// AddGradeButton
			// 
			this.AddGradeButton.AutoToolTip = false;
			this.AddGradeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddGradeButton.Enabled = false;
			this.AddGradeButton.Image = ((System.Drawing.Image)(resources.GetObject("AddGradeButton.Image")));
			this.AddGradeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddGradeButton.Name = "AddGradeButton";
			this.AddGradeButton.Size = new System.Drawing.Size(67, 20);
			this.AddGradeButton.Text = "Add Grade";
			this.AddGradeButton.Click += new System.EventHandler(this.AddGradeButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
			// 
			// DeleteButton
			// 
			this.DeleteButton.AutoToolTip = false;
			this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DeleteButton.Enabled = false;
			this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
			this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(44, 20);
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// FileToolbar
			// 
			this.FileToolbar.ClickThrough = true;
			this.FileToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.FileToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileButton,
            this.OpenFileButton,
            this.SaveFileButton,
            this.SaveAsFileButton,
            this.FileLabel,
            this.toolStripSeparator4,
            this.HelpToolbarButton});
			this.FileToolbar.Location = new System.Drawing.Point(0, 0);
			this.FileToolbar.Name = "FileToolbar";
			this.FileToolbar.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
			this.FileToolbar.Size = new System.Drawing.Size(885, 25);
			this.FileToolbar.TabIndex = 1;
			// 
			// NewFileButton
			// 
			this.NewFileButton.AutoToolTip = false;
			this.NewFileButton.Image = global::BareMinimum.Properties.Resources.filenew;
			this.NewFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NewFileButton.Name = "NewFileButton";
			this.NewFileButton.Size = new System.Drawing.Size(51, 20);
			this.NewFileButton.Text = "&New";
			this.NewFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
			// 
			// OpenFileButton
			// 
			this.OpenFileButton.AutoToolTip = false;
			this.OpenFileButton.Image = global::BareMinimum.Properties.Resources.fileopen;
			this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OpenFileButton.Name = "OpenFileButton";
			this.OpenFileButton.Size = new System.Drawing.Size(56, 20);
			this.OpenFileButton.Text = "&Open";
			this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
			// 
			// SaveFileButton
			// 
			this.SaveFileButton.AutoToolTip = false;
			this.SaveFileButton.Image = global::BareMinimum.Properties.Resources.filesave;
			this.SaveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveFileButton.Name = "SaveFileButton";
			this.SaveFileButton.Size = new System.Drawing.Size(51, 20);
			this.SaveFileButton.Text = "&Save";
			this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
			// 
			// SaveAsFileButton
			// 
			this.SaveAsFileButton.AutoToolTip = false;
			this.SaveAsFileButton.Image = global::BareMinimum.Properties.Resources.filesaveas;
			this.SaveAsFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveAsFileButton.Name = "SaveAsFileButton";
			this.SaveAsFileButton.Size = new System.Drawing.Size(76, 20);
			this.SaveAsFileButton.Text = "Save As...";
			this.SaveAsFileButton.Click += new System.EventHandler(this.SaveAsFileButton_Click);
			// 
			// FileLabel
			// 
			this.FileLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.FileLabel.Name = "FileLabel";
			this.FileLabel.Size = new System.Drawing.Size(73, 20);
			this.FileLabel.Text = "Unsaved File";
			this.FileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// HelpToolbarButton
			// 
			this.HelpToolbarButton.AutoToolTip = false;
			this.HelpToolbarButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineHelpMenuItem,
            this.bugReportMenuItem,
            this.toolStripSeparator1,
            this.aboutBareMinimumToolStripMenuItem});
			this.HelpToolbarButton.Image = global::BareMinimum.Properties.Resources.help;
			this.HelpToolbarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HelpToolbarButton.Name = "HelpToolbarButton";
			this.HelpToolbarButton.Size = new System.Drawing.Size(61, 20);
			this.HelpToolbarButton.Text = "&Help";
			// 
			// onlineHelpMenuItem
			// 
			this.onlineHelpMenuItem.Name = "onlineHelpMenuItem";
			this.onlineHelpMenuItem.Size = new System.Drawing.Size(186, 22);
			this.onlineHelpMenuItem.Text = "Help (online)";
			this.onlineHelpMenuItem.Click += new System.EventHandler(this.OnlineHelpMenuItem_Click);
			// 
			// bugReportMenuItem
			// 
			this.bugReportMenuItem.Name = "bugReportMenuItem";
			this.bugReportMenuItem.Size = new System.Drawing.Size(186, 22);
			this.bugReportMenuItem.Text = "Report a bug";
			this.bugReportMenuItem.Click += new System.EventHandler(this.BugReportMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
			// 
			// aboutBareMinimumToolStripMenuItem
			// 
			this.aboutBareMinimumToolStripMenuItem.Name = "aboutBareMinimumToolStripMenuItem";
			this.aboutBareMinimumToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.aboutBareMinimumToolStripMenuItem.Text = "About BareMinimum";
			this.aboutBareMinimumToolStripMenuItem.Click += new System.EventHandler(this.AboutBareMinimumToolStripMenuItem_Click);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(885, 585);
			this.Controls.Add(this.DataToolbar);
			this.Controls.Add(this.MainSplit);
			this.Controls.Add(this.FileToolbar);
			this.Controls.Add(this.ScenarioTitleLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(650, 400);
			this.Name = "MainWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "BareMinimum (Pre-Release)";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.MainSplit.Panel1.ResumeLayout(false);
			this.MainSplit.Panel1.PerformLayout();
			this.MainSplit.Panel2.ResumeLayout(false);
			this.MainSplit.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
			this.MainSplit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ScenarioList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ScenarioTree)).EndInit();
			this.DataToolbar.ResumeLayout(false);
			this.DataToolbar.PerformLayout();
			this.FileToolbar.ResumeLayout(false);
			this.FileToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScenarioTitleLabel;
        private ToolbarEx FileToolbar;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.Label ScenarioListLabel;
		private BrightIdeasSoftware.ObjectListView ScenarioList;
        private BrightIdeasSoftware.TreeListView ScenarioTree;
		private System.Windows.Forms.Label SelectedScenarioLabel;
        private System.Windows.Forms.ToolStripButton NewFileButton;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ToolStripButton SaveFileButton;
		private System.Windows.Forms.ToolStripButton SaveAsFileButton;
        private System.Windows.Forms.ToolStripLabel FileLabel;
        private BrightIdeasSoftware.OLVColumn ScenarioNameColumn;
        private BrightIdeasSoftware.OLVColumn ScenarioAverageColumn;
        private BrightIdeasSoftware.OLVColumn ItemNameColumn;
        private BrightIdeasSoftware.OLVColumn ItemWeightColumn;
        private BrightIdeasSoftware.OLVColumn ItemEarnedColumn;
        private BrightIdeasSoftware.OLVColumn ItemPossibleColumn;
        private BrightIdeasSoftware.OLVColumn ItemNeededColumn;
        private BrightIdeasSoftware.OLVColumn ItemNotesColumn;
		private BrightIdeasSoftware.OLVColumn ItemMarkedColumn;
		private BrightIdeasSoftware.OLVColumn ScenarioTargetColumn;
		private System.Windows.Forms.ToolStripDropDownButton HelpToolbarButton;
		private System.Windows.Forms.ToolStripMenuItem onlineHelpMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bugReportMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem aboutBareMinimumToolStripMenuItem;
		private ToolbarEx DataToolbar;
		private System.Windows.Forms.ToolStripButton AddScenarioButton;
		private System.Windows.Forms.ToolStripButton AddSectionButton;
		private System.Windows.Forms.ToolStripButton AddGradeButton;
		private System.Windows.Forms.ToolStripButton DeleteButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private BrightIdeasSoftware.OLVColumn ItemOptionsColumn;
		private System.Windows.Forms.ImageList FlagList;
    }
}

