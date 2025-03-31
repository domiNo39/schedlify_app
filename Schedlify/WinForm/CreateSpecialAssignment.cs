using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Schedlify.Controllers;
using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.WinForm
{
    public partial class CreateSpecialAssignment : Form
    {
        ClassController _classescontroller;
        AssignmentController _assignmentcontroller;
        int classNumber;
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
        public CreateSpecialAssignment(int _classNumber)
        {
            
            InitializeComponent();

            ShowClassNumberLabel(_classNumber);

            classNumber = _classNumber;
            _classescontroller = new ClassController();
            _assignmentcontroller = new AssignmentController();
            
            // Заповнення випадаючих списків (приклад)
            PopulateClassComboBox();

            // Додавання обробників подій для кнопок редагування
            btnEditClasses.Click += btnEditClasses_Click;

            // Увімкнення/вимкнення полів для адреси та аудиторії в залежності від формату
            rbtnInPerson.CheckedChanged += ModeChanged;
            rbtnRemote.CheckedChanged += ModeChanged;

            // Спочатку приховати поля для адреси й аудиторії
            ToggleAddressFields(false);
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

        private void btnEditClasses_Click(object sender, EventArgs e)
        {
            // Відкрити форму редагування предметів (приклад)
            MessageBox.Show("Форма редагування предметів відкриється тут.");
        }

        private void btnEditSlots_Click(object sender, EventArgs e)
        {
            // Відкрити форму редагування слотів (приклад)
            MessageBox.Show("Форма редагування слотів відкриється тут.");
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
                string? address = txtAddress.Text == "" ? null : txtAddress.Text;
                string? roomNumber = txtRoomNumber.Text == "" ? null : txtRoomNumber.Text;
                DateOnly date = DateOnly.FromDateTime(dateTimePicker1.Value);

                _assignmentcontroller.AddSpecialAssignment(date, classNumber, _class.Id, lecturer, address, roomNumber, (ClassType)classType, (Mode)mode);

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
