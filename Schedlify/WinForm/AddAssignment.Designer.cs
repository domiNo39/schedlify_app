namespace Schedlify.WinForm
{
    partial class AddAssignment
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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            постійнаПараToolStripMenuItem = new ToolStripMenuItem();
            разВДваТижніToolStripMenuItem = new ToolStripMenuItem();
            цьогоТижняToolStripMenuItem = new ToolStripMenuItem();
            наступногоТижняToolStripMenuItem = new ToolStripMenuItem();
            одноразоваToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(132, 84);
            button1.TabIndex = 0;
            button1.Text = "Додати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCreateAssignment_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { постійнаПараToolStripMenuItem, разВДваТижніToolStripMenuItem, одноразоваToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(167, 70);
            // 
            // постійнаПараToolStripMenuItem
            // 
            постійнаПараToolStripMenuItem.Name = "постійнаПараToolStripMenuItem";
            постійнаПараToolStripMenuItem.Size = new Size(166, 22);
            постійнаПараToolStripMenuItem.Text = "постійна пара";
            постійнаПараToolStripMenuItem.Click += постійнаПараToolStripMenuItem_Click;
            // 
            // разВДваТижніToolStripMenuItem
            // 
            разВДваТижніToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { цьогоТижняToolStripMenuItem, наступногоТижняToolStripMenuItem });
            разВДваТижніToolStripMenuItem.Name = "разВДваТижніToolStripMenuItem";
            разВДваТижніToolStripMenuItem.Size = new Size(166, 22);
            разВДваТижніToolStripMenuItem.Text = "періодична пара";
            разВДваТижніToolStripMenuItem.Click += разВДваТижніToolStripMenuItem_Click;
            // 
            // цьогоТижняToolStripMenuItem
            // 
            цьогоТижняToolStripMenuItem.Name = "цьогоТижняToolStripMenuItem";
            цьогоТижняToolStripMenuItem.Size = new Size(174, 22);
            цьогоТижняToolStripMenuItem.Text = "цього тижня";
            цьогоТижняToolStripMenuItem.Click += ЦьогоТижняToolStripMenuItem_Click;
            // 
            // наступногоТижняToolStripMenuItem
            // 
            наступногоТижняToolStripMenuItem.Name = "наступногоТижняToolStripMenuItem";
            наступногоТижняToolStripMenuItem.Size = new Size(174, 22);
            наступногоТижняToolStripMenuItem.Text = "наступного тижня";
            наступногоТижняToolStripMenuItem.Click += НаступногоТижняToolStripMenuItem_Click;
            // 
            // одноразоваToolStripMenuItem
            // 
            одноразоваToolStripMenuItem.Name = "одноразоваToolStripMenuItem";
            одноразоваToolStripMenuItem.Size = new Size(166, 22);
            одноразоваToolStripMenuItem.Text = "одноразова";
            одноразоваToolStripMenuItem.Click += ОдноразоваToolStripMenuItem_Click;
            // 
            // AddAssignment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "AddAssignment";
            Size = new Size(138, 89);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem постійнаПараToolStripMenuItem;
        private ToolStripMenuItem разВДваТижніToolStripMenuItem;
        private ToolStripMenuItem одноразоваToolStripMenuItem;
        private ToolStripMenuItem цьогоТижняToolStripMenuItem;
        private ToolStripMenuItem наступногоТижняToolStripMenuItem;
    }
}
