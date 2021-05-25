using Craftplacer.ClassicSuite.Wizards.Pages;

using ShortcutCleaner.Filters;

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

        public SelectionPage()
        {
            InitializeComponent();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var counts = new Dictionary<string, int>();
            var filters = Helpers.GetFilters();

            foreach (var filter in filters)
            {
                counts[filter.GetType().FullName] = GetCountForCategory(filter);
                backgroundWorker.ReportProgress(0, counts);
            }

            fetchedCounts = true;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lock (e.UserState)
            {
                if (e.UserState is Dictionary<string, int> counts)
                {
                    listView.BeginUpdate();

                    foreach (var kv in counts)
                    {
                        foreach (ListViewItem lvi in listView.Items)
                        {
                            if (lvi.Tag is Filter filter && filter.GetType().FullName == kv.Key)
                            {
                                if (kv.Value == 1)
                                {
                                    lvi.SubItems[1].Text = kv.Value + " item found";
                                }
                                else
                                {
                                    lvi.SubItems[1].Text = kv.Value + " items found";
                                }
                                
                                break;
                            }
                        }
                    }

                    ResizeColumns();
                    listView.EndUpdate();
                }
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
                    if (item.Checked && item.Tag is Filter filter)
                    {
                        var filterName = filter.GetType().FullName;
                        Program.TaskSettings.EnabledFilters.Add(filterName);
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

            ResizeColumns();
        }

        private int GetCountForCategory(Filter filter)
        {
            var settings = new TaskSettings()
            {
                EnabledFilters = new List<string>(1)
                {
                    filter.GetType().FullName,
                }
            };

            var path = Helpers.GetProgramsPath(Program.TaskSettings.FolderLocation == Enums.FolderLocation.AllUsers);
            var paths = Cleaner.CollectPaths(path, settings);
            return paths.Count();
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
                Tag = filter,
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

            if (item.Tag is Filter filter)
            {
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
    }
}