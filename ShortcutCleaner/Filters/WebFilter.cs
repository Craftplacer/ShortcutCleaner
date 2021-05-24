using System;
using System.Drawing;
using System.IO;

namespace ShortcutCleaner.Filters
{
    class WebFilter : Filter
    {
        public override string Name => "Web links";

        public override Image Icon => Properties.Resources.WebDocument;

        public override FilterCategory Category => FilterCategory.External;

        public override bool IsMatch(string originalPath, string resolvedPath)
        {
            return Path.GetExtension(resolvedPath).Equals(".url", StringComparison.OrdinalIgnoreCase);
        }
    }
}
