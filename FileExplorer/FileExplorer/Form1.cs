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
using System.Diagnostics;
using System.Threading;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Backend.PageData page { get; set; }
        private List<string> prevStack;
        private List<string> nextStack;
        private List<string> shortcuts;
        private List<string> drives;

        // a flag for detecting disposing to prevent async updates from occuring
        public bool disposing { get; set; }

        // a temp public variable to access to rename files and directories
        public string rename { get; set; }
        // tells when the rename form is open
        public bool RenameFormOpen { get; set; }

        public Form1()
        {
            InitializeComponent();

            InitializeVariables();

            InitializeEvents();
        }

        /// <summary>
        /// Initially set all variables here
        /// </summary>
        public void InitializeVariables()
        {
            page = new Backend.PageData(Backend.Constants.ROOT);
            prevStack = new List<string>();
            nextStack = new List<string>();
            shortcuts = new List<string>();
            drives = Directory.GetLogicalDrives().ToList();
            
            disposing = true;

            rename = "";
            RenameFormOpen = false;
        }

        /// <summary>
        /// Initialize all custom events here
        /// </summary>
        public void InitializeEvents()
        {
            // press enter to go to a url
            UrlTextBox.KeyDown += UrlTextBox_KeyDown;

            // double click on a file or folder
            FileDGV.DoubleClick += FileDGV_DoubleClick;
            FileDGV.Click += FileDGV_Click;

            ShortcutDGV.CellContentClick += ShortcutDGV_CellContentClick;
            SearchTextBox.GotFocus += SearchTextBox_GotFocus;
            SearchTextBox.LostFocus += SearchTextBox_LostFocus;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;

            FileTreeView.DoubleClick += FileTreeView_DoubleClick;
        }

        #region Events

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                UpdatePageData();

                // forward cannot go if a file is entered
                nextStack.Clear();
            }
        }

        // go into the folder
        private void FileDGV_DoubleClick(object sender, EventArgs e)
        {
            if (FileDGV.RowCount <= 0)
                return;

            // get the name of the double clicked item
            string itemName;
            try
            {
                itemName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }

            UrlTextBox.Text += @"\" + itemName;

            try
            {
                OpenFileOrDirectory();
            }
            catch
            {
                UrlTextBox.Text = page.URL;
                FileTreeView.Nodes.Clear();
                return;
            }
            
            // forward cannot go if a file is double clicked
            nextStack.Clear();
        }
        
        public void OpenFileOrDirectory()
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(UrlTextBox.Text);

            //detect whether its a directory or file
            if (attr.HasFlag(FileAttributes.Directory))
            {
                // its a directory
                UpdatePageData();
            }
            else
            {
                // its a file
                try
                {
                    Process.Start(UrlTextBox.Text);
                }
                catch (Exception ex)
                {
                    // reset the url to stay in the folder (can't be in a file)
                    UrlTextBox.Text = page.URL;
                    FileTreeView.Nodes.Clear();

                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                // reset the url to stay in the folder (can't be in a file)
                UrlTextBox.Text = page.URL;
            }
        }

        // show details of the folder
        private void FileDGV_Click(object sender, EventArgs e)
        {
            // do nothing if there are no files or directories
            if (FileDGV.RowCount <= 0 || FileDGV.SelectedRows.Count <= 0)
                return;

            FileTreeView.Nodes.Clear();

            // get the name of the clicked item
            string itemName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();
            page.GetFileDetails(page.URL + @"\" + itemName);
            
            LoadDirectory(page.URL + @"\" + itemName);
            FileTreeView.Refresh();
        }

        // click on a shortcut
        private void ShortcutDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // only update if there are valid items in the dgv
            if(e.RowIndex >= 0)
            {
                UrlTextBox.Text = shortcuts[e.RowIndex];
                UpdatePageData();
            }
        }

        // user enters search textbox
        private void SearchTextBox_GotFocus(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
        }

        // user exits search textbox
        private void SearchTextBox_LostFocus(object sender, EventArgs e)
        {
            
            if(SearchTextBox.Text == "")
            {
                UpdatePageData();
            }
        }

        // user searches for item
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string search = SearchTextBox.Text;

                if(search == "")
                {
                    FileDGV.Focus();
                    UpdatePageData();
                    return;
                }

                for(int i = 0; i < FileDGV.RowCount; i++)
                {
                    // if the name does not contain the search
                    if (!FileDGV.Rows[i].Cells[0].Value.ToString().Contains(search))
                    {
                        // remove the item displayed from the dgv
                        FileDGV.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Things to do only on startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            page.URL = Backend.Constants.ROOT;
            UrlTextBox.Text = page.URL;
            UpdatePageData();

            MenuTabControl.SelectedTab = HomeTabPage;
            SearchTextBox.Text = "Search";
            HiddenFilesCheckBox.CheckState = CheckState.Unchecked;

            LoadShortcuts();
        }

        // go into a folder and update the page info
        public async void UpdatePageData()
        {
            // reset search when updating page
            SearchTextBox.Text = "Search";

            // only update if the form is not being disposed
            if (disposing == false)
                return;

            await Task.Run(() =>
            {
                AsyncUpdate();
            });

            // remove all adjacent duplicates in prevstack
            for(int i = 0; i < prevStack.Count(); i++)
            {
                // if there is a next item
                if(i + 1 < prevStack.Count()
                    && prevStack[i] == prevStack[i + 1])
                {
                    prevStack.RemoveAt(i);
                }
            }

            FileDGV.ClearSelection();
            FileTreeView.Nodes.Clear();
        }

        // asynchronously call to let the user browse while the UI is still loading
        private void AsyncUpdate()
        {
            string newUrl = UrlTextBox.Text;

            if (Directory.Exists(newUrl))
            {
                // put the previous page on the stack
                prevStack.Add(page.URL);
                page.URL = newUrl;

                // try to get files and directories in new directory
                try
                {
                    page.GetFiles();
                }
                catch(UnauthorizedAccessException e)
                {
                    // let the user know they don't have access
                    MessageBox.Show(
                        e.Message,
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    // go back to the previous url and then put the prev url in the textbox
                    page.URL = Path.GetFullPath(Path.Combine(page.URL, @"..\"));
                    UrlTextBox.BeginInvoke((Action)(() =>
                    {
                        UrlTextBox.Text = page.URL;
                    }));
                }

                // build filedgv with all new or prev files
                page.BuildFileDGV(FileDGV, HiddenFilesCheckBox.CheckState);
            }
            else
            {
                // the url entered does not exist
                MessageBox.Show(
                    "Directory cannot be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // reset the url in the textbox
                UrlTextBox.BeginInvoke((Action)(() =>
                {
                    UrlTextBox.Text = page.URL;
                }));
            }
        }

        #region Page Details

        // https://www.c-sharpcorner.com/article/display-sub-directories-and-files-in-treeview/
        // load all items into the tree
        public void LoadDirectory(string dir)
        {
            DirectoryInfo rootdir = new DirectoryInfo(dir);

            TreeNode subTreeNode = FileTreeView.Nodes.Add(rootdir.Name);
            subTreeNode.Tag = rootdir.FullName;
            subTreeNode.StateImageIndex = 0;

            // try to load all directories and files in the treeview
            try
            {
                LoadSubDirectories(dir, subTreeNode);
                LoadFiles(dir, subTreeNode);

                // expand the first child always
                foreach (TreeNode tn in FileTreeView.Nodes)
                {
                    tn.Expand();
                }
            }
            catch
            {
                FileTreeView.Nodes.Clear();
                return;
            }
            
        }

        // load all sub directories into the tree
        private void LoadSubDirectories(string dir, TreeNode treeNode)
        {
            // Get all subdirectories  
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            // Loop through them to see if they have any other subdirectories  
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo subdir = new DirectoryInfo(subdirectory);
                TreeNode subTreeNode = new TreeNode();
                
                subTreeNode = treeNode.Nodes.Add(subdir.Name);
                    
                subTreeNode.StateImageIndex = 0;
                subTreeNode.Tag = subdir.FullName;

                // recursively get all sub files/directories
                //LoadFiles(subdirectory, subTreeNode);
                //LoadSubDirectories(subdirectory, subTreeNode);
            }
        }
        
        // load all sub files into the tree
        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            // Loop through them to see files  
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = new TreeNode();
                
                tds = td.Nodes.Add(fi.Name);
                    
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
            }
        }
        
        // open the file location if double clicked
        private void FileTreeView_DoubleClick(object sender, EventArgs e)
        {
            // Get the node at the current mouse pointer location.  
            TreeNode selectedNode = FileTreeView.GetNodeAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.  
            if (selectedNode != null && selectedNode.Tag != null)
            {
                // put the selected item in the textbox and open it
                UrlTextBox.Text = selectedNode.Tag.ToString();
                OpenFileOrDirectory();
            }
        }

        #endregion

        // put all of the shortcuts in place in the DGV
        private void LoadShortcuts()
        {
            page.GetFiles();

            // get the names of all certain files in the computer, this allows someone who may not have a built in shortcut
            // still have all the shortcuts that their computer automatically gives (eg. 3D Objects not on Windows 7)
            shortcuts = page.Directories.Select(f => f.Name.ToString())     // get all file/directory names
                .Where(s => Backend.Constants.VALID_SHORTCUTS.Contains(s)).ToList();    // get only the valid shortcuts
            
            // add all shortcuts to the shortcut area
            foreach (string s in shortcuts)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(ShortcutDGV);
                row.Cells[0] = new DataGridViewButtonCell();
                row.Cells[0].Value = s;
                ShortcutDGV.Rows.Add(row);
            }

            // make all of the confirmed-to-be-valid files a full url string
            for (int i = 0; i < shortcuts.Count(); i++)
            {
                shortcuts[i] = Backend.Constants.ROOT + @"\" + shortcuts[i];
            }

            // custom user shortcut
            DataGridViewRow userRow = new DataGridViewRow();
            userRow.CreateCells(ShortcutDGV);
            userRow.Cells[0] = new DataGridViewButtonCell();
            userRow.Cells[0].Value = Environment.UserName;
            ShortcutDGV.Rows.Add(userRow);
            shortcuts.Add(Backend.Constants.ROOT);

            // add all drives to the shortcut area
            foreach (string d in drives)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(ShortcutDGV);
                row.Cells[0] = new DataGridViewButtonCell();
                row.Cells[0].Value = d;
                ShortcutDGV.Rows.Add(row);

                // add drive to list of shortcuts
                shortcuts.Add(d);
            }
            
            // user cannot sort and update the screen
            ShortcutDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ShortcutDGV.Refresh();
            
        }

        // navigate up one directory
        private void UpDirectoryButton_Click(object sender, EventArgs e)
        {
            UrlTextBox.Text = Path.GetFullPath(Path.Combine(UrlTextBox.Text, @"..\"));
            UpdatePageData();
        }

        // go to the previous item in the stack if there is one
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            foreach (string s in prevStack)
            {
                Console.WriteLine(s);
            }

            // exit if there are no items
            if (prevStack.Count() <= 0)
                return;
            
            // pop the last item in the stack (top item is last)
            string prev = prevStack.Last();
            prevStack.RemoveAt(prevStack.Count() - 1);
            
            // put the next page on the stack
            nextStack.Add(page.URL);

            UrlTextBox.Text = prev;
            UpdatePageData();

            // remove extra item
            if(prevStack.Count() > 1)
                prevStack.RemoveAt(prevStack.Count() - 1);
        }

        // go to the next item in the stack if there is one
        private void NextButton_Click(object sender, EventArgs e)
        {
            // exit if there are no items
            if (nextStack.Count() <= 0)
                return;

            // pop the last item in the stack (top item is last)
            string next = nextStack.Last();
            nextStack.RemoveAt(nextStack.Count() - 1);

            UrlTextBox.Text = next;
            UpdatePageData();
        }

        // refresh the page data
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            UpdatePageData();
        }

        #region File

        // run another instance of this program
        private void NewWindowButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        // open powershell at the current location
        private void PowershellButton_Click(object sender, EventArgs e)
        {
            // change current dir to the one the user has open
            var temp = System.Environment.CurrentDirectory;
            System.Environment.CurrentDirectory = page.URL;

            Process.Start(Backend.Constants.POWERSHELL);

            // change it back after
            System.Environment.CurrentDirectory = temp;

        }

        // close the program
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Home

        // copy directory or file
        private void CopyButton_Click(object sender, EventArgs e)
        {
            // exit if there are no files
            if (FileDGV.RowCount <= 0)
                return;

            string itemToCopy = FileDGV.SelectedRows[0].Cells[0].Value.ToString();
            System.Windows.Forms.Clipboard.SetText(UrlTextBox.Text + @"\" + itemToCopy);
        }

        // paste directory or file
        private void PasteButton_Click(object sender, EventArgs e)
        {
            // get the name of the selected item
            string copiedItemPath = System.Windows.Forms.Clipboard.GetText();
            string pathOfItem;

            // find if there are repeats of the current copied item in the current directory
            int count = CountOccurrences(copiedItemPath);

            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(copiedItemPath);

            // check to see if there is already an item with the same name
            if (count > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Directory {copiedItemPath} already exists. Rename to '{copiedItemPath} ({count})'?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // detect whether its a directory or file
            if (attr.HasFlag(FileAttributes.Directory))
            {
                pathOfItem = UrlTextBox.Text + @"\" + new DirectoryInfo(copiedItemPath).Name;

                // paste directory
                new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(
                    copiedItemPath,
                    pathOfItem);
            }
            else
            {
                pathOfItem = UrlTextBox.Text + @"\" + new FileInfo(copiedItemPath).Name;

                // paste file
                new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyFile(
                    copiedItemPath,
                    pathOfItem);
            }
            UpdatePageData();
        }

        // rename directory or file
        private void RenameButton_Click(object sender, EventArgs e)
        {
            // exit if there are no files
            if (FileDGV.RowCount <= 0)
                return;

            // only rename one at a time
            if (RenameFormOpen == true)
                return;

            // get the name of the clicked item
            string oldName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();

            RenameForm renameForm = new RenameForm(this, oldName);

            RenameFormOpen = true;
            renameForm.Show();

            
        }

        // delete selected file or directory
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // exit if there are no files
            if (FileDGV.RowCount <= 0)
                return;

            // get the name of the selected item
            string itemToDelete = FileDGV.SelectedRows[0].Cells[0].Value.ToString();
            string pathOfItem = UrlTextBox.Text + @"\" + itemToDelete;

            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(pathOfItem);

            // detect whether its a directory or file
            if (attr.HasFlag(FileAttributes.Directory))
            {
                // move directory to recycle bin
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(
                    pathOfItem,
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin,
                    Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
            }
            else
            {
                // move file to recycle bin
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                    pathOfItem,
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin,
                    Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
            }
            UpdatePageData();
        }

        // create a new directory
        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            int count = CountOccurrences(Backend.Constants.NEW_FOLDER);

            // create the new folder and update the interface
            Directory.CreateDirectory(page.URL + @"\" + Backend.Constants.NEW_FOLDER + (count == 0 ? "" : $" ({count})"));
            UpdatePageData();
            
        }

        private int CountOccurrences(string path)
        {
            bool exists;
            int count = 0;

            // find the number of new folders created to make: "New folder (#)" if there are more than 1
            do
            {
                exists = Directory.Exists(page.URL + @"\" + path + (count == 0 ? "" : $" ({count})"));
                count = exists ? count + 1 : count;
            } while (exists == true);

            return count;
        }

        // update the page after changing the checked box
        private void HiddenFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePageData();
        }

        #endregion

        // extra methods DO NOT DELETE
        private void FileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        
    }
}
