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
               
                foreach (Body body in bodies)
                {
                    Vector bpos = body.Position;

                    Vector direction = bpos.Unit();
                    double magnitude = bpos.Modulus();

                    double logbase = 1.1;

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

        }
    }
}