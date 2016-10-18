namespace Leo.SearchEngine
{
    partial class SearchEngineOptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchEngineOptionDialog));
            this.indexDirectoryGroupBox = new System.Windows.Forms.GroupBox();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.indexDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.newIndexDirectorygroupBox = new System.Windows.Forms.GroupBox();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.clearListButton = new System.Windows.Forms.Button();
            this.createIndexFolderButton = new System.Windows.Forms.Button();
            this.loadFilesListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.selectIndexFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.indexDirectoryGroupBox.SuspendLayout();
            this.newIndexDirectorygroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexDirectoryGroupBox
            // 
            this.indexDirectoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexDirectoryGroupBox.Controls.Add(this.selectFolderButton);
            this.indexDirectoryGroupBox.Controls.Add(this.indexDirectoryTextBox);
            this.indexDirectoryGroupBox.Location = new System.Drawing.Point(12, 12);
            this.indexDirectoryGroupBox.Name = "indexDirectoryGroupBox";
            this.indexDirectoryGroupBox.Size = new System.Drawing.Size(469, 80);
            this.indexDirectoryGroupBox.TabIndex = 0;
            this.indexDirectoryGroupBox.TabStop = false;
            this.indexDirectoryGroupBox.Text = "Select Existing Index Directory";
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFolderButton.Location = new System.Drawing.Point(348, 44);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(110, 23);
            this.selectFolderButton.TabIndex = 1;
            this.selectFolderButton.Text = "Select Index";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // indexDirectoryTextBox
            // 
            this.indexDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexDirectoryTextBox.Location = new System.Drawing.Point(7, 19);
            this.indexDirectoryTextBox.Name = "indexDirectoryTextBox";
            this.indexDirectoryTextBox.ReadOnly = true;
            this.indexDirectoryTextBox.Size = new System.Drawing.Size(451, 19);
            this.indexDirectoryTextBox.TabIndex = 0;
            // 
            // newIndexDirectorygroupBox
            // 
            this.newIndexDirectorygroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newIndexDirectorygroupBox.Controls.Add(this.removeItemButton);
            this.newIndexDirectorygroupBox.Controls.Add(this.clearListButton);
            this.newIndexDirectorygroupBox.Controls.Add(this.createIndexFolderButton);
            this.newIndexDirectorygroupBox.Controls.Add(this.loadFilesListBox);
            this.newIndexDirectorygroupBox.Location = new System.Drawing.Point(12, 98);
            this.newIndexDirectorygroupBox.Name = "newIndexDirectorygroupBox";
            this.newIndexDirectorygroupBox.Size = new System.Drawing.Size(469, 235);
            this.newIndexDirectorygroupBox.TabIndex = 1;
            this.newIndexDirectorygroupBox.TabStop = false;
            this.newIndexDirectorygroupBox.Text = "Create New Index Directory";
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(114, 206);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(101, 23);
            this.removeItemButton.TabIndex = 3;
            this.removeItemButton.Text = "Remove Item";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(7, 206);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(101, 23);
            this.clearListButton.TabIndex = 2;
            this.clearListButton.Text = "Clear List";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // createIndexFolderButton
            // 
            this.createIndexFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createIndexFolderButton.Enabled = false;
            this.createIndexFolderButton.Location = new System.Drawing.Point(366, 206);
            this.createIndexFolderButton.Name = "createIndexFolderButton";
            this.createIndexFolderButton.Size = new System.Drawing.Size(98, 23);
            this.createIndexFolderButton.TabIndex = 1;
            this.createIndexFolderButton.Text = "Create Index";
            this.createIndexFolderButton.UseVisualStyleBackColor = true;
            this.createIndexFolderButton.Click += new System.EventHandler(this.CreateIndexFolderButton_Click);
            // 
            // loadFilesListBox
            // 
            this.loadFilesListBox.AllowDrop = true;
            this.loadFilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFilesListBox.FormattingEnabled = true;
            this.loadFilesListBox.ItemHeight = 12;
            this.loadFilesListBox.Location = new System.Drawing.Point(7, 18);
            this.loadFilesListBox.Name = "loadFilesListBox";
            this.loadFilesListBox.Size = new System.Drawing.Size(457, 172);
            this.loadFilesListBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(372, 339);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(265, 339);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SearchEngineOptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 373);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.newIndexDirectorygroupBox);
            this.Controls.Add(this.indexDirectoryGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(509, 411);
            this.Name = "SearchEngineOptionDialog";
            this.Text = "Search Engine Options";
            this.indexDirectoryGroupBox.ResumeLayout(false);
            this.indexDirectoryGroupBox.PerformLayout();
            this.newIndexDirectorygroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox indexDirectoryGroupBox;
        private System.Windows.Forms.TextBox indexDirectoryTextBox;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.GroupBox newIndexDirectorygroupBox;
        private System.Windows.Forms.ListBox loadFilesListBox;
        private System.Windows.Forms.Button createIndexFolderButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FolderBrowserDialog selectIndexFolderBrowserDialog;
        private System.Windows.Forms.Button clearListButton;
        private System.Windows.Forms.Button removeItemButton;
    }
}