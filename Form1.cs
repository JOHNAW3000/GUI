using System.Windows.Forms;
using static GUI.Program;


namespace GUI
{
    public partial class SimulationDisplay : Form
    {

        private CoordinateConverter coordcon;

        private SystemSimulation sim;

        private Graphics g;

        private bool running = false;

        private bool uselog = true;

        public SimulationDisplay()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //blit

            coordcon = new CoordinateConverter(this.Width, this.Height);

            g = this.CreateGraphics();

        }

        public void DrawStep(List<Body> bodies)
        {
            int size = 20;

            List<Vector> coordinates;
            if (uselog)
            {
                coordinates = coordcon.ConvertCoordsLog(sim.PlanetarySystem);
            }
            else
            {
                coordinates = coordcon.ConvertCoordsScalar(sim.PlanetarySystem, 0.000001);
            }

            this.Invalidate();


            for (int bodyindex = 0; bodyindex < bodies.Count; bodyindex++)
            {


                Vector pos = coordinates[bodyindex];
                Appearance colours = bodies[bodyindex].Colours;
                Pen p = new Pen(colours.Primary, 5);
                Brush b = new SolidBrush(colours.Secondary);
                Pen arrow = new Pen(colours.Secondary, 3);


                Vector velocity = bodies[bodyindex].Velocity;
                float startx = (float)pos.X;
                float starty = (float)pos.Y;
                float endx = (float)pos.Add(velocity).X;
                float endy = (float)pos.Add(velocity).Y;
                g.DrawLine(arrow, startx, starty, endx, endy);
                g.FillEllipse(b, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
                g.DrawEllipse(p, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
            }
        }
        public void UpdateLabel(string newdate)
        {
            BeginInvoke(new Action(() => { DateAndTimeLabel.Text = newdate; }));
        }

        public DateTime GetDate()
        {
            return Convert.ToDateTime(DateAndTimeLabel.Text);
        }
        private async void RunBtn_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                if (sim == null)
                {
                    idiotbox.Text = "No simulation loaded!!!";
                }
                else
                {
                    idiotbox.Text = "All Clear";
                    running = true;

                    await Running();
                }
            }


        }

        private async Task Running()
        {
            int timestep = 3600 * 24;
            while (running)
            {
                await Task.Run(() =>
                {
                    sim.Step(timestep);
                    this.DrawStep(sim.PlanetarySystem.GetBodies());
                    DateTime datetime = this.GetDate();
                    datetime = datetime.AddSeconds(timestep);
                    this.UpdateLabel(datetime.ToString("yyyy-MM-dd"));
                });
            }
        }

        private void UpdateUI(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
        }

        private void getLiveSolarSystemBtn_Click(object sender, EventArgs e)
        {
            Bodies.Items.Clear();

            sim = GetLiveSolarSystem();

            DateAndTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            idiotbox.Text = "Loaded Successfully";

            //sim.Run(1, 1, g, this, UpdateUI, uselog, coordcon);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load simulation
            Bodies.Items.Clear();

            string path;
            openFileDialog1.ShowDialog(this);
            path = openFileDialog1.FileName;
            if (path != null & path != "")
            {
                try
                {
                    sim = LoadSimulation(path);
                }
                catch (Exception ex)
                {
                    idiotbox.Text = "Invalid simulation file!!!";
                }




                DateAndTimeLabel.Text = sim.Date.ToString("yyyy-MM-dd");

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sim == null)
            {
                idiotbox.Text = "No simulation to save!!!";
            }
            else
            {
                string path;
                saveFileDialog1.ShowDialog(this);
                path = saveFileDialog1.FileName;

                if (path != null & path != "")
                {
                    SaveSimulation(sim, path);
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            running = false;
        }

        private void logarithmicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uselog = true;
        }

        private void linearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uselog = false;
        }

        private void Bodies_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Body> bodies = sim.PlanetarySystem.GetBodies();
            Body selectedbody = null;
            foreach (Body b in bodies)
            {
                if (b.Name == Bodies.SelectedItem.ToString())
                {
                    selectedbody = b;
                }
            }

            BodyInfo file = new BodyInfo(selectedbody, this);
            file.Show();

        }

        public void UpdateBody(Body oldbody, Body newbody)
        {
            List<Body> bodies = sim.PlanetarySystem.GetBodies();
            int index = 0;
            int i = 0;
            foreach (Body b in bodies)
            {
                if (b == oldbody)
                {
                    index = i;
                }
                i++;
            }
            sim.PlanetarySystem.ReplaceBody(newbody, index);
        }

    }
}
