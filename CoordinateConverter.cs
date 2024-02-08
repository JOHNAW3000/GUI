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
            public List<Vector> ConvertCoordsLog(AdjacencyMatrix planets)
            {
                double logbase = 1.075;


                List<Vector> coords = new List<Vector>();

                Vector centre = new Vector(this.width / 2, this.height / 2);

                List<Body> bodies = planets.GetBodies();
               
                foreach (Body body in bodies)
                {
                    Vector bpos = body.Position;

                    Vector direction = bpos.Unit();
                    double magnitude = bpos.Modulus();


                    Vector coordinate = centre;

                    if (magnitude != 0)
                    {
                        magnitude = Math.Log(magnitude, logbase);
                        coordinate = direction.Scale(magnitude);
                        coordinate = coordinate.Add(centre);
                    }

                    coords.Add(coordinate);
                }
                
                return coords;
            }


            public List<Vector> ConvertCoordsScalar(AdjacencyMatrix planets, double scalar)
            {

                List<Vector> coords = new List<Vector>();

                Vector centre = new Vector(this.width / 2, this.height / 2);

                List<Body> bodies = planets.GetBodies();

                foreach (Body body in bodies)
                {
                    Vector bpos = body.Position;

                    Vector direction = bpos.Unit();
                    double magnitude = bpos.Modulus();


                    Vector coordinate = centre;

                    if (magnitude != 0)
                    {
                        magnitude = magnitude * scalar;
                        coordinate = direction.Scale(magnitude);
                        coordinate = coordinate.Add(centre);
                    }

                    coords.Add(coordinate);
                }

                return coords;
            }


        }
    }
}