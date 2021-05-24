using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCleaner.Filters
{
    public class BrokenShortcutFilter : Filter
    {
        public BrokenShortcutFilter()
        {
        }

        public override string Name => "Broken shortcuts";

        public override Image Icon => Properties.Resources.BrokenShortcut;

        public override bool IsMatch(string originalPath, string resolvedPath)
        {
            // Weird cases, but we should ignore the shortcut then (could contain special links).
            if (string.IsNullOrWhiteSpace(resolvedPath))
            {
                return false;
            }

            var exists = File.Exists(resolvedPath);
            return !exists;
        }
    }
}
