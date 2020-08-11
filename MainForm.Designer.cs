namespace NovelsSigma
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusTextBox = new System.Windows.Forms.TextBox();
			this.chaptersListBox = new System.Windows.Forms.CheckedListBox();
			this.enterBttn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.checkAllBttn = new System.Windows.Forms.Button();
			this.uncheckAllBttn = new System.Windows.Forms.Button();
			this.renameChapterBttn = new System.Windows.Forms.Button();
			this.saveFolderTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.selectFolderBttn = new System.Windows.Forms.Button();
			this.downloadBttn = new System.Windows.Forms.Button();
			this.resetBttn = new System.Windows.Forms.Button();
			this.resetSaveLocationBttn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// statusTextBox
			// 
			this.statusTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.statusTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusTextBox.Location = new System.Drawing.Point(0, 525);
			this.statusTextBox.Multiline = true;
			this.statusTextBox.Name = "statusTextBox";
			this.statusTextBox.ReadOnly = true;
			this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.statusTextBox.Size = new System.Drawing.Size(496, 20);
			this.statusTextBox.TabIndex = 0;
			this.statusTextBox.TabStop = false;
			this.statusTextBox.Text = "Ready";
			// 
			// chaptersListBox
			// 
			this.chaptersListBox.CheckOnClick = true;
			this.chaptersListBox.FormattingEnabled = true;
			this.chaptersListBox.Location = new System.Drawing.Point(12, 52);
			this.chaptersListBox.Name = "chaptersListBox";
			this.chaptersListBox.Size = new System.Drawing.Size(378, 328);
			this.chaptersListBox.TabIndex = 1;
			// 
			// enterBttn
			// 
			this.enterBttn.Location = new System.Drawing.Point(396, 9);
			this.enterBttn.Name = "enterBttn";
			this.enterBttn.Size = new System.Drawing.Size(93, 23);
			this.enterBttn.TabIndex = 2;
			this.enterBttn.Text = "Enter";
			this.enterBttn.UseVisualStyleBackColor = true;
			this.enterBttn.Click += new System.EventHandler(this.enterBttn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "URL:";
			// 
			// urlTextBox
			// 
			this.urlTextBox.Location = new System.Drawing.Point(58, 9);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.urlTextBox.Size = new System.Drawing.Size(332, 23);
			this.urlTextBox.TabIndex = 4;
			// 
			// checkAllBttn
			// 
			this.checkAllBttn.Location = new System.Drawing.Point(396, 55);
			this.checkAllBttn.Name = "checkAllBttn";
			this.checkAllBttn.Size = new System.Drawing.Size(93, 23);
			this.checkAllBttn.TabIndex = 5;
			this.checkAllBttn.Text = "Check All";
			this.checkAllBttn.UseVisualStyleBackColor = true;
			this.checkAllBttn.Click += new System.EventHandler(this.checkAllBttn_Click);
			// 
			// uncheckAllBttn
			// 
			this.uncheckAllBttn.Location = new System.Drawing.Point(396, 84);
			this.uncheckAllBttn.Name = "uncheckAllBttn";
			this.uncheckAllBttn.Size = new System.Drawing.Size(93, 23);
			this.uncheckAllBttn.TabIndex = 6;
			this.uncheckAllBttn.Text = "Uncheck All";
			this.uncheckAllBttn.UseVisualStyleBackColor = true;
			this.uncheckAllBttn.Click += new System.EventHandler(this.uncheckAllBttn_Click);
			// 
			// renameChapterBttn
			// 
			this.renameChapterBttn.Location = new System.Drawing.Point(396, 113);
			this.renameChapterBttn.Name = "renameChapterBttn";
			this.renameChapterBttn.Size = new System.Drawing.Size(93, 23);
			this.renameChapterBttn.TabIndex = 9;
			this.renameChapterBttn.Text = "Rename...";
			this.renameChapterBttn.UseVisualStyleBackColor = true;
			this.renameChapterBttn.Click += new System.EventHandler(this.renameChapterBttn_Click);
			// 
			// saveFolderTextBox
			// 
			this.saveFolderTextBox.Location = new System.Drawing.Point(83, 398);
			this.saveFolderTextBox.Name = "saveFolderTextBox";
			this.saveFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.saveFolderTextBox.Size = new System.Drawing.Size(307, 23);
			this.saveFolderTextBox.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 401);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "Save To:";
			// 
			// selectFolderBttn
			// 
			this.selectFolderBttn.Location = new System.Drawing.Point(396, 398);
			this.selectFolderBttn.Name = "selectFolderBttn";
			this.selectFolderBttn.Size = new System.Drawing.Size(93, 23);
			this.selectFolderBttn.TabIndex = 10;
			this.selectFolderBttn.Text = "Select...";
			this.selectFolderBttn.UseVisualStyleBackColor = true;
			this.selectFolderBttn.Click += new System.EventHandler(this.selectFolderBttn_Click);
			// 
			// downloadBttn
			// 
			this.downloadBttn.Location = new System.Drawing.Point(357, 470);
			this.downloadBttn.Name = "downloadBttn";
			this.downloadBttn.Size = new System.Drawing.Size(132, 48);
			this.downloadBttn.TabIndex = 13;
			this.downloadBttn.Text = "Download Selected Chapters";
			this.downloadBttn.UseVisualStyleBackColor = true;
			this.downloadBttn.Click += new System.EventHandler(this.downloadBttn_Click);
			// 
			// resetBttn
			// 
			this.resetBttn.Location = new System.Drawing.Point(396, 142);
			this.resetBttn.Name = "resetBttn";
			this.resetBttn.Size = new System.Drawing.Size(93, 23);
			this.resetBttn.TabIndex = 14;
			this.resetBttn.Text = "Reset All";
			this.resetBttn.UseVisualStyleBackColor = true;
			this.resetBttn.Click += new System.EventHandler(this.resetBttn_Click);
			// 
			// resetSaveLocationBttn
			// 
			this.resetSaveLocationBttn.Location = new System.Drawing.Point(396, 427);
			this.resetSaveLocationBttn.Name = "resetSaveLocationBttn";
			this.resetSaveLocationBttn.Size = new System.Drawing.Size(93, 23);
			this.resetSaveLocationBttn.TabIndex = 15;
			this.resetSaveLocationBttn.Text = "Reset Path";
			this.resetSaveLocationBttn.UseVisualStyleBackColor = true;
			this.resetSaveLocationBttn.Click += new System.EventHandler(this.resetSaveLocationBttn_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 545);
			this.Controls.Add(this.resetSaveLocationBttn);
			this.Controls.Add(this.resetBttn);
			this.Controls.Add(this.downloadBttn);
			this.Controls.Add(this.saveFolderTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.selectFolderBttn);
			this.Controls.Add(this.renameChapterBttn);
			this.Controls.Add(this.uncheckAllBttn);
			this.Controls.Add(this.checkAllBttn);
			this.Controls.Add(this.urlTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.enterBttn);
			this.Controls.Add(this.chaptersListBox);
			this.Controls.Add(this.statusTextBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Novels Sigma";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox statusTextBox;
		private System.Windows.Forms.CheckedListBox chaptersListBox;
		private System.Windows.Forms.Button enterBttn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Button checkAllBttn;
		private System.Windows.Forms.Button uncheckAllBttn;
		private System.Windows.Forms.Button renameChapterBttn;
		private System.Windows.Forms.TextBox saveFolderTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button selectFolderBttn;
		private System.Windows.Forms.Button downloadBttn;
		private System.Windows.Forms.Button resetBttn;
		private System.Windows.Forms.Button resetSaveLocationBttn;
	}
}