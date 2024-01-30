namespace GUI
{
    public class Body
    {
        // Properties

        private string name;
        private string ID;
        private double mass;
        private double radius;
        private Vector position;
        private Vector velocity;
        private string stats;

        // Constructor

        public Body(string name, string id, double mass, double radius, Vector position, Vector velocity)
        {
            this.name = name;
            this.ID = id;
            this.mass = mass;
            this.radius = radius;
            this.position = position;
            this.velocity = velocity;
        }

        // Methods
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public Vector Position
        {
            get { return position; }
            set { position = value; }
        }

        public void Data()
        {
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"ID: {this.ID}");
            Console.WriteLine($"Mass: {this.mass}kg");
            Console.WriteLine($"Radius: {this.radius}km");
            Console.WriteLine($"Position: X = {this.position.X}, Y = {this.position.Y}");
            Console.WriteLine($"Velocity: VX = {this.velocity.X}, VY = {this.velocity.Y}");
            Console.WriteLine();
        }
    }
}