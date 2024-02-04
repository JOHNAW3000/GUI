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
                //Debug.WriteLine("Converting coords");

                List<Vector> coords = new List<Vector>();


                Vector centre = new Vector(this.width / 2, this.height / 2);

                List<Body> bodies = planets.GetBodies();
                //this.Coords = new List<Vector>(bodies.Count());
               
                double logbase = 1.1;

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
                        //Vector bcoords = bpos.Log(logbase);
                        Vector bcoords = bpos.Scale(0.000001);
                        //Debug.WriteLine($"Coords of {b.Name}:");
                        bcoords = bcoords.Add(centre);
                        //bcoords.Data();
                        coords.Add(bcoords);
                    }
                }

                return coords;
            }

        }
    }
}