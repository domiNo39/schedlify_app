namespace Schedlify.WinForm
{
    partial class TimeSlotsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox SlotList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NextButton;

        /// <summary>
        /// Очищення ресурсів, що використовуються.
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SlotList = new ListBox();
            AddButton = new Button();
            DeleteButton = new Button();
            EditButton = new Button();
            NextButton = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // SlotList
            // 
            SlotList.FormattingEnabled = true;
            SlotList.Location = new Point(20, 72);
            SlotList.Name = "SlotList";
            SlotList.Size = new Size(280, 356);
            SlotList.TabIndex = 4;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(350, 83);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(209, 39);
            AddButton.TabIndex = 5;
            AddButton.Text = "Додати";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += new EventHandler(AddButton_Click);
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(350, 142);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(209, 47);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "Видалити";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += new EventHandler(DeleteButton_Click);
            // 
            // EditButton
            // 
            EditButton.Location = new Point(350, 206);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(209, 47);
            EditButton.TabIndex = 7;
            EditButton.Text = "Редагувати";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += new EventHandler(EditButton_Click);
            // 
            // NextButton
            // 
            NextButton.Location = new Point(350, 268);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(209, 48);
            NextButton.TabIndex = 8;
            NextButton.Text = "Розклад";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += new EventHandler(NextButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom; // Використовуємо CustomFormat
            this.dateTimePicker1.CustomFormat = "HH:mm"; // Формат тільки години та хвилини
            this.dateTimePicker1.ShowUpDown = true; // Вимикаємо календар
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(198, 39);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom; // Використовуємо CustomFormat
            this.dateTimePicker2.CustomFormat = "HH:mm"; // Формат тільки години та хвилини
            this.dateTimePicker2.ShowUpDown = true; // Вимикаємо календар
            this.dateTimePicker2.Location = new System.Drawing.Point(320, 20);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(239, 39);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // TimeSlotsForm
            // 
            ClientSize = new Size(585, 471);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(SlotList);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(NextButton);
            Name = "TimeSlotsForm";
            Text = "Часові слоти";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
    }
}
