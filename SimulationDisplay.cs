using System.Diagnostics;
using static GUI.Program;


namespace GUI
{
    public partial class SimulationDisplay : Form
    {

        private CoordinateConverter coordcon;

        private SystemSimulation sim;

        private Graphics g;
        private Bitmap buffer;

        private bool running = false;

        private bool uselog = true;

        private Body selectedbody;

        private BodyInfo selectedbodyinfo;

        private Legend legend;

        private int zoomlevel;

        private int timesteplevel;

        public SimulationDisplay()
        {
            InitializeComponent();
            zoomlevel = 3;
            timesteplevel = 4;

            g = CreateGraphics();
            buffer = new Bitmap(Width, Height);


            coordcon = new CoordinateConverter(Width, Height);
            sim = GetLiveSolarSystem();
            DateAndTimeLabel.Text = sim.Date.ToString("yyyy-MM-dd");



            MouseClick += new MouseEventHandler(OnMouseClick);
            MouseWheel += new MouseEventHandler(OnMouseWheel);

            Paint += new PaintEventHandler(SimulationDisplay_Paint);
        }

        private void SimulationDisplay_Paint(object sender, PaintEventArgs e)
        {
            DrawPlanets(sim.GetBodies());
        }

        public Body SelectedBody
        {
            get { return selectedbody; }
            set { selectedbody = value; }
        }

        private List<Vector> GetPositions(List<Body> bodies)
        {
            List<Vector> positions = new List<Vector>();
            foreach (Body b in bodies)
            {
                positions.Add(b.Position);
            }
            return positions;
        }

        /// <summary>
        /// Draws the bodies in a system, and highlights the selected body, if any
        /// </summary>
        /// <param name="bodies"></param>
        public void DrawPlanets(List<Body> bodies)
        {
            // Creates an off screen buffer
            Graphics buffer_g = Graphics.FromImage(buffer);
            buffer_g.Clear(Color.Black);

            // Planet diameter
            int size = 20;

            List<Vector> positions = GetPositions(bodies);
            List<Vector> coordinates = coordcon.ConvertCoords(positions, uselog, zoomlevel);


            for (int bodyindex = 0; bodyindex < bodies.Count; bodyindex++)
            {
                Body body = bodies[bodyindex];

                Vector pos = coordinates[bodyindex];
                Appearance colours = body.Colours;
                Pen p = new Pen(colours.Primary, 5);
                Brush b = new SolidBrush(colours.Secondary);
                Pen arrowPen = new Pen(colours.Secondary, 3);

                //Draws velocity arrow
                Vector velocity = body.Velocity;
                float startx = (float)pos.X;
                float starty = (float)pos.Y;
                float endx = (float)pos.Add(velocity).X;
                float endy = (float)pos.Add(velocity).Y;

                // try-catch in case the simulation is so zoomed in that the body is off the buffer
                try
                {
                    buffer_g.DrawLine(arrowPen, startx, starty, endx, endy);

                    buffer_g.FillEllipse(b, startx - (size / 2), starty - (size / 2), size, size);
                    buffer_g.DrawEllipse(p, startx - (size / 2), starty - (size / 2), size, size);
                }
                catch { }
            }

            if (selectedbody != null)
            {
                int highlightsize = size + 10;
                Vector selectedbodycoord = coordcon.ConvertCoords(new List<Vector>()
                { selectedbody.Position }, uselog, zoomlevel)[0];

                Pen selectedbodyPen = new Pen(Color.White, 3);

                //selectedbody.Orbit.Data();
                //OrbitPath ellipse = coordcon.ConvertOrbit(selectedbody.Orbit, uselog, zoomlevel);

                //double minoraxislength = Math.Sqrt(ellipse.Aphelion.Modulus() * ellipse.Perihelion.Modulus());

                //Vector centralbody = new Vector(Width / 2, Height / 2);

                //selectedbodycoord.Data();
                //ellipse.Data();

                //float ellipsex = (float)(centralbody.X - minoraxislength);
                //float ellipsey = (float)(centralbody.Y - ellipse.Perihelion.Modulus());

                //float ellipsex = (float)centralbody.X;
                //float ellipsey = (float)centralbody.Y ;

                //Debug.WriteLine($"aphelion mod: {ellipse.Aphelion.Modulus()}");
                //Debug.WriteLine($"x:{ellipsex}, y:{ellipsey}");


                try
                {
                    buffer_g.DrawEllipse(selectedbodyPen, (float)selectedbodycoord.X - (highlightsize / 2), (float)selectedbodycoord.Y - (highlightsize / 2), highlightsize, highlightsize);

                    //buffer_g.RotateTransform((float)ellipse.Aphelion.AngleBetween(new Vector(0, 1)));
                    //buffer_g.DrawLine(selectedbodyPen, ellipsex, ellipsey, (float)ellipse.Aphelion.X, (float)ellipse.Aphelion.Y);
                    //buffer_g.DrawEllipse(selectedbodyPen, ellipsex, ellipsey, (float)ellipse.Perihelion.VectorTo(ellipse.Aphelion).Modulus(), (float)minoraxislength / 2);
                    //buffer_g.DrawEllipse(selectedbodyPen, ellipsex, ellipsey, 20, 20);

                    //buffer_g.ResetTransform();
                }
                catch { }
            }

            // Draws the off screen buffer onto the visible one
            g.DrawImage(buffer, 0, 0);
        }


        private async void RunBtn_Click(object sender, EventArgs e)
        {

            if (!running)
            {
                if (sim == null)
                {
                    errorbox.Text = "No simulation loaded!!!";
                }
                else
                {
                    errorbox.Text = "All Clear";
                    running = true;
                    DrawPlanets(sim.GetBodies());

                    await Running();
                }
            }
        }

        private async Task Running()
        {
            DateTime lastupdated = DateTime.Now;

            while (running)
            {
                // Draws 60 times a second
                double timesincelastupdate = (DateTime.Now - lastupdated).TotalMilliseconds;

                if (timesincelastupdate >= (1000 / 60))
                {
                    DrawPlanets(sim.GetBodies());
                    lastupdated = DateTime.Now;
                }
                await Task.Run(() =>
                {
                    sim.Step();
                });
                DateTime datetime = sim.Date;
                DateAndTimeLabel.Text = datetime.ToString("yyyy-MM-dd");
            }
        }

        private void getLiveSolarSystemBtn_Click(object sender, EventArgs e)
        {

            sim = GetLiveSolarSystem();

            DateAndTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            errorbox.Text = "Loaded Successfully";

            DrawPlanets(sim.GetBodies());
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
                    errorbox.Text = "Invalid simulation file!!!";
                }




                DateAndTimeLabel.Text = sim.Date.ToString("yyyy-MM-dd");
                DrawPlanets(sim.GetBodies());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sim == null)
            {
                errorbox.Text = "No simulation to save!!!";
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
            DrawPlanets(sim.GetBodies());
        }

        private void logarithmicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uselog = true;
            DrawPlanets(sim.GetBodies());

        }

        private void linearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uselog = false;
            DrawPlanets(sim.GetBodies());

        }
        /// <summary>
        /// Detects if the user has clicked on a planet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            selectedbody = null;
            if (sim != null)
            {
                List<Vector> coordinates = coordcon.ConvertCoords(GetPositions(sim.GetBodies()), uselog, zoomlevel);

                Vector mouseposition = new Vector(e.X, e.Y);

                int selectedbodyindex = 0;
                foreach (Vector coord in coordinates)
                {
                    int size = 20;

                    if (mouseposition.VectorTo(coord).Modulus() <= size)
                    {
                        selectedbody = sim.GetBodies()[selectedbodyindex];

                        DrawPlanets(sim.GetBodies());

                        if (selectedbodyinfo != null)
                        {
                            if (selectedbodyinfo.Visible == true)
                            {
                                selectedbodyinfo.Close();
                            }
                        }
                        ShowBodyInfo(selectedbody);
                        break;
                    }
                    selectedbodyindex++;
                }
            }
        }

        public void ShowBodyInfo(Body body)
        {
            selectedbodyinfo = new BodyInfo(body, this);
            selectedbodyinfo.Show();
        }

        /// <summary>
        /// Detects the user scrolling, and either zooms or changes the timestep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                timesteplevel += e.Delta / 120;
                if (timesteplevel < 0)
                {
                    timesteplevel = 0;
                }
                else if (timesteplevel > 7)
                {
                    timesteplevel = 7;
                }

                switch (timesteplevel)
                {

                    case 0:
                        sim.Timestep = 1;
                        break;
                    case 1:
                        sim.Timestep = 60;
                        break;
                    case 2:
                        sim.Timestep = 60 * 5;
                        break;
                    case 3:
                        sim.Timestep = 60 * 30;
                        break;
                    case 4:
                        sim.Timestep = 60 * 60;
                        break;
                    case 5:
                        sim.Timestep = 60 * 60 * 6;
                        break;
                    case 6:
                        sim.Timestep = 60 * 60 * 12;
                        break;
                    case 7:
                        sim.Timestep = 60 * 60 * 24;
                        break;
                }

                Debug.WriteLine($"Timestep: {sim.Timestep} at level {timesteplevel}");
            }
            else
            {
                zoomlevel += e.Delta / 120;
                if (zoomlevel < 1)
                {
                    zoomlevel = 1;
                }
                else if (zoomlevel > 10)
                {
                    zoomlevel = 10;
                }
                DrawPlanets(sim.GetBodies());
            }

        }

        /// <summary>
        /// Replaces the old body in the simulation with the new one
        /// </summary>
        /// <param name="oldbody"></param>
        /// <param name="newbody"></param>
        public void UpdateBody(Body oldbody, Body newbody)
        {
            List<Body> bodies = sim.GetBodies();
            int index = -1;
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
            SelectedBody = null;

            if (legend != null)
            {
                legend.Update(sim.GetBodies());
            }

            DrawPlanets(sim.GetBodies());
        }

        public void RemoveBody(Body body)
        {
            sim.PlanetarySystem.RemoveBody(body);
            DrawPlanets(sim.GetBodies());
            selectedbody = null;
        }

        private void addBodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BodyCreationForm bodyCreationForm = new BodyCreationForm(this);
            bodyCreationForm.Show();
        }


        public void AddBody(Body body)
        {
            sim.PlanetarySystem.AddBody(body);
            DrawPlanets(sim.GetBodies());
        }

        private void showLegendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (legend == null || legend.IsDisposed)
            {
                legend = new Legend(sim.GetBodies(), this);
            }
            if (!legend.Visible)
            {
                legend.Show();
            }

        }
    }
}
