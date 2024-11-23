using System;
using System.Linq;
using System.Windows.Forms;
using Schedlify.Controllers;
using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.WinForm
{
    public partial class UniDepGroupForm : Form
    {
        private readonly UniversityController _universityController;
        private readonly DepartmentController _departmentController;
        private readonly GroupController _groupController;

        public UniDepGroupForm()
        {
            InitializeComponent();
            _universityController = new UniversityController();
            _departmentController = new DepartmentController();
            _groupController = new GroupController();

            universityComboBox.TextChanged += UniversityComboBox_TextChanged;
            departmentComboBox.TextChanged += DepartmentComboBox_TextChanged;
        }

        private void UniversityComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdateComboBox(universityComboBox, input =>
            {
                var universities = _universityController.Search(input).ToList();
                return universities.Select(u => u.Name).ToArray();
            });
        }

        private void DepartmentComboBox_TextChanged(object sender, EventArgs e)
        {
            if (universityComboBox.SelectedItem == null)
                return;

            var selectedUniversity = _universityController.Search(universityComboBox.Text).FirstOrDefault();
            if (selectedUniversity == null)
                return;

            UpdateComboBox(departmentComboBox, input =>
            {
                var departments = _departmentController.Search(selectedUniversity.Id, input).ToList();
                return departments.Select(d => d.Name).ToArray();
            });
        }

        private void GroupComboBox_TextChanged(object sender, EventArgs e)
        {
            if (departmentComboBox.SelectedItem == null)
                return;

            var selectedUniversity = _universityController.Search(universityComboBox.Text).FirstOrDefault();
            var selectedDepartment = _departmentController.Search(selectedUniversity.Id, departmentComboBox.Text).FirstOrDefault();

            if (selectedDepartment == null)
                return;

            UpdateComboBox(groupComboBox, input =>
            {
                var groups = _groupController.Search(selectedDepartment.Id, input).ToList();
                return groups.Select(g => g.Name).ToArray();
            });
        }

        private void UpdateComboBox(ComboBox comboBox, Func<string, string[]> getItems)
        {
            try
            {
                // Отримуємо поточний текст із поля вводу
                string currentText = comboBox.Text;

                // Викликаємо функцію для отримання відповідних елементів списку
                var items = getItems(currentText);

                // Забороняємо оновлювати сам текст в полі, лише випадаючий список
                var previousItems = comboBox.Items.Cast<string>().ToArray();
                if (!items.SequenceEqual(previousItems)) // Перевірка, чи потрібно оновлювати
                {
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(items);
                }

                // Відкриваємо випадаючий список, якщо є результати
                comboBox.DroppedDown = items.Any();

                // Позиція курсора не змінюється
                comboBox.SelectionStart = currentText.Length;
                comboBox.SelectionLength = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні списку: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void confirmSelectionButton_Click(object sender, EventArgs e)
        {
            // Перевірка, чи вибрані всі необхідні значення
            if (string.IsNullOrEmpty(universityComboBox.Text) ||
                string.IsNullOrEmpty(departmentComboBox.Text) ||
                string.IsNullOrEmpty(groupComboBox.Text))
            {
                MessageBox.Show("Будь ласка, виберіть університет, факультет і групу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Логіка обробки вибраного університету, факультету та групи
            string selectedUniversity = universityComboBox.Text;
            string selectedDepartment = departmentComboBox.Text;
            string selectedGroup = groupComboBox.Text;

            var university = _universityController.Add(selectedUniversity);
            var department = _departmentController.Add(university.Id ,selectedDepartment);
            Console.WriteLine(UserSession.currentUser.Id);
            Guid id = UserSession.currentUser.Id;
            var group = _groupController.Add(department.Id, UserSession.currentUser.Id, selectedGroup);

            


            UserSession.currentUniversity = university;
            UserSession.currentDepartment = department;
            UserSession.currentGroup = group;
           

            MessageBox.Show($"Ви обрали: Університет - {selectedUniversity}, Факультет - {selectedDepartment}, Група - {selectedGroup}",
                "Успішний вибір", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Переходимо на ScheduleForm
            var scheduleForm = new ScheduleForm();
            scheduleForm.Show();

            // Закриваємо поточну форму
            this.Close();
        }
    }
}
