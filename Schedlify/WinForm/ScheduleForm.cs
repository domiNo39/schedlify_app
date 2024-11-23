using System;
using System.Windows.Forms;

namespace Schedlify.WinForm
{
    public partial class ScheduleForm : Form
    {
        public ScheduleForm()
        {
            InitializeComponent();
            // Встановлюємо текст "Розклад"
            scheduleLabel.Text = "Розклад";
        }
    }
}
