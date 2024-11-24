using System.Windows.Forms;

namespace Schedlify.WinForm
{
    partial class CreateAssignment
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox classesComboBox;
        private Label classesLabel;
        private Button btnEditClasses;

        private ComboBox slotsComboBox;
        private Label slotsLabel;
        private Button btnEditSlots;

        private Label lblLecturer;
        private TextBox txtLecturer;

        private GroupBox groupClassType;
        private RadioButton rbtnLecture;
        private RadioButton rbtnPractical;

        private GroupBox groupMode;
        private RadioButton rbtnInPerson;
        private RadioButton rbtnRemote;

        private Label lblAddress;
        private TextBox txtAddress;

        private Label lblRoomNumber;
        private TextBox txtRoomNumber;

        private Button btnSave;
        private Button btnCancel;

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
            this.classesComboBox = new ComboBox();
            this.classesLabel = new Label();
            this.btnEditClasses = new Button();

            this.slotsComboBox = new ComboBox();
            this.slotsLabel = new Label();
            this.btnEditSlots = new System.Windows.Forms.Button();

            this.components = new System.ComponentModel.Container();

            this.lblLecturer = new System.Windows.Forms.Label();
            this.txtLecturer = new System.Windows.Forms.TextBox();

            this.groupClassType = new System.Windows.Forms.GroupBox();
            this.rbtnLecture = new System.Windows.Forms.RadioButton();
            this.rbtnPractical = new System.Windows.Forms.RadioButton();

            this.groupMode = new System.Windows.Forms.GroupBox();
            this.rbtnInPerson = new System.Windows.Forms.RadioButton();
            this.rbtnRemote = new System.Windows.Forms.RadioButton();

            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // 
            // lblClass
            // 
            this.classesLabel.AutoSize = true;
            this.classesLabel.Location = new System.Drawing.Point(20, 20);
            this.classesLabel.Name = "classesLabel";
            this.classesLabel.Size = new System.Drawing.Size(80, 20);
            this.classesLabel.Text = "Предмет:";

            // 
            // classesComboBox
            // 
            this.classesComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.classesComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.classesComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.classesComboBox.FormattingEnabled = true;
            this.classesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classesComboBox.Location = new System.Drawing.Point(150, 20);
            this.classesComboBox.Name = "classesComboBox";
            this.classesComboBox.Size = new System.Drawing.Size(200, 28);

            // 
            // btnEditClasses
            // 
            this.btnEditClasses.Location = new System.Drawing.Point(360, 20);
            this.btnEditClasses.Name = "btnEditClasses";
            this.btnEditClasses.Size = new System.Drawing.Size(150, 28);
            this.btnEditClasses.Text = "Редагувати предмети";
            this.btnEditClasses.Click += new System.EventHandler(this.btnEditClasses_Click);

            // 
            // lblSlot
            // 
            this.slotsLabel.AutoSize = true;
            this.slotsLabel.Location = new System.Drawing.Point(20, 60);
            this.slotsLabel.Name = "lblSlot";
            this.slotsLabel.Size = new System.Drawing.Size(80, 20);
            this.slotsLabel.Text = "Часовий слот:";

            // 
            // cmbSlot
            // 
            this.slotsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slotsComboBox.Location = new System.Drawing.Point(150, 60);
            this.slotsComboBox.Name = "cmbSlot";
            this.slotsComboBox.Size = new System.Drawing.Size(200, 28);

            // 
            // btnEditSlots
            // 
            this.btnEditSlots.Location = new System.Drawing.Point(360, 60);
            this.btnEditSlots.Name = "btnEditSlots";
            this.btnEditSlots.Size = new System.Drawing.Size(150, 28);
            this.btnEditSlots.Text = "Редагувати слоти";
            this.btnEditSlots.Click += new System.EventHandler(this.btnEditSlots_Click);

            // 
            // lblLecturer
            // 
            this.lblLecturer.AutoSize = true;
            this.lblLecturer.Location = new System.Drawing.Point(20, 100);
            this.lblLecturer.Name = "lblLecturer";
            this.lblLecturer.Size = new System.Drawing.Size(80, 20);
            this.lblLecturer.Text = "Викладач:";

            // 
            // txtLecturer
            // 
            this.txtLecturer.Location = new System.Drawing.Point(150, 100);
            this.txtLecturer.Name = "txtLecturer";
            this.txtLecturer.Size = new System.Drawing.Size(200, 28);

            // 
            // groupClassType
            // 
            this.groupClassType.Controls.Add(this.rbtnLecture);
            this.groupClassType.Controls.Add(this.rbtnPractical);
            this.groupClassType.Location = new System.Drawing.Point(20, 140);
            this.groupClassType.Name = "groupClassType";
            this.groupClassType.Size = new System.Drawing.Size(490, 60);
            this.groupClassType.Text = "Тип заняття";

            // 
            // rbtnLecture
            // 
            this.rbtnLecture.AutoSize = true;
            this.rbtnLecture.Location = new System.Drawing.Point(10, 25);
            this.rbtnLecture.Name = "rbtnLecture";
            this.rbtnLecture.Size = new System.Drawing.Size(80, 24);
            this.rbtnLecture.Text = "Лекція";
            this.rbtnLecture.Checked = true;

            // 
            // rbtnPractical
            // 
            this.rbtnPractical.AutoSize = true;
            this.rbtnPractical.Location = new System.Drawing.Point(150, 25);
            this.rbtnPractical.Name = "rbtnPractical";
            this.rbtnPractical.Size = new System.Drawing.Size(100, 24);
            this.rbtnPractical.Text = "Практична";

            // 
            // groupMode
            // 
            this.groupMode.Controls.Add(this.rbtnInPerson);
            this.groupMode.Controls.Add(this.rbtnRemote);
            this.groupMode.Location = new System.Drawing.Point(20, 210);
            this.groupMode.Name = "groupMode";
            this.groupMode.Size = new System.Drawing.Size(490, 60);
            this.groupMode.Text = "Формат";

            // 
            // rbtnInPerson
            // 
            this.rbtnInPerson.AutoSize = true;
            this.rbtnInPerson.Location = new System.Drawing.Point(10, 25);
            this.rbtnInPerson.Name = "rbtnInPerson";
            this.rbtnInPerson.Size = new System.Drawing.Size(60, 24);
            this.rbtnInPerson.Text = "Очно";

            // 
            // rbtnRemote
            // 
            this.rbtnRemote.AutoSize = true;
            this.rbtnRemote.Location = new System.Drawing.Point(150, 25);
            this.rbtnRemote.Name = "rbtnRemote";
            this.rbtnRemote.Size = new System.Drawing.Size(100, 24);
            this.rbtnRemote.Text = "Дистанційно";
            this.rbtnRemote.Checked = true;

            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 290);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 20);
            this.lblAddress.Text = "Адреса:";

            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(150, 290);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 28);

            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Location = new System.Drawing.Point(20, 330);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(100, 20);
            this.lblRoomNumber.Text = "Номер аудиторії:";

            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(150, 330);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(200, 28);

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(50, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Зберегти";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.Click += (s, e) => this.Close();

            // 
            // CreateAssignment
            // 
            this.ClientSize = new System.Drawing.Size(380, 450);
            this.Controls.Add(this.classesLabel);
            this.Controls.Add(this.classesComboBox);
            this.Controls.Add(this.slotsLabel);
            this.Controls.Add(this.slotsComboBox);
            this.Controls.Add(this.lblLecturer);
            this.Controls.Add(this.txtLecturer);
            this.Controls.Add(this.groupClassType);
            this.Controls.Add(this.groupMode);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Створення заняття";
        }
    }
}
