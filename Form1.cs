using Newtonsoft.Json;
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


        private void RunBtn_Click(object sender, EventArgs e)
        {
            running = true;

            this.Run();
        }

        private void Run()
        {
            while (running)
            {
                sim.Run(3600 * 24, 5, g, this);
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
            sim.Run(1, 1, g, this);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load simulation
            string path;
            openFileDialog1.ShowDialog(this);
            path = openFileDialog1.FileName;
            string jsontext = File.ReadAllText(path);

            List<Body> storedbodies = JsonConvert.DeserializeObject<List<Body>>(jsontext);
            AdjacencyMatrix newsystem = new AdjacencyMatrix();

            foreach (Body b in storedbodies)
            {
                newsystem.AddBody(b);
            }

            Sim1.ResetSystem();
            planetarysystem = newsystem;
            sim = new SystemSimulation(planetarysystem, coordcon, this);
            DateAndTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            sim.Run(1, 1, g, this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            saveFileDialog1.ShowDialog(this);
            path = saveFileDialog1.FileName;

            string jsonfile = sim.SaveSim();
            File.WriteAllText(path, jsonfile);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            running = false;
        }
    }
}
