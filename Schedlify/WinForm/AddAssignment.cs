using Schedlify.Models;
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
    public partial class AddAssignment : UserControl
    {
        DateOnly date;
        int classNumber;
        Weekday weekDay;

        public AddAssignment(DateOnly _date, int _classNumber)
        {
            date = _date;
            classNumber = _classNumber;
            weekDay = (Weekday)(((int)_date.DayOfWeek + 6) % 7);
            InitializeComponent();
        }
        private void btnCreateAssignment_Click(object sender, EventArgs e)
        {
            // Відкрити форму CreateAssignmentForm

            //var createAssignmentForm = new CreateAssignment();
            //createAssignmentForm.ShowDialog(); // Використовуємо ShowDialog для модального відкриття

            contextMenuStrip1.Show(Cursor.Position);
        }

        private void постійнаПараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createAssignmentForm = new CreateRegularAssignment(classNumber, weekDay);
            createAssignmentForm.ShowDialog();
        }

        private void разВДваТижніToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void НаступногоТижняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ЦьогоТижняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ОдноразоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createAssignmentForm = new CreateSpecialAssignment(classNumber);
            createAssignmentForm.ShowDialog();
        }
    }

}
