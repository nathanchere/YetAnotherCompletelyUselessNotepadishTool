using System;
using System.Windows.Forms;
using YACUNT.Util;

namespace YACUNT.UI
{
    public partial class ics : Form
    {
        //private readonly iCalendar _calendar;
        private readonly string _fileName;

        public ics(string filename)
        {
            InitializeComponent();

            _fileName = filename;
            Open();
        }

        private void Open()
        {
            try
            {
                var result = new iCalParser().ParseFile(_fileName);
                if (result.CalendarList.Count == 0)
                {
                    MessageBox.Show("No calendars found");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open file: " + ex.Message);
            }

        }

        private void ics_Load(object sender, System.EventArgs e)
        {
            menuStrip.LostFocus += (o, args) => menuStrip.Visible = false;
        }

        private void ics_KeyDown(object sender, KeyEventArgs e)
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
