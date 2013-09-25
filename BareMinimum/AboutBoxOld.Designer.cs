namespace BareMinimum
{
	partial class AboutBoxOld
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
			this.LogoPictureBox = new System.Windows.Forms.PictureBox();
			this.VersionLabel = new System.Windows.Forms.Label();
			this.CreditsLabel = new System.Windows.Forms.Label();
			this.CreditsTextBox = new System.Windows.Forms.TextBox();
			this.CloseButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// LogoPictureBox
			// 
			this.LogoPictureBox.Image = global::BareMinimum.Properties.Resources.Logo;
			this.LogoPictureBox.Location = new System.Drawing.Point(5, 5);
			this.LogoPictureBox.Name = "LogoPictureBox";
			this.LogoPictureBox.Size = new System.Drawing.Size(128, 128);
			this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.LogoPictureBox.TabIndex = 0;
			this.LogoPictureBox.TabStop = false;
			// 
			// VersionLabel
			// 
			this.VersionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VersionLabel.Location = new System.Drawing.Point(135, 10);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(245, 20);
			this.VersionLabel.TabIndex = 1;
			this.VersionLabel.Text = "Version: 1.0.0";
			// 
			// CreditsLabel
			// 
			this.CreditsLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreditsLabel.Location = new System.Drawing.Point(135, 35);
			this.CreditsLabel.Name = "CreditsLabel";
			this.CreditsLabel.Size = new System.Drawing.Size(245, 20);
			this.CreditsLabel.TabIndex = 2;
			this.CreditsLabel.Text = "Credits:";
			// 
			// CreditsTextBox
			// 
			this.CreditsTextBox.Location = new System.Drawing.Point(140, 55);
			this.CreditsTextBox.Multiline = true;
			this.CreditsTextBox.Name = "CreditsTextBox";
			this.CreditsTextBox.ReadOnly = true;
			this.CreditsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.CreditsTextBox.Size = new System.Drawing.Size(240, 95);
			this.CreditsTextBox.TabIndex = 3;
			this.CreditsTextBox.Text = "Copyright © Alex House 2013\r\nIcon Design by Zac Abbott\r\nJson.NET by James Newton-" +
    "King\r\nObjectListView by Bright Ideas Software\r\nPlexiglass Class by Hans Passant";
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseButton.Location = new System.Drawing.Point(305, 155);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 4;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// AboutBox
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(384, 182);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.CreditsTextBox);
			this.Controls.Add(this.CreditsLabel);
			this.Controls.Add(this.VersionLabel);
			this.Controls.Add(this.LogoPictureBox);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About BareMinimum";
			this.Load += new System.EventHandler(this.AboutBox_Load);
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox LogoPictureBox;
		private System.Windows.Forms.Label VersionLabel;
		private System.Windows.Forms.Label CreditsLabel;
		private System.Windows.Forms.TextBox CreditsTextBox;
		private System.Windows.Forms.Button CloseButton;
	}
}