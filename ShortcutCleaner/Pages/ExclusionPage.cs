using Craftplacer.ClassicSuite.Wizards.Pages;

using Microsoft.VisualBasic;

using System;

namespace ShortcutCleaner.Pages
{
    public partial class ExclusionPage : WizardPage
    {
        public ExclusionPage()
        {
            InitializeComponent();
        }

        private void ExclusionPage_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var input = Interaction.InputBox("Enter the name of the folder you want to exclude here:", "Exclude folders");

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            excludeListBox.Items.Add(input);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var index = excludeListBox.SelectedIndex;
            excludeListBox.Items.RemoveAt(index);
        }

        private void ExcludeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = excludeListBox.SelectedIndex != -1;
        }
    }
}
