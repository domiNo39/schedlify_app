using System;
using System.Linq;
using System.Windows.Forms;
using Schedlify.Controllers;
using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.WinForm
{
    public partial class UniDepGroupFormUser : Form
    {
        private readonly UniversityController _universityController;
        private readonly DepartmentController _departmentController;
        private readonly GroupController _groupController;
        List<University> universities;
        List<Department> departments;
        List<Group> groups;

        public UniDepGroupFormUser()
        {
            InitializeComponent();
            _universityController = new UniversityController();
            _departmentController = new DepartmentController();
            _groupController = new GroupController();
            this.Load += LoadUniController;

            List<string> universitiesNames = universities.Select(c => c.Name).ToList();
            universityComboBox.Items.AddRange(universitiesNames.ToArray());
            universityComboBox.SelectedIndex = 0;
        }
        
        async private void LoadUniController(object sender, EventArgs e)
        {
            universities = await _universityController.Search("");
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

            var university = universities[universityComboBox.SelectedIndex];
            var department = departments[departmentComboBox.SelectedIndex];
            var group = groups[groupComboBox.SelectedIndex];

            UserSession.currentUniversity = university;
            UserSession.currentDepartment = department;
            UserSession.currentGroup = group;
            ScheduleForm scheduleForm = new ScheduleForm();
            scheduleForm.Show();

            // Закриваємо поточну форму
            this.Close();
        }

        async private void universityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            departments = await _departmentController.Search(universities[universityComboBox.SelectedIndex].Id, "");
            departmentComboBox.Items.Clear();
            List<string> departmentsNames = departments.Select(c => c.Name).ToList();
            departmentComboBox.Items.AddRange(departmentsNames.ToArray());
            departmentComboBox.SelectedIndex = 0;
        }

        async private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groups = await _groupController.Search(departments[departmentComboBox.SelectedIndex].Id, "");
            groupComboBox.Items.Clear();
            List<string> groupsNames = groups.Select(c => c.Name).ToList();
            groupComboBox.Items.AddRange(groupsNames.ToArray());
            groupComboBox.SelectedIndex = 0;

        }
    }
}
