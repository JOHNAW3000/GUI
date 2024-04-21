using System.Drawing;

namespace GUI
{
    public partial class BodyInfo : Form
    {
        // Properties
        private Body body;
        private SimulationDisplay form;

        // Constructor
        public BodyInfo(Body b, SimulationDisplay form)
        {
            InitializeComponent();

            this.body = b;
            this.form = form;
            // initialises text boxes with current values
            nametextbox.Text = b.Name;
            masstextbox.Text = b.Mass.ToString();
            positiontextbox.Text = b.Position.Modulus().ToString();
            velocitytextbox.Text = b.Velocity.Modulus().ToString();
            primarytextbox.Text = b.Colours.Primary.Name;
            secondarytextbox.Text = b.Colours.Secondary.Name;

            this.Paint += new PaintEventHandler(this.BodyInfo_Paint);
        }

        private void BodyInfo_Paint(object sender, PaintEventArgs e)
        {
            DrawPlanetIcon();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            Body newbody = CreateBody();
            // from testing
            /*if (body.Position.Modulus() == 0)
            {
                newbody.Position = new Vector(0, 0);
            }
            if (body.Velocity.Modulus() == 0)
            {
                newbody.Velocity = new Vector(0, 0);
            }*/
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
            if (Color.FromName(primarytextbox.Text).IsKnownColor && Color.FromName(secondarytextbox.Text).IsKnownColor)
            {
                newbody.Colours = new Appearance(Color.FromName(primarytextbox.Text), Color.FromName(secondarytextbox.Text));
            }
            else
            {
                newbody.Colours = body.Colours;
            }
            newbody.IsStar = body.IsStar;

            return newbody;
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            form.RemoveBody(body);
            this.Close();
        }

        private void DrawPlanetIcon()
        {
            Graphics g = CreateGraphics();

            Pen p = new Pen(Color.FromName(primarytextbox.Text), 5);
            Brush b = new SolidBrush(Color.FromName(secondarytextbox.Text));

            int size = 20;

            g.FillEllipse(b, 45, 180, size, size);
            g.DrawEllipse(p, 45, 180, size, size);
        }

        private void primarytextbox_TextChanged(object sender, EventArgs e)
        {
            DrawPlanetIcon();
        }

        private void secondarytextbox_TextChanged(object sender, EventArgs e)
        {
            DrawPlanetIcon();
        }
    }
}
