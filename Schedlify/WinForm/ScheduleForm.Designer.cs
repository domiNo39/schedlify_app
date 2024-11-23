using Schedlify.Controllers;
using System.Windows.Forms;
using Schedlify.Global;

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
        /// 
        private void InitializeTable(int rowsNum, AssignmentController assignmentController) 
        {
            
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, // Make it fill the form
                ColumnCount = 6, // Initial columns
                RowCount = rowsNum,    // Initial rows
            };

            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100/rowsNum)); // Evenly distributed
            }

            // Add initial column styles
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6/rowsNum)); // Evenly distributed
            }
            DateOnly date = DateOnly.FromDateTime(new DateTime(2024, 11, 24));
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++) 
            {

                List<Models.Assignment> assignmentsList = assignmentController.GetByGroupIdAndDate(UserSession.currentGroup.Id, date.AddDays(col));
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    if (assignmentsList.Count >= row + 1)
                    {
                        Assignment assignment = new Assignment(assignmentsList[row]);
                        tableLayoutPanel1.Controls.Add(assignment, col, row); // Додаємо текст у комірку
                    }
  
                    //tableLayoutPanel1.Controls.Add(label, col, row); // Додаємо текст у комірку
                }
            }
            this.Controls.Add(tableLayoutPanel1);
        }
        private void InitializeComponent()
        {
            scheduleLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label_group_static = new Label();
            label_group = new Label();
            SuspendLayout();
            // 
            // scheduleLabel
            // 
            scheduleLabel.AutoSize = true;
            scheduleLabel.Font = new Font("Myanmar Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scheduleLabel.Location = new Point(581, 19);
            scheduleLabel.Margin = new Padding(6, 0, 6, 0);
            scheduleLabel.Name = "scheduleLabel";
            scheduleLabel.Size = new Size(228, 75);
            scheduleLabel.TabIndex = 0;
            scheduleLabel.Text = "Розклад";
            scheduleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(52, 143);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(163, 36);
            label1.TabIndex = 2;
            label1.Text = "ПОНЕДІЛОК";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(299, 143);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(136, 36);
            label2.TabIndex = 3;
            label2.Text = "ВІВТОРОК";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(535, 143);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 36);
            label3.TabIndex = 4;
            label3.Text = "СЕРЕДА";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(763, 143);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 36);
            label4.TabIndex = 5;
            label4.Text = "ЧЕТВЕР";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(982, 143);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(140, 36);
            label5.TabIndex = 6;
            label5.Text = "П'ЯТНИЦЯ";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(1218, 143);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(112, 36);
            label6.TabIndex = 7;
            label6.Text = "СУБОТА";
            // 
            // label_group_static
            // 
            label_group_static.AutoSize = true;
            label_group_static.Location = new Point(22, 41);
            label_group_static.Margin = new Padding(6, 0, 6, 0);
            label_group_static.Name = "label_group_static";
            label_group_static.Size = new Size(89, 32);
            label_group_static.TabIndex = 8;
            label_group_static.Text = "Група: ";
            label_group_static.Click += label7_Click;
            // 
            // label_group
            // 
            label_group.AutoSize = true;
            label_group.Location = new Point(100, 41);
            label_group.Margin = new Padding(6, 0, 6, 0);
            label_group.Name = "label_group";
            label_group.Size = new Size(80, 32);
            label_group.TabIndex = 12;
            label_group.Text = "Group";
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1405, 1372);
            Controls.Add(label_group);
            Controls.Add(label_group_static);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(scheduleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Розклад";
            Load += ScheduleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label scheduleLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label_group_static;
        private Label label_group;
    }
}
