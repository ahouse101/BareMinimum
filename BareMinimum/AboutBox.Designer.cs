namespace BareMinimum
{
	partial class AboutBox
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
			this.CreditsLabel = new System.Windows.Forms.Label();
			this.VersionLabel = new System.Windows.Forms.Label();
			this.CreditsText = new System.Windows.Forms.Label();
			this.LogoPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// CreditsLabel
			// 
			this.CreditsLabel.BackColor = System.Drawing.Color.Transparent;
			this.CreditsLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreditsLabel.Location = new System.Drawing.Point(135, 35);
			this.CreditsLabel.Name = "CreditsLabel";
			this.CreditsLabel.Size = new System.Drawing.Size(245, 20);
			this.CreditsLabel.TabIndex = 7;
			this.CreditsLabel.Text = "Credits:";
			// 
			// VersionLabel
			// 
			this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
			this.VersionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VersionLabel.Location = new System.Drawing.Point(135, 10);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(209, 20);
			this.VersionLabel.TabIndex = 6;
			this.VersionLabel.Text = "Version: 1.0.0";
			// 
			// CreditsText
			// 
			this.CreditsText.BackColor = System.Drawing.Color.Transparent;
			this.CreditsText.Location = new System.Drawing.Point(145, 60);
			this.CreditsText.Name = "CreditsText";
			this.CreditsText.Size = new System.Drawing.Size(235, 73);
			this.CreditsText.TabIndex = 8;
			this.CreditsText.Text = "Copyright © Alex House 2013\r\nIcon Design by Zac Abbott\r\nJson.NET by James Newton-" +
    "King\r\nObjectListView by Bright Ideas Software";
			// 
			// LogoPictureBox
			// 
			this.LogoPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.LogoPictureBox.Image = global::BareMinimum.Properties.Resources.Logo;
			this.LogoPictureBox.Location = new System.Drawing.Point(5, 5);
			this.LogoPictureBox.Name = "LogoPictureBox";
			this.LogoPictureBox.Size = new System.Drawing.Size(128, 128);
			this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.LogoPictureBox.TabIndex = 5;
			this.LogoPictureBox.TabStop = false;
			// 
			// AboutBox
			// 
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.CreditsText);
			this.Controls.Add(this.CreditsLabel);
			this.Controls.Add(this.VersionLabel);
			this.Controls.Add(this.LogoPictureBox);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "AboutBox";
			this.Size = new System.Drawing.Size(387, 140);
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label CreditsLabel;
		private System.Windows.Forms.Label VersionLabel;
		private System.Windows.Forms.PictureBox LogoPictureBox;
		private System.Windows.Forms.Label CreditsText;

	}
}
