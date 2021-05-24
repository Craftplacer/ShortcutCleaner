using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ShortcutCleaner.Filters
{
    public abstract class Filter
    {
        public abstract string Name { get; }

        public abstract Image Icon { get; }

        public virtual string Description => string.Empty;

        public virtual FilterCategory Category => FilterCategory.General;

        public virtual bool SelectedByDefault => true;

        /// <summary>
        /// Checks whether this filter matches with this file.
        /// </summary>
        /// <param name="originalPath">The location of the file being inspected.</param>
        /// <param name="resolvedPath">The location of the actual file, usually the a shortcut destination. Defaults to original path if unresolvable (i.e. not a shortcut).</param>
        /// <returns>Whether this file matched this filter</returns>
        public abstract bool IsMatch(string originalPath, string resolvedPath);

        protected bool IsExtensions(string filePath, params string[] extensions)
        {
            var extension = Path.GetExtension(filePath);
            return extensions.Any(e => extension.Equals(e, StringComparison.OrdinalIgnoreCase));
        }

        protected bool ContainsWords(string filePath, params string[]words)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath).ToLowerInvariant();

            return words.Any((w) => fileName.Contains(w.ToLowerInvariant()));
        }
    }
}
