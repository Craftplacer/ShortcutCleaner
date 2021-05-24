using System;
using System.Drawing;

namespace ShortcutCleaner.Filters
{
    public class DocumentsFilter : Filter
    {
        private static readonly string[] extensions = new string[]
        {
            ".rtf",
            ".txt",
            ".chm",
            ".html",
            ".pdf"
        };

        private static readonly string[] fileNames = new string[]
        {
            "help",
            "documentation",
            "README",
            "license",
            "manual"
        };

        public override string Name => "Documentation and help documents";

        public override string Description => $"Shortcuts of documents like documentation or similar.\r\n\r\nShortcuts of file types {string.Join(", ", extensions)} and of file names containing {string.Join(", ", fileNames)} get deleted.";

        public override Image Icon => Properties.Resources.TextFile;

        public override bool IsMatch(string originalPath, string resolvedPath)
        {
            var isDocument = IsExtensions(resolvedPath, extensions);
            var hasNames = ContainsWords(originalPath, fileNames);

            return isDocument || hasNames;
        }
    }
}
