using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YACUNT.Util;

namespace YACUNT.Controls
{
    public partial class CalendarControl : UserControl
    {
        private readonly iCalendar _calendar;

        public CalendarControl(iCalendar calendar)
        {            
            InitializeComponent();
            
            _calendar = calendar;
            calendar.EventList.ForEach(e =>
            {
                listEvents.Items.Add(e);
            });
        }

        private void listEvents_DoubleClick(object sender, EventArgs e)
        {
            var entry = listEvents.SelectedItem;
            if (entry == null) return;

            panelInfo.Controls.Clear();

            AddPanel("When", "12.1.1");
            AddPanel("Test", "My event ");
        }

        private void AddPanel(string caption, string value)
        {
            var panel = new Panel();
            panelInfo.Controls.Add(panel);
            panel.Dock = DockStyle.Top;

            var label = new Label();
            label.Text = caption;
            panel.Controls.Add(label);

            var label2 = new Label();
            label2.Text = value;
            panel.Controls.Add(label2);
            label2.Left = label.Width + 10;

            panel.Height = label.Height + 4;
        }
    }
}
