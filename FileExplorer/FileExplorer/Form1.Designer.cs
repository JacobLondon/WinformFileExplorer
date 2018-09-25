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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MenuTabControl = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.FileTabPage = new System.Windows.Forms.TabPage();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.FileTabControl = new System.Windows.Forms.TabControl();
            this.DefaultTabPage = new System.Windows.Forms.TabPage();
            this.NextTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.FileDGV)).BeginInit();
            this.MenuTabControl.SuspendLayout();
            this.FileTabControl.SuspendLayout();
            this.DefaultTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDGV
            // 
            this.FileDGV.AllowUserToAddRows = false;
            this.FileDGV.AllowUserToDeleteRows = false;
            this.FileDGV.AllowUserToOrderColumns = true;
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
            this.FileDGV.Size = new System.Drawing.Size(603, 382);
            this.FileDGV.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(603, 22);
            this.textBox1.TabIndex = 1;
            // 
            // MenuTabControl
            // 
            this.MenuTabControl.Controls.Add(this.FileTabPage);
            this.MenuTabControl.Controls.Add(this.HomeTabPage);
            this.MenuTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTabControl.Location = new System.Drawing.Point(-3, -2);
            this.MenuTabControl.Name = "MenuTabControl";
            this.MenuTabControl.SelectedIndex = 0;
            this.MenuTabControl.Size = new System.Drawing.Size(934, 129);
            this.MenuTabControl.TabIndex = 3;
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.HomeTabPage.Location = new System.Drawing.Point(4, 29);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(926, 96);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            // 
            // FileTabPage
            // 
            this.FileTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.FileTabPage.Location = new System.Drawing.Point(4, 29);
            this.FileTabPage.Name = "FileTabPage";
            this.FileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FileTabPage.Size = new System.Drawing.Size(926, 96);
            this.FileTabPage.TabIndex = 1;
            this.FileTabPage.Text = "File";
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 300;
            // 
            // DateModifiedColumn
            // 
            this.DateModifiedColumn.HeaderText = "DateModified";
            this.DateModifiedColumn.Name = "DateModifiedColumn";
            this.DateModifiedColumn.ReadOnly = true;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            // 
            // SizeColumn
            // 
            this.SizeColumn.HeaderText = "Size";
            this.SizeColumn.Name = "SizeColumn";
            this.SizeColumn.ReadOnly = true;
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
            this.FileTabControl.Controls.Add(this.NextTabPage);
            this.FileTabControl.Location = new System.Drawing.Point(141, 129);
            this.FileTabControl.Name = "FileTabControl";
            this.FileTabControl.SelectedIndex = 0;
            this.FileTabControl.Size = new System.Drawing.Size(790, 446);
            this.FileTabControl.TabIndex = 5;
            // 
            // DefaultTabPage
            // 
            this.DefaultTabPage.Controls.Add(this.groupBox1);
            this.DefaultTabPage.Controls.Add(this.FileDGV);
            this.DefaultTabPage.Controls.Add(this.SearchTextBox);
            this.DefaultTabPage.Controls.Add(this.textBox1);
            this.DefaultTabPage.Location = new System.Drawing.Point(4, 25);
            this.DefaultTabPage.Name = "DefaultTabPage";
            this.DefaultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultTabPage.Size = new System.Drawing.Size(782, 417);
            this.DefaultTabPage.TabIndex = 0;
            this.DefaultTabPage.Text = "Home";
            this.DefaultTabPage.UseVisualStyleBackColor = true;
            // 
            // NextTabPage
            // 
            this.NextTabPage.Location = new System.Drawing.Point(4, 25);
            this.NextTabPage.Name = "NextTabPage";
            this.NextTabPage.Size = new System.Drawing.Size(845, 417);
            this.NextTabPage.TabIndex = 1;
            this.NextTabPage.Text = "    +";
            this.NextTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(609, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 382);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(931, 573);
            this.Controls.Add(this.FileTabControl);
            this.Controls.Add(this.MenuTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FileDGV)).EndInit();
            this.MenuTabControl.ResumeLayout(false);
            this.FileTabControl.ResumeLayout(false);
            this.DefaultTabPage.ResumeLayout(false);
            this.DefaultTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FileDGV;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl MenuTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.TabPage FileTabPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModifiedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.TabControl FileTabControl;
        private System.Windows.Forms.TabPage DefaultTabPage;
        private System.Windows.Forms.TabPage NextTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

