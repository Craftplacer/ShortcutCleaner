using System;
using System.Drawing;
using System.IO;

namespace ShortcutCleaner.Filters
{
    public class DonationFilter : Filter
    {
        public override string Name => "Donation links";

        public override Image Icon => Properties.Resources.Star;

        public override FilterCategory Category => FilterCategory.External;

        public override bool SelectedByDefault => false;

        public override bool IsMatch(string originalPath, string resolvedPath)
{
            var fileName = Path.GetFileNameWithoutExtension(originalPath);
            return fileName.Equals("Donate", StringComparison.OrdinalIgnoreCase);
        }
    }
}
