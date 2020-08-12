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
		public MainForm()
		{
			InitializeComponent();
			this.Load += resetBttn_Click;

			this.Icon = Resource.logo_icon;
		}
		
		private void GotResultHandler()
		{
			BindCheckedListBox();
			//
			// check all items
			for (int i = 0; i < chaptersListBox.Items.Count; ++i)
				chaptersListBox.SetItemChecked(i, true);

			checkAllBttn.Enabled = uncheckAllBttn.Enabled = renameChapterBttn.Enabled
			= downloadBttn.Enabled = resetBttn.Enabled = chaptersListBox.Enabled = saveFolderTextBox.Enabled = selectFolderBttn.Enabled = resetSaveLocationBttn.Enabled = true;
			saveFolderTextBox.Text = downloader.SaveLocation.OriginalString;
		}

		private void enterBttn_Click(object sender, EventArgs e)
		{
				Uri url = null;
				string dialogTitle = "Fetch chapter lists";
			try
			{
				url = new Uri(urlTextBox.Text.Trim());
			}
			catch(Exception err) { MessageBox.Show(this, err.Message + "\r\nPlease try a different URL", "Fetch Chapter Lists Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

			ProgressDialog dialog = new ProgressDialog(dialogTitle);
			dialog.worker.DoWork += (pbsher, arg) =>
			{
				BackgroundWorker bgrWorker = pbsher as BackgroundWorker;
				arg.Result = new Downloader(Downloader.Process(Downloader.PreProcess((string)arg.Argument, bgrWorker, arg), bgrWorker, arg));
			};
			dialog.worker.RunWorkerCompleted += (pbsher, arg) =>
			{
				if (arg.Error != null)
					MessageBox.Show(this, arg.Error.Message, "Fetch Chapter Lists Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error); 
				else if (!arg.Cancelled)
				{
					downloader = arg.Result as Downloader;
					MessageBox.Show($"Fetched {downloader.Resource.Chapters.Count} chapters of \"{downloader.Resource.NovelName}\".", dialogTitle + " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					GotResultHandler();
				}
			};
			dialog.ShowDialog(this, url.AbsoluteUri);
			
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
			= downloadBttn.Enabled = resetBttn.Enabled = chaptersListBox.Enabled 
			= saveFolderTextBox.Enabled = selectFolderBttn.Enabled = resetSaveLocationBttn.Enabled = false;
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
				saveFolderTextBox.Text = downloader.SaveLocation.OriginalString;
			}
		}

		private void resetSaveLocationBttn_Click(object sender, EventArgs e)
		{
			downloader.ResetSaveLocation();
			saveFolderTextBox.Text = downloader.SaveLocation.OriginalString;
		}

		private void downloadBttn_Click(object sender, EventArgs e)
		{
			try
			{
				string customUri = saveFolderTextBox.Text.Trim();
				downloader.checkedIndices = new int[chaptersListBox.CheckedIndices.Count];
				foreach (int i in chaptersListBox.CheckedIndices)
					downloader.checkedIndices[i] = i;
				downloader.SaveLocation = new Uri(customUri);

				if (!Directory.Exists(downloader.SaveLocation.OriginalString)
					&& MessageBox.Show(this, "The path \"" + downloader.SaveLocation.OriginalString + "\"doesn't exist.\r\nDo you want to create this path?", "Path doesn't exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					throw new Exception("Please reselect save path.");

				Downloader _downloader = new Downloader(downloader);
				ProgressDialog dialog = new ProgressDialog("Download chapters");
				dialog.worker.DoWork += (pbsher, arg) =>
				 {
					 Downloader passedDownloader = arg.Argument as Downloader;
					 passedDownloader.Download(pbsher as BackgroundWorker, arg);
					 // quick solution; improvable
					 arg.Result = passedDownloader;
				 };
				dialog.worker.RunWorkerCompleted += (pbsher, arg) =>
				 {
					 if (arg.Error != null)
						 MessageBox.Show(arg.Error.Message + "Please remove the downloaded files manually at\r\n" + _downloader.SaveLocation.OriginalString, "Download Chapters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					 else if (arg.Cancelled)
						 MessageBox.Show(this, "Download cancelled. Please remove the downloaded files manually at\r\n" + _downloader.SaveLocation.OriginalString, "Download Chapters Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					 else
					 {
						 Downloader passedDownloader = arg.Result as Downloader;
						 MessageBox.Show(this, passedDownloader.checkedIndices.Length + " files downloaded to " + passedDownloader.SaveLocation.OriginalString + ".", "Download Chapters Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
					 }

				 };

				dialog.Show(_downloader);
			}
			catch (Exception err) { MessageBox.Show(err.Message, "Download Chapters Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}



	}
}
