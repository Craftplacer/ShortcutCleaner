using ShortcutCleaner.Filters;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShortcutCleaner
{
    public class Cleaner
    {
        public static IEnumerable<string> CollectPaths(string path, TaskSettings settings)
        {
            var paths = new List<string>();

            foreach (var subPath in Directory.GetDirectories(path))
            {
                var subPaths = CollectPaths(subPath, settings);
                paths.AddRange(subPaths);
            }

            foreach (var originalPath in Directory.GetFiles(path))
            {
                var selectedFilters = Program.AvailableFilters.Where((f) => settings.EnabledFilters.Contains(f.Id));
                foreach (var filter in selectedFilters)
                {
                    var resolvedPath = ResolvePath(originalPath);
                    if (filter.IsMatch(originalPath, resolvedPath))
                    {
                        paths.Add(originalPath);
                    }
                }
            }

            return paths;
        }

        private static string ResolvePath(string path)
        {
            var isShortcut = Path.GetExtension(path).Equals(".lnk", StringComparison.InvariantCultureIgnoreCase);
            if (isShortcut && GetDestinationPath(path) is string shortcutPath)
            {
                return shortcutPath;
            }

            return path;
        }

        private static string GetDestinationPath(string shortcutPath)
        {
            var shell = new IWshRuntimeLibrary.WshShell();
            var item = shell.CreateShortcut(shortcutPath);

            if (item is IWshRuntimeLibrary.IWshShortcut link)
            {
                return link.TargetPath;
            }

            return null;
        }
    }
}