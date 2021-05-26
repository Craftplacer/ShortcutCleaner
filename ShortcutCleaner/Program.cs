using Craftplacer.ClassicSuite.Wizards.Forms;
using Craftplacer.ClassicSuite.Wizards.Pages;

using ShortcutCleaner.Filters;
using ShortcutCleaner.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ShortcutCleaner
{
    internal static class Program
    {
        public static Assembly Assembly { get; private set; }

        public static ImageList DeletedIcons = new ImageList()
        {
            ColorDepth = ColorDepth.Depth32Bit,
            ImageSize = new System.Drawing.Size(16, 16),
        };

        public static List<string> DeletedPaths = new List<string>();
        public static TaskSettings TaskSettings { get; internal set; } = new TaskSettings();

        public static Filter[] AvailableFilters { get; private set; }
        public static bool SkipStartPage { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Assembly = Assembly.GetExecutingAssembly();
            SkipStartPage = args.Contains("-cau");
            AvailableFilters = Helpers.GetFilters().ToArray();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var wizard = CreateWizard())
            {
                Application.Run(wizard);
            }
        }

        private static WizardForm CreateWizard()
        {
            var pages = new WizardPage[]
            {
                new StartPage(),

                new SelectionPage(),
                new FolderPage(),
                // new ExclusionPage(),

                new DeletionPage(),

                new FinishPage()
            };

            var wizard = WizardForm.FromList(pages);
            wizard.Text = "Shortcut Cleaner";
            wizard.DefaultHeaderImage = Properties.Resources.WizardHeader;
            wizard.DefaultSidebarImage = Properties.Resources.WizardSidebar;
            wizard.Icon = Properties.Resources.Icon;

            return wizard;
        }
    }
}