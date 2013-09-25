using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace BareMinimum
{
	public partial class AboutBoxOld : Form
	{
		private AboutBoxOld()
		{
			InitializeComponent();
			VersionLabel.Text = "Version: " + AssemblyVersion;
		}

		public static void ShowAbout()
		{
			AboutBoxOld box = new AboutBoxOld();
			box.ShowDialog();
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

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AboutBox_Load(object sender, EventArgs e)
		{
			this.CreditsTextBox.SelectionLength = 0;
			this.CloseButton.Select();
		}
	}
}
