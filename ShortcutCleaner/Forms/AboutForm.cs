using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ShortcutCleaner.Forms
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text = string.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            this.logoPictureBox.Image = GetLogoBitmap();
        }

        #region Assembly Attribute Accessors

        private static T FetchAssemblyAttribute<T>() where T : Attribute
        {
            var attributes = Program.Assembly.GetCustomAttributes(typeof(T), false);

            if (attributes.Length == 0)
            {
                return null;
            }

            return (T)attributes[0];
        }

        public string AssemblyTitle
        {
            get
            {
                var titleAttribute = FetchAssemblyAttribute<AssemblyTitleAttribute>();

                if (string.IsNullOrEmpty(titleAttribute?.Title))
                {
                    return Path.GetFileNameWithoutExtension(Program.Assembly.CodeBase);
                }
                else
                {
                    return titleAttribute.Title;
                }
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Program.Assembly.GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                var descriptionAttribute = FetchAssemblyAttribute<AssemblyDescriptionAttribute>();
                if (descriptionAttribute == null)
                {
                    return string.Empty;
                }
                else
                {
                    return descriptionAttribute.Description;
                }
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var versionAttribute = FetchAssemblyAttribute<AssemblyProductAttribute>();
                if (versionAttribute == null)
                {
                    return string.Empty;
                }
                else
                {
                    return versionAttribute.Product;
                }
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var copyrightAttribute = FetchAssemblyAttribute<AssemblyCopyrightAttribute>();
                if (copyrightAttribute == null)
                {
                    return string.Empty;
                }
                else
                {
                    return copyrightAttribute.Copyright;
                }
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var companyAttribute = FetchAssemblyAttribute<AssemblyCompanyAttribute>();
                if (companyAttribute == null)
                {
                    return string.Empty;
                }
                else
                {
                    return companyAttribute.Company;
                }
            }
        }
        #endregion

        private Bitmap GetLogoBitmap()
        {
            var logo = Properties.Resources.AboutLogo;
            var bitmap = new Bitmap(logo.Width, logo.Height);

            using (var graphics = Graphics.FromImage(bitmap))
            using (var gradientBrush = new LinearGradientBrush(Point.Empty, new Point(bitmap.Width, 0), SystemColors.ActiveCaption, SystemColors.GradientActiveCaption))
            {
                graphics.FillRectangle(gradientBrush, logoPictureBox.Margin.Left, logoPictureBox.Margin.Top, logoPictureBox.Width, logoPictureBox.Height);

                graphics.DrawImage(logo, Point.Empty);
            }

            return bitmap;
        }
    }
}
