
namespace ShortcutCleaner.Pages
{
    partial class FolderPage
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
            this.flattenRadioButton = new System.Windows.Forms.RadioButton();
            this.ignoreRadioButton = new System.Windows.Forms.RadioButton();
            this.flattenLabel = new System.Windows.Forms.Label();
            this.ignoreLabel = new System.Windows.Forms.Label();
            this.ignorePictureBox = new System.Windows.Forms.PictureBox();
            this.flattenPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ignorePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flattenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flattenRadioButton
            // 
            this.flattenRadioButton.AutoSize = true;
            this.flattenRadioButton.Checked = true;
            this.flattenRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.flattenRadioButton.Location = new System.Drawing.Point(96, 72);
            this.flattenRadioButton.Name = "flattenRadioButton";
            this.flattenRadioButton.Size = new System.Drawing.Size(191, 18);
            this.flattenRadioButton.TabIndex = 2;
            this.flattenRadioButton.TabStop = true;
            this.flattenRadioButton.Text = "Flatten out folders (recommended)";
            this.flattenRadioButton.UseVisualStyleBackColor = true;
            // 
            // ignoreRadioButton
            // 
            this.ignoreRadioButton.AutoSize = true;
            this.ignoreRadioButton.Location = new System.Drawing.Point(96, 144);
            this.ignoreRadioButton.Name = "ignoreRadioButton";
            this.ignoreRadioButton.Size = new System.Drawing.Size(89, 17);
            this.ignoreRadioButton.TabIndex = 3;
            this.ignoreRadioButton.Text = "Ignore folders";
            this.ignoreRadioButton.UseVisualStyleBackColor = true;
            // 
            // flattenLabel
            // 
            this.flattenLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.flattenLabel.Location = new System.Drawing.Point(112, 96);
            this.flattenLabel.Name = "flattenLabel";
            this.flattenLabel.Size = new System.Drawing.Size(328, 32);
            this.flattenLabel.TabIndex = 4;
            this.flattenLabel.Text = "Folders with no or one shortcut will be deleted and their shortcuts will be put i" +
    "nto the parent folder.";
            // 
            // ignoreLabel
            // 
            this.ignoreLabel.Location = new System.Drawing.Point(112, 168);
            this.ignoreLabel.Name = "ignoreLabel";
            this.ignoreLabel.Size = new System.Drawing.Size(328, 16);
            this.ignoreLabel.TabIndex = 5;
            this.ignoreLabel.Text = "Folders stay as is, even if they\'re empty.";
            // 
            // ignorePictureBox
            // 
            this.ignorePictureBox.Image = global::ShortcutCleaner.Properties.Resources.FolderPrograms;
            this.ignorePictureBox.Location = new System.Drawing.Point(56, 136);
            this.ignorePictureBox.Name = "ignorePictureBox";
            this.ignorePictureBox.Size = new System.Drawing.Size(32, 32);
            this.ignorePictureBox.TabIndex = 1;
            this.ignorePictureBox.TabStop = false;
            // 
            // flattenPictureBox
            // 
            this.flattenPictureBox.Image = global::ShortcutCleaner.Properties.Resources.FolderArrow;
            this.flattenPictureBox.Location = new System.Drawing.Point(56, 64);
            this.flattenPictureBox.Name = "flattenPictureBox";
            this.flattenPictureBox.Size = new System.Drawing.Size(32, 32);
            this.flattenPictureBox.TabIndex = 0;
            this.flattenPictureBox.TabStop = false;
            // 
            // FolderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ignoreLabel);
            this.Controls.Add(this.flattenLabel);
            this.Controls.Add(this.ignoreRadioButton);
            this.Controls.Add(this.flattenRadioButton);
            this.Controls.Add(this.ignorePictureBox);
            this.Controls.Add(this.flattenPictureBox);
            this.Name = "FolderPage";
            this.PageParts = Craftplacer.ClassicSuite.Wizards.Enums.PagePart.Header;
            this.Size = new System.Drawing.Size(497, 253);
            this.Title = "Select whether to flatten folders";
            this.PageLeave += new System.EventHandler<System.EventArgs>(this.FolderPage_LeavePage);
            ((System.ComponentModel.ISupportInitialize)(this.ignorePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flattenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox flattenPictureBox;
        private System.Windows.Forms.PictureBox ignorePictureBox;
        private System.Windows.Forms.RadioButton flattenRadioButton;
        private System.Windows.Forms.RadioButton ignoreRadioButton;
        private System.Windows.Forms.Label flattenLabel;
        private System.Windows.Forms.Label ignoreLabel;
    }
}
