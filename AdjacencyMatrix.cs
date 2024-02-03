using System.Diagnostics;

namespace GUI
{
    internal partial class Program
    {
        public class AdjacencyMatrix
        {
            // Properties 
            private double G = 6.67 * Math.Pow(10, -11);
            private List<List<Vector>> edges = new List<List<Vector>>();
            private List<Body> bodies = new List<Body>();

            // Constructor
            public AdjacencyMatrix()
            {

            }

            // Methods

            public void ReplaceBody(Body body, int index)
            {
                this.bodies[index] = body;
            }
            public List<Body> GetBodies()
            {
                return this.bodies;
            }

            // Add Body
            public void AddBody(Body a)
            {
                bodies.Add(a);
                edges = Expand(edges, bodies.Count);
                //Console.WriteLine($"Edges is {edges.Count} by {edges[0].Count}");
            }

            // Update edges when a body is added
            private static List<List<Vector>> Expand(List<List<Vector>> edges, int dimensions)
            {
                Vector defaultvector = new Vector(0, 0);
                List<Vector> newcolumn = new List<Vector>();
                edges.Add(newcolumn);

                foreach (List<Vector> column in edges)
                {
                    while (column.Count < dimensions)
                    {
                        column.Add(defaultvector);
                    }
                }

                return edges;
            }

            // Update Forces
            public void Update()
            {
                for (int i = 0; i < bodies.Count; i++)
                {
                    for (int j = 0; j < bodies.Count; j++)
                    {
                        if (i == j)
                        {
                            edges[i][j] = new Vector(0, 0);
                        }
                        else
                        {
                            Body a = bodies[i];
                            Body b = bodies[j];
                            double masses = a.Mass * b.Mass;
                            Vector rvector = a.Position.VectorTo(b.Position);
                            double rmod = rvector.Modulus();
                            //Debug.WriteLine($"Distance between {a.Name} and {b.Name} = {rmod}");
                            double rsquared = Math.Pow(rmod, 2);
                            // Calculate Unit vector of r
                            Vector runit = rvector.Unit();
                            // Calculate scalar coefficient
                            double scalarcoefficient = (G * masses) / rsquared;
                            // Force
                            Vector force = runit.Scale(scalarcoefficient);
                            //Console.WriteLine($"bodies.Count: {bodies.Count}, i: {i}, j: {j}");
                            edges[i][j] = force;
                        }

                    }
                }

            }

            public Vector Resultant(int index)
            {
                Vector resultantforce = new Vector(0, 0);
               
                foreach (List<Vector> column in edges)
                {
                    resultantforce = resultantforce.Add(column[index]);
                }

                Debug.WriteLine($"Force on {bodies[index].Name}: {resultantforce.Modulus()}");
                return resultantforce;

            }

            public void Data()
            {
                for (int i = 0; i < bodies.Count; i++)
                {
                    Body a = bodies[i];

                    for (int j = 0; j < bodies.Count; j++)
                    {
                        Body b = bodies[j];
                        if (i != j)
                        {
                            Debug.WriteLine($"Force between {a.Name} and {b.Name} is:");
                            edges[i][j].Data();

                        }

                    }
                    //a.Position.Data();
                    Debug.WriteLine($"Resultant force on {a.Name} is:");
                    this.Resultant(i).Data();
                }
            }


        }
    }
}