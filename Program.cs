namespace GUI
{
    internal static partial class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SimulationDisplay());
        }


        public static SystemSimulation GetLiveSolarSystem(CoordinateConverter coordcon)
        {
            HorizonsAPI api = new HorizonsAPI();
            AdjacencyMatrix planetarysystem = new AdjacencyMatrix();

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
                        //
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
                planetarysystem.AddBody(body);
            }


            SystemSimulation sim = new SystemSimulation(planetarysystem, coordcon);
            return sim;

        }
    }
}