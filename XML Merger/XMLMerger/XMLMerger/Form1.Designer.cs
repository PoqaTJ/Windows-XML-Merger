namespace XMLMerger
{
    partial class Form1
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
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.RemoveFileButton = new System.Windows.Forms.Button();
            this.ClearFilesButton = new System.Windows.Forms.Button();
            this.FileList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MergeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.Location = new System.Drawing.Point(3, 294);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(75, 23);
            this.AddFilesButton.TabIndex = 1;
            this.AddFilesButton.Text = "Add Files";
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // RemoveFileButton
            // 
            this.RemoveFileButton.Location = new System.Drawing.Point(84, 294);
            this.RemoveFileButton.Name = "RemoveFileButton";
            this.RemoveFileButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveFileButton.TabIndex = 2;
            this.RemoveFileButton.Text = "Remove File";
            this.RemoveFileButton.UseVisualStyleBackColor = true;
            this.RemoveFileButton.Click += new System.EventHandler(this.RemoveFileButton_Click);
            // 
            // ClearFilesButton
            // 
            this.ClearFilesButton.Location = new System.Drawing.Point(165, 294);
            this.ClearFilesButton.Name = "ClearFilesButton";
            this.ClearFilesButton.Size = new System.Drawing.Size(75, 23);
            this.ClearFilesButton.TabIndex = 3;
            this.ClearFilesButton.Text = "Clear";
            this.ClearFilesButton.UseVisualStyleBackColor = true;
            this.ClearFilesButton.Click += new System.EventHandler(this.ClearFilesButton_Click);
            // 
            // FileList
            // 
            this.FileList.FormattingEnabled = true;
            this.FileList.Items.AddRange(new object[] {
            "None"});
            this.FileList.Location = new System.Drawing.Point(3, 3);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(237, 290);
            this.FileList.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FileList);
            this.panel1.Controls.Add(this.RemoveFileButton);
            this.panel1.Controls.Add(this.ClearFilesButton);
            this.panel1.Controls.Add(this.AddFilesButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 320);
            this.panel1.TabIndex = 5;
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(15, 338);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(240, 25);
            this.MergeButton.TabIndex = 6;
            this.MergeButton.Text = "Merge";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 375);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.Button RemoveFileButton;
        private System.Windows.Forms.Button ClearFilesButton;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MergeButton;
    }
}

