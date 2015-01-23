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
                listEvents.Items.Add(e.DateTimeStamp.Value);
            });
        }
    }
}
