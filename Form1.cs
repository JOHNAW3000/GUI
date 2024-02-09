using System.Diagnostics;
using static GUI.Program;


namespace GUI
{
    public partial class Sim1 : Form
    {
        public Sim1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }



        private void StartBtn_Click(object sender, EventArgs e)
        {
            // Create API and force matrix for the simulation
            HorizonsAPI api = new HorizonsAPI();
            AdjacencyMatrix forces = new AdjacencyMatrix();
            Debug.WriteLine("Creating force matrix");

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
                        body.MakeStar();
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
                forces.AddBody(body);

                Debug.WriteLine($"   - Added {body.Name}");

            }

            CoordinateConverter coords = new CoordinateConverter(1000, 1000);

            Graphics g = this.CreateGraphics();


            SystemSimulation sim = new SystemSimulation(forces, coords);

            sim.Run(3600 * 24, 364, g, this);
        }
    }
}
