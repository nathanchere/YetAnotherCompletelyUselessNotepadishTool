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
    }
}
