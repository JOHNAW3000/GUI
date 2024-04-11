using Newtonsoft.Json;
using System.Diagnostics;
namespace GUI

{
    internal partial class Program
    {
        public class SystemSimulation
        {
            // Properties
            private AdjacencyMatrix planetarysystem;
            private DateTime date;

            private int timestep = 3600 * 24;

            // Constructor
            public SystemSimulation(AdjacencyMatrix forces, DateTime date)
            {
                this.planetarysystem = forces;
                this.date = date;
            }


            // Methods

            public int Timestep
            {
                get { return timestep; }
                set { timestep = value; }
            }
            public AdjacencyMatrix PlanetarySystem
            {
                get { return planetarysystem; }
                set { planetarysystem = value; }
            }
            public DateTime Date
            {
                get { return date; }
                set { date = value; }
            }
            public string SaveSim()
            {
                List<Body> bodies = PlanetarySystem.GetBodies();

                string jsontext = JsonConvert.SerializeObject(bodies);

                return jsontext;
            }

            public List<Body> GetBodies()
            {
                return PlanetarySystem.GetBodies();
            }

            /*public void Run(int timestep, Graphics g, SimulationDisplay form)
            {

                form.DrawStep(planetarysystem.GetBodies());

                this.Step(timestep);

                DateTime datetime = form.GetDate();
                datetime = datetime.AddSeconds(timestep);
                form.UpdateLabel(datetime.ToString("yyyy-MM-dd"));


                // make this consistent
                //Thread.Sleep(10);
            }*/

            public void Step()
            {
                
                date = date.AddSeconds(timestep);


                List<Body> bodies = planetarysystem.GetBodies();

                for (int i = 0; i < bodies.Count; i++)
                {

                    // Now using Verlet method

                    Body body = bodies[i];
                    if (!body.IsStar)
                    {

                        double mass = body.Mass;

                        Vector resultant = planetarysystem.Resultant(i);

                        Vector acceleration = resultant.Scale(1 / mass);

                        //Debug.WriteLine($"Acceleration of {body.Name}");
                        //acceleration.Data();

                        Vector position = body.Position;
                        position = position.Scale(1000);

                        Vector velocity = body.Velocity;
                        velocity = velocity.Scale(1000);

                        //Vector centralbodypos = new Vector(0,0);
                        //body.Orbit.Update(centralbodypos, position, timestep);


                        // Calculate new position
                        Vector newpos = new Vector(0, 0);


                        newpos = deltaPosition(position, velocity, acceleration, timestep);


                        // Calculate new velocity

                        body.Position = newpos;
                        planetarysystem.ReplaceBody(body, i);

                        planetarysystem.SingleBodyUpdate(i);

                        resultant = PlanetarySystem.Resultant(i);
                        //resultant.Data();
                        Vector newacceleration = resultant.Scale(1 / mass);

                        Vector newvelocity = deltaVelocity(velocity, acceleration, newacceleration, timestep);



                        // Outputs and checks

                        // Debug.WriteLine($"Velocity of {body.Name}");
                        //body.Velocity.Data();

                        body.Velocity = newvelocity;
                        //Debug.WriteLine($"newVelocity of {body.Name}");
                        //body.Velocity.Data();

                        planetarysystem.ReplaceBody(body, i);
                    }

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
