namespace BareMinimum
{
	partial class ItemOptionsDialog
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
			this.table = new System.Windows.Forms.TableLayoutPanel();
			this.Label = new System.Windows.Forms.Label();
			this.SaveButton = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.OptionsChecklist = new System.Windows.Forms.CheckedListBox();
			this.table.SuspendLayout();
			this.SuspendLayout();
			// 
			// table
			// 
			this.table.ColumnCount = 2;
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.table.Controls.Add(this.Label, 0, 0);
			this.table.Controls.Add(this.SaveButton, 0, 2);
			this.table.Controls.Add(this.Cancel, 1, 2);
			this.table.Controls.Add(this.OptionsChecklist, 0, 1);
			this.table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.table.Location = new System.Drawing.Point(0, 0);
			this.table.Name = "table";
			this.table.RowCount = 3;
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.table.Size = new System.Drawing.Size(234, 111);
			this.table.TabIndex = 0;
			// 
			// Label
			// 
			this.Label.AutoSize = true;
			this.table.SetColumnSpan(this.Label, 2);
			this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label.Location = new System.Drawing.Point(3, 0);
			this.Label.Name = "Label";
			this.Label.Padding = new System.Windows.Forms.Padding(5);
			this.Label.Size = new System.Drawing.Size(228, 25);
			this.Label.TabIndex = 0;
			this.Label.Text = "Select the options that should be active:";
			// 
			// SaveButton
			// 
			this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SaveButton.Location = new System.Drawing.Point(3, 84);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(111, 24);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Ok";
			this.SaveButton.UseVisualStyleBackColor = true;
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Cancel.Location = new System.Drawing.Point(120, 84);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(111, 24);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// OptionsChecklist
			// 
			this.OptionsChecklist.CheckOnClick = true;
			this.table.SetColumnSpan(this.OptionsChecklist, 2);
			this.OptionsChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OptionsChecklist.FormattingEnabled = true;
			this.OptionsChecklist.Location = new System.Drawing.Point(8, 28);
			this.OptionsChecklist.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
			this.OptionsChecklist.Name = "OptionsChecklist";
			this.OptionsChecklist.Size = new System.Drawing.Size(218, 50);
			this.OptionsChecklist.TabIndex = 4;
			// 
			// ItemOptionsDialog
			// 
			this.AcceptButton = this.SaveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(234, 111);
			this.ControlBox = false;
			this.Controls.Add(this.table);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ItemOptionsDialog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Item Options";
			this.table.ResumeLayout(false);
			this.table.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel table;
		private System.Windows.Forms.Label Label;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.CheckedListBox OptionsChecklist;
	}
}