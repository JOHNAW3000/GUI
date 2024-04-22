using Newtonsoft.Json;
namespace GUI

{
    internal partial class Program
    {
        public class SystemSimulation
        {
            // Properties
            private AdjacencyMatrix planetarysystem;
            private DateTime date;

            private int timestep = 60 * 60;

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
            }*/

            /// <summary>
            /// Represents one timestep in the simulation
            /// </summary>
            public void Step()
            {

                date = date.AddSeconds(timestep);


                List<Body> bodies = planetarysystem.GetBodies();

                for (int i = 0; i < bodies.Count; i++)
                {
                    Body body = bodies[i];
                    if (!body.IsStar && body.Mass != 0)
                    {

                        double mass = body.Mass;

                        Vector resultant = planetarysystem.Resultant(i);

                        // Using F = ma
                        Vector acceleration = resultant.Scale(1 / mass);

                        Vector position = body.Position;
                        position = position.Scale(1000); // Converts to m

                        Vector velocity = body.Velocity;
                        velocity = velocity.Scale(1000); // Converts to m

                        // Calculate new position
                        Vector newpos = deltaPosition(position, velocity, acceleration, timestep);

                        // Calculate new velocity
                        body.Position = newpos;
                        planetarysystem.ReplaceBody(body, i);
                        planetarysystem.SingleBodyUpdate(i);
                        resultant = PlanetarySystem.Resultant(i);
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
                // x = vt
                Vector displacement = velocity.Scale(timestep);

                // 1/2 at^2
                Vector AccTimeSquared = acceleration.Scale(0.5 * timestep * timestep);

                // x = vt + 1/2 at^2
                Vector deltaP = displacement.Add(AccTimeSquared);
                Vector newpos = position.Add(deltaP);

                newpos = newpos.Scale(0.001); // Converts to km
                return newpos;
            }

            private static Vector deltaVelocity(Vector velocity, Vector acceleration, Vector newacceleration, double timestep)
            {
                Vector newvelocity = velocity;

                acceleration = acceleration.Add(newacceleration);
                acceleration = acceleration.Scale(0.5 * timestep);

                // v(n+1) = v(n) + at
                newvelocity = newvelocity.Add(acceleration);

                newvelocity = newvelocity.Scale(0.001); // Converts to km
                return newvelocity;
            }


        }
    }



}
