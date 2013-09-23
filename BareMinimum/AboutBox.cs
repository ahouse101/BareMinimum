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
	public partial class AboutBox : Form
	{
		private AboutBox()
		{
			InitializeComponent();
			VersionLabel.Text = "Version: " + AssemblyVersion;
		}

		public static void ShowAbout()
		{
			AboutBox box = new AboutBox();
			box.ShowDialog();
		}

		private string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
