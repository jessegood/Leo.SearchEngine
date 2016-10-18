namespace Leo.SearchEngine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.Core;

    public partial class SearchEngineOptionDialog : Form
    {
        /// <summary>
        /// Stores file names in the listbox
        /// T1 is the full path to the file name
        /// T2 is the file name only
        /// </summary>
        private readonly List<Tuple<string, string>> fileNames = new List<Tuple<string, string>>();
        private readonly LanguagePair[] languagePairs;

        public SearchEngineOptionDialog(LanguagePair[] languagePairs)
        {
            this.languagePairs = languagePairs;

            InitializeComponent();

            // List Box drag and drop
            loadFilesListBox.DragEnter += LoadFilesListBox_DragEnter;
            loadFilesListBox.DragDrop += LoadFilesListBox_DragDrop;
        }

        /// <summary>
        /// An instance of <see cref="SearchEngineTranslationOptions"/> to store our settings
        /// </summary>
        public SearchEngineTranslationOptions Options { get; set; } = new SearchEngineTranslationOptions();

        private void ClearListButton_Click(object sender, EventArgs e)
        {
            loadFilesListBox.Items.Clear();
            fileNames.Clear();
            createIndexFolderButton.Enabled = false;
        }

        private void CreateIndexFolderButton_Click(object sender, EventArgs e)
        {
            SelectFolderButton_Click(sender, e);

            LuceneSearch.IndexDirectory = Options.IndexDirectory;

            foreach (var pair in fileNames)
            {
                IndexDispatcher.AddToIndex(pair.Item1, languagePairs);
            }
        }

        #region ListBox drag and drop

        private void LoadFilesListBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var item in data)
            {
                if (!fileNames.Any(t => t.Item1 == item))
                {
                    var fileName = Path.GetFileName(item);
                    fileNames.Add(new Tuple<string, string>(item, fileName));
                    loadFilesListBox.Items.Add(fileName);
                    createIndexFolderButton.Enabled = true;
                }
            }
        }

        private void LoadFilesListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion ListBox drag and drop

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Options.IndexDirectory != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            var selectedItem = loadFilesListBox.SelectedItem as string;

            if (selectedItem != null)
            {
                loadFilesListBox.Items.Remove(selectedItem);
                fileNames.RemoveAll(t => t.Item2 == selectedItem);

                if (fileNames.Count == 0)
                {
                    createIndexFolderButton.Enabled = false;
                }
            }
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            var result = selectIndexFolderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var folderName = selectIndexFolderBrowserDialog.SelectedPath;
                Options.IndexDirectory = folderName;
                indexDirectoryTextBox.Text = folderName;
            }
        }
    }
}