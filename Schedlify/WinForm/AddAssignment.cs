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

        public AddAssignment(DateOnly _date, int _classNumber)
        {
            date = _date;
            classNumber = _classNumber;
            InitializeComponent();
        }
        private void btnCreateAssignment_Click(object sender, EventArgs e)
        {
            // Відкрити форму CreateAssignmentForm

            var createAssignmentForm = new CreateAssignment();
            createAssignmentForm.ShowDialog(); // Використовуємо ShowDialog для модального відкриття
        }

    }
    
}
