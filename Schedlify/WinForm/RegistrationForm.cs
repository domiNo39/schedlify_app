using System;
using System.Windows.Forms;
using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Global;
using Microsoft.VisualBasic.ApplicationServices;

namespace Schedlify.WinForm
{
    public partial class RegistrationForm : Form
    {
        private UsersController _usersController;

        public RegistrationForm()
        {
            InitializeComponent();
            _usersController = new UsersController();
        }

        // Обробник події для кнопки "Створити аккаунт"
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;   // Отримуємо логін з поля
            string password = passwordTextBox.Text;  // Отримуємо пароль з поля

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Будь ласка, введіть логін і пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Виходимо, якщо хоча б одне з полів порожнє
            }

            // Викликаємо метод Register з UsersController
            var newUser = _usersController.Register(login, password);

            if (newUser != null)
            {
                // Реєстрація успішна
                UserSession.currentUser = newUser;
                //this.Close(); // Закриваємо форму після успішної реєстрації
                // Закриваємо поточне вікно
                this.Close();

                // Відкриваємо форму UniDepGroupForm
                var uniDepGroupForm = new UniDepGroupForm();
                uniDepGroupForm.Show();
            }
            else
            {
                // Реєстрація не вдалася (можливо, логін вже існує)
                MessageBox.Show("Реєстрація не вдалася. Логін вже використовується.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
