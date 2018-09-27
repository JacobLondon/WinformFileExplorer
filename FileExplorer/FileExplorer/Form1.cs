using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private Backend.PageData page;

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
        }

        /// <summary>
        /// Initialize all custom events here
        /// </summary>
        public void InitializeEvents()
        {

        }

        /// <summary>
        /// Things to do only on startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            MenuTabControl.SelectedTab = HomeTabPage;
            SearchTextBox.Text = "Search";
        }

        /// <summary>
        /// Update all of the UI elements from here
        /// </summary>
        public void UpdateInterface()
        {
            
        }

        // test method for actions
        private void testbutton_Click(object sender, EventArgs e)
        {
            page.GetFiles();
        }
    }
}
