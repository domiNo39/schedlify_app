using Schedlify.Controllers;
using Schedlify.Global;
using Schedlify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Schedlify.WinForm
{
    public partial class ClassesForm : Form
    {
        private readonly ClassController _classController;
        private List<Class> classes;

        public ClassesForm()
        {
            InitializeComponent();
            _classController = new ClassController();

            // Завантаження даних з бази даних
            LoadClasses();
        }

        private void LoadClasses()
        {
            Предмети.Items.Clear(); // Очищення відображення
            classes = _classController.GetByGroupId(UserSession.currentGroup.Id).ToList();

            // Додавання предметів до відображення
            foreach (Class c in classes)
            {
                Предмети.Items.Add(c.Name);
            }
        }

        // Додавання предмета
        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = itemTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                var newClass = _classController.Add(UserSession.currentGroup.Id, name);
                if (newClass != null)
                {
                    classes.Add(newClass);
                    Предмети.Items.Add(newClass.Name);
                    itemTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Не вдалося додати предмет", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введіть правильну назву", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Редагування вибраного предмета
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Предмети.SelectedItem != null)
            {
                string newName = itemTextBox.Text.Trim();
                int selectedIndex = Предмети.SelectedIndex;

                if (!string.IsNullOrEmpty(newName) && selectedIndex >= 0)
                {
                    var selectedClass = classes[selectedIndex];
                    var updatedClass = _classController.Edit(selectedClass.Id, newName);

                    if (updatedClass != null)
                    {
                        classes[selectedIndex].Name = newName;
                        Предмети.Items[selectedIndex] = newName;
                        itemTextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося оновити предмет", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введіть правильну назву", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Оберіть предмет для редагування", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Видалення вибраного предмета
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Предмети.SelectedItem != null)
            {
                int selectedIndex = Предмети.SelectedIndex;
                var selectedClass = classes[selectedIndex];

                if (_classController.Delete(selectedClass.Id))
                {
                    classes.RemoveAt(selectedIndex);
                    Предмети.Items.RemoveAt(selectedIndex);
                }
                else
                {
                    MessageBox.Show("Не вдалося видалити предмет", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Оберіть предмет для видалення", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            ScheduleForm scheduleForm = new ScheduleForm();
            scheduleForm.Show();
            this.Close();
        }
    }
}
