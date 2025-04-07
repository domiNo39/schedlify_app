using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Global;

namespace Schedlify.WinForm
{
    public partial class ScheduleForm : Form
    {
        AssignmentController _assignmentController;
        TemplateSlotController _templateSlotController;
        List<TemplateSlot> _templateSlots;
        DateOnly previousWeek;

        public ScheduleForm()
        {
            _assignmentController = new AssignmentController();
            _templateSlotController = new TemplateSlotController();
           
            
            InitializeComponent();
            this.Load += ScheduleFormLoad;
            var size = this.Size;
            AutoSize = false;
            this.Size = size;
            previousWeek = weekSelector1.CurrWeekStart;
            // Встановлюємо текст "Розклад"
            scheduleLabel.Text = "Розклад";
        }


        private async void ScheduleFormLoad(object? sender, EventArgs e)
        {
            _templateSlots = await _templateSlotController.GetByDepartmentId(UserSession.currentDepartment.Id);
            InitializeTable(_templateSlots, _assignmentController, weekSelector1.CurrWeekStart);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
            UserSession.currentUser = null;
            UserSession.currentGroup = null;
            UserSession.currentDepartment = null;
            UserSession.currentUniversity = null;
        }

        private void ChangeClassesBtn_Click(object sender, EventArgs e)
        {
            ClassesForm classesForm = new ClassesForm();
            classesForm.Show();
            this.Close();
        }


        public void changeSchedule_ValueChanged(object sender, EventArgs e)
        {
            panel1.Location = new Point(22, 82);
            if ( previousWeek < weekSelector1.CurrWeekStart)
            {
                while (panel1.Location.X >-1300)
                    {
                        panel1.Location = new Point(panel1.Location.X-1, panel1.Location.Y);
                    }
            }
            else if (previousWeek > weekSelector1.CurrWeekStart)
            {
                while (panel1.Location.X < 1400)
                {
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                }
            }
            
            panel1.Controls.Clear();
            panel1.Location=new Point(22, 82);
            InitializeTable(_templateSlots, _assignmentController, weekSelector1.CurrWeekStart);
            previousWeek = weekSelector1.CurrWeekStart;
        }
    }
}
