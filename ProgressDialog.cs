using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovelsSigma.Properties;

namespace NovelsSigma
{
	public partial class ProgressDialog : Form
	{
		private bool isDialog;
		public BackgroundWorker worker;
		public object arg;
		public ProgressDialog(string caption)
		{
			InitializeComponent();
			this.Icon = Resource.process_icon;
			captionLabel.Text = caption;
		}
		public new void Show()
		{
			isDialog = false;
			base.Show();
		}
		public new DialogResult ShowDialog(IWin32Window owner)
		{
			isDialog = true;
			return base.ShowDialog(owner);
		}

		private void ProgressDialog_Load(object sender, EventArgs e)
		{
			if (isDialog)
			{
				this.ShowInTaskbar = this.ShowIcon = false;
			}
			else
			{
				this.ShowInTaskbar = this.ShowIcon = false;
			}
		}

		private void cancelBttn_Click(object sender, EventArgs e)
		{
			worker.RunWorkerAsync(arg);
		}
	}
}
