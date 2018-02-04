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
			this.CollapseSidebarButton = new System.Windows.Forms.Button();
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
			this.ScenarioTitleLabel = new System.Windows.Forms.Label();
			this.ExpandSidebarButton = new System.Windows.Forms.Button();
			this.ScenarioListLabel = new System.Windows.Forms.Label();
			this.ScenarioTitleTextbox = new System.Windows.Forms.TextBox();
			this.DataToolbar = new BareMinimum.ToolbarEx();
			this.AddScenarioButton = new System.Windows.Forms.ToolStripButton();
			this.ScenarioOptionsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ChangeScenarioDropdown = new System.Windows.Forms.ToolStripDropDownButton();
			this.ScenarioOptionsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ScenarioAverageLabel = new System.Windows.Forms.ToolStripLabel();
			this.ScenarioTargetLabel = new System.Windows.Forms.ToolStripLabel();
			this.ScenarioTargetTextbox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.AddSectionButton = new System.Windows.Forms.ToolStripButton();
			this.AddGradeButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DeleteButton = new System.Windows.Forms.ToolStripButton();
			this.FileToolbar = new BareMinimum.ToolbarEx();
			this.NewFileButton = new System.Windows.Forms.ToolStripButton();
			this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveFileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveAsFileButton = new System.Windows.Forms.ToolStripButton();
			this.FileLabel = new System.Windows.Forms.ToolStripLabel();
			this.ProgressBarSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.MainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.InfoLabel = new System.Windows.Forms.ToolStripLabel();
			this.AboutButton = new System.Windows.Forms.ToolStripButton();
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
			this.MainSplit.Panel1.Controls.Add(this.CollapseSidebarButton);
			this.MainSplit.Panel1.Controls.Add(this.ScenarioList);
			this.MainSplit.Panel1MinSize = 150;
			// 
			// MainSplit.Panel2
			// 
			this.MainSplit.Panel2.Controls.Add(this.ScenarioTree);
			this.MainSplit.Panel2MinSize = 420;
			this.MainSplit.Size = new System.Drawing.Size(875, 499);
			this.MainSplit.SplitterDistance = 250;
			this.MainSplit.TabIndex = 2;
			// 
			// CollapseSidebarButton
			// 
			this.CollapseSidebarButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CollapseSidebarButton.FlatAppearance.BorderSize = 0;
			this.CollapseSidebarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CollapseSidebarButton.Image = global::BareMinimum.Properties.Resources._1leftarrow;
			this.CollapseSidebarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CollapseSidebarButton.Location = new System.Drawing.Point(0, 474);
			this.CollapseSidebarButton.Name = "CollapseSidebarButton";
			this.CollapseSidebarButton.Size = new System.Drawing.Size(250, 25);
			this.CollapseSidebarButton.TabIndex = 5;
			this.CollapseSidebarButton.Text = "Collapse";
			this.CollapseSidebarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CollapseSidebarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.CollapseSidebarButton.UseVisualStyleBackColor = true;
			this.CollapseSidebarButton.Click += new System.EventHandler(this.CollapseSidebarButton_Click);
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
			this.ScenarioList.Location = new System.Drawing.Point(0, 0);
			this.ScenarioList.MultiSelect = false;
			this.ScenarioList.Name = "ScenarioList";
			this.ScenarioList.OwnerDraw = true;
			this.ScenarioList.RowHeight = 25;
			this.ScenarioList.ShowCommandMenuOnRightClick = true;
			this.ScenarioList.ShowGroups = false;
			this.ScenarioList.Size = new System.Drawing.Size(250, 472);
			this.ScenarioList.TabIndex = 0;
			this.ScenarioList.UseCompatibleStateImageBehavior = false;
			this.ScenarioList.UseHotItem = true;
			this.ScenarioList.UseTranslucentHotItem = true;
			this.ScenarioList.UseTranslucentSelection = true;
			this.ScenarioList.View = System.Windows.Forms.View.Details;
			this.ScenarioList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioList_CellEditFinishing);
			this.ScenarioList.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioList_CellEditStarting);
			this.ScenarioList.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ScenarioList_FormatRow);
			this.ScenarioList.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.ScenarioList_ItemsChanged);
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
			this.ScenarioTree.Location = new System.Drawing.Point(0, 0);
			this.ScenarioTree.MultiSelect = false;
			this.ScenarioTree.Name = "ScenarioTree";
			this.ScenarioTree.OwnerDraw = true;
			this.ScenarioTree.RowHeight = 25;
			this.ScenarioTree.ShowGroups = false;
			this.ScenarioTree.ShowImagesOnSubItems = true;
			this.ScenarioTree.Size = new System.Drawing.Size(621, 499);
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
			// ScenarioTitleLabel
			// 
			this.ScenarioTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScenarioTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScenarioTitleLabel.Location = new System.Drawing.Point(116, 25);
			this.ScenarioTitleLabel.Name = "ScenarioTitleLabel";
			this.ScenarioTitleLabel.Size = new System.Drawing.Size(769, 30);
			this.ScenarioTitleLabel.TabIndex = 0;
			this.ScenarioTitleLabel.Text = "No Scenario Selected";
			this.ScenarioTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ScenarioTitleLabel.DoubleClick += new System.EventHandler(this.ScenarioTitleLabel_DoubleClick);
			// 
			// ExpandSidebarButton
			// 
			this.ExpandSidebarButton.FlatAppearance.BorderSize = 0;
			this.ExpandSidebarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExpandSidebarButton.Image = global::BareMinimum.Properties.Resources._1rightarrow;
			this.ExpandSidebarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExpandSidebarButton.Location = new System.Drawing.Point(5, 25);
			this.ExpandSidebarButton.Name = "ExpandSidebarButton";
			this.ExpandSidebarButton.Size = new System.Drawing.Size(105, 30);
			this.ExpandSidebarButton.TabIndex = 4;
			this.ExpandSidebarButton.Text = "Open Sidebar";
			this.ExpandSidebarButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExpandSidebarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.ExpandSidebarButton.UseVisualStyleBackColor = true;
			this.ExpandSidebarButton.Visible = false;
			this.ExpandSidebarButton.Click += new System.EventHandler(this.ExpandSidebarButton_Click);
			// 
			// ScenarioListLabel
			// 
			this.ScenarioListLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScenarioListLabel.Location = new System.Drawing.Point(5, 39);
			this.ScenarioListLabel.Name = "ScenarioListLabel";
			this.ScenarioListLabel.Size = new System.Drawing.Size(70, 13);
			this.ScenarioListLabel.TabIndex = 5;
			this.ScenarioListLabel.Text = "Scenarios:";
			this.ScenarioListLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.ScenarioListLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScenarioTitleLabel_MouseDoubleClick);
			// 
			// ScenarioTitleTextbox
			// 
			this.ScenarioTitleTextbox.BackColor = System.Drawing.SystemColors.Control;
			this.ScenarioTitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ScenarioTitleTextbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScenarioTitleTextbox.Location = new System.Drawing.Point(510, 25);
			this.ScenarioTitleTextbox.Name = "ScenarioTitleTextbox";
			this.ScenarioTitleTextbox.Size = new System.Drawing.Size(370, 27);
			this.ScenarioTitleTextbox.TabIndex = 6;
			this.ScenarioTitleTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ScenarioTitleTextbox.Visible = false;
			this.ScenarioTitleTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScenarioTitleTextbox_KeyPress);
			this.ScenarioTitleTextbox.Leave += new System.EventHandler(this.ScenarioTitleTextbox_Leave);
			// 
			// DataToolbar
			// 
			this.DataToolbar.AutoSize = false;
			this.DataToolbar.ClickThrough = true;
			this.DataToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.DataToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.DataToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddScenarioButton,
            this.ScenarioOptionsSeparator1,
            this.ChangeScenarioDropdown,
            this.ScenarioOptionsSeparator2,
            this.ScenarioAverageLabel,
            this.ScenarioTargetLabel,
            this.ScenarioTargetTextbox,
            this.toolStripSeparator3,
            this.AddSectionButton,
            this.AddGradeButton,
            this.toolStripSeparator2,
            this.DeleteButton});
			this.DataToolbar.Location = new System.Drawing.Point(0, 557);
			this.DataToolbar.Name = "DataToolbar";
			this.DataToolbar.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
			this.DataToolbar.Size = new System.Drawing.Size(885, 28);
			this.DataToolbar.TabIndex = 3;
			// 
			// AddScenarioButton
			// 
			this.AddScenarioButton.AutoToolTip = false;
			this.AddScenarioButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddScenarioButton.Image = ((System.Drawing.Image)(resources.GetObject("AddScenarioButton.Image")));
			this.AddScenarioButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddScenarioButton.Name = "AddScenarioButton";
			this.AddScenarioButton.Size = new System.Drawing.Size(81, 23);
			this.AddScenarioButton.Text = "Add Scenario";
			this.AddScenarioButton.Click += new System.EventHandler(this.AddScenarioButton_Click);
			// 
			// ScenarioOptionsSeparator1
			// 
			this.ScenarioOptionsSeparator1.Name = "ScenarioOptionsSeparator1";
			this.ScenarioOptionsSeparator1.Size = new System.Drawing.Size(6, 26);
			this.ScenarioOptionsSeparator1.Visible = false;
			// 
			// ChangeScenarioDropdown
			// 
			this.ChangeScenarioDropdown.Enabled = false;
			this.ChangeScenarioDropdown.Name = "ChangeScenarioDropdown";
			this.ChangeScenarioDropdown.Size = new System.Drawing.Size(109, 23);
			this.ChangeScenarioDropdown.Text = "Change Scenario";
			this.ChangeScenarioDropdown.Visible = false;
			// 
			// ScenarioOptionsSeparator2
			// 
			this.ScenarioOptionsSeparator2.Name = "ScenarioOptionsSeparator2";
			this.ScenarioOptionsSeparator2.Size = new System.Drawing.Size(6, 26);
			this.ScenarioOptionsSeparator2.Visible = false;
			// 
			// ScenarioAverageLabel
			// 
			this.ScenarioAverageLabel.Name = "ScenarioAverageLabel";
			this.ScenarioAverageLabel.Size = new System.Drawing.Size(74, 23);
			this.ScenarioAverageLabel.Text = "Average: n/a";
			this.ScenarioAverageLabel.Visible = false;
			// 
			// ScenarioTargetLabel
			// 
			this.ScenarioTargetLabel.Name = "ScenarioTargetLabel";
			this.ScenarioTargetLabel.Size = new System.Drawing.Size(43, 23);
			this.ScenarioTargetLabel.Text = "Target:";
			this.ScenarioTargetLabel.Visible = false;
			// 
			// ScenarioTargetTextbox
			// 
			this.ScenarioTargetTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ScenarioTargetTextbox.Enabled = false;
			this.ScenarioTargetTextbox.Name = "ScenarioTargetTextbox";
			this.ScenarioTargetTextbox.ShortcutsEnabled = false;
			this.ScenarioTargetTextbox.Size = new System.Drawing.Size(50, 26);
			this.ScenarioTargetTextbox.Visible = false;
			this.ScenarioTargetTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScenarioTargetTextbox_KeyPress);
			this.ScenarioTargetTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.ScenarioTargetTextbox_Validating);
			this.ScenarioTargetTextbox.Validated += new System.EventHandler(this.ScenarioTargetTextbox_Validated);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
			// 
			// AddSectionButton
			// 
			this.AddSectionButton.AutoToolTip = false;
			this.AddSectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddSectionButton.Enabled = false;
			this.AddSectionButton.Image = ((System.Drawing.Image)(resources.GetObject("AddSectionButton.Image")));
			this.AddSectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddSectionButton.Name = "AddSectionButton";
			this.AddSectionButton.Size = new System.Drawing.Size(75, 23);
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
			this.AddGradeButton.Size = new System.Drawing.Size(67, 23);
			this.AddGradeButton.Text = "Add Grade";
			this.AddGradeButton.Click += new System.EventHandler(this.AddGradeButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
			// 
			// DeleteButton
			// 
			this.DeleteButton.AutoToolTip = false;
			this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DeleteButton.Enabled = false;
			this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
			this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(44, 23);
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
            this.ProgressBarSeparator,
            this.MainProgressBar,
            this.toolStripSeparator4,
            this.InfoLabel,
            this.AboutButton});
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
			this.NewFileButton.Size = new System.Drawing.Size(72, 20);
			this.NewFileButton.Text = "&New File";
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
			// ProgressBarSeparator
			// 
			this.ProgressBarSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.ProgressBarSeparator.Name = "ProgressBarSeparator";
			this.ProgressBarSeparator.Size = new System.Drawing.Size(6, 23);
			// 
			// MainProgressBar
			// 
			this.MainProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.MainProgressBar.Name = "MainProgressBar";
			this.MainProgressBar.Size = new System.Drawing.Size(100, 20);
			this.MainProgressBar.Visible = false;
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// InfoLabel
			// 
			this.InfoLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new System.Drawing.Size(116, 20);
			this.InfoLabel.Text = "Checking for Update";
			this.InfoLabel.Visible = false;
			// 
			// AboutButton
			// 
			this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
			this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AboutButton.Name = "AboutButton";
			this.AboutButton.Size = new System.Drawing.Size(123, 20);
			this.AboutButton.Text = "About BareMinimum";
			this.AboutButton.Click += new System.EventHandler(this.AboutBareMinimum_Click);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(885, 585);
			this.Controls.Add(this.ScenarioTitleTextbox);
			this.Controls.Add(this.ScenarioListLabel);
			this.Controls.Add(this.ExpandSidebarButton);
			this.Controls.Add(this.DataToolbar);
			this.Controls.Add(this.MainSplit);
			this.Controls.Add(this.FileToolbar);
			this.Controls.Add(this.ScenarioTitleLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(650, 400);
			this.Name = "MainWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "BareMinimum (Alpha)";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.MainSplit.Panel1.ResumeLayout(false);
			this.MainSplit.Panel2.ResumeLayout(false);
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
		private BrightIdeasSoftware.ObjectListView ScenarioList;
		private BrightIdeasSoftware.TreeListView ScenarioTree;
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
		private ToolbarEx DataToolbar;
		private System.Windows.Forms.ToolStripButton AddScenarioButton;
		private System.Windows.Forms.ToolStripButton AddSectionButton;
		private System.Windows.Forms.ToolStripButton AddGradeButton;
		private System.Windows.Forms.ToolStripButton DeleteButton;
		private System.Windows.Forms.ToolStripSeparator ScenarioOptionsSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private BrightIdeasSoftware.OLVColumn ItemOptionsColumn;
		private System.Windows.Forms.ImageList FlagList;
		private System.Windows.Forms.ToolStripTextBox ScenarioTargetTextbox;
		private System.Windows.Forms.ToolStripLabel ScenarioTargetLabel;
		private System.Windows.Forms.ToolStripLabel ScenarioAverageLabel;
		private System.Windows.Forms.Button ExpandSidebarButton;
		private System.Windows.Forms.Button CollapseSidebarButton;
		private System.Windows.Forms.Label ScenarioListLabel;
		private System.Windows.Forms.ToolStripSeparator ScenarioOptionsSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton ChangeScenarioDropdown;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator ProgressBarSeparator;
		private System.Windows.Forms.ToolStripProgressBar MainProgressBar;
		private System.Windows.Forms.ToolStripLabel InfoLabel;
		private System.Windows.Forms.TextBox ScenarioTitleTextbox;
		private System.Windows.Forms.ToolStripButton AboutButton;
	}
}

