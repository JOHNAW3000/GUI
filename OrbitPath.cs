using System.Diagnostics;

namespace GUI
{
    public class OrbitPath
    {

        private Vector aphelion;
        private Vector perihelion;


        private int period;

        private Vector focusposition;

        private bool orbitcomplete = false;

        private Vector majoraxis;
        private double minoraxislength;
        public OrbitPath(Vector currentpos)
        {
            aphelion = currentpos;
            perihelion = currentpos;
            this.period = 0;
        }

        public Vector Aphelion
        {
            get { return aphelion; }
            set { aphelion = value; }
        }

        public Vector Perihelion
        {
            get { return perihelion; }
            set { perihelion = value; }
        }

        public Vector Majoraxis
        {
            get { return majoraxis; }
            set { majoraxis = value; }
        }

        public double Minoraxislength
        {
            get { return minoraxislength; }
            set { minoraxislength = value; }
        }

        public void Update(Vector currentfocuspos, Vector currentpos, int timestep)
        {
            orbitcomplete = true;

            focusposition = currentfocuspos;

            Vector vectorfromfocus = focusposition.VectorTo(currentpos);

            //Debug.WriteLine(vectorfromfocus.Modulus());
            //Debug.WriteLine(currentpos.Modulus());
            period += timestep;

            if (vectorfromfocus.Modulus() >= aphelion.Modulus())
            {
                aphelion = vectorfromfocus;
                orbitcomplete = false;
            }
            if (vectorfromfocus.Modulus() <= perihelion.Modulus())
            {
                perihelion = vectorfromfocus;
                orbitcomplete = false;
            }

            if (orbitcomplete)
            {
                majoraxis = perihelion.VectorTo(aphelion);
                minoraxislength = Math.Sqrt(aphelion.Modulus() * perihelion.Modulus());

            }

        }


        public void Data()
        {
            aphelion.Data();
            perihelion.Data();
        }





    }
}
