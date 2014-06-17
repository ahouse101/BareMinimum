namespace BareMinimum
{
	partial class ItemOptionsBox
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.table = new System.Windows.Forms.TableLayoutPanel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.OptionsChecklist = new System.Windows.Forms.CheckedListBox();
			this.Label = new System.Windows.Forms.Label();
			this.table.SuspendLayout();
			this.SuspendLayout();
			// 
			// table
			// 
			this.table.ColumnCount = 2;
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.table.Controls.Add(this.SaveButton, 0, 2);
			this.table.Controls.Add(this.Cancel, 1, 2);
			this.table.Controls.Add(this.OptionsChecklist, 0, 1);
			this.table.Controls.Add(this.Label, 0, 0);
			this.table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.table.Location = new System.Drawing.Point(1, 1);
			this.table.Name = "table";
			this.table.RowCount = 3;
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.table.Size = new System.Drawing.Size(248, 123);
			this.table.TabIndex = 1;
			// 
			// SaveButton
			// 
			this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SaveButton.Location = new System.Drawing.Point(3, 96);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(118, 24);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Ok";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Cancel.Location = new System.Drawing.Point(124, 96);
			this.Cancel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(121, 24);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// OptionsChecklist
			// 
			this.OptionsChecklist.CheckOnClick = true;
			this.table.SetColumnSpan(this.OptionsChecklist, 2);
			this.OptionsChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OptionsChecklist.FormattingEnabled = true;
			this.OptionsChecklist.Location = new System.Drawing.Point(4, 25);
			this.OptionsChecklist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.OptionsChecklist.Name = "OptionsChecklist";
			this.OptionsChecklist.Size = new System.Drawing.Size(240, 68);
			this.OptionsChecklist.TabIndex = 4;
			// 
			// Label
			// 
			this.Label.AutoSize = true;
			this.Label.BackColor = System.Drawing.Color.Transparent;
			this.table.SetColumnSpan(this.Label, 2);
			this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label.Location = new System.Drawing.Point(3, 0);
			this.Label.Name = "Label";
			this.Label.Size = new System.Drawing.Size(242, 25);
			this.Label.TabIndex = 5;
			this.Label.Text = "Select the options that should be active:";
			this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ItemOptionsBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.table);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "ItemOptionsBox";
			this.Padding = new System.Windows.Forms.Padding(1);
			this.Size = new System.Drawing.Size(250, 125);
			this.table.ResumeLayout(false);
			this.table.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel table;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.CheckedListBox OptionsChecklist;
		private System.Windows.Forms.Label Label;

	}
}
