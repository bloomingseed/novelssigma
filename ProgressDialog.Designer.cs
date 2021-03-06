﻿namespace NovelsSigma
{
	partial class ProgressDialog
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
			this.captionLabel = new System.Windows.Forms.Label();
			this.cancelBttn = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// captionLabel
			// 
			this.captionLabel.AutoSize = true;
			this.captionLabel.Location = new System.Drawing.Point(13, 9);
			this.captionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.captionLabel.Name = "captionLabel";
			this.captionLabel.Size = new System.Drawing.Size(92, 17);
			this.captionLabel.TabIndex = 0;
			this.captionLabel.Text = "Progressing..";
			// 
			// cancelBttn
			// 
			this.cancelBttn.Location = new System.Drawing.Point(300, 66);
			this.cancelBttn.Margin = new System.Windows.Forms.Padding(4);
			this.cancelBttn.Name = "cancelBttn";
			this.cancelBttn.Size = new System.Drawing.Size(100, 28);
			this.cancelBttn.TabIndex = 1;
			this.cancelBttn.TabStop = false;
			this.cancelBttn.Text = "Cancel";
			this.cancelBttn.UseVisualStyleBackColor = true;
			this.cancelBttn.Click += new System.EventHandler(this.cancelBttn_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.progressBar1.Location = new System.Drawing.Point(16, 30);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(384, 28);
			this.progressBar1.TabIndex = 2;
			// 
			// ProgressDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 104);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.cancelBttn);
			this.Controls.Add(this.captionLabel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ProgressDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Progress";
			this.Load += new System.EventHandler(this.ProgressDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label captionLabel;
		private System.Windows.Forms.Button cancelBttn;
		private System.Windows.Forms.ProgressBar progressBar1;
	}
}