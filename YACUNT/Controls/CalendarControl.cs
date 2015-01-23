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
using YACUNT.Util.Component;

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
            var entry = listEvents.SelectedItem as iCalEvent;
            if (entry == null) return;

            panelInfo.Controls.Clear();

            if (entry.Classification != null) AddPanel("Classification", entry.Classification.Value.Text);
            if (entry.DateTimeStart!= null) AddPanel("DateTimeStart", entry.DateTimeStart.Value.ToString());
            if (entry.DateTimeEnd != null) AddPanel("DateTimeEnd", entry.DateTimeEnd.Value.ToString());
            if (entry.DateTimeCreated!= null) AddPanel("DateTimeCreated", entry.DateTimeCreated.Value.ToString());
            if (entry.DateTimeStamp != null) AddPanel("DateTimeStamp", entry.DateTimeStamp.Value.ToString());
            if (entry.Description != null) AddPanel("Description", entry.Description.Value.ToString());
        }

        private void AddPanel(string caption, string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            var panel = new Panel();
            panelInfo.Controls.Add(panel);
            panel.Dock = DockStyle.Top;
            panel.BackColor = Color.Lime;

            var label = new Label();
            label.Text = caption;
            panel.Controls.Add(label);
            label.AutoSize = true;
            label.BackColor = Color.Pink;

            var label2 = new Label();
            label2.Text = value;
            panel.Controls.Add(label2);
            label2.AutoSize = true;
            label2.Left = label.Width + 10;            
            label2.BackColor = Color.Cyan;

            panel.Height = label.Height + 4;
        }
    }
}
