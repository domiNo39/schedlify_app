namespace Schedlify.WinForm
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
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

            // Тут можна додати логіку для перевірки наявності користувача або створення нового акаунта
            // Наприклад, звернення до бази даних або локального сховища

            // Для прикладу, просто виводимо повідомлення
            MessageBox.Show($"Логін: {login}\nПароль: {password}", "Реєстрація успішна", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Тут можна, наприклад, закрити форму або перейти до іншої
            // this.Close(); // Закриваємо форму після успішної реєстрації
        }
    }
}
