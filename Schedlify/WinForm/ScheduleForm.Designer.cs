namespace Schedlify.WinForm
{
    partial class ScheduleForm
    {
        /// <summary>
        /// Обов'язкова змінна конструктора форм
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка всіх ресурсів
        /// </summary>
        /// <param name="disposing">істина, якщо керовані ресурси мають бути видалені; інакше - хиба.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, створений конструктором форм Windows

        /// <summary>
        /// Метод для ініціалізації компонентів
        /// </summary>
        private void InitializeComponent()
        {
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scheduleLabel
            // 
            this.scheduleLabel.AutoSize = true;
            this.scheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scheduleLabel.Location = new System.Drawing.Point(150, 50);
            this.scheduleLabel.Name = "scheduleLabel";
            this.scheduleLabel.Size = new System.Drawing.Size(120, 31);
            this.scheduleLabel.TabIndex = 0;
            this.scheduleLabel.Text = "Розклад";
            this.scheduleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.scheduleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Розклад";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label scheduleLabel;
    }
}
