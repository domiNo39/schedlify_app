using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schedlify.Controllers;

namespace Schedlify.WinForm
{
    public partial class Assignment : UserControl
    {
        private Models.Assignment assignment;
        private AssignmentController assignmentController;
        public Assignment(Models.Assignment _assignment)
        {
            assignment = _assignment;
            InitializeComponent(_assignment);
            assignmentController = new AssignmentController();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            assignmentController.Remove(assignment.Id);
            var mainForm = Application.OpenForms.OfType<ScheduleForm>().FirstOrDefault();
            mainForm.changeSchedule_ValueChanged(sender, EventArgs.Empty);


        }
    }
}
