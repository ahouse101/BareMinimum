﻿namespace BareMinimum
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
			this.DeleteScenarioButton = new System.Windows.Forms.Button();
			this.AddScenarioButton = new System.Windows.Forms.Button();
			this.ScenarioListLabel = new System.Windows.Forms.Label();
			this.ScenarioList = new BrightIdeasSoftware.ObjectListView();
			this.ScenarioNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ScenarioAverageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ScenarioTargetColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.DeleteItemButton = new System.Windows.Forms.Button();
			this.AddGradeButton = new System.Windows.Forms.Button();
			this.AddSectionButton = new System.Windows.Forms.Button();
			this.ScenarioTree = new BrightIdeasSoftware.TreeListView();
			this.ItemNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemWeightColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemEarnedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemPossibleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemMarkedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemNeededColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ItemNotesColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.SelectedScenarioLabel = new System.Windows.Forms.Label();
			this.ScenarioTitleLabel = new System.Windows.Forms.Label();
			this.FileToolbar = new BareMinimum.ToolbarEx();
			this.NewFileButton = new System.Windows.Forms.ToolStripButton();
			this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveFileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveAsFileButton = new System.Windows.Forms.ToolStripButton();
			this.FileLabel = new System.Windows.Forms.ToolStripLabel();
			this.HelpToolbarButton = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
			this.MainSplit.Panel1.SuspendLayout();
			this.MainSplit.Panel2.SuspendLayout();
			this.MainSplit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScenarioList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ScenarioTree)).BeginInit();
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
			this.MainSplit.Panel1.Controls.Add(this.DeleteScenarioButton);
			this.MainSplit.Panel1.Controls.Add(this.AddScenarioButton);
			this.MainSplit.Panel1.Controls.Add(this.ScenarioListLabel);
			this.MainSplit.Panel1.Controls.Add(this.ScenarioList);
			this.MainSplit.Panel1MinSize = 150;
			// 
			// MainSplit.Panel2
			// 
			this.MainSplit.Panel2.Controls.Add(this.DeleteItemButton);
			this.MainSplit.Panel2.Controls.Add(this.AddGradeButton);
			this.MainSplit.Panel2.Controls.Add(this.AddSectionButton);
			this.MainSplit.Panel2.Controls.Add(this.ScenarioTree);
			this.MainSplit.Panel2.Controls.Add(this.SelectedScenarioLabel);
			this.MainSplit.Panel2MinSize = 420;
			this.MainSplit.Size = new System.Drawing.Size(725, 400);
			this.MainSplit.SplitterDistance = 200;
			this.MainSplit.TabIndex = 2;
			// 
			// DeleteScenarioButton
			// 
			this.DeleteScenarioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteScenarioButton.Enabled = false;
			this.DeleteScenarioButton.Location = new System.Drawing.Point(135, 375);
			this.DeleteScenarioButton.Name = "DeleteScenarioButton";
			this.DeleteScenarioButton.Size = new System.Drawing.Size(65, 25);
			this.DeleteScenarioButton.TabIndex = 3;
			this.DeleteScenarioButton.Text = "Delete";
			this.DeleteScenarioButton.UseVisualStyleBackColor = true;
			this.DeleteScenarioButton.Click += new System.EventHandler(this.DeleteScenarioButton_Click);
			// 
			// AddScenarioButton
			// 
			this.AddScenarioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AddScenarioButton.Location = new System.Drawing.Point(50, 375);
			this.AddScenarioButton.Name = "AddScenarioButton";
			this.AddScenarioButton.Size = new System.Drawing.Size(80, 25);
			this.AddScenarioButton.TabIndex = 2;
			this.AddScenarioButton.Text = "Add Scenario";
			this.AddScenarioButton.UseVisualStyleBackColor = true;
			this.AddScenarioButton.Click += new System.EventHandler(this.AddScenarioButton_Click);
			// 
			// ScenarioListLabel
			// 
			this.ScenarioListLabel.AutoSize = true;
			this.ScenarioListLabel.Location = new System.Drawing.Point(0, 0);
			this.ScenarioListLabel.Name = "ScenarioListLabel";
			this.ScenarioListLabel.Size = new System.Drawing.Size(71, 13);
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
			this.ScenarioList.ShowGroups = false;
			this.ScenarioList.Size = new System.Drawing.Size(200, 355);
			this.ScenarioList.TabIndex = 0;
			this.ScenarioList.UseCompatibleStateImageBehavior = false;
			this.ScenarioList.UseHotItem = true;
			this.ScenarioList.UseTranslucentHotItem = true;
			this.ScenarioList.UseTranslucentSelection = true;
			this.ScenarioList.View = System.Windows.Forms.View.Details;
			this.ScenarioList.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioList_CellEditStarting);
			this.ScenarioList.SelectionChanged += new System.EventHandler(this.ScenarioList_SelectionChanged);
			this.ScenarioList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScenarioList_KeyDown);
			// 
			// ScenarioNameColumn
			// 
			this.ScenarioNameColumn.AspectName = "Name";
			this.ScenarioNameColumn.FillsFreeSpace = true;
			this.ScenarioNameColumn.Hideable = false;
			this.ScenarioNameColumn.MinimumWidth = 40;
			this.ScenarioNameColumn.Text = "Name";
			// 
			// ScenarioAverageColumn
			// 
			this.ScenarioAverageColumn.AspectName = "PointsEarned";
			this.ScenarioAverageColumn.AspectToStringFormat = "";
			this.ScenarioAverageColumn.IsEditable = false;
			this.ScenarioAverageColumn.Text = "Average";
			this.ScenarioAverageColumn.Width = 55;
			// 
			// ScenarioTargetColumn
			// 
			this.ScenarioTargetColumn.AspectName = "Target";
			this.ScenarioTargetColumn.Text = "Target";
			this.ScenarioTargetColumn.Width = 55;
			// 
			// DeleteItemButton
			// 
			this.DeleteItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DeleteItemButton.Enabled = false;
			this.DeleteItemButton.Location = new System.Drawing.Point(170, 375);
			this.DeleteItemButton.Name = "DeleteItemButton";
			this.DeleteItemButton.Size = new System.Drawing.Size(65, 25);
			this.DeleteItemButton.TabIndex = 9;
			this.DeleteItemButton.Text = "Delete";
			this.DeleteItemButton.UseVisualStyleBackColor = true;
			this.DeleteItemButton.Click += new System.EventHandler(this.DeleteItemButton_Click);
			// 
			// AddGradeButton
			// 
			this.AddGradeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddGradeButton.Enabled = false;
			this.AddGradeButton.Location = new System.Drawing.Point(85, 375);
			this.AddGradeButton.Name = "AddGradeButton";
			this.AddGradeButton.Size = new System.Drawing.Size(80, 25);
			this.AddGradeButton.TabIndex = 5;
			this.AddGradeButton.Text = "Add Grade";
			this.AddGradeButton.UseVisualStyleBackColor = true;
			this.AddGradeButton.Click += new System.EventHandler(this.AddGradeButton_Click);
			// 
			// AddSectionButton
			// 
			this.AddSectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddSectionButton.Enabled = false;
			this.AddSectionButton.Location = new System.Drawing.Point(0, 375);
			this.AddSectionButton.Name = "AddSectionButton";
			this.AddSectionButton.Size = new System.Drawing.Size(80, 25);
			this.AddSectionButton.TabIndex = 4;
			this.AddSectionButton.Text = "Add Section";
			this.AddSectionButton.UseVisualStyleBackColor = true;
			this.AddSectionButton.Click += new System.EventHandler(this.AddSectionButton_Click);
			// 
			// ScenarioTree
			// 
			this.ScenarioTree.AllColumns.Add(this.ItemNameColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemWeightColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemEarnedColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemPossibleColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemMarkedColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemNeededColumn);
			this.ScenarioTree.AllColumns.Add(this.ItemNotesColumn);
			this.ScenarioTree.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ScenarioTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScenarioTree.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
			this.ScenarioTree.CheckedAspectName = "Marked";
			this.ScenarioTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemNameColumn,
            this.ItemWeightColumn,
            this.ItemEarnedColumn,
            this.ItemPossibleColumn,
            this.ItemMarkedColumn,
            this.ItemNeededColumn,
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
			this.ScenarioTree.Size = new System.Drawing.Size(521, 355);
			this.ScenarioTree.TabIndex = 3;
			this.ScenarioTree.UseCellFormatEvents = true;
			this.ScenarioTree.UseCompatibleStateImageBehavior = false;
			this.ScenarioTree.UseHotItem = true;
			this.ScenarioTree.UseSubItemCheckBoxes = true;
			this.ScenarioTree.UseTranslucentHotItem = true;
			this.ScenarioTree.UseTranslucentSelection = true;
			this.ScenarioTree.View = System.Windows.Forms.View.Details;
			this.ScenarioTree.VirtualMode = true;
			this.ScenarioTree.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ScenarioTree_CellEditStarting);
			this.ScenarioTree.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ScenarioTree_FormatCell);
			this.ScenarioTree.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ScenarioTree_FormatRow);
			this.ScenarioTree.SelectionChanged += new System.EventHandler(this.ScenarioTree_SelectionChanged);
			this.ScenarioTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScenarioTree_KeyDown);
			// 
			// ItemNameColumn
			// 
			this.ItemNameColumn.AspectName = "Name";
			this.ItemNameColumn.Text = "Name";
			this.ItemNameColumn.Width = 120;
			// 
			// ItemWeightColumn
			// 
			this.ItemWeightColumn.AspectName = "Weight";
			this.ItemWeightColumn.AspectToStringFormat = "";
			this.ItemWeightColumn.Text = "Weight";
			this.ItemWeightColumn.Width = 80;
			// 
			// ItemEarnedColumn
			// 
			this.ItemEarnedColumn.AspectName = "PointsEarned";
			this.ItemEarnedColumn.Text = "Earned";
			this.ItemEarnedColumn.Width = 50;
			// 
			// ItemPossibleColumn
			// 
			this.ItemPossibleColumn.AspectName = "PointsPossible";
			this.ItemPossibleColumn.Text = "Possible";
			this.ItemPossibleColumn.Width = 55;
			// 
			// ItemMarkedColumn
			// 
			this.ItemMarkedColumn.AspectName = "Marked";
			this.ItemMarkedColumn.CheckBoxes = true;
			this.ItemMarkedColumn.HeaderImageKey = "(none)";
			this.ItemMarkedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.ItemNeededColumn.Text = "Needed";
			this.ItemNeededColumn.Width = 55;
			// 
			// ItemNotesColumn
			// 
			this.ItemNotesColumn.AspectName = "Notes";
			this.ItemNotesColumn.FillsFreeSpace = true;
			this.ItemNotesColumn.MinimumWidth = 50;
			this.ItemNotesColumn.Text = "Notes";
			this.ItemNotesColumn.Width = 50;
			// 
			// SelectedScenarioLabel
			// 
			this.SelectedScenarioLabel.AutoSize = true;
			this.SelectedScenarioLabel.Location = new System.Drawing.Point(0, 0);
			this.SelectedScenarioLabel.Name = "SelectedScenarioLabel";
			this.SelectedScenarioLabel.Size = new System.Drawing.Size(97, 13);
			this.SelectedScenarioLabel.TabIndex = 2;
			this.SelectedScenarioLabel.Text = "Selected Scenario:";
			// 
			// ScenarioTitleLabel
			// 
			this.ScenarioTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScenarioTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
			this.ScenarioTitleLabel.Location = new System.Drawing.Point(0, 25);
			this.ScenarioTitleLabel.Name = "ScenarioTitleLabel";
			this.ScenarioTitleLabel.Size = new System.Drawing.Size(735, 30);
			this.ScenarioTitleLabel.TabIndex = 0;
			this.ScenarioTitleLabel.Text = "No Scenario Selected";
			this.ScenarioTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.HelpToolbarButton});
			this.FileToolbar.Location = new System.Drawing.Point(0, 0);
			this.FileToolbar.Name = "FileToolbar";
			this.FileToolbar.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
			this.FileToolbar.Size = new System.Drawing.Size(735, 25);
			this.FileToolbar.TabIndex = 1;
			this.FileToolbar.Text = "File";
			// 
			// NewFileButton
			// 
			this.NewFileButton.Image = global::BareMinimum.Properties.Resources.filenew;
			this.NewFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NewFileButton.Name = "NewFileButton";
			this.NewFileButton.Size = new System.Drawing.Size(51, 20);
			this.NewFileButton.Text = "&New";
			this.NewFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
			// 
			// OpenFileButton
			// 
			this.OpenFileButton.Image = global::BareMinimum.Properties.Resources.fileopen;
			this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OpenFileButton.Name = "OpenFileButton";
			this.OpenFileButton.Size = new System.Drawing.Size(56, 20);
			this.OpenFileButton.Text = "&Open";
			this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
			// 
			// SaveFileButton
			// 
			this.SaveFileButton.Image = global::BareMinimum.Properties.Resources.filesave;
			this.SaveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveFileButton.Name = "SaveFileButton";
			this.SaveFileButton.Size = new System.Drawing.Size(51, 20);
			this.SaveFileButton.Text = "&Save";
			this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
			// 
			// SaveAsFileButton
			// 
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
			this.FileLabel.AutoSize = false;
			this.FileLabel.Name = "FileLabel";
			this.FileLabel.Size = new System.Drawing.Size(220, 20);
			this.FileLabel.Text = "Unsaved File";
			this.FileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// HelpToolbarButton
			// 
			this.HelpToolbarButton.Image = global::BareMinimum.Properties.Resources.help;
			this.HelpToolbarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HelpToolbarButton.Name = "HelpToolbarButton";
			this.HelpToolbarButton.Size = new System.Drawing.Size(52, 20);
			this.HelpToolbarButton.Text = "&Help";
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(735, 460);
			this.Controls.Add(this.MainSplit);
			this.Controls.Add(this.FileToolbar);
			this.Controls.Add(this.ScenarioTitleLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(751, 400);
			this.Name = "MainWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "BareMinimum";
			this.MainSplit.Panel1.ResumeLayout(false);
			this.MainSplit.Panel1.PerformLayout();
			this.MainSplit.Panel2.ResumeLayout(false);
			this.MainSplit.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
			this.MainSplit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ScenarioList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ScenarioTree)).EndInit();
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
        private System.Windows.Forms.Button AddScenarioButton;
        private BrightIdeasSoftware.TreeListView ScenarioTree;
        private System.Windows.Forms.Label SelectedScenarioLabel;
        private System.Windows.Forms.Button AddGradeButton;
        private System.Windows.Forms.Button AddSectionButton;
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
        private System.Windows.Forms.Button DeleteScenarioButton;
        private System.Windows.Forms.Button DeleteItemButton;
        private System.Windows.Forms.ToolStripButton HelpToolbarButton;
		private BrightIdeasSoftware.OLVColumn ScenarioTargetColumn;
    }
}

