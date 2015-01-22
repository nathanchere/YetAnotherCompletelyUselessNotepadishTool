using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                // Display file open dialog
                // set fileName
            }
            else fileName = args[0];

            if (string.IsNullOrEmpty(fileName)) return; // errors here
            if (!File.Exists(fileName)) return; // errors here

            var extension = Path.GetExtension(args[0]);

            // TODO: Detect file type and launch appropriate viewer
            //Application.Run(new Form1());

            MessageBox.Show("Opening format " + extension);
        }

        // TODO: option to register file handler with system
    }
}
