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
        public DateOnly curr_week_start;
        public DateOnly curr_week_end;
        public WeekSelector()
        {
            InitializeComponent();
        }


        private void button_prev_week_Click(object sender, EventArgs e)
        {

        }
        private void button_next_week_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateOnly curr_selected_date = DateOnly.FromDateTime(dateTimePicker1.Value.Date);


        }
    }
}
