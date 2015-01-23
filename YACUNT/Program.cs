﻿using System;
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
                Application.Run(new frmDefault());
                // Set file name if they chose to open a file, otherwise return
                return;
            }

            fileName = fileName ?? args[0];
            if (!File.Exists(fileName)) return; // errors here

            var extension = Path.GetExtension(args[0]);

            switch (extension)
            {
                case ".nfo":
                    Application.Run(new UI.nfo(fileName));

                    break;

                default:
                    MessageBox.Show("Opening format " + extension + "\nFilename:" + fileName + "\nExtension:" + extension);
                    break;
            }                        
        }

        // TODO: option to register file handler with system
    }
}
