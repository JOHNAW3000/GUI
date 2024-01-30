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
            List<Vector> coords = new List<Vector>();




            public CoordinateConverter(int width, int height)
            {
                this.width = width;
                this.height = height;
            }


            // Methods

            // Outputs coordinate list
            public List<Vector> Coords
            {
                get { return coords; }
                set { coords = value; }
            }

            public void ConvertCoords(AdjacencyMatrix forces)
            {
                Vector centre = new Vector(this.width / 2, this.height / 2);
                
                List<Body> bodies = forces.GetBodies();

                double logbase = 1.1;

                foreach (Body b in bodies)
                {
                    Console.WriteLine(b.Name);
                    Vector bpos = b.Position;
                    if (bpos.X == 0 && bpos.Y == 0)
                    {
                        coords.Add(bpos.Add(centre));
                    }
                    else
                    {
                        Vector bcoords = bpos.Log(logbase);
                        coords.Add(bcoords.Add(centre));
                    }

                }

            }


            public void Data()
            {
                foreach (Vector v in coords)
                {
                    v.Data();
                }
            }
        }
    }
}