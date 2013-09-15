using System.Windows.Forms;

namespace BareMinimum
{
	public partial class InfoBox : Form
	{
		private InfoBox()
		{
			InitializeComponent();
		}

		public static InfoBox ShowMessage(string message, string caption, Form parent)
		{
			InfoBox box = new InfoBox();
			box.MessageLabel.Text = message;
			box.Text = caption;
			int x = (parent.DesktopLocation.X + (parent.Width / 2)) - (box.Width / 2);
			int y = (parent.DesktopLocation.Y + (parent.Height / 2)) - (box.Height / 2);
			box.Show();
			box.SetDesktopLocation(x, y);
			box.Refresh();
			return box;
		}

		public string Message
		{
			get
			{
				return this.MessageLabel.Text;
			}
			set
			{
				this.MessageLabel.Text = value;
			}
		}
	}
}
