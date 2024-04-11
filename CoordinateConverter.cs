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
                        //magnitude = Math.Log(magnitude, logbase);
                        magnitude = Math.Pow(magnitude / 6E9, 1f / zoomlevel) * height * 0.9 * 0.5; ///// EXPLAIN //// and fix

                        coordinate = direction.Scale(magnitude);
                        coordinate = coordinate.Add(centre);
                    }

                    coords.Add(coordinate);
                }

                return coords;
            }


            private List<Vector> ConvertCoordsScalar(List<Vector> positions, float zoomlevel)
            {
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


            public OrbitPath ConvertOrbit(OrbitPath orbit, bool uselog, int zoomlevel)
            {

                Vector centre = new Vector(this.width / 2, this.height / 2);

                List<Vector> ellipsevertices = ConvertCoords(new List<Vector>()
                {
                    orbit.Aphelion, orbit.Perihelion
                }, uselog, zoomlevel);


                // comment 
                // |        |        |
                // -------------------

                Vector aphelion = ellipsevertices[0];
                Vector perihelion = ellipsevertices[1];

                //this is a bodge

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