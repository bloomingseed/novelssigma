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
		public BackgroundWorker worker;
		//public Downloader.ProcessResult Result;
		private object workerArg;
		public ProgressDialog(string title)
		{
			InitializeComponent();

			this.Icon = Resource.process_icon;
			this.Text = title;

			worker = new BackgroundWorker();
			worker.WorkerReportsProgress = worker.WorkerSupportsCancellation = true;
			worker.ProgressChanged += (sender, e) =>
			{
				if(e.UserState != null)
					captionLabel.Text = e.UserState.ToString();
				progressBar1.Value = e.ProgressPercentage;
			};
			worker.RunWorkerCompleted += (sender, e) =>
			{
				//if (e.Error != null)
				//{
				//	MessageBox.Show(e.Error.Message, title + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//}
				//if (e.Cancelled)
				//{
				//	MessageBox.Show("Result discarded.", title + " Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//}
				//else
				//{
				//	Downloader.ProcessResult res = e.Result as Downloader.ProcessResult;
				//	MessageBox.Show($"Fetched {res.Chapters} chapters of \"{res.NovelName}\".", title + " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//}
				this.Close();
			};
		}
		//public void Show(Downloader downloader)
		public void Show(Downloader downloader)
		{
			workerArg = downloader;
			base.Show();
		}
		public DialogResult ShowDialog(IWin32Window owner, string url)
		{
			workerArg = url;
			return base.ShowDialog(owner);
		}

		private void ProgressDialog_Load(object sender, EventArgs e)
		{
			worker.RunWorkerAsync(workerArg);
		}

		private void cancelBttn_Click(object sender, EventArgs e)
		{
				worker.CancelAsync();
		}
	}
}
