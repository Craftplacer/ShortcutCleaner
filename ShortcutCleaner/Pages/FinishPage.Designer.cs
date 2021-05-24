
namespace ShortcutCleaner.Pages
{
    partial class FinishPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.recycleBinLinkLabel = new System.Windows.Forms.LinkLabel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(8, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(283, 17);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Finishing the Shortcut Cleaner Wizard";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Below you find a list of shortcuts and folders that have been removed.";
            // 
            // recycleBinLinkLabel
            // 
            this.recycleBinLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(29, 23);
            this.recycleBinLinkLabel.Location = new System.Drawing.Point(8, 290);
            this.recycleBinLinkLabel.Name = "recycleBinLinkLabel";
            this.recycleBinLinkLabel.Size = new System.Drawing.Size(320, 13);
            this.recycleBinLinkLabel.TabIndex = 4;
            this.recycleBinLinkLabel.TabStop = true;
            this.recycleBinLinkLabel.Text = "You can restore the items by opening the recycle bin.";
            this.recycleBinLinkLabel.UseCompatibleTextRendering = true;
            this.recycleBinLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecycleBinLinkLabel_LinkClicked);
            // 
            // treeView
            // 
            this.treeView.FullRowSelect = true;
            this.treeView.Location = new System.Drawing.Point(8, 88);
            this.treeView.Name = "treeView";
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(320, 192);
            this.treeView.TabIndex = 5;
            // 
            // FinishPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.recycleBinLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Name = "FinishPage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.PageParts = Craftplacer.ClassicSuite.Wizards.Enums.PagePart.Sidebar;
            this.Size = new System.Drawing.Size(333, 313);
            this.PageEnter += new System.EventHandler<System.EventArgs>(this.FinishPage_EnterPage);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel recycleBinLinkLabel;
        private System.Windows.Forms.TreeView treeView;
    }
}
