
using Craftplacer.ClassicSuite.Wizards.Enums;

namespace ShortcutCleaner.Pages
{
    partial class StartPage
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.introductionLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label = new System.Windows.Forms.Label();
            this.folderLabel = new System.Windows.Forms.Label();
            this.backupLabel = new System.Windows.Forms.Label();
            this.folderComboBox = new System.Windows.Forms.ComboBox();
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(8, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(302, 17);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Welcome to the Shortcut Cleaner Wizard";
            // 
            // introductionLabel
            // 
            this.introductionLabel.Location = new System.Drawing.Point(8, 56);
            this.introductionLabel.Name = "introductionLabel";
            this.introductionLabel.Size = new System.Drawing.Size(320, 72);
            this.introductionLabel.TabIndex = 1;
            this.introductionLabel.Text = "This wizard helps you clean your start menu by:\r\n\r\n• Removing unused documentatio" +
    "n shortcuts and links\r\n• Removing redundant uninstall shortcuts\r\n• Reducing fold" +
    "ers";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a folder where the start menu items get copied to.";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(8, 200);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(320, 16);
            this.label.TabIndex = 3;
            this.label.Text = "To continue, click Next.";
            // 
            // folderLabel
            // 
            this.folderLabel.Location = new System.Drawing.Point(8, 128);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(216, 24);
            this.folderLabel.TabIndex = 4;
            this.folderLabel.Text = "Clean following start menu folder:";
            this.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backupLabel
            // 
            this.backupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupLabel.Location = new System.Drawing.Point(8, 164);
            this.backupLabel.Name = "backupLabel";
            this.backupLabel.Size = new System.Drawing.Size(320, 32);
            this.backupLabel.TabIndex = 7;
            this.backupLabel.Text = "It\'s recommended to make a backup of your programs folder before continuing in ca" +
    "se of a bug.";
            // 
            // folderComboBox
            // 
            this.folderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.folderComboBox.FormattingEnabled = true;
            this.folderComboBox.Items.AddRange(new object[] {
            "Current User",
            "All Users"});
            this.folderComboBox.Location = new System.Drawing.Point(224, 130);
            this.folderComboBox.Name = "folderComboBox";
            this.folderComboBox.Size = new System.Drawing.Size(104, 21);
            this.folderComboBox.TabIndex = 8;
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.Location = new System.Drawing.Point(8, 288);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(320, 13);
            this.aboutLinkLabel.TabIndex = 9;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "About Shortcut Cleaner...";
            this.aboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutLinkLabel_LinkClicked);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.aboutLinkLabel);
            this.Controls.Add(this.folderComboBox);
            this.Controls.Add(this.backupLabel);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.label);
            this.Controls.Add(this.introductionLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "StartPage";
            this.PageParts = Craftplacer.ClassicSuite.Wizards.Enums.PagePart.Sidebar;
            this.Size = new System.Drawing.Size(333, 313);
            this.PageEnter += new System.EventHandler<System.EventArgs>(this.StartPage_PageEnter);
            this.PageLeave += new System.EventHandler<System.EventArgs>(this.StartPage_PageLeave);
            this.Load += new System.EventHandler(this.StartPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label introductionLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.Label backupLabel;
        private System.Windows.Forms.ComboBox folderComboBox;
        private System.Windows.Forms.LinkLabel aboutLinkLabel;
    }
}
