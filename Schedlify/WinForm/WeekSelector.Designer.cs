namespace Schedlify.WinForm
{
    partial class WeekSelector
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button button_prev_week;
        private Button button_next_week;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_prev_week = new Button();
            button_next_week = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // button_prev_week
            // 
            button_prev_week.Location = new Point(2, 3);
            button_prev_week.Name = "button_prev_week";
            button_prev_week.Size = new Size(21, 23);
            button_prev_week.TabIndex = 19;
            button_prev_week.Text = "<";
            button_prev_week.UseVisualStyleBackColor = true;
            button_prev_week.Click += button_prev_week_Click;
            // 
            // button_next_week
            // 
            button_next_week.Location = new Point(125, 2);
            button_next_week.Name = "button_next_week";
            button_next_week.Size = new Size(21, 23);
            button_next_week.TabIndex = 18;
            button_next_week.Text = ">";
            button_next_week.UseVisualStyleBackColor = true;
            button_next_week.Click += button_next_week_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(26, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(94, 23);
            dateTimePicker1.TabIndex = 20;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // WeekSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateTimePicker1);
            Controls.Add(button_prev_week);
            Controls.Add(button_next_week);
            Name = "WeekSelector";
            Size = new Size(150, 29);
            ResumeLayout(false);
        }

        #endregion



        public DateTimePicker dateTimePicker1;
    }
}
