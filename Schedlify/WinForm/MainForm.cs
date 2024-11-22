using System;
using System.Windows.Forms;

namespace Schedlify.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Відкриваємо форму реєстрації
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Close(); // Закриваємо основне вікно
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close(); // Закриваємо головне вікно
        }

    }
}

