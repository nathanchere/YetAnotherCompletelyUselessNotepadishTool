using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YACUNT
{
    public partial class frmDefault : Form
    {
        public frmDefault()
        {
            InitializeComponent();
        }

        public string FileName { get; private set; }    

        private void btnSetFileAssociations_Click(object sender, EventArgs e)
        {
            var extensions = new List<string>();
            foreach (var item in groupFileTypes.Controls)
            {
                var checkbox = item as CheckBox;
                if (checkbox != null && checkbox.Checked)
                {
                    extensions.Add(checkbox.Text);
                }
            }

            foreach (var extension in extensions)
            {
                FileAssociationManager.SetAssociation(extension, Application.ExecutablePath, "YACUNT_" + extension, "Opened with YACUNT", true);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if(dialog.ShowDialog() != DialogResult.OK) return;
            FileName = dialog.FileName;
            Close();
        }
    }
}
