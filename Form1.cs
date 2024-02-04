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
            // string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
            string[] planets = { "Sun", "Mercury" };
            foreach (string planet in planets)
            {
                // Creates a body from each API response
                Body body = api.ParseAPIResponse(planet);

                if (planet == "Sun")
                {
                    Pen p = new Pen(Color.OrangeRed);
                    Brush b = new SolidBrush(Color.Yellow);
                    Colours sun = new Colours(p, b);
                    body.Colours = sun;
                }
                else
                {
                    Pen p = new Pen(Color.Gray);
                    Brush b = new SolidBrush(Color.DarkGray);
                    Colours merc = new Colours(p, b);
                    body.Colours = merc;
                }

                // Add to force matrix
                forces.AddBody(body);

                Debug.WriteLine($"   - Added {body.Name}");

            }

            CoordinateConverter coords = new CoordinateConverter(1000, 1000);

            Graphics g = this.CreateGraphics();

            SystemSimulation sim = new SystemSimulation(forces, coords);

            sim.Run(60, 60 * 24, g);
        }
    }
}
