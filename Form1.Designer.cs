namespace GUI
{
    partial class SimulationDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationDisplay));
            menuStrip1 = new MenuStrip();
            FileMenu = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            getLiveSolarSystemBtn = new ToolStripMenuItem();
            RunBtn = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            scaleTypeToolStripMenuItem = new ToolStripMenuItem();
            logarithmicToolStripMenuItem = new ToolStripMenuItem();
            linearToolStripMenuItem = new ToolStripMenuItem();
            DateAndTimeLabel = new Label();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            idiotbox = new Label();
            Bodies = new ListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileMenu, RunBtn, stopToolStripMenuItem, scaleTypeToolStripMenuItem });
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
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(46, 20);
            stopToolStripMenuItem.Text = "Stop!";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // scaleTypeToolStripMenuItem
            // 
            scaleTypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logarithmicToolStripMenuItem, linearToolStripMenuItem });
            scaleTypeToolStripMenuItem.Name = "scaleTypeToolStripMenuItem";
            scaleTypeToolStripMenuItem.Size = new Size(73, 20);
            scaleTypeToolStripMenuItem.Text = "Scale Type";
            // 
            // logarithmicToolStripMenuItem
            // 
            logarithmicToolStripMenuItem.Name = "logarithmicToolStripMenuItem";
            logarithmicToolStripMenuItem.Size = new Size(138, 22);
            logarithmicToolStripMenuItem.Text = "Logarithmic";
            logarithmicToolStripMenuItem.Click += logarithmicToolStripMenuItem_Click;
            // 
            // linearToolStripMenuItem
            // 
            linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            linearToolStripMenuItem.Size = new Size(138, 22);
            linearToolStripMenuItem.Text = "Linear";
            linearToolStripMenuItem.Click += linearToolStripMenuItem_Click;
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
            // idiotbox
            // 
            idiotbox.AutoSize = true;
            idiotbox.Location = new Point(8, 58);
            idiotbox.Name = "idiotbox";
            idiotbox.Size = new Size(190, 15);
            idiotbox.TabIndex = 3;
            idiotbox.Text = "You haven't broken anything, yet...";
            // 
            // Bodies
            // 
            Bodies.FormattingEnabled = true;
            Bodies.ItemHeight = 15;
            Bodies.Location = new Point(8, 82);
            Bodies.Name = "Bodies";
            Bodies.Size = new Size(190, 49);
            Bodies.TabIndex = 4;
            Bodies.SelectedIndexChanged += Bodies_SelectedIndexChanged;
            // 
            // Sim1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(984, 961);
            Controls.Add(Bodies);
            Controls.Add(idiotbox);
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
        private Label idiotbox;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem scaleTypeToolStripMenuItem;
        private ToolStripMenuItem logarithmicToolStripMenuItem;
        private ToolStripMenuItem linearToolStripMenuItem;
        private ListBox Bodies;
    }
}
