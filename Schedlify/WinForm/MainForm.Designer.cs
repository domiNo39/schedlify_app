namespace Schedlify.WinForm
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Створення компонентів
            this.SuspendLayout();

            // Заголовок "Schedlify"
            Label titleLabel = new Label
            {
                Text = "Schedlify",
                Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(150, 30),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            // Опис "зручний розклад в тебе під рукою!"
            Label descriptionLabel = new Label
            {
                Text = "зручний розклад в тебе під рукою!",
                Font = new System.Drawing.Font("Arial", 14),
                Location = new System.Drawing.Point(100, 80),
                AutoSize = true
            };
            this.Controls.Add(descriptionLabel);

            // Текст "Ти-" жирним шрифтом
            Label youTextLabel = new Label
            {
                Text = "Ти-",
                Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(150, 130),
                AutoSize = true
            };
            this.Controls.Add(youTextLabel);

            // Лінія
            Panel line = new Panel
            {
                BackColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(50, 160),
                Size = new System.Drawing.Size(500, 2)
            };
            this.Controls.Add(line);

            // Ліворуч текст "хочеш переглянути існуючий розклад"
            Label leftTextLabel = new Label
            {
                Text = "хочеш переглянути існуючий розклад",
                Font = new System.Drawing.Font("Arial", 12),
                Location = new System.Drawing.Point(50, 170),
                AutoSize = true
            };
            this.Controls.Add(leftTextLabel);

            // Кнопка "глянути розклад"
            Button viewScheduleButton = new Button
            {
                Text = "глянути розклад",
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(150, 40)
            };
            this.Controls.Add(viewScheduleButton);

            // Праворуч текст "заповнюєш розклад"
            Label rightTextLabel = new Label
            {
                Text = "заповнюєш розклад",
                Font = new System.Drawing.Font("Arial", 12),
                Location = new System.Drawing.Point(350, 170),
                AutoSize = true
            };
            this.Controls.Add(rightTextLabel);

            // Кнопка "Увійти"
            Button loginButton = new Button
            {
                Text = "Увійти",
                Location = new System.Drawing.Point(350, 200),
                Size = new System.Drawing.Size(100, 40)
            };
            this.Controls.Add(loginButton);

            // Кнопка "Реєстрація"
            Button registerButton = new Button
            {
                Text = "Реєстрація",
                Location = new System.Drawing.Point(460, 200),
                Size = new System.Drawing.Size(100, 40)
            };
            this.Controls.Add(registerButton);

            // Прив'язка обробника події до кнопки "Увійти"
            loginButton.Click += new System.EventHandler(this.loginButton_Click);

            // Прив'язка обробника події до кнопки "Реєстрація"
            registerButton.Click += new System.EventHandler(this.registrationButton_Click);
            viewScheduleButton.Click += new System.EventHandler(this.viewScheduleButton_Click);

            // Налаштування форми
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Schedlify";
            this.ResumeLayout(false);
        }

        // Обробник події для кнопки "Реєстрація"
        private void registrationButton_Click(object sender, EventArgs e)
        {
            // Створення нового вікна реєстрації
            RegistrationForm registrationForm = new RegistrationForm();

            // Показуємо вікно реєстрації
            registrationForm.Show();

            // (Необов'язково) Закриваємо поточне вікно, якщо не хочемо, щоб воно залишалося відкритим
            this.Close(); // Приховуємо головне вікно
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide(); // Закриваємо головне вікно
        }
        private void viewScheduleButton_Click(object sender, EventArgs e)
        {
            UniDepGroupFormUser unidepForm = new UniDepGroupFormUser();
            unidepForm.Show();
            this.Hide(); // Закриваємо головне вікно
        }
    }
}
