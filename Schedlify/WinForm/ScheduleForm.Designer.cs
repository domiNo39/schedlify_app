using Schedlify.Controllers;
using System.Windows.Forms;
using Schedlify.Global;
using Schedlify.Models;
using Schedlify.Utils;

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
        private void InitializeTable(List<TemplateSlot> slots, AssignmentController assignmentController, DateOnly date) 
        {
            int rowsNum = slots.Count;

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
            
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++) 
            {

                List<Models.Assignment> assignmentsList = assignmentController.GetByGroupIdAndDate(UserSession.currentGroup.Id, date.AddDays(col));
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    //if (assignmentsList.Count >= row + 1)
                    //{
                    //    Assignment assignment = new Assignment(assignmentsList[row]);
                    //    TemplateSlot filterSlot = slots.FirstOrDefault(s => s.StartTime == assignmentsList[row].StartTime);
                    //    if (filterSlot != null) { 
                    //        tableLayoutPanel1.Controls.Add(assignment, col, filterSlot.ClassNumber); // Додаємо текст у комірку
                    //    }
                        
                    //}
                    if (assignmentsList.FirstOrDefault(p => p.StartTime == slots[row].StartTime) != null)
                    {
                        Assignment assignment = new Assignment(assignmentsList.FirstOrDefault(p => p.StartTime == slots[row].StartTime));
                        tableLayoutPanel1.Controls.Add(assignment, col, row);
                    }
                    else
                    {
                        if (UserSession.currentUser is not null)
                        {
                            tableLayoutPanel1.Controls.Add(new AddAssignment(date.AddDays(col), row), col, row);
                        }
                        else
                        {
                            tableLayoutPanel1.Controls.Add(new BlankAssignment(), col, row);
                        }
                    }


                    //tableLayoutPanel1.Controls.Add(label, col, row); // Додаємо текст у комірку
                }
            }
            panel1.Controls.Add(tableLayoutPanel1);
        }
        private void InitializeComponent()
        {
            scheduleLabel = new Label();
            label_group_static = new Label();
            label_group = new Label();
            panel1 = new Panel();
            weekSelector1 = new WeekSelector();
            logoutBtn = new Button();
            changeClassesBtn = new Button();
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
            // label_group_static
            // 
            label_group_static.AutoSize = true;
            label_group_static.Location = new Point(169, 37);
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
            label_group.Location = new Point(260, 37);
            label_group.Margin = new Padding(6, 0, 6, 0);
            label_group.Name = "label_group";
            label_group.Size = new Size(80, 32);
            label_group.TabIndex = 12;
            label_group.Text = "Group";
            // 
            // panel1
            // 
            panel1.Location = new Point(22, 182);
            panel1.Name = "panel1";
            panel1.Size = new Size(1548, 1160);
            panel1.TabIndex = 14;
            // 
            // weekSelector1
            // 
            weekSelector1.Location = new Point(1106, 30);
            weekSelector1.Margin = new Padding(6, 6, 6, 6);
            weekSelector1.Name = "weekSelector1";
            weekSelector1.Size = new Size(274, 54);
            weekSelector1.dateTimePicker1.ValueChanged += changeSchedule_ValueChanged;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(22, 30);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(111, 46);
            logoutBtn.TabIndex = 16;
            logoutBtn.Text = "Вийти";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += LogoutBtn_Click;
            // 
            // changeClassesBtn
            // 
            changeClassesBtn.Location = new Point(1409, 37);
            changeClassesBtn.Name = "changeClassesBtn";
            changeClassesBtn.Size = new Size(150, 46);
            changeClassesBtn.TabIndex = 17;
            changeClassesBtn.Text = "Предмети";
            changeClassesBtn.UseVisualStyleBackColor = true;
            changeClassesBtn.Click += ChangeClassesBtn_Click;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1600, 1360);
            if (UserSession.currentUser is not null)
            {
                Controls.Add(changeClassesBtn);
            }
            Controls.Add(logoutBtn);
            Controls.Add(weekSelector1);
            Controls.Add(panel1);
            Controls.Add(label_group);
            Controls.Add(label_group_static);
            Controls.Add(scheduleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Schedlify";
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
        private Panel panel1;
        private WeekSelector weekSelector1;
        private Button logoutBtn;
        private Button changeClassesBtn;
    }
}
