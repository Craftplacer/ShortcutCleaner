using Craftplacer.ClassicSuite.Wizards.Pages;

using ShortcutCleaner.Filters;
using ShortcutCleaner.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ShortcutCleaner.Pages
{
    public partial class SelectionPage : WizardPage
    {
        private bool fetchedCounts;
        private Dictionary<string, IEnumerable<string>> paths;

        public SelectionPage()
        {
            InitializeComponent();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var paths = new Dictionary<string, IEnumerable<string>>();

            foreach (var filter in Program.AvailableFilters)
            {
                paths[filter.GetType().FullName] = GetPathsForFilter(filter);
                backgroundWorker.ReportProgress(0, paths);
            }

            fetchedCounts = true;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lock (e.UserState)
            {
                if (!(e.UserState is Dictionary<string, IEnumerable<string>> newPaths))
                {
                    return;
                }

                paths = newPaths;

                listView.BeginUpdate();

                foreach (var kv in paths)
                {
                    foreach (ListViewItem lvi in listView.Items)
                    {
                        if (!(lvi.Tag is string filterId) || filterId != kv.Key)
                        {
                            continue;
                        }

                        var count = kv.Value.Count();
                        if (count == 1)
                        {
                            lvi.SubItems[1].Text = count + " item found";
                        }
                        else
                        {
                            lvi.SubItems[1].Text = count + " items found";
                        }

                        break;
                    }
                }

                ResizeColumns();
                listView.EndUpdate();
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"A problem occured while calculating the item estimates.\n\nThis may indicate a problem with the program. Further details are shown below:\n\n{e.Error}", "Shortcut Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FirstPage_EnterPage(object sender, EventArgs e)
        {
            if (!(backgroundWorker.IsBusy || fetchedCounts))
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void FirstPage_LeavePage(object sender, EventArgs e)
        {
            lock (Program.TaskSettings.EnabledFilters)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    if (item.Checked && item.Tag is string filterId)
                    {
                        Program.TaskSettings.EnabledFilters.Add(filterId);
                    }
                }
            }
        }

        private void FirstPage_Load(object sender, EventArgs e)
        {
            foreach (var filter in Helpers.GetFilters())
            {
                var group = GetGroup(filter.Category);

                imageList.Images.Add(filter.GetType().FullName, filter.Icon);

                var lvi = MakeListViewItem(filter, group);
                listView.Items.Add(lvi);
            }

            if (listView.Items.Count != 0)
            {
                listView.Items[0].Selected = true;
            }

            ResizeColumns();
        }

        private IEnumerable<string> GetPathsForFilter(Filter filter)
        {
            var settings = new TaskSettings()
            {
                EnabledFilters = new List<string>(1)
                {
                    filter.GetType().FullName,
                }
            };

            var path = Helpers.GetProgramsPath(Program.TaskSettings.FolderLocation == Enums.FolderLocation.AllUsers);
            return Cleaner.CollectPaths(path, settings);
        }

        private ListViewGroup GetGroup(FilterCategory filterCategory)
        {
            foreach (ListViewGroup group in listView.Groups)
            {
                if (group.Tag is FilterCategory groupCategory && groupCategory == filterCategory)
                {
                    return group;
                }
            }

            var newGroup = new ListViewGroup(filterCategory.ToString())
            {
                Tag = filterCategory,
            };

            listView.Groups.Add(newGroup);

            return newGroup;
        }

        private ListViewItem MakeListViewItem(Filter filter, ListViewGroup group)
        {
            var labels = new string[] { filter.Name, "Calculating..." };
            return new ListViewItem(labels, filter.GetType().FullName)
            {
                Tag = filter.GetType().ToString(),
                Group = group,
                Checked = filter.SelectedByDefault,
            };
        }

        private void ResizeColumns()
        {
            listView.Columns[1].Width = -1;
            listView.Columns[0].Width = -2;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }

            var item = listView.SelectedItems[0];

            if (item.Tag is string filterId)
            {
                if (paths != null)
                {
                    viewSelectedButton.Enabled = paths[filterId]?.Any() ?? false;
                }

                var filter = Program.AvailableFilters.First((f) => f.GetType().FullName == filterId);

                titleLabel.Text = filter.Name;

                if (string.IsNullOrWhiteSpace(filter.Description))
                {
                    descriptionLabel.Text = "(no description provided)";
                }
                else
                {
                    descriptionLabel.Text = filter.Description;
                }
            }
        }

        private void ViewSelectedButton_Click(object sender, EventArgs e)
        {
            var item = listView.SelectedItems[0];
            if (item.Tag is string filterId)
            {
                var filterPaths = paths[filterId];

                using (var itemsForm = new ItemsForm(filterPaths))
                {
                    itemsForm.ShowDialog(this);
                }
            }
        }
    }
}