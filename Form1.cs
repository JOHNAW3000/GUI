using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static GUI.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


namespace GUI
{
    public partial class Sim1 : Form
    {

        private static AdjacencyMatrix planetarysystem = new AdjacencyMatrix();
        private CoordinateConverter coordcon;

        private SystemSimulation sim;

        private Graphics g;

        private bool running = false;

        private bool uselog = true;

        public Sim1()
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
            Sim1.ResetSystem();
            Bodies.Items.Clear();
            // Create API and force matrix for the simulation
            HorizonsAPI api = new HorizonsAPI();

            // Creates a list of planets to loop through
            string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
            //string[] planets = { "Earth", "Moon" };
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars" };
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Saturn", "Uranus", "Neptune", "Pluto" };


            foreach (string planet in planets)
            {

                // Creates a body from each API response
                Body body = api.ParseAPIResponse(planet);

                switch (body.Name)
                {
                    case "Sun":
                        body.Colours = new Appearance(Color.OrangeRed, Color.Yellow);
                        body.IsStar = true;
                        break;
                    case "Mercury":
                        body.Colours = new Appearance(Color.Gray, Color.DarkGray);
                        break;
                    case "Venus":
                        body.Colours = new Appearance(Color.DarkOrange, Color.Chocolate);
                        break;
                    case "Earth":
                        body.Colours = new Appearance(Color.SpringGreen, Color.SteelBlue);
                        break;
                    case "Mars":
                        body.Colours = new Appearance(Color.Firebrick, Color.Tomato);
                        break;
                    case "Jupiter":
                        body.Colours = new Appearance(Color.Peru, Color.Tan);
                        //
                        body.Mass = body.Mass / 1000;
                        break;
                    case "Saturn":
                        body.Colours = new Appearance(Color.DarkKhaki, Color.Khaki);
                        break;
                    case "Neptune":
                        body.Colours = new Appearance(Color.LightSkyBlue, Color.LightCyan);
                        break;
                    case "Uranus":
                        body.Colours = new Appearance(Color.RoyalBlue, Color.SlateBlue);
                        break;
                    case "Pluto":
                        body.Colours = new Appearance(Color.PaleTurquoise, Color.Lavender);
                        break;
                    case "Moon":
                        body.Colours = new Appearance(Color.Gray, Color.DarkGray);
                        break;
                }



                // Add to force matrix

                Bodies.Items.Add(body.Name);

                planetarysystem.AddBody(body);
            }


            sim = new SystemSimulation(planetarysystem, coordcon, this);
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

                    Sim1.ResetSystem();
                    planetarysystem = newsystem;
                    sim = new SystemSimulation(planetarysystem, coordcon, this);
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
            foreach (Body b in bodies)
            {
                if (b.Name == Bodies.SelectedItem.ToString())
                {
                    BodyInfo file = new BodyInfo(b);
                    file.Show();
                }
            }

        }
    }
}
