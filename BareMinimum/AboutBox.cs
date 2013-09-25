﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace BareMinimum
{
	public partial class AboutBox : UserControl
	{
		public AboutBox()
		{
			InitializeComponent();
			VersionLabel.Text = "Version: " + AssemblyVersion;
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
