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

    }
}

