using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShortcutCleaner.Forms
{
    public partial class ItemsForm : Form
    {
        private readonly string[] paths;

        public ItemsForm(IEnumerable<string> paths = null)
        {
            InitializeComponent();
            this.paths = paths?.ToArray();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            if (paths == null)
            {
                return;
            }

            foreach (var path in paths)
            {
                var pathIcon = Icon.ExtractAssociatedIcon(path);
                imageList.Images.Add(path, pathIcon);
            }

            foreach (var path in paths)
            {
                treeView.Nodes.Add(null, path, path, path);
            }
        }
    }
}
