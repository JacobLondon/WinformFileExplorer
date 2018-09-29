namespace FileExplorer
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
            this.FileDGV = new System.Windows.Forms.DataGridView();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.MenuTabControl = new System.Windows.Forms.TabControl();
            this.FileTabPage = new System.Windows.Forms.TabPage();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PowershellButton = new System.Windows.Forms.Button();
            this.NewWindowButton = new System.Windows.Forms.Button();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.NewFolderButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PasteButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.FileTabControl = new System.Windows.Forms.TabControl();
            this.DefaultTabPage = new System.Windows.Forms.TabPage();
            this.FileDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.ShortcutGroupBox = new System.Windows.Forms.GroupBox();
            this.UpDirectoryButton = new System.Windows.Forms.Button();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.DetailLabel = new System.Windows.Forms.Label();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FileDGV)).BeginInit();
            this.MenuTabControl.SuspendLayout();
            this.FileTabPage.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.FileTabControl.SuspendLayout();
            this.DefaultTabPage.SuspendLayout();
            this.FileDetailGroupBox.SuspendLayout();
            this.ShortcutGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDGV
            // 
            this.FileDGV.AllowUserToAddRows = false;
            this.FileDGV.AllowUserToDeleteRows = false;
            this.FileDGV.AllowUserToResizeRows = false;
            this.FileDGV.BackgroundColor = System.Drawing.Color.White;
            this.FileDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.DateModifiedColumn,
            this.TypeColumn,
            this.SizeColumn});
            this.FileDGV.GridColor = System.Drawing.SystemColors.Control;
            this.FileDGV.Location = new System.Drawing.Point(0, 35);
            this.FileDGV.Margin = new System.Windows.Forms.Padding(4);
            this.FileDGV.Name = "FileDGV";
            this.FileDGV.RowHeadersVisible = false;
            this.FileDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FileDGV.Size = new System.Drawing.Size(603, 405);
            this.FileDGV.TabIndex = 0;
            this.FileDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileDGV_CellContentClick);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(0, 6);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(603, 22);
            this.UrlTextBox.TabIndex = 1;
            // 
            // MenuTabControl
            // 
            this.MenuTabControl.Controls.Add(this.FileTabPage);
            this.MenuTabControl.Controls.Add(this.HomeTabPage);
            this.MenuTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTabControl.Location = new System.Drawing.Point(-3, -2);
            this.MenuTabControl.Name = "MenuTabControl";
            this.MenuTabControl.SelectedIndex = 0;
            this.MenuTabControl.Size = new System.Drawing.Size(934, 99);
            this.MenuTabControl.TabIndex = 3;
            // 
            // FileTabPage
            // 
            this.FileTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.FileTabPage.Controls.Add(this.CloseButton);
            this.FileTabPage.Controls.Add(this.PowershellButton);
            this.FileTabPage.Controls.Add(this.NewWindowButton);
            this.FileTabPage.Location = new System.Drawing.Point(4, 29);
            this.FileTabPage.Name = "FileTabPage";
            this.FileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FileTabPage.Size = new System.Drawing.Size(926, 66);
            this.FileTabPage.TabIndex = 1;
            this.FileTabPage.Text = "  File";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(358, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(170, 53);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close Explorer";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // PowershellButton
            // 
            this.PowershellButton.Location = new System.Drawing.Point(182, 6);
            this.PowershellButton.Name = "PowershellButton";
            this.PowershellButton.Size = new System.Drawing.Size(170, 53);
            this.PowershellButton.TabIndex = 1;
            this.PowershellButton.Text = "Open Powershell";
            this.PowershellButton.UseVisualStyleBackColor = true;
            // 
            // NewWindowButton
            // 
            this.NewWindowButton.Location = new System.Drawing.Point(6, 6);
            this.NewWindowButton.Name = "NewWindowButton";
            this.NewWindowButton.Size = new System.Drawing.Size(170, 53);
            this.NewWindowButton.TabIndex = 0;
            this.NewWindowButton.Text = "Open New Window";
            this.NewWindowButton.UseVisualStyleBackColor = true;
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.HomeTabPage.Controls.Add(this.NewFolderButton);
            this.HomeTabPage.Controls.Add(this.RenameButton);
            this.HomeTabPage.Controls.Add(this.DeleteButton);
            this.HomeTabPage.Controls.Add(this.PasteButton);
            this.HomeTabPage.Controls.Add(this.CopyButton);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 29);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(926, 66);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            // 
            // NewFolderButton
            // 
            this.NewFolderButton.Location = new System.Drawing.Point(558, 6);
            this.NewFolderButton.Name = "NewFolderButton";
            this.NewFolderButton.Size = new System.Drawing.Size(132, 53);
            this.NewFolderButton.TabIndex = 5;
            this.NewFolderButton.Text = "New Folder";
            this.NewFolderButton.UseVisualStyleBackColor = true;
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(420, 6);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(132, 53);
            this.RenameButton.TabIndex = 4;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(282, 6);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(132, 53);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // PasteButton
            // 
            this.PasteButton.Location = new System.Drawing.Point(144, 6);
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.Size = new System.Drawing.Size(132, 53);
            this.PasteButton.TabIndex = 2;
            this.PasteButton.Text = "Paste";
            this.PasteButton.UseVisualStyleBackColor = true;
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(6, 6);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(132, 53);
            this.CopyButton.TabIndex = 1;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.SearchTextBox.Location = new System.Drawing.Point(609, 6);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(170, 22);
            this.SearchTextBox.TabIndex = 4;
            // 
            // FileTabControl
            // 
            this.FileTabControl.Controls.Add(this.DefaultTabPage);
            this.FileTabControl.Location = new System.Drawing.Point(141, 103);
            this.FileTabControl.Name = "FileTabControl";
            this.FileTabControl.SelectedIndex = 0;
            this.FileTabControl.Size = new System.Drawing.Size(790, 469);
            this.FileTabControl.TabIndex = 5;
            // 
            // DefaultTabPage
            // 
            this.DefaultTabPage.Controls.Add(this.FileDetailGroupBox);
            this.DefaultTabPage.Controls.Add(this.FileDGV);
            this.DefaultTabPage.Controls.Add(this.SearchTextBox);
            this.DefaultTabPage.Controls.Add(this.UrlTextBox);
            this.DefaultTabPage.Location = new System.Drawing.Point(4, 25);
            this.DefaultTabPage.Name = "DefaultTabPage";
            this.DefaultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultTabPage.Size = new System.Drawing.Size(782, 440);
            this.DefaultTabPage.TabIndex = 0;
            this.DefaultTabPage.Text = "Home";
            this.DefaultTabPage.UseVisualStyleBackColor = true;
            // 
            // FileDetailGroupBox
            // 
            this.FileDetailGroupBox.Controls.Add(this.DetailLabel);
            this.FileDetailGroupBox.Location = new System.Drawing.Point(609, 35);
            this.FileDetailGroupBox.Name = "FileDetailGroupBox";
            this.FileDetailGroupBox.Size = new System.Drawing.Size(170, 405);
            this.FileDetailGroupBox.TabIndex = 5;
            this.FileDetailGroupBox.TabStop = false;
            this.FileDetailGroupBox.Text = "File Detail";
            // 
            // ShortcutGroupBox
            // 
            this.ShortcutGroupBox.Controls.Add(this.button7);
            this.ShortcutGroupBox.Controls.Add(this.button6);
            this.ShortcutGroupBox.Controls.Add(this.button5);
            this.ShortcutGroupBox.Controls.Add(this.button4);
            this.ShortcutGroupBox.Controls.Add(this.button3);
            this.ShortcutGroupBox.Controls.Add(this.button2);
            this.ShortcutGroupBox.Controls.Add(this.button1);
            this.ShortcutGroupBox.Location = new System.Drawing.Point(2, 96);
            this.ShortcutGroupBox.Name = "ShortcutGroupBox";
            this.ShortcutGroupBox.Size = new System.Drawing.Size(133, 476);
            this.ShortcutGroupBox.TabIndex = 6;
            this.ShortcutGroupBox.TabStop = false;
            this.ShortcutGroupBox.Text = "Shortcuts";
            // 
            // UpDirectoryButton
            // 
            this.UpDirectoryButton.Location = new System.Drawing.Point(195, 102);
            this.UpDirectoryButton.Name = "UpDirectoryButton";
            this.UpDirectoryButton.Size = new System.Drawing.Size(70, 23);
            this.UpDirectoryButton.TabIndex = 6;
            this.UpDirectoryButton.Text = "Up";
            this.UpDirectoryButton.UseVisualStyleBackColor = true;
            this.UpDirectoryButton.Click += new System.EventHandler(this.UpDirectoryButton_Click);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 250;
            // 
            // DateModifiedColumn
            // 
            this.DateModifiedColumn.HeaderText = "Date Modified";
            this.DateModifiedColumn.Name = "DateModifiedColumn";
            this.DateModifiedColumn.ReadOnly = true;
            this.DateModifiedColumn.Width = 150;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            // 
            // SizeColumn
            // 
            this.SizeColumn.HeaderText = "Size (KB)";
            this.SizeColumn.Name = "SizeColumn";
            this.SizeColumn.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "This PC";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Desktop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "Documents";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 123);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 28);
            this.button4.TabIndex = 3;
            this.button4.Text = "Downloads";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 28);
            this.button5.TabIndex = 4;
            this.button5.Text = "Music";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 191);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 28);
            this.button6.TabIndex = 5;
            this.button6.Text = "Pictures";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 225);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 28);
            this.button7.TabIndex = 6;
            this.button7.Text = "Videos";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // DetailLabel
            // 
            this.DetailLabel.AutoSize = true;
            this.DetailLabel.Location = new System.Drawing.Point(6, 18);
            this.DetailLabel.Name = "DetailLabel";
            this.DetailLabel.Size = new System.Drawing.Size(77, 16);
            this.DetailLabel.TabIndex = 0;
            this.DetailLabel.Text = "DetailLabel";
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(265, 102);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(70, 23);
            this.PreviousButton.TabIndex = 7;
            this.PreviousButton.Text = "<<<";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(335, 102);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(70, 23);
            this.NextButton.TabIndex = 8;
            this.NextButton.Text = ">>>";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(931, 573);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.UpDirectoryButton);
            this.Controls.Add(this.ShortcutGroupBox);
            this.Controls.Add(this.FileTabControl);
            this.Controls.Add(this.MenuTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FileDGV)).EndInit();
            this.MenuTabControl.ResumeLayout(false);
            this.FileTabPage.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            this.FileTabControl.ResumeLayout(false);
            this.DefaultTabPage.ResumeLayout(false);
            this.DefaultTabPage.PerformLayout();
            this.FileDetailGroupBox.ResumeLayout(false);
            this.FileDetailGroupBox.PerformLayout();
            this.ShortcutGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FileDGV;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.TabControl MenuTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.TabPage FileTabPage;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.TabControl FileTabControl;
        private System.Windows.Forms.TabPage DefaultTabPage;
        private System.Windows.Forms.GroupBox FileDetailGroupBox;
        private System.Windows.Forms.Button NewWindowButton;
        private System.Windows.Forms.Button PowershellButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button PasteButton;
        private System.Windows.Forms.Button NewFolderButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.GroupBox ShortcutGroupBox;
        private System.Windows.Forms.Button UpDirectoryButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModifiedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label DetailLabel;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
    }
}

