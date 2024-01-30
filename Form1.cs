using System.Text.RegularExpressions;
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
            Console.WriteLine("Creating force matrix");

            // Creates a list of planets to loop through
            string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
            foreach (string planet in planets)
            {
                // Creates a body from each API response
                Body body = api.ParseAPIResponse(planet);
                // Add to force matrix
                forces.AddBody(body);

                Console.WriteLine($"   - Added {body.Name}");

            }

            CoordinateConverter coords = new CoordinateConverter(1000,1000);
            coords.ConvertCoords(forces);



            Graphics g = this.CreateGraphics();

            SystemSimulation sim = new SystemSimulation(forces, coords);
            sim.Run(3600, 1000, g);



        }



    }
}
