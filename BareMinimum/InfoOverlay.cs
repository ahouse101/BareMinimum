using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BareMinimum
{
	public class InfoOverlay
	{
		private Form owner;
		private GlassPanel background;
		private ContentPanelOverlay contentPanel;
		private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;

		public InfoOverlay(Form formToOverlay, Control contentControl, bool closeOnClick)
		{
			this.owner = formToOverlay;
			this.background = new GlassPanel(formToOverlay, Color.White, 0.75, closeOnClick);
			this.contentPanel = new ContentPanelOverlay(contentControl, background);

			contentPanel.Refresh();
		}

		public Control Content
		{
			get
			{
				return contentPanel.Content;
			}
			set
			{
				contentPanel.Content = value;
			}
		}

		public void Close()
		{
			contentPanel.Close();
			background.Close();
		}
	}

	public class ContentPanelOverlay : GlassPanel
	{
		Control content;
		GlassPanel background;

		public Control Content
		{
			get
			{
				return content;
			}
			set
			{
				content = value;
				RecalculateLocation();
			}
		}

		public ContentPanelOverlay(Control contentControl, GlassPanel background)
			: base(background, Color.White, 1.0, false)
		{
			this.content = contentControl;
			this.background = background;

			Size size = contentControl.Size;
			Point location = background.PointToScreen(Point.Empty);
			location.X += (background.ClientSize.Width - size.Width) / 2;
			location.Y += (background.ClientSize.Height - size.Height) / 2;

			this.ClientSize = size;
			this.Location = location;

			background.LocationChanged += RecalculateNeeded;
			background.ClientSizeChanged += RecalculateNeeded;
			contentControl.SizeChanged += RecalculateNeeded;

			this.Controls.Add(contentControl);
		}

		private void RecalculateNeeded(object sender, EventArgs e)
		{
			RecalculateLocation();
		}

		private void RecalculateLocation()
		{
			ClientSize = content.Size;
			Point location = background.PointToScreen(Point.Empty);
			location.X += (background.ClientSize.Width - ClientSize.Width) / 2;
			location.Y += (background.ClientSize.Height - ClientSize.Height) / 2;

			this.Location = location;
		}
	}

	// Thanks to Hans Passant, who wrote the original Plexiglass class for a StackOverlow question (the URL is below). 
	// http://stackoverflow.com/questions/4503210/draw-semi-transparent-overlay-image-all-over-the-windows-form-having-some-contro
	public class GlassPanel : Form
	{
		private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;

		public GlassPanel(Form toCover, Color color, double opacity, bool closeOnClick)
		{
			this.BackColor = color;
			this.Opacity = opacity;
			this.FormBorderStyle = FormBorderStyle.None;
			this.ControlBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.Manual;
			this.AutoScaleMode = AutoScaleMode.None;
			this.Location = toCover.PointToScreen(Point.Empty);
			this.ClientSize = toCover.ClientSize;
			toCover.LocationChanged += Cover_LocationChanged;
			toCover.ClientSizeChanged += Cover_ClientSizeChanged;
			if (closeOnClick)
				this.Click += GlassPanel_Click;
			this.Show(toCover);
			toCover.Focus();
			// Disable Aero transitions, the plexiglass gets too visible
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int value = 1;
				DwmSetWindowAttribute(toCover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
			}
		}

		void GlassPanel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected virtual void Cover_LocationChanged(object sender, EventArgs e)
		{
			// Ensure the plexiglass follows the owner
			this.Location = this.Owner.PointToScreen(Point.Empty);
		}

		protected virtual void Cover_ClientSizeChanged(object sender, EventArgs e)
		{
			// Ensure the plexiglass keeps the owner covered
			this.ClientSize = this.Owner.ClientSize;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			// Restore owner
			this.Owner.LocationChanged -= Cover_LocationChanged;
			this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
			if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
			{
				int value = 0;
				DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
			}
			base.OnFormClosing(e);
		}

		protected override void OnActivated(EventArgs e)
		{
			// Always keep the owner activated instead
			this.BeginInvoke(new Action(() => this.Owner.Activate()));
		}

		[DllImport("dwmapi.dll")]
		private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
	}
}