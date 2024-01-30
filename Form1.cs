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


            // Calculates the forces between objects
            forces.Update();

            // Still in progress
            CoordinateConverter coords = new CoordinateConverter(1000,1000);
            coords.ConvertCoords(forces);

            Console.WriteLine("Coordinates");
            coords.Data();

            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.OrangeRed, 5);
            Brush b = new SolidBrush(Color.Yellow);
            int size = 20;



            for (int i = 0; i < coords.Coords.Count; i++)
            {
                Vector pos = coords.Coords[i];
                if (pos.X == 500 && pos.Y == 500)
                {
                    p = new Pen(Color.OrangeRed, 5);
                    b = new SolidBrush(Color.Yellow);
                    size = 20;
                }
                else
                {
                    p = new Pen(Color.DarkGray, 5);
                    b = new SolidBrush(Color.Gray);
                    size = 10;

                }
                g.FillEllipse(b, (float)pos.X, (float)pos.Y, size, size);
                g.DrawEllipse(p, (float)pos.X, (float)pos.Y, size, size);
            }


        }



    }
}
