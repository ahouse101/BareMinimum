using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace BareMinimum
{
	public partial class AboutBox : UserControl
	{
		public AboutBox()
		{
			InitializeComponent();
			VersionLabel.Text = "Version: " + AssemblyVersion;

			Bitmap bmp = new Bitmap(this.Width, this.Height);
			Graphics g = Graphics.FromImage(bmp);
			Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
			LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.White, Color.FromArgb(230, 230, 230), LinearGradientMode.Vertical);
			g.FillRectangle(lgb, 0, 0, this.Width, this.Height);
			this.BackgroundImage = bmp;
		}

		private string AssemblyVersion
		{
			get
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;
				string versionString;
				versionString = String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
				if (version.Revision != 0)
				{
					versionString += String.Format("r{0}", version.Revision);
				}
				return versionString;
			}
		}
	}
}
