namespace GUI
{
    partial class Sim1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sim1));
            menuStrip1 = new MenuStrip();
            FileMenu = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            getLiveSolarSystemBtn = new ToolStripMenuItem();
            RunBtn = new ToolStripMenuItem();
            DateAndTimeLabel = new Label();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileMenu, RunBtn });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            FileMenu.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, getLiveSolarSystemBtn });
            FileMenu.Name = "FileMenu";
            FileMenu.Size = new Size(37, 20);
            FileMenu.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(186, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(186, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // getLiveSolarSystemBtn
            // 
            getLiveSolarSystemBtn.Name = "getLiveSolarSystemBtn";
            getLiveSolarSystemBtn.Size = new Size(186, 22);
            getLiveSolarSystemBtn.Text = "Get Live Solar System";
            getLiveSolarSystemBtn.Click += getLiveSolarSystemBtn_Click;
            // 
            // RunBtn
            // 
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(37, 20);
            RunBtn.Text = "Go!";
            RunBtn.Click += RunBtn_Click;
            // 
            // DateAndTimeLabel
            // 
            DateAndTimeLabel.AutoSize = true;
            DateAndTimeLabel.Location = new Point(8, 31);
            DateAndTimeLabel.Name = "DateAndTimeLabel";
            DateAndTimeLabel.Size = new Size(190, 15);
            DateAndTimeLabel.TabIndex = 2;
            DateAndTimeLabel.Text = "Currently outside space and time...";
            // 
            // Sim1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(984, 961);
            Controls.Add(DateAndTimeLabel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Sim1";
            Text = "Simulation - 1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileMenu;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem RunBtn;
        private ToolStripMenuItem getLiveSolarSystemBtn;
        private Label DateAndTimeLabel;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}
