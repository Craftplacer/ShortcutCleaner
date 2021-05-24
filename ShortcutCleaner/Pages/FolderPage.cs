using Craftplacer.ClassicSuite.Wizards.Pages;

using System;

namespace ShortcutCleaner.Pages
{
    public partial class FolderPage : WizardPage
    {
        public FolderPage()
        {
            InitializeComponent();
        }

        private void FolderPage_LeavePage(object sender, EventArgs e)
        {
            Program.TaskSettings.RemoveRedundantFolders = flattenRadioButton.Checked;
        }
    }
}