using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GUI
{
    internal static partial class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new SimulationDisplay());
        }


        public static SystemSimulation GetLiveSolarSystem()
        {
            HorizonsAPI api = new HorizonsAPI();
            AdjacencyMatrix planetarysystem = new AdjacencyMatrix();

            // Creates a list of planets to loop through
            string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto"};

            // Testing planets
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto", "Commet"};
            //string[] planets = {"Sun", "Earth", "Moon" };
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars" };
            //string[] planets = { "Sun", "Mercury", "Venus", "Earth", "Mars", "Saturn", "Uranus", "Neptune", "Pluto" };


            foreach (string planet in planets)
            {

                // Creates a body from each API response
                Body body = api.ParseAPIResponse(planet);

                // Sets the appearance of each planet to an easily distinguishable colour
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

                    default:
                        body.Colours = new Appearance(Color.Pink, Color.Magenta);
                        break;
                }

                // Add to force matrix
                body.Data();
                planetarysystem.AddBody(body);
            }

            DateTime date = DateTime.Today;

            SystemSimulation sim = new SystemSimulation(planetarysystem, date);
            return sim;

        }
        /// <summary>
        /// Loads a JSOn sim file, and parses it into a simulation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SystemSimulation LoadSimulation(string path)
        {
            string jsontext = File.ReadAllText(path);

            JObject jsoncompletefile = JObject.Parse(jsontext);
            // List of bodies and their data
            JArray jsonplanets = (JArray)jsoncompletefile["Planets"];
            // The simulation date
            string jsondate = jsoncompletefile["Date"].ToString();

            AdjacencyMatrix planetarysystem = new AdjacencyMatrix();
            foreach (JToken jsonplanet in jsonplanets)
            {
                Body planet = jsonplanet.ToObject<Body>();
                planetarysystem.AddBody(planet);
            }

            DateTime date = JsonConvert.DeserializeObject<DateTime>(jsondate);

            SystemSimulation sim = new SystemSimulation(planetarysystem, date);
            return sim;
        }

        public static void SaveSimulation(SystemSimulation sim, string path)
        {
            string jsonfile = sim.SaveSim();
            JObject jsoncomplete = new JObject();
            // Parses the planets and date separately
            jsoncomplete["Planets"] = JArray.Parse(jsonfile);
            jsoncomplete["Date"] = JsonConvert.SerializeObject(sim.Date);
            File.WriteAllText(path, jsoncomplete.ToString());
        }

    }
}
