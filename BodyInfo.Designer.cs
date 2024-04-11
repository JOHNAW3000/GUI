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
            positionlabel = new Label();
            velocitylabel = new Label();
            primarycolourlabel = new Label();
            secondarycolourlabel = new Label();
            masstextbox = new TextBox();
            positiontextbox = new TextBox();
            velocitytextbox = new TextBox();
            primarytextbox = new TextBox();
            secondarytextbox = new TextBox();
            updatebtn = new Button();
            removebtn = new Button();
            iconlabel = new Label();
            SuspendLayout();
            // 
            // nametextbox
            // 
            nametextbox.Location = new Point(118, 10);
            nametextbox.Name = "nametextbox";
            nametextbox.Size = new Size(164, 23);
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
            masslabel.Size = new Size(58, 15);
            masslabel.TabIndex = 2;
            masslabel.Text = "Mass: /kg";
            // 
            // positionlabel
            // 
            positionlabel.AutoSize = true;
            positionlabel.Location = new Point(9, 68);
            positionlabel.Name = "positionlabel";
            positionlabel.Size = new Size(84, 15);
            positionlabel.TabIndex = 3;
            positionlabel.Text = "Orbital Radius:";
            // 
            // velocitylabel
            // 
            velocitylabel.AutoSize = true;
            velocitylabel.Location = new Point(9, 96);
            velocitylabel.Name = "velocitylabel";
            velocitylabel.Size = new Size(51, 15);
            velocitylabel.TabIndex = 4;
            velocitylabel.Text = "Velocity:";
            // 
            // primarycolourlabel
            // 
            primarycolourlabel.AutoSize = true;
            primarycolourlabel.Location = new Point(8, 121);
            primarycolourlabel.Name = "primarycolourlabel";
            primarycolourlabel.Size = new Size(90, 15);
            primarycolourlabel.TabIndex = 5;
            primarycolourlabel.Text = "Primary Colour:";
            // 
            // secondarycolourlabel
            // 
            secondarycolourlabel.AutoSize = true;
            secondarycolourlabel.Location = new Point(8, 146);
            secondarycolourlabel.Name = "secondarycolourlabel";
            secondarycolourlabel.Size = new Size(104, 15);
            secondarycolourlabel.TabIndex = 6;
            secondarycolourlabel.Text = "Secondary Colour:";
            // 
            // masstextbox
            // 
            masstextbox.Location = new Point(118, 39);
            masstextbox.Name = "masstextbox";
            masstextbox.Size = new Size(164, 23);
            masstextbox.TabIndex = 7;
            // 
            // positiontextbox
            // 
            positiontextbox.Location = new Point(118, 65);
            positiontextbox.Name = "positiontextbox";
            positiontextbox.Size = new Size(164, 23);
            positiontextbox.TabIndex = 8;
            // 
            // velocitytextbox
            // 
            velocitytextbox.Location = new Point(118, 93);
            velocitytextbox.Name = "velocitytextbox";
            velocitytextbox.Size = new Size(164, 23);
            velocitytextbox.TabIndex = 9;
            // 
            // primarytextbox
            // 
            primarytextbox.Location = new Point(118, 118);
            primarytextbox.Name = "primarytextbox";
            primarytextbox.Size = new Size(164, 23);
            primarytextbox.TabIndex = 10;
            primarytextbox.TextChanged += primarytextbox_TextChanged;
            // 
            // secondarytextbox
            // 
            secondarytextbox.Location = new Point(118, 143);
            secondarytextbox.Name = "secondarytextbox";
            secondarytextbox.Size = new Size(164, 23);
            secondarytextbox.TabIndex = 11;
            secondarytextbox.TextChanged += secondarytextbox_TextChanged;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(98, 180);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(75, 23);
            updatebtn.TabIndex = 12;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = true;
            updatebtn.Click += updatebtn_Click;
            // 
            // removebtn
            // 
            removebtn.Location = new Point(194, 178);
            removebtn.Name = "removebtn";
            removebtn.Size = new Size(75, 23);
            removebtn.TabIndex = 13;
            removebtn.Text = "Remove";
            removebtn.UseVisualStyleBackColor = true;
            removebtn.Click += removebtn_Click;
            // 
            // iconlabel
            // 
            iconlabel.AutoSize = true;
            iconlabel.Location = new Point(6, 180);
            iconlabel.Name = "iconlabel";
            iconlabel.Size = new Size(33, 15);
            iconlabel.TabIndex = 14;
            iconlabel.Text = "Icon:";
            // 
            // BodyInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 213);
            Controls.Add(iconlabel);
            Controls.Add(removebtn);
            Controls.Add(updatebtn);
            Controls.Add(secondarytextbox);
            Controls.Add(primarytextbox);
            Controls.Add(velocitytextbox);
            Controls.Add(positiontextbox);
            Controls.Add(masstextbox);
            Controls.Add(secondarycolourlabel);
            Controls.Add(primarycolourlabel);
            Controls.Add(velocitylabel);
            Controls.Add(positionlabel);
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
        private Label positionlabel;
        private Label velocitylabel;
        private Label primarycolourlabel;
        private Label secondarycolourlabel;
        private TextBox masstextbox;
        private TextBox positiontextbox;
        private TextBox velocitytextbox;
        private TextBox primarytextbox;
        private TextBox secondarytextbox;
        private Button updatebtn;
        private Button removebtn;
        private Label iconlabel;
    }
}