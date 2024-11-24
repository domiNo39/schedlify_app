using Schedlify.Controllers;
using Schedlify.Models;
using System;
using System.Windows.Forms;
using Schedlify.Global;

namespace Schedlify.WinForm
{
    public partial class ScheduleForm : Form
    {
        AssignmentController _assignmentController;
        TemplateSlotController _templateSlotController;
        List<TemplateSlot> _templateSlots;

        public ScheduleForm()
        {
            _assignmentController = new AssignmentController();
            _templateSlotController = new TemplateSlotController();
            _templateSlots = _templateSlotController.GetByDepartmentId(UserSession.currentDepartment.Id);
           
            
            InitializeComponent();
            InitializeTable(_templateSlots, _assignmentController, weekSelector1.CurrWeekStart);
            // Встановлюємо текст "Розклад"
            scheduleLabel.Text = "Розклад";
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

        private void btnCreateAssignment_Click(object sender, EventArgs e)
        {
            // Відкрити форму CreateAssignmentForm
            var createAssignmentForm = new CreateAssignment();
            createAssignmentForm.ShowDialog(); // Використовуємо ShowDialog для модального відкриття
        }

        private void changeSchedule_ValueChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InitializeTable(_templateSlots, _assignmentController, weekSelector1.CurrWeekStart);
        }
    }
}
