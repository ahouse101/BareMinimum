using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BareMinimum
{
	public class InfoOverlay
	{
		private Form owner;
		public Panel Background { get; set; }
		public Control Content { get; set; }
		public event EventHandler PanelClosing;

		public InfoOverlay(Form owner, Control content, bool closeOnClick)
			: this(owner, content, Color.White, closeOnClick)
		{ }

		public InfoOverlay(Form owner, Control content, Color backColor, bool closeOnClick)
		{
			this.owner = owner;
			Background = new Panel();
			Content = content;

			Background.BackColor = backColor;
			Background.Location = new Point(0, 0);
			Background.Size = owner.ClientSize;
			Background.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
			if (closeOnClick)
				Background.Click += Background_Click;

			Point location = new Point();
			location.X = (Background.Size.Width - Content.Size.Width) / 2;
			location.Y = (Background.Size.Height - Content.Size.Height) / 2;
			Content.Location = location;
			Content.Anchor = AnchorStyles.None;

			Background.Controls.Add(Content);
			owner.Controls.Add(Background);
			Background.BringToFront();
			Background.Refresh();
		}

		void Background_Click(object sender, EventArgs e)
		{
			if (!OnPanelClosing(new EventArgs()))
				Close();
		}

		public void Close()
		{
			Content.Dispose();
			Background.Dispose();
		}

		protected virtual bool OnPanelClosing(EventArgs e)
		{
			EventHandler handler = PanelClosing;

			// Event will be null if there are no subscribers 
			if (handler != null)
			{
				handler(this, e);
				return true;
			}
			else
				return false;
		}
	}
}