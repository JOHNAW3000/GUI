namespace GUI
{
    partial class BodyCreationForm
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
            createbtn = new Button();
            secondarytextbox = new TextBox();
            primarytextbox = new TextBox();
            velocityxtextbox = new TextBox();
            masstextbox = new TextBox();
            secondarycolourlabel = new Label();
            primarycolourlabel = new Label();
            velocityxlabel = new Label();
            positionlabel = new Label();
            masslabel = new Label();
            namelabel = new Label();
            nametextbox = new TextBox();
            positionxlabel = new Label();
            positionylabel = new Label();
            positionxtextbox = new TextBox();
            positionytextbox = new TextBox();
            velocityylabel = new Label();
            velocityytextbox = new TextBox();
            velocitylabel = new Label();
            label1 = new Label();
            radiustextbox = new TextBox();
            SuspendLayout();
            // 
            // createbtn
            // 
            createbtn.Location = new Point(100, 288);
            createbtn.Name = "createbtn";
            createbtn.Size = new Size(75, 23);
            createbtn.TabIndex = 25;
            createbtn.Text = "Create";
            createbtn.UseVisualStyleBackColor = true;
            createbtn.Click += createbtn_Click;
            // 
            // secondarytextbox
            // 
            secondarytextbox.Location = new Point(122, 261);
            secondarytextbox.Name = "secondarytextbox";
            secondarytextbox.Size = new Size(164, 23);
            secondarytextbox.TabIndex = 24;
            // 
            // primarytextbox
            // 
            primarytextbox.Location = new Point(122, 236);
            primarytextbox.Name = "primarytextbox";
            primarytextbox.Size = new Size(164, 23);
            primarytextbox.TabIndex = 23;
            // 
            // velocityxtextbox
            // 
            velocityxtextbox.Location = new Point(122, 152);
            velocityxtextbox.Name = "velocityxtextbox";
            velocityxtextbox.Size = new Size(164, 23);
            velocityxtextbox.TabIndex = 22;
            velocityxtextbox.TextChanged += velocityxtextbox_TextChanged;
            // 
            // masstextbox
            // 
            masstextbox.Location = new Point(121, 33);
            masstextbox.Name = "masstextbox";
            masstextbox.Size = new Size(164, 23);
            masstextbox.TabIndex = 20;
            // 
            // secondarycolourlabel
            // 
            secondarycolourlabel.AutoSize = true;
            secondarycolourlabel.Location = new Point(12, 264);
            secondarycolourlabel.Name = "secondarycolourlabel";
            secondarycolourlabel.Size = new Size(104, 15);
            secondarycolourlabel.TabIndex = 19;
            secondarycolourlabel.Text = "Secondary Colour:";
            // 
            // primarycolourlabel
            // 
            primarycolourlabel.AutoSize = true;
            primarycolourlabel.Location = new Point(12, 239);
            primarycolourlabel.Name = "primarycolourlabel";
            primarycolourlabel.Size = new Size(90, 15);
            primarycolourlabel.TabIndex = 18;
            primarycolourlabel.Text = "Primary Colour:";
            // 
            // velocityxlabel
            // 
            velocityxlabel.AutoSize = true;
            velocityxlabel.Location = new Point(12, 160);
            velocityxlabel.Name = "velocityxlabel";
            velocityxlabel.Size = new Size(69, 15);
            velocityxlabel.TabIndex = 17;
            velocityxlabel.Text = "Velocity - X:";
            // 
            // positionlabel
            // 
            positionlabel.AutoSize = true;
            positionlabel.Location = new Point(12, 136);
            positionlabel.Name = "positionlabel";
            positionlabel.Size = new Size(84, 15);
            positionlabel.TabIndex = 16;
            positionlabel.Text = "Orbital Radius:";
            // 
            // masslabel
            // 
            masslabel.AutoSize = true;
            masslabel.Location = new Point(12, 37);
            masslabel.Name = "masslabel";
            masslabel.Size = new Size(58, 15);
            masslabel.TabIndex = 15;
            masslabel.Text = "Mass: /kg";
            // 
            // namelabel
            // 
            namelabel.AutoSize = true;
            namelabel.Location = new Point(12, 9);
            namelabel.Name = "namelabel";
            namelabel.Size = new Size(42, 15);
            namelabel.TabIndex = 14;
            namelabel.Text = "Name:";
            // 
            // nametextbox
            // 
            nametextbox.Location = new Point(121, 6);
            nametextbox.Name = "nametextbox";
            nametextbox.Size = new Size(164, 23);
            nametextbox.TabIndex = 13;
            // 
            // positionxlabel
            // 
            positionxlabel.AutoSize = true;
            positionxlabel.Location = new Point(12, 86);
            positionxlabel.Name = "positionxlabel";
            positionxlabel.Size = new Size(71, 15);
            positionxlabel.TabIndex = 26;
            positionxlabel.Text = "Position - X:";
            // 
            // positionylabel
            // 
            positionylabel.AutoSize = true;
            positionylabel.Location = new Point(12, 111);
            positionylabel.Name = "positionylabel";
            positionylabel.Size = new Size(71, 15);
            positionylabel.TabIndex = 27;
            positionylabel.Text = "Position - Y:";
            // 
            // positionxtextbox
            // 
            positionxtextbox.Location = new Point(122, 85);
            positionxtextbox.Name = "positionxtextbox";
            positionxtextbox.Size = new Size(164, 23);
            positionxtextbox.TabIndex = 28;
            positionxtextbox.TextChanged += positionxtextbox_TextChanged;
            // 
            // positionytextbox
            // 
            positionytextbox.Location = new Point(122, 111);
            positionytextbox.Name = "positionytextbox";
            positionytextbox.Size = new Size(164, 23);
            positionytextbox.TabIndex = 29;
            positionytextbox.TextChanged += positionytextbox_TextChanged;
            // 
            // velocityylabel
            // 
            velocityylabel.AutoSize = true;
            velocityylabel.Location = new Point(12, 184);
            velocityylabel.Name = "velocityylabel";
            velocityylabel.Size = new Size(69, 15);
            velocityylabel.TabIndex = 30;
            velocityylabel.Text = "Velocity - Y:";
            // 
            // velocityytextbox
            // 
            velocityytextbox.Location = new Point(122, 181);
            velocityytextbox.Name = "velocityytextbox";
            velocityytextbox.Size = new Size(164, 23);
            velocityytextbox.TabIndex = 31;
            velocityytextbox.TextChanged += velocityytextbox_TextChanged;
            // 
            // velocitylabel
            // 
            velocitylabel.AutoSize = true;
            velocitylabel.Location = new Point(12, 207);
            velocitylabel.Name = "velocitylabel";
            velocitylabel.Size = new Size(42, 15);
            velocitylabel.TabIndex = 32;
            velocitylabel.Text = "Speed:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 33;
            label1.Text = "Radius:";
            // 
            // radiustextbox
            // 
            radiustextbox.Location = new Point(121, 59);
            radiustextbox.Name = "radiustextbox";
            radiustextbox.Size = new Size(164, 23);
            radiustextbox.TabIndex = 34;
            // 
            // BodyCreationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 317);
            Controls.Add(radiustextbox);
            Controls.Add(label1);
            Controls.Add(velocitylabel);
            Controls.Add(velocityytextbox);
            Controls.Add(velocityylabel);
            Controls.Add(positionytextbox);
            Controls.Add(positionxtextbox);
            Controls.Add(positionylabel);
            Controls.Add(positionxlabel);
            Controls.Add(createbtn);
            Controls.Add(secondarytextbox);
            Controls.Add(primarytextbox);
            Controls.Add(velocityxtextbox);
            Controls.Add(masstextbox);
            Controls.Add(secondarycolourlabel);
            Controls.Add(primarycolourlabel);
            Controls.Add(velocityxlabel);
            Controls.Add(positionlabel);
            Controls.Add(masslabel);
            Controls.Add(namelabel);
            Controls.Add(nametextbox);
            Name = "BodyCreationForm";
            Text = "BodyCreationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createbtn;
        private TextBox secondarytextbox;
        private TextBox primarytextbox;
        private TextBox velocityxtextbox;
        private TextBox masstextbox;
        private Label secondarycolourlabel;
        private Label primarycolourlabel;
        private Label velocityxlabel;
        private Label positionlabel;
        private Label masslabel;
        private Label namelabel;
        private TextBox nametextbox;
        private Label positionxlabel;
        private Label positionylabel;
        private TextBox positionxtextbox;
        private TextBox positionytextbox;
        private Label velocityylabel;
        private TextBox velocityytextbox;
        private Label velocitylabel;
        private Label label1;
        private TextBox radiustextbox;
    }
}