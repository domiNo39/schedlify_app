using System;
using System.Windows.Forms;
using Schedlify.Controllers;
using Schedlify.Models;

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
            User? newUser = _usersController.Register(login, password);

            if (newUser != null)
            {
                // Реєстрація успішна
                MessageBox.Show("Реєстрація успішна! Ваш акаунт створено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close(); // Закриваємо форму після успішної реєстрації
                // Закриваємо поточне вікно
                this.Hide();

                // Відкриваємо форму UniDepGroupForm
                var uniDepGroupForm = new UniDepGroupForm();
                uniDepGroupForm.FormClosed += (s, args) => this.Close(); // Закриваємо RegistrationForm після закриття UniDepGroupForm
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
