using System.IO;
using System.Windows.Forms;

namespace YACUNT.Forms
{
    public partial class nfo : Form
    {
        private readonly string _fileName;

        public nfo(string filename)
        {
            InitializeComponent();

            _fileName = filename;
            Open(filename);
        }

        private void Open(string filename)
        {
            var content = File.ReadAllText(filename);
            txtBody.Text = content;
            txtBody.SelectionLength = 0;
            txtBody.SelectionStart = 0;
        }

        private void nfo_Load(object sender, System.EventArgs e)
        {
            menuStrip.LostFocus += (o, args) => menuStrip.Visible = false;
        }

        private void nfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                var isVisible = !menuStrip.Visible;
                menuStrip.Visible = isVisible;
                if (isVisible) menuStrip.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                menuStrip.Visible = false;
            }
        }        
    }
}
