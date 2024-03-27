using System.Diagnostics;
using System.Xml.Linq;

namespace GUI
{
    public class Body
    {
        // Properties

        private string name;
        private string id;
        private double mass;
        private double radius;
        private Vector position;
        private Vector velocity;
        private string stats;
        private Appearance colours;
        private bool isstar = false;


        // Constructor

        public Body(string name, string id, double mass, double radius, Vector position, Vector velocity)
        {
            this.name = name;
            this.id = id;
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

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Vector Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Appearance Colours
        {
            get { return colours; }
            set { colours = value; }
        }

        public bool IsStar
        {
            get { return isstar; }
            set { isstar = value; }
        }



        public void Data()
        {
            Debug.WriteLine($"Name: {this.name}");
            Debug.WriteLine($"ID: {this.ID}");
            Debug.WriteLine($"Mass: {this.mass}kg");
            Debug.WriteLine($"Radius: {this.radius}km");
            Debug.WriteLine($"Position: X = {this.position.X}, Y = {this.position.Y}");
            Debug.WriteLine($"Velocity: VX = {this.velocity.X}, VY = {this.velocity.Y}");
            Debug.WriteLine("");
        }
    }


}