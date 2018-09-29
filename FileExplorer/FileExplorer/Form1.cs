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

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private Backend.PageData page;
        private List<string> prevStack;
        private List<string> nextStack;

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

        }


        #region Events

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                UpdatePageData();
        }

        // go into the folder
        private void FileDGV_DoubleClick(object sender, EventArgs e)
        {
            // get the name of the double clicked item
            string itemName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();

            UrlTextBox.Text += @"\" + itemName;
            DetailLabel.Text = "";
            UpdatePageData();
        }
        
        // show details of the folder
        private void FileDGV_Click(object sender, EventArgs e)
        {
            // get the name of the clicked item
            string itemName = FileDGV.SelectedRows[0].Cells[0].Value.ToString();
            page.GetFileDetails(page.URL + @"\" + itemName);
            UpdatePageDetails();
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
        }

        /// <summary>
        /// Update all of the UI elements from here
        /// </summary>
        public void UpdateInterface()
        {
            
        }

        // go into a folder and update the page info
        private void UpdatePageData()
        {
            string newUrl = UrlTextBox.Text;

            if (Directory.Exists(newUrl))
            {
                // put the previous page on the stack
                prevStack.Add(page.URL);

                page.URL = newUrl;

                // put the next page on the stack
                nextStack.Add(page.URL);
                page.GetFiles();
                page.BuildFileDGV(ref FileDGV);
            }

            else
            {
                MessageBox.Show(
                    "Directory cannot be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                UrlTextBox.Text = page.URL;
            }
                
        }

        // update the right element with details of subfolders
        private void UpdatePageDetails()
        {
            // clear all previous items
            DetailLabel.Text = "";

            // add all new items in
            foreach (string d in page.FileDetail)
            {
                DetailLabel.Text += d + "\n";
            }
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
            // exit if there are no items
            if (prevStack.Count() <= 0)
                return;

            // pop the last item in the stack (top item is last)
            string prev = prevStack.Last();
            prevStack.RemoveAt(prevStack.Count() - 1);

            UrlTextBox.Text = prev;
            UpdatePageData();
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

        // extra methods DO NOT DELETE
        private void FileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
