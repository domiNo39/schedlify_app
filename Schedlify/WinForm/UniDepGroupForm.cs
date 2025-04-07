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
        private readonly TemplateSlotController _templateSlotController;

        public UniDepGroupForm()
        {
            InitializeComponent();
            _universityController = new UniversityController();
            _departmentController = new DepartmentController();
            _groupController = new GroupController();
            _templateSlotController = new TemplateSlotController();

            universityComboBox.TextChanged += UniversityComboBox_TextChanged;
            departmentComboBox.TextChanged += DepartmentComboBox_TextChanged;
        }

        async private void UniversityComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdateComboBox(universityComboBox, async input =>
            {
                var universities = await _universityController.Search(input);
                return universities.Select(u => u.Name).ToArray();
            });
        }

        async private void DepartmentComboBox_TextChanged(object sender, EventArgs e)
        {
            if (universityComboBox.SelectedItem == null)
                return;

            var selectedUniversity = (await _universityController.Search(universityComboBox.Text)).FirstOrDefault();
            if (selectedUniversity == null)
                return;

            UpdateComboBox(departmentComboBox, async input =>
            {
                var departments = await _departmentController.Search(selectedUniversity.Id, input);
                return departments.Select(d => d.Name).ToArray();
            });
        }

        async private void GroupComboBox_TextChanged(object sender, EventArgs e)
        {
            if (departmentComboBox.SelectedItem == null)
                return;

            var selectedUniversity = (await _universityController.Search(universityComboBox.Text)).FirstOrDefault();
            var selectedDepartment = (await _departmentController.Search(selectedUniversity.Id, departmentComboBox.Text)).FirstOrDefault();

            if (selectedDepartment == null)
                return;

            UpdateComboBox(groupComboBox, async input =>
            {
                var groups = await _groupController.Search(selectedDepartment.Id, input);
                return groups.Select(g => g.Name).ToArray();
            });
        }

        async private void UpdateComboBox(ComboBox comboBox, Func<string, Task<string[]>> getSuggestions)
        {
            try
            {
                // Отримуємо поточний текст із поля вводу
                string currentText = comboBox.Text;

                // Викликаємо функцію для отримання відповідних елементів списку
                var items = await getSuggestions(currentText);

                // Забороняємо оновлювати сам текст в полі, лише випадаючий список
                var previousItems = comboBox.Items.Cast<string>().ToArray();
                if (!items.SequenceEqual(previousItems)) // Перевірка, чи потрібно оновлювати
                {
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(items);
                }

                // Відкриваємо випадаючий список, якщо є результати
                if (items.Length > 0)
                {
                    comboBox.DroppedDown = items.Any();
                }

                // Позиція курсора не змінюється
                comboBox.SelectionStart = currentText.Length;
                comboBox.SelectionLength = 0;
            }
            catch (Exception ex)
            {
            }
        }


        async private void confirmSelectionButton_Click(object sender, EventArgs e)
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

            var university = await _universityController.Add(selectedUniversity);
            var department = await _departmentController.Add(university.Id ,selectedDepartment);
            var group = await _groupController.Add(department.Id, UserSession.currentUser.Id, selectedGroup);

            UserSession.currentUniversity = university;
            UserSession.currentDepartment = department;
            UserSession.currentGroup = group;
            var slots = await _templateSlotController.GetByDepartmentId(department.Id);
            if (slots.Count() != 0)
            {
                ScheduleForm scheduleForm = new ScheduleForm();
                scheduleForm.Show();
            }
            else
            {
                TimeSlotsForm timeSlotsForm = new TimeSlotsForm();
                timeSlotsForm.Show();
            }
            

            // Закриваємо поточну форму
            this.Close();
        }
    }
}
