using Craftplacer.ClassicSuite.Wizards.Enums;
using Craftplacer.ClassicSuite.Wizards.Pages;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ShortcutCleaner.Pages
{
    public partial class FinishPage : WizardPage
    {
        public FinishPage()
        {
            InitializeComponent();
            AllowedButtons = AllowedButton.Next;
        }

        private void FinishPage_EnterPage(object sender, EventArgs e)
        {
            treeView.BeginUpdate();

            treeView.ImageList = Program.DeletedIcons;

            treeView.Nodes.Clear();

            var allUsersSelected = Program.TaskSettings.FolderLocation == Enums.FolderLocation.AllUsers;
            var programsPath = Helpers.GetProgramsPath(allUsersSelected) + Path.DirectorySeparatorChar;
            foreach (var path in Program.DeletedPaths)
            {
                var treeNode = new TreeNode
                {
                    Text = path.Substring(programsPath.Length),
                    ImageKey = path.ToLowerInvariant(),
                    SelectedImageKey = path.ToLowerInvariant(),
                };

                treeView.Nodes.Add(treeNode);
            }

            treeView.EndUpdate();
        }

        private void RecycleBinLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "shell:RecycleBinFolder",
                UseShellExecute = true,
            });
        }
    }
}