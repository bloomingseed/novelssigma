using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovelsSigma.Properties;

namespace NovelsSigma
{
	public partial class MainForm : Form
	{
		private Downloader downloader;
		private event EventHandler GotResult;
		public MainForm()
		{
			InitializeComponent();
			this.Load += resetBttn_Click;
			this.GotResult += GotResultHandler;

			this.Icon = Resource.logo_icon;
		}
		
		private void GotResultHandler(object sender, EventArgs args)
		{
			BindCheckedListBox();
			//
			// check all items
			for (int i = 0; i < chaptersListBox.Items.Count; ++i)
				chaptersListBox.SetItemChecked(i, true);

			checkAllBttn.Enabled = uncheckAllBttn.Enabled = renameChapterBttn.Enabled
			= downloadBttn.Enabled = resetBttn.Enabled = chaptersListBox.Enabled = saveFolderTextBox.Enabled = selectFolderBttn.Enabled = true;
			saveFolderTextBox.Text = downloader.SaveLocation.AbsolutePath;
		}

		private async void enterBttn_Click(object sender, EventArgs e)
		{
			try
			{
				Uri url = new Uri(urlTextBox.Text.Trim());
				statusTextBox.Text = "Getting chapters list.. (This process may take time)";
				//Task<Downloader> task = new TaskFactory<Downloader>().StartNew(() => new Downloader(Downloader.Process(url.AbsoluteUri)));

				////while (task.IsCompleted)
				////	progressBar1.PerformStep();
				//await task;
				//downloader = task.Result;
				////downloader = new Downloader(Downloader.Process(url.AbsoluteUri));

				//GotResult.Invoke(this, new EventArgs());
				ProgressDialog dialog = new ProgressDialog("Getting chapters list..");
				dialog.arg = url;
				dialog.worker.DoWork += (pbsher, arg) =>
				{
					BackgroundWorker bgrWorker = pbsher as BackgroundWorker;
					if (bgrWorker.CancellationPending)
						throw new Exception("Process canceled.");
					arg.Result = new Downloader(Downloader.Process((arg.Argument as Uri).AbsoluteUri), null);
				};
			}
			catch(Exception err) { MessageBox.Show(this, err.Message, "Process URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
		private void BindCheckedListBox()
		{
			chaptersListBox.Items.Clear();
			foreach(var item in downloader.Resource.Chapters)
			{
				chaptersListBox.Items.Add(item.Key);
			}
		}

		private void checkAllBttn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < chaptersListBox.Items.Count; ++i)
				chaptersListBox.SetItemChecked(i, true);
		}

		private void uncheckAllBttn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < chaptersListBox.Items.Count; ++i)
				chaptersListBox.SetItemChecked(i, false);
		}

		private void renameChapterBttn_Click(object sender, EventArgs e)
		{
			RenameDialog renameDialog = new RenameDialog();
			if(renameDialog.ShowDialog(this) == DialogResult.OK)
			{
				for(int i = 0;i<chaptersListBox.CheckedItems.Count;++i)
				{
					chaptersListBox.Items[chaptersListBox.CheckedIndices[i]] = downloader.Resource.Chapters[(string)chaptersListBox.CheckedItems[i]]
																			= renameDialog.Pattern + (i + 1); ;
					
				}
			}
		}

		private void resetBttn_Click(object sender, EventArgs e)
		{
			chaptersListBox.Items.Clear();
			checkAllBttn.Enabled = uncheckAllBttn.Enabled = renameChapterBttn.Enabled
			= downloadBttn.Enabled = resetBttn.Enabled = chaptersListBox.Enabled = saveFolderTextBox.Enabled = selectFolderBttn.Enabled = false;
			saveFolderTextBox.Text = "";
			downloader = null;
		}

		private void selectFolderBttn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog browserDialog = new FolderBrowserDialog();
			browserDialog.Description = "Select where to save your chapter files";
			browserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
			browserDialog.ShowNewFolderButton = true;
			if (browserDialog.ShowDialog(this) == DialogResult.OK)
			{
				downloader.SaveLocation = new Uri(browserDialog.SelectedPath);
				saveFolderTextBox.Text = downloader.SaveLocation.AbsolutePath;
			}
		}

		private void resetSaveLocationBttn_Click(object sender, EventArgs e)
		{
			downloader.ResetSaveLocation();
			saveFolderTextBox.Text = downloader.SaveLocation.AbsolutePath;
		}

		private async void downloadBttn_Click(object sender, EventArgs e)
		{
			try
			{
				string customUri = saveFolderTextBox.Text.Trim();
				int[] indices = null;
				downloader.SaveLocation = new Uri(customUri);

				if (!Directory.Exists(downloader.SaveLocation.AbsolutePath))
					if (MessageBox.Show(this, "The path \"" + downloader.SaveLocation.AbsolutePath + "\"doesn't exist.\r\nDo you want to create this path?", "Path doesn't exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
						throw new Exception("Please reselect save path.");

				if (chaptersListBox.CheckedIndices.Count > 0)
				{
					indices = new int[chaptersListBox.CheckedIndices.Count];
					for (int i = 0; i < chaptersListBox.CheckedIndices.Count; ++i)
						indices[i] = chaptersListBox.CheckedIndices[i];
				}
				else
					throw new Exception("Please select (check) at least 1 chapter to download.");

				downloader.Downloading += Downloader_Downloading;

				await Task.Run(() => downloader.Download(indices));
				
				MessageBox.Show(this, indices.Length + " files downloaded to " + downloader.SaveLocation.AbsolutePath + ".", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
				statusTextBox.Text = "Ready";
			}
			catch (Exception err) { MessageBox.Show(err.Message + "\r\nPlease visit development site for help.", "Download Chapters Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		//private delegate void SetStatusTextDelegate(string text);
		private void Downloader_Downloading(object sender, Downloader.DownloadingEventArgs e)
		{
			Action<string> action = new Action<string>((txt) => { statusTextBox.Text = $"Downloading {txt}.."; });
			statusTextBox.Invoke(action, new object[] { e.Target.Key });
		}



	}
}
