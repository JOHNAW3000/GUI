namespace GUI
{
    internal partial class Program
    {
        public class SystemSimulation
        {
            // Properties
            AdjacencyMatrix forces;
            CoordinateConverter converter;

            // Constructor
            public SystemSimulation(AdjacencyMatrix forces, CoordinateConverter converter)
            {
                this.forces = forces;
                this.converter = converter;
            }


            // Methods

            public void Run(int timestep, int length, Graphics g)
            {


                Pen p = new Pen(Color.OrangeRed, 5);
                Brush b = new SolidBrush(Color.Yellow);
                int size = 20;

                for (int i = 0; i < length; i++)
                {
                    // need to invalidate here!!!
                    this.Step(timestep);

                    for (int j = 0; j < converter.Coords.Count; j++)
                    {
                        Vector pos = converter.Coords[j];
                        if (pos.X == 500 && pos.Y == 500)
                        {
                            p = new Pen(Color.OrangeRed, 5);
                            b = new SolidBrush(Color.Yellow);
                            size = 20;
                        }
                        else
                        {
                            p = new Pen(Color.DarkGray, 5);
                            b = new SolidBrush(Color.Gray);
                            size = 10;

                        }
                        g.FillEllipse(b, (float)pos.X, (float)pos.Y, size, size);
                        g.DrawEllipse(p, (float)pos.X, (float)pos.Y, size, size);
                    }


                    Thread.Sleep(100);
                }
            }


            private void Step(int t)
            {
                // t is the timestep
                forces.Update();
                List<Body> bodies = forces.GetBodies();
                for (int i = 0; i < bodies.Count; i++)
                {
                    Body body = bodies[i];
                    Vector resultant = forces.Resultant(i);
                    double mass = body.Mass;
                    Vector acceleration = resultant.Scale(1 / mass);

                    Vector position = body.Position;
                    Vector velocity = body.Velocity;

                    // Calculate new position
                    double Half_t_squared = 0.5 * (t * t);
                    Vector newpos = position.Add(velocity.Scale(t).Add(acceleration.Scale(Half_t_squared)));

                    // Calculate new velocity
                    Vector newvelocity = velocity.Add(acceleration.Scale(t));

                    body.Position = newpos;
                    body.Velocity = newvelocity;
                }

                converter.ConvertCoords(forces);

            }




        }



    }
}