namespace Schedlify.WinForm
{
    partial class Assignment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(Models.Assignment assignment)
        {
            startTime = new Label();
            className = new Label();
            classType = new Label();
            roomNumber = new Label();
            lecturer = new Label();
            address = new Label();
            SuspendLayout();
            // 
            // startTime
            // 
            startTime.AutoSize = true;
            startTime.Location = new Point(307, 14);
            startTime.Name = "startTime";
            startTime.Size = new Size(58, 32);
            startTime.TabIndex = 0;
            startTime.Text = assignment.StartTime.ToShortTimeString();
            //startTime.Click += this.label1_Click;
            // 
            // className
            // 
            className.AutoSize = true;
            className.Font = new Font("Segoe UI", 12F);
            className.Location = new Point(18, 14);
            className.Name = "className";
            className.Size = new Size(226, 51);
            className.TabIndex = 1;
            className.Text = assignment.Class.Name;
            //className.Click += this.label2_Click;
            // 
            // classType
            // 
            classType.AutoSize = true;
            classType.Location = new Point(18, 83);
            classType.Name = "classType";
            classType.Size = new Size(84, 32);
            classType.TabIndex = 2;
            classType.Text = assignment.ClassType.ToString();
            // 
            // roomNumber
            // 
            roomNumber.AutoSize = true;
            roomNumber.Location = new Point(131, 83);
            roomNumber.Name = "roomNumber";
            roomNumber.Size = new Size(103, 32);
            roomNumber.TabIndex = 3;
            roomNumber.Text = assignment.RoomNumber + ".авд";
            // 
            // lecturer
            // 
            lecturer.AutoSize = true;
            lecturer.Location = new Point(18, 217);
            lecturer.Name = "lecturer";
            lecturer.Size = new Size(197, 32);
            lecturer.TabIndex = 4;
            lecturer.Text = assignment.Lecturer;
            // 
            // address
            // 
            address.AutoSize = true;
            address.Location = new Point(24, 146);
            address.Name = "address";
            address.Size = new Size(263, 32);
            address.TabIndex = 5;
            address.Text = assignment.Address;
            // 
            // Assignment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(address);
            Controls.Add(lecturer);
            Controls.Add(roomNumber);
            Controls.Add(classType);
            Controls.Add(className);
            Controls.Add(startTime);
            Name = "Assignment";
            Size = new Size(256, 190);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label startTime;
        private Label className;
        private Label classType;
        private Label roomNumber;
        private Label lecturer;
        private Label address;
    }
}
