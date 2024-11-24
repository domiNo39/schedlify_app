using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedlify.WinForm
{
    public partial class WeekSelector : UserControl
    {
        public DateOnly CurrWeekStart;
        public WeekSelector()
        {
            DateOnly nowDate = DateOnly.FromDateTime(DateTime.Now);
            this.CurrWeekStart = nowDate.AddDays((((int)nowDate.DayOfWeek + 6) % 7) * -1);
            InitializeComponent();
            InitializeTime();


        }
        private void InitializeTime()
        {
            dateTimePicker1.Value = CurrWeekStart.ToDateTime(new TimeOnly(0,0));
        }


        private void button_prev_week_Click(object sender, EventArgs e)
        {
            this.CurrWeekStart = CurrWeekStart.AddDays(7);
            InitializeTime();


        }
        private void button_next_week_Click(object sender, EventArgs e)
        {
            this.CurrWeekStart = CurrWeekStart.AddDays(-7);
            InitializeTime();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateOnly curr_selected_date = DateOnly.FromDateTime(dateTimePicker1.Value);
            this.CurrWeekStart = curr_selected_date.AddDays((((int)curr_selected_date.DayOfWeek + 6) % 7) * -1);
            InitializeTime();

        }
    }
}
