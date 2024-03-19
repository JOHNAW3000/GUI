using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static GUI.Program;


namespace GUI
{
    public partial class Sim1 : Form
    {

        private static AdjacencyMatrix planetarysystem = new AdjacencyMatrix();
        private CoordinateConverter coordcon;

        private SystemSimulation sim;

        private Graphics g;

        private bool running = false;

        public Sim1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            coordcon = new CoordinateConverter(this.Width, this.Height);

            g = this.CreateGraphics();

        }

        public void UpdateLabel(string newdate)
        {
            DateAndTimeLabel.Text = newdate;
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

        private async Task Running()
        {
            while (running)
            {
                await Task.Run(() => sim.Run(3600 * 24, 5, g, this, UpdateUI));
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
            // Create API and force matrix for the simulation
            HorizonsAPI api = new HorizonsAPI();

            // Creates a list of planets to loop through
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
            //string[] planets = { "Sun", "Earth" };
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars" };
            string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Saturn", "Uranus", "Neptune", "Pluto" };


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
                }



                // Add to force matrix
                planetarysystem.AddBody(body);
            }


            sim = new SystemSimulation(planetarysystem, coordcon, this);
            DateAndTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            idiotbox.Text = "All Clear";

            sim.Run(1, 1, g, this, UpdateUI);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load simulation
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
                    }

                    DateTime date = JsonConvert.DeserializeObject<DateTime>(jsondate);
                    DateAndTimeLabel.Text = date.ToString("yyyy-MM-dd");

                    Sim1.ResetSystem();
                    planetarysystem = newsystem;
                    sim = new SystemSimulation(planetarysystem, coordcon, this);
                    idiotbox.Text = "All Clear";


                    sim.Run(1, 1, g, this, UpdateUI);
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
    }
}
