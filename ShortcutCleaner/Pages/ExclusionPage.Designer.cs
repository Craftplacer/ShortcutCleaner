
namespace ShortcutCleaner.Pages
{
    partial class ExclusionPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.subFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.excludeFoldersGroupBox = new System.Windows.Forms.GroupBox();
            this.excludeListBox = new System.Windows.Forms.ListBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.excludeFoldersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // subFoldersCheckBox
            // 
            this.subFoldersCheckBox.AutoSize = true;
            this.subFoldersCheckBox.Location = new System.Drawing.Point(16, 16);
            this.subFoldersCheckBox.Name = "subFoldersCheckBox";
            this.subFoldersCheckBox.Size = new System.Drawing.Size(115, 17);
            this.subFoldersCheckBox.TabIndex = 0;
            this.subFoldersCheckBox.Text = "Include sub-folders";
            this.subFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // excludeFoldersGroupBox
            // 
            this.excludeFoldersGroupBox.Controls.Add(this.excludeListBox);
            this.excludeFoldersGroupBox.Controls.Add(this.removeButton);
            this.excludeFoldersGroupBox.Controls.Add(this.addButton);
            this.excludeFoldersGroupBox.Location = new System.Drawing.Point(16, 40);
            this.excludeFoldersGroupBox.Name = "excludeFoldersGroupBox";
            this.excludeFoldersGroupBox.Size = new System.Drawing.Size(464, 184);
            this.excludeFoldersGroupBox.TabIndex = 1;
            this.excludeFoldersGroupBox.TabStop = false;
            this.excludeFoldersGroupBox.Text = "Exclude folders";
            // 
            // excludeListBox
            // 
            this.excludeListBox.FormattingEnabled = true;
            this.excludeListBox.Location = new System.Drawing.Point(8, 16);
            this.excludeListBox.Name = "excludeListBox";
            this.excludeListBox.Size = new System.Drawing.Size(368, 160);
            this.excludeListBox.TabIndex = 2;
            this.excludeListBox.SelectedIndexChanged += new System.EventHandler(this.ExcludeListBox_SelectedIndexChanged);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(384, 48);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "&Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(384, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(16, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "System folders (like the startup folder) get ignored automatically.";
            // 
            // ExclusionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excludeFoldersGroupBox);
            this.Controls.Add(this.subFoldersCheckBox);
            this.Name = "ExclusionPage";
            this.PageParts = Craftplacer.ClassicSuite.Wizards.Enums.PagePart.Header;
            this.Size = new System.Drawing.Size(497, 253);
            this.Title = "Select which folders to include or exclude";
            this.Load += new System.EventHandler(this.ExclusionPage_Load);
            this.excludeFoldersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox subFoldersCheckBox;
        private System.Windows.Forms.GroupBox excludeFoldersGroupBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox excludeListBox;
    }
}
