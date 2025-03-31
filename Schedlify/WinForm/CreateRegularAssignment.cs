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
using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.WinForm
{
    public partial class CreateRegularAssignment : Form
    {
        ClassController _classescontroller;
        AssignmentController _assignmentcontroller;
        int classNumber;
        Weekday weekDay;
        List<Class> classes;
        Dictionary<int, string> daysOfWeek = new Dictionary<int, string>
        {
            { 0, "Понеділок"},
            { 1, "Вівторок"},
            { 2, "Середа"},
            { 3, "Четвер" },
            { 4, "П'ятниця" },
            { 5, "Субота" },
        };
        public CreateRegularAssignment(int _classNumber, Weekday _weekDay)
        {
            
            InitializeComponent();

           

            ShowDayWeekLabel(_weekDay);
            ShowClassNumberLabel(_classNumber);



            classNumber = _classNumber;
            _classescontroller = new ClassController();
            _assignmentcontroller = new AssignmentController();
            weekDay = _weekDay;


            // Заповнення випадаючих списків (приклад)
            PopulateClassComboBox();

            // Увімкнення/вимкнення полів для адреси та аудиторії в залежності від формату
            rbtnInPerson.CheckedChanged += ModeChanged;
            rbtnRemote.CheckedChanged += ModeChanged;

            // Спочатку приховати поля для адреси й аудиторії
            ToggleAddressFields(false);
        }

        private void ShowDayWeekLabel(Weekday _weekday)
        {
            dayWeekLabel.Text = daysOfWeek[(int)_weekday];
        }

        private void ShowClassNumberLabel(int _classNumber)
        {
            classNumberLabel.Text = (_classNumber+1).ToString() + " пара";
        }

        private void PopulateClassComboBox()
        {
            // Приклад даних для предметів
            classes = _classescontroller.GetByGroupId(UserSession.currentGroup.Id);
            List<string> classesNames = classes.Select(c => c.Name).ToList();
            classesComboBox.Items.AddRange(classesNames.ToArray());
            classesComboBox.SelectedIndex = 0; // Вибрати перший елемент за замовчуванням
        }

        private void ModeChanged(object sender, EventArgs e)
        {
            // Увімкнення/вимкнення полів для адреси й аудиторії залежно від формату
            ToggleAddressFields(rbtnInPerson.Checked);
        }

        private void ToggleAddressFields(bool isInPerson)
        {
            lblAddress.Visible = isInPerson;
            txtAddress.Visible = isInPerson;
            lblRoomNumber.Visible = isInPerson;
            txtRoomNumber.Visible = isInPerson;

            if (!isInPerson)
            {
                // Очищення полів, якщо формат дистанційний
                txtAddress.Text = string.Empty;
                txtRoomNumber.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Збереження Assignment (приклад)
            if (ValidateInputs())
            {
                Class _class = classes[classesComboBox.SelectedIndex]; 
                string? lecturer = txtLecturer.Text == "" ? null : txtLecturer.Text;
                int classType = rbtnLecture.Checked ? 0 : 1;
                int mode = rbtnInPerson.Checked ? 1 : 0;
                string? address = txtAddress.Text == "" ? null: txtAddress.Text;
                string? roomNumber = txtRoomNumber.Text == "" ? null: txtRoomNumber.Text;

                _assignmentcontroller.AddRegularAssignment(weekDay, classNumber, _class.Id, lecturer, address, roomNumber, (ClassType)classType, (Mode)mode);

                var mainForm = Application.OpenForms.OfType<ScheduleForm>().FirstOrDefault();
                mainForm.changeSchedule_ValueChanged(sender, EventArgs.Empty);

                this.Close();
            }
        }

        private bool ValidateInputs()
        {
            if (classesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть предмет.");
                return false;
            }


            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
