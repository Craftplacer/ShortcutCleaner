using Craftplacer.ClassicSuite.Wizards.Pages;

using ShortcutCleaner.Enums;
using ShortcutCleaner.Forms;

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ShortcutCleaner.Pages
{
    public partial class StartPage : WizardPage
    {
        private bool exiting;

        public StartPage()
        {
            InitializeComponent();
        }

        private void StartPage_PageEnter(object sender, EventArgs e)
        {
            if (Program.SkipStartPage)
            {
                Program.SkipStartPage = false;

                folderComboBox.SelectedIndex = 1;
                OnNextPageRequested();
            }
        }

        private void StartPage_PageLeave(object sender, EventArgs e)
        {
            var selectedLocation = (FolderLocation)folderComboBox.SelectedIndex;

            Program.TaskSettings.FolderLocation = selectedLocation;

            if (selectedLocation == FolderLocation.AllUsers)
            {
                if (Helpers.IsRunningAsAdministrator() || exiting)
                {
                    return;
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    Verb = "runas",
                    Arguments = "-cau"
                };

                Process.Start(startInfo);

                exiting = true;

                Application.Exit();
            }
        }

        private void AboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void StartPage_Load(object sender, EventArgs e)
        {
            folderComboBox.SelectedIndex = 0;
        }
    }
}