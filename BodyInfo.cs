namespace GUI
{
    public partial class BodyInfo : Form
    {
        private Body body;
        private SimulationDisplay form;
        public BodyInfo(Body b, SimulationDisplay form)
        {
            InitializeComponent();
            this.body = b;
            this.form = form;
            nametextbox.Text = b.Name;
            masstextbox.Text = b.Mass.ToString();
            positiontextbox.Text = b.Position.Modulus().ToString();
            velocitytextbox.Text = b.Velocity.Modulus().ToString();
            primarytextbox.Text = b.Colours.Primary.Name;
            secondarytextbox.Text = b.Colours.Secondary.Name;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            Body newbody = CreateBody();
            if (body.Position.Modulus() == 0)
            {
                newbody.Position = new Vector(0, 0);
            }
            if (body.Velocity.Modulus() == 0)
            {
                newbody.Velocity = new Vector(0, 0);
            }
            form.UpdateBody(body, newbody);
            this.Close();
        }

        private Body CreateBody()
        {
            Vector newvel = body.Velocity.Unit();
            newvel = newvel.Scale(Convert.ToDouble(velocitytextbox.Text));

            Vector newpos = body.Position.Unit();
            newpos = newpos.Scale(Convert.ToDouble(positiontextbox.Text));

            Body newbody = new Body(nametextbox.Text, body.ID, Convert.ToDouble(masstextbox.Text), body.Radius, newpos, newvel);
            newbody.Colours = new Appearance(Color.FromName(primarytextbox.Text), Color.FromName(secondarytextbox.Text));
            newbody.IsStar = body.IsStar;

            return newbody;
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            form.RemoveBody(body);
            this.Close();
        }
    }
}
