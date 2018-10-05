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
    public partial class RenameForm : Form
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
        public Form1 Form { get; set; }

        public RenameForm(Form1 Form, string OldName)
        {
            InitializeComponent();

            this.Form = Form;
            this.OldName = OldName;
            NewName = "";

        }

        private void RenameForm_Load(object sender, EventArgs e)
        {
            OldNameLabel.Text = OldName;
            NewNameTextBox.Text = OldName;
            NewNameTextBox.Select(0, NewNameTextBox.Text.LastIndexOf("."));

            NewNameTextBox.KeyDown += NewNameTextBox_KeyDown;
            Disposed += RenameForm_Disposed;
        }

        // look for enter keypress
        private void NewNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // same as pressing confirm
            if(e.KeyCode == Keys.Enter)
            {
                ConfirmButton_Click(this, new EventArgs());
            }
        }

        // tell the other form that it may continue
        private void RenameForm_Disposed(object sender, EventArgs e)
        {
            // tell the main form that this form is closed
            Form.RenameFormOpen = false;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            FileInfo old = new FileInfo(Form.page.URL + @"\" + OldName);
            NewName = NewNameTextBox.Text;
            Form.rename = NewName;

            // the user did not rename
            if (Form.rename == "")
                return;

            // if you press confirm w/o any changes, it won't add another extension
            string newFile = Form.page.URL + @"\" + Form.rename;

            // make sure the extension is already there, if it is remove it from the end of the name
            if (newFile.IndexOf(old.Extension) == newFile.Length)
                newFile.Substring(0, newFile.IndexOf(old.Extension) + 1);

            FileAttributes attr = File.GetAttributes(Form.page.URL + @"\" + OldName);

            // don't do anything if the name hasn't changed
            if (OldName != NewName)
            {
                // detect whether its a directory or file
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Directory.Move(Form.page.URL + @"\" + OldName, newFile);
                }
                else
                {
                    // its a file, rename it
                    File.Move(Form.page.URL + @"\" + OldName, newFile);
                }
            }

            // reset renaming variable
            Form.rename = "";

            Form.UpdatePageData();

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
