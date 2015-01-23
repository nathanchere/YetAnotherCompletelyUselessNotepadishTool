using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace YACUNT
{
    static class Program
    {        
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string fileName = null;

            if (args.Length == 0)
            {
                var form = new frmDefault();
                form.ShowDialog();
                if (form.FileName != null)
                {
                    fileName = form.FileName;
                }
                else
                    return;
            }

            fileName = fileName ?? args[0];
            if (!File.Exists(fileName)) return; // errors here

            var extension = Path.GetExtension(fileName);

            switch (extension)
            {
                case ".nfo":
                    Application.Run(new Forms.nfo(fileName));
                    break;

                case ".ics":
                case ".ical":
                    Application.Run(new Forms.ics(fileName));
                    break;

                default:
                    MessageBox.Show("Opening format " + extension + "\nFilename:" + fileName + "\nExtension:" + extension);
                    break;
            }                        
        }

        // TODO: option to register file handler with system
    }
}
