using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            public string SaveSim()
            {
                List<Body> bodies = PlanetarySystem.GetBodies();
               
                string jsontext = JsonConvert.SerializeObject(bodies);

                return jsontext;
            }

            public void Run(int timestep, int length, Graphics g, Form form)
            {

                int size = 20;

                for (int i = 0; i < length; i++)
                {



                    List<Body> bodies = PlanetarySystem.GetBodies();
                    //List<Vector> coordinates = converter.ConvertCoordsScalar(PlanetarySystem, 0.000001);
                    List<Vector> coordinates = converter.ConvertCoordsLog(PlanetarySystem);

                    form.Refresh();

                    for (int bodyindex = 0; bodyindex < bodies.Count; bodyindex++)
                    {

                        Vector pos = coordinates[bodyindex];
                        Appearance colours = PlanetarySystem.GetBodies()[bodyindex].Colours;
                        Pen p = new Pen(colours.Primary, 5);
                        Brush b = new SolidBrush(colours.Secondary);


                        Vector velocity = bodies[bodyindex].Velocity;
                        float startx = (float)pos.X;
                        float starty = (float)pos.Y;
                        float endx = (float)pos.Add(velocity).X;
                        float endy = (float)pos.Add(velocity).Y;
                        g.DrawLine(p, startx, starty, endx, endy);


                        g.FillEllipse(b, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
                        g.DrawEllipse(p, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
                    }

                    this.Step(timestep);


                    // make this consistent
                    //Thread.Sleep(10);
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

                    //Debug.WriteLine($"Acceleration of {body.Name}");
                    //acceleration.Data();

                    Vector position = body.Position;
                    position = position.Scale(1000);

                    Vector velocity = body.Velocity;
                    velocity = velocity.Scale(1000);


                    // Calculate new position
                    Vector newpos = new Vector(0, 0);

                    if (!body.IsStar)
                    {
                        newpos = deltaPosition(position, velocity, acceleration, timestep);
                    }

                    // Calculate new velocity

                    body.Position = newpos;
                    PlanetarySystem.ReplaceBody(body, i);
                    PlanetarySystem.Update();

                    resultant = PlanetarySystem.Resultant(i);
                    Vector newacceleration = resultant.Scale(1 / mass);


                    Vector newvelocity = new Vector(0, 0);

                    if (!body.IsStar)
                    {
                        newvelocity = deltaVelocity(velocity, acceleration, newacceleration, timestep);

                    }


                    // Outputs and checks

                    // Debug.WriteLine($"Velocity of {body.Name}");
                    //body.Velocity.Data();

                    body.Velocity = newvelocity;
                    //Debug.WriteLine($"newVelocity of {body.Name}");
                    //body.Velocity.Data();


                    PlanetarySystem.ReplaceBody(body, i);
                }

                //PlanetarySystem.Data();
                //converter.ConvertCoordsLog(PlanetarySystem);

            }

            private static Vector deltaPosition(Vector position, Vector velocity, Vector acceleration, double timestep)
            {

                // Debug.WriteLine("deltaPosition using pos, vel, acc and t:");
                //position.Data();
                // velocity.Data();
                //acceleration.Data();
                //Debug.WriteLine(timestep);

                Vector displacement = velocity.Scale(timestep);

                Vector AccTimeSquared = acceleration.Scale(0.5 * timestep * timestep);

                Vector deltaP = displacement.Add(AccTimeSquared);
                Vector newpos = position.Add(deltaP);

                //Debug.WriteLine("Pos");
                //position.Data();

                //Debug.WriteLine("Newpos");
                //newpos.Data();

                newpos = newpos.Scale(0.001);
                return newpos;
            }

            private static Vector deltaVelocity(Vector velocity, Vector acceleration, Vector newacceleration, double timestep)
            {

                // Debug.WriteLine("Old acc, new acc");
                //acceleration.Data();
                // newacceleration.Data();

                Vector newvelocity = velocity;

                //Debug.WriteLine("Newacc:");
                //newacceleration.Data();

                acceleration = acceleration.Add(newacceleration);
                acceleration = acceleration.Scale(0.5 * timestep);

                newvelocity = newvelocity.Add(acceleration);
                //Debug.WriteLine("newvel:");
                //newvelocity.Data();
                newvelocity = newvelocity.Scale(0.001);
                return newvelocity;
            }


        }



    }
}