using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BareMinimum
{
	public partial class ItemOptionsBox : UserControl
	{
		public event EventHandler<ItemOptionsEventArgs> DialogFinished;
		private Dictionary<string, bool> results;
		private InfoOverlay overlay;
		private bool isDialogMode = false;

		public ItemOptionsBox(Dictionary<string, bool> options)
		{
			InitializeComponent();

			Bitmap bmp = new Bitmap(this.Width, this.Height);
			Graphics g = Graphics.FromImage(bmp);
			Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
			LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.FromArgb(230, 230, 230), Color.White, LinearGradientMode.ForwardDiagonal);
			g.FillRectangle(lgb, 0, 0, this.Width, this.Height);
			table.BackgroundImage = bmp;
			this.BackColor = Color.FromArgb(25, 25, 25);
			
			results = options;
			foreach (KeyValuePair<string, bool> option in options)
			{
				OptionsChecklist.Items.Add(option.Key, option.Value);
			}
		}

		public void ShowPanel(Form owner, Point location)
		{
			this.Location = location;
			this.Anchor = AnchorStyles.Left;

			owner.Controls.Add(this);
			this.BringToFront();
		}

		public void ShowDialogPanel(Form owner)
		{
			overlay = new InfoOverlay(owner, this, true);
			overlay.PanelClosing += Panel_Closing;
			isDialogMode = true;

			Refresh();
		}

		private void Panel_Closing(object sender, EventArgs e)
		{
			Close();
			overlay.Close();
			OnDialogFinished(new ItemOptionsEventArgs(false));
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			results.Clear();
			for (int i = 0; i < OptionsChecklist.Items.Count; i++)
				results.Add(OptionsChecklist.Items[i].ToString(), OptionsChecklist.GetItemChecked(i));
			Close();
			OnDialogFinished(new ItemOptionsEventArgs(true, results));
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			Close();
			OnDialogFinished(new ItemOptionsEventArgs(false));
		}

		protected virtual void Close()
		{
			if (isDialogMode)
				overlay.Close();
			else
				this.Dispose();
		}

		protected virtual void OnDialogFinished(ItemOptionsEventArgs e)
		{
			// Make a temporary copy of the event to avoid possibility of 
			// a race condition if the last subscriber unsubscribes 
			// immediately after the null check and before the event is raised.
			EventHandler<ItemOptionsEventArgs> handler = DialogFinished;

			// Event will be null if there are no subscribers 
			if (handler != null)
			{
				handler(this, e);
			}
		}
	}

	public class ItemOptionsEventArgs : EventArgs
	{
		private Dictionary<string, bool> optionsChecked;
		private bool dialogOk;

		public ItemOptionsEventArgs(bool dialogOk, Dictionary<string, bool> results = null)
		{
			this.optionsChecked = results;
			this.dialogOk = dialogOk;
		}

		public Dictionary<string, bool> OptionsChecked
		{
			get { return optionsChecked; }
		}

		public bool DialogOk
		{
			get { return dialogOk; }
		}
	}

}
