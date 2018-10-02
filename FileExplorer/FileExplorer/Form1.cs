﻿using System;
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

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private Backend.PageData page;
        private List<string> prevStack;
        private List<string> nextStack;
        private List<string> shortcuts;
        private List<string> drives;

        // a flag for detecting disposing to prevent async updates from occuring
        public bool disposing { get; set; }

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
            // get the name of the double clicked item
            string itemName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();

            UrlTextBox.Text += @"\" + itemName;
            DetailLabel.Text = "";

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
                Process.Start(UrlTextBox.Text);

                // reset the url to stay in the folder (can't be in a file)
                UrlTextBox.Text = page.URL;
            }

            // forward cannot go if a file is double clicked
            nextStack.Clear();
        }
        
        // show details of the folder
        private void FileDGV_Click(object sender, EventArgs e)
        {
            // get the name of the clicked item
            string itemName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();
            page.GetFileDetails(page.URL + @"\" + itemName);
            UpdatePageDetails();
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
            DetailLabel.Text = "";
            
            LoadShortcuts();
        }

        // go into a folder and update the page info
        private async void UpdatePageData()
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
                page.BuildFileDGV(FileDGV);
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

        // update the right element with details of subfolders
        private void UpdatePageDetails()
        {
            // clear all previous items
            DetailLabel.Text = "";

            // add all new items in
            try
            {
                foreach (string d in page.FileDetail)
                {
                    DetailLabel.Text += d + "\n";
                }
            }
            catch
            {

            }
            
        }

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

        // extra methods DO NOT DELETE
        private void FileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        
    }
}
