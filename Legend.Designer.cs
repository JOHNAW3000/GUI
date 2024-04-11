namespace GUI
{
    partial class Legend
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            legendlist = new ListBox();
            titlelabel = new Label();
            SuspendLayout();
            // 
            // legendlist
            // 
            legendlist.FormattingEnabled = true;
            legendlist.ItemHeight = 15;
            legendlist.Location = new Point(17, 27);
            legendlist.Name = "legendlist";
            legendlist.Size = new Size(208, 379);
            legendlist.TabIndex = 0;
            legendlist.SelectedIndexChanged += legendlist_SelectedIndexChanged;
            // 
            // titlelabel
            // 
            titlelabel.AutoSize = true;
            titlelabel.Location = new Point(17, 9);
            titlelabel.Name = "titlelabel";
            titlelabel.Size = new Size(89, 15);
            titlelabel.TabIndex = 1;
            titlelabel.Text = "Celestial Bodies";
            // 
            // Legend
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 429);
            Controls.Add(titlelabel);
            Controls.Add(legendlist);
            Name = "Legend";
            Text = "Legend";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox legendlist;
        private Label titlelabel;
    }
}