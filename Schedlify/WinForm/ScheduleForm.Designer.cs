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
            scheduleLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel7 = new FlowLayoutPanel();
            flowLayoutPanel8 = new FlowLayoutPanel();
            flowLayoutPanel9 = new FlowLayoutPanel();
            flowLayoutPanel10 = new FlowLayoutPanel();
            flowLayoutPanel11 = new FlowLayoutPanel();
            flowLayoutPanel12 = new FlowLayoutPanel();
            flowLayoutPanel13 = new FlowLayoutPanel();
            flowLayoutPanel14 = new FlowLayoutPanel();
            flowLayoutPanel15 = new FlowLayoutPanel();
            flowLayoutPanel16 = new FlowLayoutPanel();
            flowLayoutPanel17 = new FlowLayoutPanel();
            flowLayoutPanel18 = new FlowLayoutPanel();
            flowLayoutPanel19 = new FlowLayoutPanel();
            flowLayoutPanel20 = new FlowLayoutPanel();
            flowLayoutPanel21 = new FlowLayoutPanel();
            flowLayoutPanel22 = new FlowLayoutPanel();
            flowLayoutPanel23 = new FlowLayoutPanel();
            flowLayoutPanel24 = new FlowLayoutPanel();
            flowLayoutPanel25 = new FlowLayoutPanel();
            flowLayoutPanel26 = new FlowLayoutPanel();
            flowLayoutPanel27 = new FlowLayoutPanel();
            flowLayoutPanel28 = new FlowLayoutPanel();
            flowLayoutPanel29 = new FlowLayoutPanel();
            flowLayoutPanel30 = new FlowLayoutPanel();
            flowLayoutPanel31 = new FlowLayoutPanel();
            flowLayoutPanel32 = new FlowLayoutPanel();
            flowLayoutPanel33 = new FlowLayoutPanel();
            flowLayoutPanel34 = new FlowLayoutPanel();
            flowLayoutPanel35 = new FlowLayoutPanel();
            flowLayoutPanel36 = new FlowLayoutPanel();
            flowLayoutPanel37 = new FlowLayoutPanel();
            label_group_static = new Label();
            label_group = new Label();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // scheduleLabel
            // 
            scheduleLabel.AutoSize = true;
            scheduleLabel.Font = new Font("Myanmar Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scheduleLabel.Location = new Point(313, 9);
            scheduleLabel.Name = "scheduleLabel";
            scheduleLabel.Size = new Size(121, 37);
            scheduleLabel.TabIndex = 0;
            scheduleLabel.Text = "Розклад";
            scheduleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel7);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel10);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel11);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel12);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel13);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel14);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel15);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel16);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel17);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel18);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel19);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel20);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel21);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel22);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel23);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel24);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel25);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel27);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel26);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel28);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel29);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel30);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel31);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel32);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel33);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel34);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel35);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel36);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel37);
            flowLayoutPanel1.Location = new Point(12, 87);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(734, 544);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(28, 67);
            label1.Name = "label1";
            label1.Size = new Size(82, 17);
            label1.TabIndex = 2;
            label1.Text = "ПОНЕДІЛОК";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(161, 67);
            label2.Name = "label2";
            label2.Size = new Size(67, 17);
            label2.TabIndex = 3;
            label2.Text = "ВІВТОРОК";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(288, 67);
            label3.Name = "label3";
            label3.Size = new Size(54, 17);
            label3.TabIndex = 4;
            label3.Text = "СЕРЕДА";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(411, 67);
            label4.Name = "label4";
            label4.Size = new Size(52, 17);
            label4.TabIndex = 5;
            label4.Text = "ЧЕТВЕР";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(529, 67);
            label5.Name = "label5";
            label5.Size = new Size(72, 17);
            label5.TabIndex = 6;
            label5.Text = "П'ЯТНИЦЯ";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(656, 67);
            label6.Name = "label6";
            label6.Size = new Size(55, 17);
            label6.TabIndex = 7;
            label6.Text = "СУБОТА";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(125, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(116, 84);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Location = new Point(247, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(116, 84);
            flowLayoutPanel3.TabIndex = 1;
            flowLayoutPanel3.Paint += flowLayoutPanel3_Paint;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(369, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(116, 84);
            flowLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Location = new Point(491, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(116, 84);
            flowLayoutPanel5.TabIndex = 3;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Location = new Point(613, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(116, 84);
            flowLayoutPanel6.TabIndex = 4;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Location = new Point(3, 93);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(116, 84);
            flowLayoutPanel7.TabIndex = 5;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Location = new Point(3, 3);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(116, 84);
            flowLayoutPanel8.TabIndex = 1;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Location = new Point(247, 93);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(116, 84);
            flowLayoutPanel9.TabIndex = 6;
            // 
            // flowLayoutPanel10
            // 
            flowLayoutPanel10.Location = new Point(125, 93);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new Size(116, 84);
            flowLayoutPanel10.TabIndex = 7;
            // 
            // flowLayoutPanel11
            // 
            flowLayoutPanel11.Location = new Point(369, 93);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            flowLayoutPanel11.Size = new Size(116, 84);
            flowLayoutPanel11.TabIndex = 8;
            // 
            // flowLayoutPanel12
            // 
            flowLayoutPanel12.Location = new Point(491, 93);
            flowLayoutPanel12.Name = "flowLayoutPanel12";
            flowLayoutPanel12.Size = new Size(116, 84);
            flowLayoutPanel12.TabIndex = 9;
            // 
            // flowLayoutPanel13
            // 
            flowLayoutPanel13.Location = new Point(613, 93);
            flowLayoutPanel13.Name = "flowLayoutPanel13";
            flowLayoutPanel13.Size = new Size(116, 84);
            flowLayoutPanel13.TabIndex = 10;
            // 
            // flowLayoutPanel14
            // 
            flowLayoutPanel14.Location = new Point(3, 183);
            flowLayoutPanel14.Name = "flowLayoutPanel14";
            flowLayoutPanel14.Size = new Size(116, 84);
            flowLayoutPanel14.TabIndex = 6;
            // 
            // flowLayoutPanel15
            // 
            flowLayoutPanel15.Location = new Point(125, 183);
            flowLayoutPanel15.Name = "flowLayoutPanel15";
            flowLayoutPanel15.Size = new Size(116, 84);
            flowLayoutPanel15.TabIndex = 7;
            // 
            // flowLayoutPanel16
            // 
            flowLayoutPanel16.Location = new Point(247, 183);
            flowLayoutPanel16.Name = "flowLayoutPanel16";
            flowLayoutPanel16.Size = new Size(116, 84);
            flowLayoutPanel16.TabIndex = 8;
            // 
            // flowLayoutPanel17
            // 
            flowLayoutPanel17.Location = new Point(369, 183);
            flowLayoutPanel17.Name = "flowLayoutPanel17";
            flowLayoutPanel17.Size = new Size(116, 84);
            flowLayoutPanel17.TabIndex = 9;
            // 
            // flowLayoutPanel18
            // 
            flowLayoutPanel18.Location = new Point(491, 183);
            flowLayoutPanel18.Name = "flowLayoutPanel18";
            flowLayoutPanel18.Size = new Size(116, 84);
            flowLayoutPanel18.TabIndex = 9;
            // 
            // flowLayoutPanel19
            // 
            flowLayoutPanel19.Location = new Point(613, 183);
            flowLayoutPanel19.Name = "flowLayoutPanel19";
            flowLayoutPanel19.Size = new Size(116, 84);
            flowLayoutPanel19.TabIndex = 10;
            // 
            // flowLayoutPanel20
            // 
            flowLayoutPanel20.Location = new Point(3, 273);
            flowLayoutPanel20.Name = "flowLayoutPanel20";
            flowLayoutPanel20.Size = new Size(116, 84);
            flowLayoutPanel20.TabIndex = 7;
            // 
            // flowLayoutPanel21
            // 
            flowLayoutPanel21.Location = new Point(125, 273);
            flowLayoutPanel21.Name = "flowLayoutPanel21";
            flowLayoutPanel21.Size = new Size(116, 84);
            flowLayoutPanel21.TabIndex = 8;
            // 
            // flowLayoutPanel22
            // 
            flowLayoutPanel22.Location = new Point(247, 273);
            flowLayoutPanel22.Name = "flowLayoutPanel22";
            flowLayoutPanel22.Size = new Size(116, 84);
            flowLayoutPanel22.TabIndex = 8;
            // 
            // flowLayoutPanel23
            // 
            flowLayoutPanel23.Location = new Point(369, 273);
            flowLayoutPanel23.Name = "flowLayoutPanel23";
            flowLayoutPanel23.Size = new Size(116, 84);
            flowLayoutPanel23.TabIndex = 8;
            // 
            // flowLayoutPanel24
            // 
            flowLayoutPanel24.Location = new Point(491, 273);
            flowLayoutPanel24.Name = "flowLayoutPanel24";
            flowLayoutPanel24.Size = new Size(116, 84);
            flowLayoutPanel24.TabIndex = 8;
            // 
            // flowLayoutPanel25
            // 
            flowLayoutPanel25.Location = new Point(613, 273);
            flowLayoutPanel25.Name = "flowLayoutPanel25";
            flowLayoutPanel25.Size = new Size(116, 84);
            flowLayoutPanel25.TabIndex = 8;
            // 
            // flowLayoutPanel26
            // 
            flowLayoutPanel26.Location = new Point(125, 363);
            flowLayoutPanel26.Name = "flowLayoutPanel26";
            flowLayoutPanel26.Size = new Size(116, 84);
            flowLayoutPanel26.TabIndex = 8;
            // 
            // flowLayoutPanel27
            // 
            flowLayoutPanel27.Location = new Point(3, 363);
            flowLayoutPanel27.Name = "flowLayoutPanel27";
            flowLayoutPanel27.Size = new Size(116, 84);
            flowLayoutPanel27.TabIndex = 9;
            // 
            // flowLayoutPanel28
            // 
            flowLayoutPanel28.Location = new Point(247, 363);
            flowLayoutPanel28.Name = "flowLayoutPanel28";
            flowLayoutPanel28.Size = new Size(116, 84);
            flowLayoutPanel28.TabIndex = 9;
            // 
            // flowLayoutPanel29
            // 
            flowLayoutPanel29.Location = new Point(369, 363);
            flowLayoutPanel29.Name = "flowLayoutPanel29";
            flowLayoutPanel29.Size = new Size(116, 84);
            flowLayoutPanel29.TabIndex = 9;
            // 
            // flowLayoutPanel30
            // 
            flowLayoutPanel30.Location = new Point(491, 363);
            flowLayoutPanel30.Name = "flowLayoutPanel30";
            flowLayoutPanel30.Size = new Size(116, 84);
            flowLayoutPanel30.TabIndex = 9;
            // 
            // flowLayoutPanel31
            // 
            flowLayoutPanel31.Location = new Point(613, 363);
            flowLayoutPanel31.Name = "flowLayoutPanel31";
            flowLayoutPanel31.Size = new Size(116, 84);
            flowLayoutPanel31.TabIndex = 9;
            // 
            // flowLayoutPanel32
            // 
            flowLayoutPanel32.Location = new Point(3, 453);
            flowLayoutPanel32.Name = "flowLayoutPanel32";
            flowLayoutPanel32.Size = new Size(116, 84);
            flowLayoutPanel32.TabIndex = 10;
            // 
            // flowLayoutPanel33
            // 
            flowLayoutPanel33.Location = new Point(125, 453);
            flowLayoutPanel33.Name = "flowLayoutPanel33";
            flowLayoutPanel33.Size = new Size(116, 84);
            flowLayoutPanel33.TabIndex = 11;
            // 
            // flowLayoutPanel34
            // 
            flowLayoutPanel34.Location = new Point(247, 453);
            flowLayoutPanel34.Name = "flowLayoutPanel34";
            flowLayoutPanel34.Size = new Size(116, 84);
            flowLayoutPanel34.TabIndex = 11;
            // 
            // flowLayoutPanel35
            // 
            flowLayoutPanel35.Location = new Point(369, 453);
            flowLayoutPanel35.Name = "flowLayoutPanel35";
            flowLayoutPanel35.Size = new Size(116, 84);
            flowLayoutPanel35.TabIndex = 11;
            // 
            // flowLayoutPanel36
            // 
            flowLayoutPanel36.Location = new Point(491, 453);
            flowLayoutPanel36.Name = "flowLayoutPanel36";
            flowLayoutPanel36.Size = new Size(116, 84);
            flowLayoutPanel36.TabIndex = 11;
            // 
            // flowLayoutPanel37
            // 
            flowLayoutPanel37.Location = new Point(613, 453);
            flowLayoutPanel37.Name = "flowLayoutPanel37";
            flowLayoutPanel37.Size = new Size(116, 84);
            flowLayoutPanel37.TabIndex = 11;
            // 
            // label_group_static
            // 
            label_group_static.AutoSize = true;
            label_group_static.Location = new Point(12, 19);
            label_group_static.Name = "label_group_static";
            label_group_static.Size = new Size(45, 15);
            label_group_static.TabIndex = 8;
            label_group_static.Text = "Група: ";
            label_group_static.Click += label7_Click;
            // 
            // label_group
            // 
            label_group.AutoSize = true;
            label_group.Location = new Point(54, 19);
            label_group.Name = "label_group";
            label_group.Size = new Size(40, 15);
            label_group.TabIndex = 12;
            label_group.Text = "Group";
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(757, 643);
            Controls.Add(label_group);
            Controls.Add(label_group_static);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(scheduleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Розклад";
            Load += ScheduleForm_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label scheduleLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel7;
        private FlowLayoutPanel flowLayoutPanel8;
        private FlowLayoutPanel flowLayoutPanel10;
        private FlowLayoutPanel flowLayoutPanel9;
        private FlowLayoutPanel flowLayoutPanel11;
        private FlowLayoutPanel flowLayoutPanel12;
        private FlowLayoutPanel flowLayoutPanel13;
        private FlowLayoutPanel flowLayoutPanel14;
        private FlowLayoutPanel flowLayoutPanel15;
        private FlowLayoutPanel flowLayoutPanel16;
        private FlowLayoutPanel flowLayoutPanel17;
        private FlowLayoutPanel flowLayoutPanel18;
        private FlowLayoutPanel flowLayoutPanel19;
        private FlowLayoutPanel flowLayoutPanel20;
        private FlowLayoutPanel flowLayoutPanel21;
        private FlowLayoutPanel flowLayoutPanel22;
        private FlowLayoutPanel flowLayoutPanel23;
        private FlowLayoutPanel flowLayoutPanel24;
        private FlowLayoutPanel flowLayoutPanel25;
        private FlowLayoutPanel flowLayoutPanel26;
        private FlowLayoutPanel flowLayoutPanel27;
        private FlowLayoutPanel flowLayoutPanel28;
        private FlowLayoutPanel flowLayoutPanel29;
        private FlowLayoutPanel flowLayoutPanel30;
        private FlowLayoutPanel flowLayoutPanel31;
        private FlowLayoutPanel flowLayoutPanel32;
        private FlowLayoutPanel flowLayoutPanel33;
        private FlowLayoutPanel flowLayoutPanel34;
        private FlowLayoutPanel flowLayoutPanel35;
        private FlowLayoutPanel flowLayoutPanel36;
        private FlowLayoutPanel flowLayoutPanel37;
        private Label label_group_static;
        private Label label_group;
    }
}
