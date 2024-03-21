namespace GUI
{
    partial class BodyInfo
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
            nametextbox = new TextBox();
            namelabel = new Label();
            masslabel = new Label();
            radiuslabel = new Label();
            velocitylabel = new Label();
            primarycolourlabel = new Label();
            secondarycolourlabel = new Label();
            masstextbox = new TextBox();
            radiustextbox = new TextBox();
            velocitytextbox = new TextBox();
            primarytextbox = new TextBox();
            secondarytextbox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // nametextbox
            // 
            nametextbox.Location = new Point(118, 10);
            nametextbox.Name = "nametextbox";
            nametextbox.Size = new Size(100, 23);
            nametextbox.TabIndex = 0;
            // 
            // namelabel
            // 
            namelabel.AutoSize = true;
            namelabel.Location = new Point(9, 13);
            namelabel.Name = "namelabel";
            namelabel.Size = new Size(42, 15);
            namelabel.TabIndex = 1;
            namelabel.Text = "Name:";
            // 
            // masslabel
            // 
            masslabel.AutoSize = true;
            masslabel.Location = new Point(9, 41);
            masslabel.Name = "masslabel";
            masslabel.Size = new Size(37, 15);
            masslabel.TabIndex = 2;
            masslabel.Text = "Mass:";
            // 
            // radiuslabel
            // 
            radiuslabel.AutoSize = true;
            radiuslabel.Location = new Point(9, 68);
            radiuslabel.Name = "radiuslabel";
            radiuslabel.Size = new Size(45, 15);
            radiuslabel.TabIndex = 3;
            radiuslabel.Text = "Radius:";
            // 
            // velocitylabel
            // 
            velocitylabel.AutoSize = true;
            velocitylabel.Location = new Point(9, 95);
            velocitylabel.Name = "velocitylabel";
            velocitylabel.Size = new Size(51, 15);
            velocitylabel.TabIndex = 4;
            velocitylabel.Text = "Velocity:";
            // 
            // primarycolourlabel
            // 
            primarycolourlabel.AutoSize = true;
            primarycolourlabel.Location = new Point(8, 120);
            primarycolourlabel.Name = "primarycolourlabel";
            primarycolourlabel.Size = new Size(90, 15);
            primarycolourlabel.TabIndex = 5;
            primarycolourlabel.Text = "Primary Colour:";
            // 
            // secondarycolourlabel
            // 
            secondarycolourlabel.AutoSize = true;
            secondarycolourlabel.Location = new Point(8, 145);
            secondarycolourlabel.Name = "secondarycolourlabel";
            secondarycolourlabel.Size = new Size(104, 15);
            secondarycolourlabel.TabIndex = 6;
            secondarycolourlabel.Text = "Secondary Colour:";
            // 
            // masstextbox
            // 
            masstextbox.Location = new Point(118, 39);
            masstextbox.Name = "masstextbox";
            masstextbox.Size = new Size(100, 23);
            masstextbox.TabIndex = 7;
            // 
            // radiustextbox
            // 
            radiustextbox.Location = new Point(118, 65);
            radiustextbox.Name = "radiustextbox";
            radiustextbox.Size = new Size(100, 23);
            radiustextbox.TabIndex = 8;
            // 
            // velocitytextbox
            // 
            velocitytextbox.Location = new Point(118, 92);
            velocitytextbox.Name = "velocitytextbox";
            velocitytextbox.Size = new Size(100, 23);
            velocitytextbox.TabIndex = 9;
            // 
            // primarytextbox
            // 
            primarytextbox.Location = new Point(118, 117);
            primarytextbox.Name = "primarytextbox";
            primarytextbox.Size = new Size(100, 23);
            primarytextbox.TabIndex = 10;
            // 
            // secondarytextbox
            // 
            secondarytextbox.Location = new Point(118, 142);
            secondarytextbox.Name = "secondarytextbox";
            secondarytextbox.Size = new Size(100, 23);
            secondarytextbox.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(98, 179);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // BodyInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 214);
            Controls.Add(button1);
            Controls.Add(secondarytextbox);
            Controls.Add(primarytextbox);
            Controls.Add(velocitytextbox);
            Controls.Add(radiustextbox);
            Controls.Add(masstextbox);
            Controls.Add(secondarycolourlabel);
            Controls.Add(primarycolourlabel);
            Controls.Add(velocitylabel);
            Controls.Add(radiuslabel);
            Controls.Add(masslabel);
            Controls.Add(namelabel);
            Controls.Add(nametextbox);
            Name = "BodyInfo";
            Text = "BodyInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nametextbox;
        private Label namelabel;
        private Label masslabel;
        private Label radiuslabel;
        private Label velocitylabel;
        private Label primarycolourlabel;
        private Label secondarycolourlabel;
        private TextBox masstextbox;
        private TextBox radiustextbox;
        private TextBox velocitytextbox;
        private TextBox primarytextbox;
        private TextBox secondarytextbox;
        private Button button1;
    }
}