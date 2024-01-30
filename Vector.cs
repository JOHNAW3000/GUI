namespace GUI
{
    public class Vector
    {
        // Properties

        private double x_component;
        private double y_component;

        // Constructor
        public Vector(double x_component, double y_component)
        {
            this.x_component = x_component;
            this.y_component = y_component;
        }

        // Methods

        // Get and Set the XY values
        public double X
        {
            get { return x_component; }
            set { x_component = value; }
        }
        public double Y
        {
            get { return y_component; }
            set { y_component = value; }
        }


        // Returns the modulus of the vector
        public double Modulus()
        {
            double mod = Math.Sqrt((x_component * x_component) + (y_component * y_component));
            return mod;
        }

        // Returns position vector of input vector relative to this vector
        public Vector VectorTo(Vector v)
        {
            double x = this.X - v.X;
            double y = this.Y - v.Y;
            return new Vector(x, y);
        }

        public Vector Scale(double scalar)
        {
            double x = this.X * scalar;
            double y = this.Y * scalar;
            return new Vector(x, y);
        }

        public Vector Add(Vector v)
        {
            double x = this.X + v.X;
            double y = this.Y + v.Y;
            return new Vector(x, y);
        }

        public Vector Unit()
        {
            double mod = this.Modulus();
            Vector unit = this.Scale(1 / mod);
            return unit;

        }

        public void Data()
        {
            double mod = this.Modulus();
            Console.WriteLine($"X: {this.X}");
            Console.WriteLine($"Y: {this.Y}");
            Console.WriteLine($"Mod: {mod}");
        }


        public Vector Log(double scalar)
        {
            double x = Math.Log(Math.Abs(this.X), scalar);
            double y = Math.Log(Math.Abs(this.Y), scalar);
            if (this.X < 0)
            {
                x *= -1;
            }
            if (this.Y < 0)
            {
                y *= -1;
            }
            return new Vector(x, y);
        }
    }
}
