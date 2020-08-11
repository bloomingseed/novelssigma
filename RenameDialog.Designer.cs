namespace NovelsSigma
{
	partial class RenameDialog
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.patternTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.previewTextBox = new System.Windows.Forms.TextBox();
			this.renameBttn = new System.Windows.Forms.Button();
			this.cancelBttn = new System.Windows.Forms.Button();
			this.previewToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Define name pattern:";
			// 
			// patternTextBox
			// 
			this.patternTextBox.Location = new System.Drawing.Point(159, 12);
			this.patternTextBox.Name = "patternTextBox";
			this.patternTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.patternTextBox.Size = new System.Drawing.Size(171, 23);
			this.patternTextBox.TabIndex = 0;
			this.patternTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Preview:";
			// 
			// previewTextBox
			// 
			this.previewTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.previewTextBox.Location = new System.Drawing.Point(159, 49);
			this.previewTextBox.Name = "previewTextBox";
			this.previewTextBox.ReadOnly = true;
			this.previewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.previewTextBox.Size = new System.Drawing.Size(171, 23);
			this.previewTextBox.TabIndex = 1;
			// 
			// renameBttn
			// 
			this.renameBttn.Location = new System.Drawing.Point(159, 89);
			this.renameBttn.Name = "renameBttn";
			this.renameBttn.Size = new System.Drawing.Size(75, 23);
			this.renameBttn.TabIndex = 2;
			this.renameBttn.Text = "Rename";
			this.renameBttn.UseVisualStyleBackColor = true;
			this.renameBttn.Click += new System.EventHandler(this.renameBttn_Click);
			// 
			// cancelBttn
			// 
			this.cancelBttn.Location = new System.Drawing.Point(255, 89);
			this.cancelBttn.Name = "cancelBttn";
			this.cancelBttn.Size = new System.Drawing.Size(75, 23);
			this.cancelBttn.TabIndex = 3;
			this.cancelBttn.Text = "Cancel";
			this.cancelBttn.UseVisualStyleBackColor = true;
			this.cancelBttn.Click += new System.EventHandler(this.cancelBttn_Click);
			// 
			// previewToolTip
			// 
			this.previewToolTip.AutoPopDelay = 5000;
			this.previewToolTip.InitialDelay = 300;
			this.previewToolTip.ReshowDelay = 100;
			this.previewToolTip.UseFading = false;
			// 
			// RenameDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 121);
			this.Controls.Add(this.cancelBttn);
			this.Controls.Add(this.renameBttn);
			this.Controls.Add(this.previewTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.patternTextBox);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "RenameDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Rename selected items";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox patternTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox previewTextBox;
		private System.Windows.Forms.Button renameBttn;
		private System.Windows.Forms.Button cancelBttn;
		private System.Windows.Forms.ToolTip previewToolTip;
	}
}