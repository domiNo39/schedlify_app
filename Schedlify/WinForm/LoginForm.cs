using System;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using Schedlify.Controllers;
using Schedlify.Global;

namespace Schedlify.WinForm
{
    public partial class LoginForm : Form
    {
        private UsersController _usersController;
        private GroupController _groupController;
        private TemplateSlotController _templateSlotController;
        private DepartmentController _departmentController;

        public LoginForm()
        {
            InitializeComponent();
            _usersController = new UsersController();
            _groupController = new GroupController();
            _templateSlotController = new TemplateSlotController();
        }

        // Обробник події для кнопки "Увійти"
        async private void authButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;   // Отримуємо логін з поля
            string password = passwordTextBox.Text;  // Отримуємо пароль з поля

            // Перевірка на порожні поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Будь ласка, введіть логін і пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Виходимо, якщо хоча б одне з полів порожнє
            }

            // Викликаємо метод Login з UsersController для перевірки введених даних
            var user = await _usersController.Login(login, password);

            if (user != null)
            {
                // Авторизація успішна
                UserSession.currentUser = user;



                var group = await _groupController.GetByAdministratorId(user.Id);

                if (group != null)
                {
                    UserSession.currentGroup = group;
                    _departmentController = new DepartmentController();
                    UserSession.currentDepartment = await _departmentController.GetById(group.DepartmentId);
                    var timeSlots = await _templateSlotController.GetByDepartmentId(group.DepartmentId);
                    if (!timeSlots.IsNullOrEmpty())
                    {
                        ScheduleForm scheduleForm = new ScheduleForm();
                        scheduleForm.Show();
                    }
                    else
                    {
                        TimeSlotsForm timeSlotsForm = new TimeSlotsForm();
                        timeSlotsForm.Show();
                    }

                }
                else
                {
                    UniDepGroupForm uniDepGroupForm = new UniDepGroupForm();
                    uniDepGroupForm.Show();
                }
                // Переходимо до UniDepGroupForm
                this.Close(); // Закриваємо форму після успішного входу
            }
            else
            {
                // Авторизація не вдалася (логін/пароль некоректні)
                MessageBox.Show("Невірний логін або пароль. Спробуйте ще раз.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
