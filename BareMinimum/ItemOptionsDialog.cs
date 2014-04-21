using BareMinimumCore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BareMinimum
{
	public partial class ItemOptionsDialog : Form
	{
		public ItemOptionsDialog(Dictionary<string, bool> options)
		{
			InitializeComponent();
			foreach (KeyValuePair<string, bool> option in options)
			{
				OptionsChecklist.Items.Add(option.Key, option.Value);
			}
		}

		public DialogResult ShowDialog(out Dictionary<string, bool> optionsResults)
		{
			DialogResult result = base.ShowDialog();
			optionsResults = new Dictionary<string, bool>();
			for (int i = 0; i < OptionsChecklist.Items.Count; i++)
			{
				optionsResults.Add(OptionsChecklist.Items[i].ToString(), OptionsChecklist.GetItemChecked(i));
			}
			return result;
		}
	}
}
