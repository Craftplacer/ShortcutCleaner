using System.Drawing;
using System.IO;

namespace ShortcutCleaner.Filters
{
    public class UpdateFilter : Filter
    {
        public override string Name => "Updaters";

        public override Image Icon => Properties.Resources.Refresh;

        public override bool IsMatch(string originalPath, string resolvedPath)
        {
            var fileName = Path.GetFileNameWithoutExtension(originalPath).ToLowerInvariant();

            return fileName.Contains("update");
        }
    }
}
