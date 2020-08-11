using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelsSigma
{
	public partial class RenameDialog : Form
	{
		public string Pattern { get; set; }
		public RenameDialog()
		{
			InitializeComponent();
			previewToolTip.SetToolTip(this.previewTextBox, "Each item name will have an increasing number at the end, starting from number 1.");
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Pattern = patternTextBox.Text;
			previewTextBox.Text = Pattern + "1";
		}

		private void renameBttn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelBttn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
