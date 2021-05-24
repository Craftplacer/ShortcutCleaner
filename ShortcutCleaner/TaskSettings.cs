using ShortcutCleaner.Enums;

using System.Collections.Generic;

namespace ShortcutCleaner
{
    public class TaskSettings
    {
        public FolderLocation FolderLocation { get; set; } = FolderLocation.CurrentUser;

        public bool RemoveRedundantFolders { get; set; }

        public bool ScanSubFolders { get; set; }

        public List<string> ExcludedFolderNames { get; set; }

        public List<string> EnabledFilters { get; set; } = new List<string>();
    }
}