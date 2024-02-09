
using System.Drawing.Text;

namespace GUI
{
    internal partial class Program
    {
        public class Kepler
        {
            // Properties
            private int sectornum;
            private Rectangle[] sectors;
            private double angle;
            private Vector normal;

            public Kepler(Vector coords, int sectornum, Vector centre)
            {
                this.sectornum = sectornum;
                this.sectors = new Rectangle[sectornum];
                this.angle = 360 / sectornum;
                this.normal = coords.Unit();
                
                for (int i = 0; i < sectornum; i++)
                {
                    sectors[i] = new Rectangle(Convert.ToInt32(centre.X), Convert.ToInt32(centre.Y), 0, 0);
                }
            }


            public void Update(Vector coords)
            {
                double internalangle = normal.AngleBetween(coords);
                int index = 360 / Convert.ToInt32(internalangle);
                Rectangle rectangle = sectors[index];


            }




        }



    }
}