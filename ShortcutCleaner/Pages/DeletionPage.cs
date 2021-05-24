using Craftplacer.ClassicSuite.Wizards.Pages;

using Microsoft.VisualBasic.FileIO;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShortcutCleaner.Pages
{
    public partial class DeletionPage : WizardPage
    {
        public DeletionPage()
        {
            InitializeComponent();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var startMenuPath = Helpers.GetProgramsPath(Program.TaskSettings.FolderLocation == Enums.FolderLocation.AllUsers);
            var startupPath = GetStartupPath(Program.TaskSettings.FolderLocation);

            backgroundWorker.ReportProgress(0, "Searching through start menu...");
            var paths = Cleaner.CollectPaths(startMenuPath, Program.TaskSettings);

            if (paths.Any())
            {
                foreach (var path in paths)
                {
                    if (!File.Exists(path))
                    {
                        Debug.WriteLine($"Tried to delete {path} but the file does not exist anymore", "Deletion");
                        continue;
                    }

                    backgroundWorker.ReportProgress(0, $"Recycling {path.Substring(startMenuPath.Length + 1)}...");

                    var icon = Icon.ExtractAssociatedIcon(path);
                    Program.DeletedIcons.Images.Add(path.ToLowerInvariant(), icon);

                    FileSystem.DeleteFile(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

                    Program.DeletedPaths.Add(path);
                }
            }


            if (!Program.TaskSettings.RemoveRedundantFolders)
            {
                return;
            }

            backgroundWorker.ReportProgress(0, "Searching for redundant folders...");

            foreach (var folderPath in Directory.GetDirectories(startMenuPath))
            {
                if (folderPath.Equals(startupPath, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                try
                {
                    var files = Directory.GetFiles(folderPath);
                    if (files.Length <= 1)
                    {
                        EmptyFolder(folderPath, files);
                    }
                }
                catch (IOException)
                {
                    Debug.WriteLine("Failed to empty folder: " + folderPath);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string status)
            {
                fileNameLabel.Text = status;
                fileNameLabel.Invalidate();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"While deleting items, Shortcut Cleaner has encountered following error:\n\n{e.Error}", "Shortcut Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            OnNextPageRequested();
        }

        private void DeletionPage_EnterPage(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void EmptyFolder(string path, string[] files)
        {
            foreach (var filePath in files)
            {
                var fileInfo = new FileInfo(filePath);
                var parentPath = fileInfo.Directory.Parent.FullName;
                var newPath = Path.Combine(parentPath, fileInfo.Name);

                backgroundWorker.ReportProgress(0, $"Moving {fileInfo.Name}...");

                if (File.Exists(newPath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    File.Move(filePath, newPath);
                }
            }

            if (!Directory.GetDirectories(path).Any())
            {
                backgroundWorker.ReportProgress(0, $"Deleting {path}...");

                Directory.Delete(path);
            }

            Program.DeletedPaths.Add(path);
            Program.DeletedIcons.Images.Add(path, Properties.Resources.Folder);
        }

        private string GetStartupPath(Enums.FolderLocation folderLocation)
        {
            switch (folderLocation)
            {
                case Enums.FolderLocation.CurrentUser:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                case Enums.FolderLocation.AllUsers:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);

                default:
                    throw new ArgumentOutOfRangeException(nameof(folderLocation));
            }
        }
    }
}