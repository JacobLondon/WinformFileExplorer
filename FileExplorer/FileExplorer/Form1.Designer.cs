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
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.DetailLabel = new System.Windows.Forms.Label();
            this.UpDirectoryButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.ShortcutDGV = new System.Windows.Forms.DataGridView();
            this.ShortcutColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FileDGV)).BeginInit();
            this.MenuTabControl.SuspendLayout();
            this.FileTabPage.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.FileTabControl.SuspendLayout();
            this.DefaultTabPage.SuspendLayout();
            this.FileDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShortcutDGV)).BeginInit();
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
            this.FileDGV.Location = new System.Drawing.Point(0, 31);
            this.FileDGV.Margin = new System.Windows.Forms.Padding(4);
            this.FileDGV.Name = "FileDGV";
            this.FileDGV.RowHeadersVisible = false;
            this.FileDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FileDGV.Size = new System.Drawing.Size(603, 409);
            this.FileDGV.TabIndex = 0;
            this.FileDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileDGV_CellContentClick);
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
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PowershellButton
            // 
            this.PowershellButton.Location = new System.Drawing.Point(182, 6);
            this.PowershellButton.Name = "PowershellButton";
            this.PowershellButton.Size = new System.Drawing.Size(170, 53);
            this.PowershellButton.TabIndex = 1;
            this.PowershellButton.Text = "Open Powershell";
            this.PowershellButton.UseVisualStyleBackColor = true;
            this.PowershellButton.Click += new System.EventHandler(this.PowershellButton_Click);
            // 
            // NewWindowButton
            // 
            this.NewWindowButton.Location = new System.Drawing.Point(6, 6);
            this.NewWindowButton.Name = "NewWindowButton";
            this.NewWindowButton.Size = new System.Drawing.Size(170, 53);
            this.NewWindowButton.TabIndex = 0;
            this.NewWindowButton.Text = "Open New Window";
            this.NewWindowButton.UseVisualStyleBackColor = true;
            this.NewWindowButton.Click += new System.EventHandler(this.NewWindowButton_Click);
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
            // DetailLabel
            // 
            this.DetailLabel.AutoSize = true;
            this.DetailLabel.Location = new System.Drawing.Point(6, 18);
            this.DetailLabel.Name = "DetailLabel";
            this.DetailLabel.Size = new System.Drawing.Size(77, 16);
            this.DetailLabel.TabIndex = 0;
            this.DetailLabel.Text = "DetailLabel";
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
            // ShortcutDGV
            // 
            this.ShortcutDGV.AllowUserToAddRows = false;
            this.ShortcutDGV.AllowUserToDeleteRows = false;
            this.ShortcutDGV.AllowUserToResizeColumns = false;
            this.ShortcutDGV.AllowUserToResizeRows = false;
            this.ShortcutDGV.BackgroundColor = System.Drawing.Color.White;
            this.ShortcutDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShortcutDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShortcutColumn});
            this.ShortcutDGV.GridColor = System.Drawing.SystemColors.Control;
            this.ShortcutDGV.Location = new System.Drawing.Point(4, 102);
            this.ShortcutDGV.Margin = new System.Windows.Forms.Padding(4);
            this.ShortcutDGV.MultiSelect = false;
            this.ShortcutDGV.Name = "ShortcutDGV";
            this.ShortcutDGV.RowHeadersVisible = false;
            this.ShortcutDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ShortcutDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShortcutDGV.Size = new System.Drawing.Size(134, 466);
            this.ShortcutDGV.TabIndex = 9;
            // 
            // ShortcutColumn
            // 
            this.ShortcutColumn.HeaderText = "Shortcuts";
            this.ShortcutColumn.Name = "ShortcutColumn";
            this.ShortcutColumn.ReadOnly = true;
            this.ShortcutColumn.Width = 131;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(931, 573);
            this.Controls.Add(this.ShortcutDGV);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.UpDirectoryButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.ShortcutDGV)).EndInit();
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
        private System.Windows.Forms.Button UpDirectoryButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModifiedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.Label DetailLabel;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.DataGridView ShortcutDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortcutColumn;
    }
}

