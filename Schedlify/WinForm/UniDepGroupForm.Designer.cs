using System.Windows.Forms;

namespace Schedlify.WinForm
{
    partial class UniDepGroupForm
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
            this.universityComboBox = new ComboBox();
            this.departmentComboBox = new ComboBox();
            this.groupComboBox = new ComboBox();
            this.universityLabel = new Label();
            this.departmentLabel = new Label();
            this.groupLabel = new Label();
            this.continueButton = new Button();

            // 
            // universityComboBox
            // 
            this.universityComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.universityComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.universityComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.universityComboBox.FormattingEnabled = true;
            this.universityComboBox.Location = new System.Drawing.Point(200, 60);
            this.universityComboBox.Width = 300;

            // 
            // departmentComboBox
            // 
            this.departmentComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.departmentComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.departmentComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(200, 140);
            this.departmentComboBox.Width = 300;

            // 
            // groupComboBox
            // 
            this.groupComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.groupComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.groupComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(200, 220);
            this.groupComboBox.Width = 300;

            // 
            // universityLabel
            // 
            this.universityLabel.AutoSize = true;
            this.universityLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.universityLabel.Location = new System.Drawing.Point(80, 60);
            this.universityLabel.Text = "Університет";

            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.departmentLabel.Location = new System.Drawing.Point(80, 140);
            this.departmentLabel.Text = "Факультет";

            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupLabel.Location = new System.Drawing.Point(80, 220);
            this.groupLabel.Text = "Група";

            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.continueButton.Location = new System.Drawing.Point(250, 300);
            this.continueButton.Text = "Продовжити";
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);

            // 
            // UniDepGroupForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.universityComboBox);
            this.Controls.Add(this.departmentComboBox);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.universityLabel);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.groupLabel);
            this.Controls.Add(this.continueButton);
            this.Text = "Вибір університету, факультету та групи";
        }
    }
}
