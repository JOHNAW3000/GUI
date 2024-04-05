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

        private Body selectedbody;

        private BodyInfo selectedbodyinfo;

        public SimulationDisplay()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            coordcon = new CoordinateConverter(this.Width, this.Height);

            g = this.CreateGraphics();

            this.MouseClick += new MouseEventHandler(OnMouseClick);
        }

        public Body SelectedBody
        {
            get { return selectedbody; }
            set { selectedbody = value; }
        }

        private List<Vector> GetPositions(AdjacencyMatrix matrix)
        {
            List<Vector> positions = new List<Vector>();
            foreach (Body b in matrix.GetBodies())
            {
                positions.Add(b.Position);
            }
            return positions;
        }

        public void DrawStep(List<Body> bodies)
        {
            Bitmap buffer = new Bitmap(this.Width, this.Height);
            Graphics buffer_g = Graphics.FromImage(buffer);
            buffer_g.Clear(Color.Black);

            int size = 20;
            List<Vector> positions = GetPositions(sim.PlanetarySystem);
            List<Vector> coordinates = coordcon.ConvertCoords(positions, uselog);


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
                buffer_g.DrawLine(arrow, startx, starty, endx, endy);
                buffer_g.FillEllipse(b, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
                buffer_g.DrawEllipse(p, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
            }

            if (selectedbody != null)
            {
                int highlightsize = size + 10;
                Vector selectedbodycoord = coordcon.ConvertCoords(new List<Vector>()
                { selectedbody.Position }, uselog)[0];

                Pen select = new Pen(Color.White, 3);
                buffer_g.DrawEllipse(select, (float)selectedbodycoord.X - (highlightsize / 2), (float)selectedbodycoord.Y - (highlightsize / 2), highlightsize, highlightsize);
            }


            g.DrawImage(buffer, 0, 0);
        }
        private void ReplaceSimulation(SystemSimulation simulation)
        {
            sim = simulation;
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
                    this.DrawStep(sim.PlanetarySystem.GetBodies());

                    await Running();
                }
            }


        }

        private async Task Running()
        {
            int timestep = 3600 * 24;
            DateTime lastupdated = DateTime.Now;

            while (running)
            {
                double timesincelastupdate = (DateTime.Now - lastupdated).TotalMilliseconds;

                if (timesincelastupdate >= (1000 / 60))
                {
                    this.DrawStep(sim.PlanetarySystem.GetBodies());
                    lastupdated = DateTime.Now;
                }
                await Task.Run(() =>
                {
                    sim.Step(timestep);


                });
                DateTime datetime = sim.Date;
                DateAndTimeLabel.Text = datetime.ToString("yyyy-MM-dd");
            }
        }

        private void getLiveSolarSystemBtn_Click(object sender, EventArgs e)
        {

            sim = GetLiveSolarSystem();

            DateAndTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            idiotbox.Text = "Loaded Successfully";

            //sim.Run(1, 1, g, this, UpdateUI, uselog, coordcon);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load simulation

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
            DrawStep(sim.PlanetarySystem.GetBodies());
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


            BodyInfo file = new BodyInfo(selectedbody, this);
            file.Show();

        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            selectedbody = null;
            if (sim != null)
            {
                List<Vector> coordinates = coordcon.ConvertCoords(GetPositions(sim.PlanetarySystem), uselog);

                Vector mouseposition = new Vector(e.X, e.Y);

                int selectedbodyindex = 0;
                foreach (Vector coord in coordinates)
                {
                    int size = 20;

                    if (mouseposition.VectorTo(coord).Modulus() <= size)
                    {
                        selectedbody = sim.PlanetarySystem.GetBodies()[selectedbodyindex];

                        DrawStep(sim.PlanetarySystem.GetBodies());

                        if (selectedbodyinfo != null)
                        {
                           if (selectedbodyinfo.Visible == true)
                            {
                                selectedbodyinfo.Close();
                            }
                        }
                        selectedbodyinfo = new BodyInfo(selectedbody, this);
                        selectedbodyinfo.Show();
                        break;
                    }
                    selectedbodyindex++;
                }
            }
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
