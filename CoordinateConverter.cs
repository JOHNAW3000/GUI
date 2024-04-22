using System.Configuration;
using System.Diagnostics;

namespace GUI
{
    internal static partial class Program
    {
        public class CoordinateConverter
        {
            // Properties
            private int width;
            private int height;
            private int screenradius;

            private const double solarsystemradius = 6E9;

            public CoordinateConverter(int width, int height)
            {
                this.width = width;
                this.height = height;

                int smallestdimension = Math.Min(width, height);
                screenradius = smallestdimension / 2;
            }


            // Methods

            // Outputs coordinate list
            public List<Vector> ConvertCoords(List<Vector> positions, bool uselog, float zoomlevel)
            {
                List<Vector> coordinates;

                if (uselog)
                {
                    coordinates = ConvertCoordsLog(positions, zoomlevel);
                }
                else
                {
                    coordinates = ConvertCoordsScalar(positions, zoomlevel);
                }

                return coordinates;
            }

            /// <summary>
            /// Uses power law to scale distances
            /// </summary>
            /// <param name="positions"> The list of planet positions</param>
            /// <param name="zoomlevel"> The integer zoom level of the form</param>
            /// <returns></returns>
            // This method uses the power law
            // It originally used a logarithmic scale,
            // but after a conversation where my supervisor suggested looking at the power rule I decided to use that
            private List<Vector> ConvertCoordsLog(List<Vector> positions, float zoomlevel)
            {

                List<Vector> coords = new List<Vector>();

                Vector centre = new Vector(this.width / 2, this.height / 2);


                foreach (Vector pos in positions)
                {

                    Vector direction = pos.Unit();
                    double magnitude = pos.Modulus();


                    Vector coordinate = centre;

                    if (magnitude != 0)
                    {

                        // Uses power law scaling
                        // The formula can be seen in detail under the Algorithms section
                        // Previous method used:
                        // magnitude = Math.Log(magnitude, logbase);
                        magnitude = Math.Pow(magnitude / solarsystemradius, 1f / zoomlevel) * screenradius * 0.9; 
                        // The 0.9 is a scalar so that the drawing takes up 90% of the screen when drawn

                        coordinate = direction.Scale(magnitude);
                        coordinate = coordinate.Add(centre);
                    }

                    coords.Add(coordinate);
                }

                return coords;
            }

            /// <summary>
            /// Uses a scalar to scale down distances
            /// </summary>
            /// <param name="positions"> The list of planet positions</param>
            /// <param name="zoomlevel"> The integer zoom level of the form</param>
            /// <returns></returns>
            private List<Vector> ConvertCoordsScalar(List<Vector> positions, float zoomlevel)
            {
                // Converts zoom level to a scalar, the lowest being 1:1, highest being 1:1,000,000,000
                double scalar = Math.Pow(10, -10 + zoomlevel);

                List<Vector> coords = new List<Vector>();

                Vector centre = new Vector(this.width / 2, this.height / 2);

                foreach (Vector pos in positions)
                {

                    Vector direction = pos.Unit();
                    double magnitude = pos.Modulus();


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


            // Unused code from the start of implementing Kepler's Laws
            public OrbitPath ConvertOrbit(OrbitPath orbit, bool uselog, int zoomlevel)
            {

                Vector centre = new Vector(this.width / 2, this.height / 2);

                List<Vector> ellipsevertices = ConvertCoords(new List<Vector>()
                {
                    orbit.Aphelion, orbit.Perihelion
                }, uselog, zoomlevel);

                Vector aphelion = ellipsevertices[0];
                Vector perihelion = ellipsevertices[1];

                aphelion = aphelion.Add(centre.Scale(-1));
                perihelion = perihelion.Add(centre.Scale(-1));

                OrbitPath ellipse = new OrbitPath(aphelion);
                ellipse.Aphelion = aphelion;
                ellipse.Perihelion = perihelion;


                //Debug.WriteLine("Orbit");
                //orbit.Data();
                //Debug.WriteLine("Ellipse");
                //ellipse.Data();
                return ellipse;
            }


        }
    }
}