using ShortcutCleaner.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCleaner
{
    public static class Helpers
    {
        public static string GetProgramsPath(bool allUsers = true)
        {
            string startMenuPath;

            if (allUsers)
            {
                startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);
            }
            else
            {
                startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            }

            return startMenuPath;
        }

        public static bool IsRunningAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        private static IEnumerable<Type> GetFilterTypes()
        {
            var assembly = typeof(Program).Assembly;
            foreach (var type in assembly.GetTypes())
            {
                if (type.BaseType == typeof(Filter))
                {
                    yield return type;
                }
            }
        }

        public static IEnumerable<Filter> GetFilters()
        {
            var types = GetFilterTypes();
            foreach (var type in types)
            {
                var filterInstance = (Filter)Activator.CreateInstance(type);
                yield return filterInstance;
            }
        }
    }
}