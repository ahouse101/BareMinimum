namespace BareMinimum
{
	partial class InfoBox
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
			this.MessageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// MessageLabel
			// 
			this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MessageLabel.Location = new System.Drawing.Point(0, 0);
			this.MessageLabel.Name = "MessageLabel";
			this.MessageLabel.Size = new System.Drawing.Size(222, 75);
			this.MessageLabel.TabIndex = 0;
			this.MessageLabel.Text = "Message goes here.";
			this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// InfoBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 75);
			this.ControlBox = false;
			this.Controls.Add(this.MessageLabel);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InfoBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "InfoBox";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label MessageLabel;
	}
}