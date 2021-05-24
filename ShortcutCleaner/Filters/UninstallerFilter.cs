using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCleaner.Filters
{
    public class UninstallerFilter : Filter
    {
        public override string Name => "Uninstallers";

        public override Image Icon => Properties.Resources.Installer;

        public override bool IsMatch(string originalPath, string resolvedPath)
        {
            var originalFileName = Path.GetFileNameWithoutExtension(originalPath);
            var resolvedFileName = Path.GetFileName(originalPath);

            var uninstallerFileNames = new string[]
            {
                "uninst.exe",
                "uninstall.exe"
            };

            return originalFileName.Contains("Uninstall") ||
                uninstallerFileNames.Any((fn) => fn.Equals(resolvedFileName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
