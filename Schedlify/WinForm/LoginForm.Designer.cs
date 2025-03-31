namespace Schedlify.WinForm
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginLabel = new Label();
            passwordLabel = new Label();
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            authButton = new Button();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(39, 58);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(40, 15);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "Логін:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(39, 108);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(52, 15);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Пароль:";
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(119, 58);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(200, 23);
            loginTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(119, 108);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(200, 23);
            passwordTextBox.TabIndex = 3;
            // 
            // authButton
            // 
            authButton.Location = new Point(139, 158);
            authButton.Name = "authButton";
            authButton.Size = new Size(100, 30);
            authButton.TabIndex = 4;
            authButton.Text = "Увійти";
            authButton.UseVisualStyleBackColor = true;
            authButton.Click += authButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Arial", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(24, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(162, 29);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Авторизація";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 200);
            Controls.Add(titleLabel);
            Controls.Add(authButton);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Schedulify";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button authButton;
        private Label titleLabel;
    }
}
