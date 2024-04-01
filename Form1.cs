using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static GUI.Program;


namespace GUI
{
    public partial class SimulationDisplay : Form
    {

        private static AdjacencyMatrix planetarysystem = new AdjacencyMatrix();
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

        public void UpdateLabel(string newdate)
        {
            BeginInvoke(new Action(() => { DateAndTimeLabel.Text = newdate; }));
        }

        public DateTime GetDate()
        {
            return Convert.ToDateTime(DateAndTimeLabel.Text);
        }

        private static void ResetSystem()
        {
            planetarysystem = new AdjacencyMatrix();
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

                    await Running(sim);
                }
            }


        }

        private async Task Running(SystemSimulation sim)
        {
            while (running)
            {
                await Task.Run(() => sim.Run(3600 * 24, 5, g, this, UpdateUI, uselog));
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
            SimulationDisplay.ResetSystem();
            Bodies.Items.Clear();

            sim = GetLiveSolarSystem(coordcon);

            DateAndTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            idiotbox.Text = "All Clear";

            sim.Run(1, 1, g, this, UpdateUI, uselog);

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
                string jsontext = File.ReadAllText(path);
                try
                {
                    JObject jsoncomplete = JObject.Parse(jsontext);
                    JArray jsonplanets = (JArray)jsoncomplete["Planets"];
                    string jsondate = jsoncomplete["Date"].ToString();

                    AdjacencyMatrix newsystem = new AdjacencyMatrix();
                    foreach (JToken jsonplanet in jsonplanets)
                    {
                        Body planet = jsonplanet.ToObject<Body>();
                        newsystem.AddBody(planet);
                        Bodies.Items.Add(planet.Name);

                    }

                    DateTime date = JsonConvert.DeserializeObject<DateTime>(jsondate);
                    DateAndTimeLabel.Text = date.ToString("yyyy-MM-dd");

                    SimulationDisplay.ResetSystem();
                    planetarysystem = newsystem;
                    sim = new SystemSimulation(planetarysystem, coordcon);
                    idiotbox.Text = "All Clear";


                    sim.Run(1, 1, g, this, UpdateUI, uselog);
                }
                catch (Exception ex)
                {
                    idiotbox.Text = "Invalid simulation file!!!";
                }
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
                    string jsonfile = sim.SaveSim();
                    JObject jsoncomplete = new JObject();
                    jsoncomplete["Planets"] = JArray.Parse(jsonfile);
                    jsoncomplete["Date"] = JsonConvert.SerializeObject(GetDate());
                    File.WriteAllText(path, jsoncomplete.ToString());
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
            List<Body> bodies = planetarysystem.GetBodies();
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
            List<Body> bodies = planetarysystem.GetBodies();
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
            planetarysystem.ReplaceBody(newbody, index);
        }

    }
}
