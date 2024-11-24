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
    public partial class CreateAssignment : Form
    {
        ClassController _classescontroller;
        TemplateSlotController _templateslotcontroller;

        public CreateAssignment()
        {
            InitializeComponent();

            _classescontroller = new ClassController();
            _templateslotcontroller = new TemplateSlotController();


            // Заповнення випадаючих списків (приклад)
            PopulateClassComboBox();
            PopulateSlotComboBox();

            // Додавання обробників подій для кнопок редагування
            btnEditClasses.Click += btnEditClasses_Click;
            btnEditSlots.Click += btnEditSlots_Click;

            // Увімкнення/вимкнення полів для адреси та аудиторії в залежності від формату
            rbtnInPerson.CheckedChanged += ModeChanged;
            rbtnRemote.CheckedChanged += ModeChanged;

            // Спочатку приховати поля для адреси й аудиторії
            ToggleAddressFields(false);
        }

        private void PopulateClassComboBox()
        {
            // Приклад даних для предметів
            classesComboBox.Items.AddRange(new object[] { "Математика", "Фізика", "Програмування" });
            classesComboBox.SelectedIndex = 0; // Вибрати перший елемент за замовчуванням
        }

        private void PopulateSlotComboBox()
        {
            // Приклад даних для слотів
            slotsComboBox.Items.AddRange(new object[] { "8:00-9:20", "9:30-10:50", "11:00-12:20" });
            slotsComboBox.SelectedIndex = 0; // Вибрати перший елемент за замовчуванням
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
                string className = classesComboBox.SelectedItem.ToString();
                string slot = slotsComboBox.SelectedItem.ToString();
                string lecturer = txtLecturer.Text;
                string classType = rbtnLecture.Checked ? "Лекція" : "Практична";
                string mode = rbtnInPerson.Checked ? "Очно" : "Дистанційно";
                string address = txtAddress.Text;
                string roomNumber = txtRoomNumber.Text;

                MessageBox.Show($"Збережено нове заняття:\n\n" +
                                $"Предмет: {className}\n" +
                                $"Слот: {slot}\n" +
                                $"Викладач: {lecturer}\n" +
                                $"Тип: {classType}\n" +
                                $"Формат: {mode}\n" +
                                $"Адреса: {address}\n" +
                                $"Аудиторія: {roomNumber}");
            }
        }

        private bool ValidateInputs()
        {
            if (classesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть предмет.");
                return false;
            }

            if (slotsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть часовий слот.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLecturer.Text))
            {
                MessageBox.Show("Будь ласка, введіть ім'я викладача.");
                return false;
            }

            if (rbtnInPerson.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Будь ласка, введіть адресу.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
                {
                    MessageBox.Show("Будь ласка, введіть номер аудиторії.");
                    return false;
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Закриття форми без збереження
            this.Close();
        }
    }
}
