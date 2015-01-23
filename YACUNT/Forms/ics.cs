using System;
using System.Windows.Forms;
using YACUNT.Controls;
using YACUNT.Util;

namespace YACUNT.Forms
{
    public partial class ics : Form
    {
        //private readonly iCalendar _calendar;
        private readonly string _fileName;

        public ics(string filename)
        {
            InitializeComponent();

            _fileName = filename;            
        }

        private void Open()
        {
            tabControl.TabPages.Clear();

            try
            {
                var result = new iCalParser().ParseFile(_fileName);
                if (result.CalendarList.Count == 0)
                {
                    MessageBox.Show("No calendars found");
                    return;
                }

                int count = 0;
                foreach (var calendar in result.CalendarList)
                {
                    var page = new TabPage {
                        Text = (++count).ToString(),
                    };
                    var control = new CalendarControl(calendar);
                    page.Controls.Add(control);
                    control.Dock = DockStyle.Fill;                    
                    tabControl.TabPages.Add(page);
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

            Open();            
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
