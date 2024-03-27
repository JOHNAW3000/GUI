﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class BodyInfo : Form
    {
        private Body body;
        private Sim1 form;
        public BodyInfo(Body b, Sim1 form)
        {
            InitializeComponent();
            this.body = b;
            this.form = form;
            nametextbox.Text = b.Name;
            masstextbox.Text = b.Mass.ToString();
            radiustextbox.Text = b.Radius.ToString();
            velocitytextbox.Text = b.Velocity.Modulus().ToString();
            primarytextbox.Text = b.Colours.Primary.Name;
            secondarytextbox.Text = b.Colours.Secondary.Name;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            Body newbody = this.CreateBody();
            form.UpdateBody(body, newbody);
            this.Close();
        }

        private Body CreateBody()
        {
            Vector newvel = body.Velocity.Unit();
            newvel = newvel.Scale(Convert.ToDouble(velocitytextbox.Text));
            Body newbody = new Body(nametextbox.Text, body.ID, Convert.ToDouble(masstextbox.Text), Convert.ToDouble(radiustextbox.Text), body.Position, newvel);
            newbody.Colours = new Appearance(Color.FromName(primarytextbox.Text), Color.FromName(secondarytextbox.Text));
            return newbody;
        }
    }
}
