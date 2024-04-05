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

            public List<Vector> ConvertCoords(List<Vector> positions, bool uselog)
            {
                List<Vector> coordinates;

                if (uselog)
                {
                    coordinates = ConvertCoordsLog(positions);
                }
                else
                {
                    coordinates = ConvertCoordsScalar(positions, 0.000001);
                }

                return coordinates;
            }




            private List<Vector> ConvertCoordsLog(List<Vector> positions)
            {
                double logbase = 1.075;

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
                        magnitude = Math.Pow(magnitude / 5E9, 1 / 3f) * height * 0.9 * 0.5;

                        coordinate = direction.Scale(magnitude);
                        coordinate = coordinate.Add(centre);
                    }

                    coords.Add(coordinate);
                }

                return coords;
            }


            private List<Vector> ConvertCoordsScalar(List<Vector> positions, double scalar)
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