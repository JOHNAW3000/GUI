using System.Diagnostics;

namespace GUI
{
    internal partial class Program
    {
        public class SystemSimulation
        {
            // Properties
            AdjacencyMatrix PlanetarySystem;
            CoordinateConverter converter;

            // Constructor
            public SystemSimulation(AdjacencyMatrix forces, CoordinateConverter converter)
            {
                this.PlanetarySystem = forces;
                this.converter = converter;
            }


            // Methods

            public void Run(int timestep, int length, Graphics g)
            {


              
                int size = 20;

                for (int i = 0; i < length; i++)
                {
                    // need to invalidate here!!!
                    List<Body> bodies = PlanetarySystem.GetBodies();
                    List<Vector> coordinates = converter.ConvertCoords(PlanetarySystem);

                    for (int bodyindex = 0; bodyindex < bodies.Count; bodyindex++)
                    {
                        //
                        Body test = bodies[bodyindex];

                        Debug.WriteLine($"Position of {test.Name}");
                        test.Position.Data();
                        //
                        Vector pos = coordinates[bodyindex];
                        Colours colours = PlanetarySystem.GetBodies()[bodyindex].Colours;
                        Pen p = colours.getOutline();
                        Brush b = colours.getFill();
                        
                        g.FillEllipse(b, (float)pos.X, (float)pos.Y, size, size);
                        g.DrawEllipse(p, (float)pos.X, (float)pos.Y, size, size);
                    }

                    this.Step(timestep);

                    Thread.Sleep(5);
                }
            }


            private void Step(int timestep)
            {
                PlanetarySystem.Update();
                List<Body> bodies = PlanetarySystem.GetBodies();

                for (int i = 0; i < bodies.Count; i++)
                {

                    // Now using Verlet method

                    Body body = bodies[i];
                    double mass = body.Mass;

                    Vector resultant = PlanetarySystem.Resultant(i);

                    Vector acceleration = resultant.Scale(1 / mass);
                    if (acceleration.Modulus() < 0.01)
                    {
                        acceleration = new Vector(0, 0);
                    }
                    Debug.WriteLine($"Acceleration of {body.Name}");
                    acceleration.Data();

                    Vector position = body.Position;

                    Vector lastpos = body.PreviousPosition;

                    Vector velocity = body.Velocity;

                    // Calculate new position
                    Vector newpos = deltaPosition(position, velocity, acceleration, timestep);
                    Debug.WriteLine($"Change in pos:");
                    position.VectorTo(newpos).Data();


                    // Calculate new velocity

                    // 1/timestep
                    double timestepreciprocal = 1.0 / timestep;

                    Vector newvelocity = newpos.VectorTo(position);
                    newvelocity.Scale(timestepreciprocal);

                    //Vector newvelocity = velocity.Add(acceleration.Scale(timestep));

                    Debug.WriteLine($"Velocity of {body.Name}");
                    body.Velocity.Data();

                    body.Velocity = newvelocity;
                    Debug.WriteLine($"newVelocity of {body.Name}");
                    body.Velocity.Data();

                    body.Position = newpos;

                    PlanetarySystem.ReplaceBody(body, i);
                }

                //PlanetarySystem.Data();
                converter.ConvertCoords(PlanetarySystem);
                
            }

            private static Vector deltaPosition(Vector position, Vector velocity, Vector acceleration, double timestep)
            {
                // fix this

                Vector displacement = velocity.Scale(timestep);

                Vector AccTimeSquared = acceleration.Scale(0.5 * timestep * timestep);

                Vector newpos = position.Add(displacement);
                newpos.Add(AccTimeSquared);
                    

                return newpos;
            }




        }



    }
}