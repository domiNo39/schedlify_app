using System.Windows.Forms;

namespace Schedlify.WinForm
{
    partial class UniDepGroupFormUser
    {
        private ComboBox universityComboBox;
        private ComboBox departmentComboBox;
        private ComboBox groupComboBox;
        private Label universityLabel;
        private Label departmentLabel;
        private Label groupLabel;
        private Button continueButton;

        private void InitializeComponent()
        {
            universityComboBox = new ComboBox();
            departmentComboBox = new ComboBox();
            groupComboBox = new ComboBox();
            universityLabel = new Label();
            departmentLabel = new Label();
            groupLabel = new Label();
            continueButton = new Button();
            // 
            // universityComboBox
            // 
            universityComboBox.Font = new Font("Segoe UI", 10F);
            universityComboBox.FormattingEnabled = true;
            universityComboBox.Location = new Point(200, 60);
            universityComboBox.Width = 300;
            universityComboBox.SelectedIndexChanged += universityComboBox_SelectedIndexChanged;
            // 
            // departmentComboBox
            // 
            departmentComboBox.Font = new Font("Segoe UI", 10F);
            departmentComboBox.FormattingEnabled = true;
            departmentComboBox.Location = new Point(200, 140);
            departmentComboBox.Width = 300;
            departmentComboBox.SelectedIndexChanged += departmentComboBox_SelectedIndexChanged;
            // 
            // groupComboBox
            // 
            groupComboBox.Font = new Font("Segoe UI", 10F);
            groupComboBox.FormattingEnabled = true;
            groupComboBox.Location = new Point(200, 220);
            groupComboBox.Width = 300;
            // 
            // universityLabel
            // 
            universityLabel.AutoSize = true;
            universityLabel.Font = new Font("Segoe UI", 10F);
            universityLabel.Location = new Point(80, 60);
            universityLabel.Text = "Університет";
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Font = new Font("Segoe UI", 10F);
            departmentLabel.Location = new Point(80, 140);
            departmentLabel.Text = "Факультет";
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Segoe UI", 10F);
            groupLabel.Location = new Point(80, 220);
            groupLabel.Text = "Група";
            // 
            // continueButton
            // 
            continueButton.Font = new Font("Segoe UI", 10F);
            continueButton.Location = new Point(250, 300);
            continueButton.Text = "Продовжити";
            continueButton.Click += confirmSelectionButton_Click;
            // 
            // UniDepGroupForm
            // 
            ClientSize = new Size(600, 400);
            Controls.Add(universityComboBox);
            Controls.Add(departmentComboBox);
            Controls.Add(groupComboBox);
            Controls.Add(universityLabel);
            Controls.Add(departmentLabel);
            Controls.Add(groupLabel);
            Controls.Add(continueButton);
            Text = "Вибір університету, факультету та групи";
        }
    }
}
