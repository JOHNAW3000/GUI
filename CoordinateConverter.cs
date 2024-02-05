using System.Diagnostics;

namespace GUI
{
    internal static partial class Program
    {
        public class CoordinateConverter
        {
            // Properties
            int width;
            int height;
            // Stores the coordinates of each planet to be plotted




            public CoordinateConverter(int width, int height)
            {
                this.width = width;
                this.height = height;
            }


            // Methods

            // Outputs coordinate list
            public List<Vector> ConvertCoords(AdjacencyMatrix planets)
            {

                List<Vector> coords = new List<Vector>();

                Vector centre = new Vector(this.width / 2, this.height / 2);

                List<Body> bodies = planets.GetBodies();
               
                List<double> logdistances = new List<double>();


                foreach (Body body in bodies)
                {
                    if (body.Position.Modulus() != 0)
                    {
                        Vector origin = new Vector(0, 0);
                        Vector radius = origin.VectorTo(body.Position);
                        double radiusmod = radius.Modulus();
                        double logdist = Math.Log(radiusmod);
                        logdistances.Add(logdist);
                    }
                    else
                    {
                        logdistances.Add(0);
                    }
                }

                // Calculate furthest log distance

                double maxlogdist = logdistances.Max();

                double scalarx = width / maxlogdist;
                double scalary = height / maxlogdist;





                for (int i = 0; i < bodies.Count; i++)
                {
                    Body b = bodies[i];
                    //Debug.WriteLine(b.Name);
                    Vector bpos = b.Position;

                    if (bpos.X == 0 && bpos.Y == 0)
                    {
                        //Debug.WriteLine($"Coords of {b.Name}:");
                        //bpos.Add(centre).Data();
                        coords.Add(bpos.Add(centre));
                    }
                    else
                    {
                        //Vector bcoords = bpos.Scale(0.000001);
                        Vector bcoords = new Vector(bpos.X, bpos.Y);
                        bcoords.X = logdistances[i] * scalarx;
                        bcoords.Y = logdistances[i] + scalary;


                        bcoords = bcoords.Add(centre);
                        coords.Add(bcoords);
                    }
                }

                return coords;
            }

        }
    }
}