namespace Schedlify.WinForm
{
    partial class ClassesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox Предмети;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;

        /// <summary>
        /// Звільнення ресурсів
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Ініціалізація компонентів
        /// </summary>
        private void InitializeComponent()
        {
            Предмети = new ListBox();
            itemTextBox = new TextBox();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            scheduleButton = new Button();
            SuspendLayout();
            // 
            // Предмети
            // 
            Предмети.Dock = DockStyle.Left;
            Предмети.ItemHeight = 15;
            Предмети.Location = new Point(0, 0);
            Предмети.Name = "Предмети";
            Предмети.Size = new Size(178, 281);
            Предмети.TabIndex = 0;
            // 
            // itemTextBox
            // 
            itemTextBox.Dock = DockStyle.Top;
            itemTextBox.Location = new Point(178, 0);
            itemTextBox.Name = "itemTextBox";
            itemTextBox.PlaceholderText = "Введіть назву предмету";
            itemTextBox.Size = new Size(173, 23);
            itemTextBox.TabIndex = 1;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Top;
            addButton.Location = new Point(178, 23);
            addButton.Name = "addButton";
            addButton.Size = new Size(173, 22);
            addButton.TabIndex = 2;
            addButton.Text = "Додати";
            addButton.Click += AddButton_Click;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Top;
            editButton.Location = new Point(178, 45);
            editButton.Name = "editButton";
            editButton.Size = new Size(173, 22);
            editButton.TabIndex = 3;
            editButton.Text = "Редагувати";
            editButton.Click += EditButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Dock = DockStyle.Top;
            deleteButton.Location = new Point(178, 67);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(173, 22);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Видалити";
            deleteButton.Click += DeleteButton_Click;
            // 
            // scheduleButton
            // 
            scheduleButton.Location = new Point(178, 258);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(172, 23);
            scheduleButton.TabIndex = 5;
            scheduleButton.Text = "Розклад";
            scheduleButton.UseVisualStyleBackColor = true;
            scheduleButton.Click += ScheduleButton_Click;
            // 
            // ClassesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 281);
            Controls.Add(scheduleButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(itemTextBox);
            Controls.Add(Предмети);
            Name = "ClassesForm";
            Text = "Schedulify";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button scheduleButton;
    }
}
