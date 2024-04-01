﻿using Newtonsoft.Json;
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

            public void Run(int timestep, int length, Graphics g, SimulationDisplay form, Action<Action> asyncaction, bool uselog)
            {

                int size = 20;

                for (int i = 0; i < length; i++)
                {

                    //BufferedGraphicsContext context;
                    //context = new BufferedGraphicsContext();

                    List<Body> bodies = PlanetarySystem.GetBodies();
                    List<Vector> coordinates = new List<Vector>();
                    if (uselog)
                    {
                        coordinates = converter.ConvertCoordsLog(PlanetarySystem);
                    }
                    else
                    {
                        coordinates = converter.ConvertCoordsScalar(PlanetarySystem, 0.000001);
                    }

                    asyncaction(form.Refresh);

                    for (int bodyindex = 0; bodyindex < bodies.Count; bodyindex++)
                    {
                        //Point point = new Point(0, 0);
                        //Size s = new Size(1000, 1000);
                        //g.CopyFromScreen(point, point, s);


                        Vector pos = coordinates[bodyindex];
                        Appearance colours = PlanetarySystem.GetBodies()[bodyindex].Colours;
                        Pen p = new Pen(colours.Primary, 5);
                        Brush b = new SolidBrush(colours.Secondary);
                        Pen arrow = new Pen(colours.Secondary, 3);


                        Vector velocity = bodies[bodyindex].Velocity;
                        float startx = (float)pos.X;
                        float starty = (float)pos.Y;
                        float endx = (float)pos.Add(velocity).X;
                        float endy = (float)pos.Add(velocity).Y;
                        g.DrawLine(arrow, startx, starty, endx, endy);


                        g.FillEllipse(b, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
                        g.DrawEllipse(p, (float)pos.X - (size / 2), (float)pos.Y - (size / 2), size, size);
                    }

                    this.Step(timestep);

                    DateTime datetime = form.GetDate();
                    datetime = datetime.AddSeconds(timestep);
                    form.UpdateLabel(datetime.ToString("yyyy-MM-dd"));

                    //context.Dispose();

                    // make this consistent
                    //Thread.Sleep(10);
                }
            }


            private void Step(int timestep)
            {
                //PlanetarySystem.Update();
                List<Body> bodies = PlanetarySystem.GetBodies();

                for (int i = 0; i < bodies.Count; i++)
                {

                    // Now using Verlet method

                    Body body = bodies[i];
                    if (!body.IsStar)
                    {
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


                        newpos = deltaPosition(position, velocity, acceleration, timestep);


                        // Calculate new velocity

                        body.Position = newpos;
                        PlanetarySystem.ReplaceBody(body, i);

                        PlanetarySystem.SingleBodyUpdate(i);

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

                        PlanetarySystem.ReplaceBody(body, i);
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