using System;
using Vs.Graph.Structure;
using System.Collections.Generic;
using Vs.Graph.Algorithms.ShortestPath;
using Vs.Graph.Parsers.GraphML;
using System.IO;
using System.Linq;

namespace Vs.Graph.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Database();
            g["label"] = "Germany";

            #region cities

            var Frankfurt = new Vertex(Guid.NewGuid().ToString(),new Dictionary<string, object>()
                {
                 {"id", Guid.NewGuid().ToString()},
                 {"label", "Frankfurt"}
                });
            var Mannheim = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Mannheim"}
                });

            var Wuerzburg = new Vertex(Guid.NewGuid().ToString(),new Dictionary<string, object>()
                {
                 {"label", "Wuerzburg"}
                });

            var Stuttgart = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Stuttgart"}
                });

            var Karlsruhe = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Karlsruhe"}
                });

            var Erfurt = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Erfurt"}
                });

            var Nuernberg = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Nuernberg"}
                });

            var Kassel = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Kassel"}
                });

            var Augsburg = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Augsburg"}
                });

            var Muenchen = new Vertex(Guid.NewGuid().ToString(), new Dictionary<string, object>()
                {
                 {"label", "Muenchen"}
                });


            g.AddVertex(Frankfurt);
            g.AddVertex(Mannheim);
            g.AddVertex(Wuerzburg);
            g.AddVertex(Stuttgart);
            g.AddVertex(Karlsruhe);
            g.AddVertex(Erfurt);
            g.AddVertex(Nuernberg);
            g.AddVertex(Kassel);
            g.AddVertex(Augsburg);
            g.AddVertex(Muenchen);

            #endregion

            #region roads

            g.AddEdge(new Edge(Frankfurt, Mannheim, new Dictionary<string, object>()
                {
                    { "s", 85 }
                }));

            g.AddEdge(new Edge(Frankfurt, Wuerzburg, new Dictionary<string, object>()
                {
                    { "s", 127 }
                }));

            g.AddEdge(new Edge(Frankfurt, Kassel, new Dictionary<string, object>()
                {
                    { "s", 172 }
                }));

            g.AddEdge(new Edge(Mannheim, Karlsruhe, new Dictionary<string, object>()
                {
                    { "s", 80 }
                }));

            g.AddEdge(new Edge(Wuerzburg, Erfurt, new Dictionary<string, object>()
                {
                    { "s", 186 }
                }));

            g.AddEdge(new Edge(Wuerzburg, Nuernberg, new Dictionary<string, object>()
                {
                    { "s", 103 }
                }));

            g.AddEdge(new Edge(Nuernberg, Stuttgart, new Dictionary<string, object>()
                {
                    { "s", 183 }
                }));

            g.AddEdge(new Edge(Nuernberg, Muenchen, new Dictionary<string, object>()
                {
                    { "s", 167 }
                }));

            g.AddEdge(new Edge(Karlsruhe, Augsburg, new Dictionary<string, object>()
                {
                    { "s", 250 }
                }));

            g.AddEdge(new Edge(Augsburg, Muenchen, new Dictionary<string, object>()
                {
                    { "s", 84 }
                }));

            g.AddEdge(new Edge(Kassel, Muenchen, new Dictionary<string, object>()
                {
                    { "s", 502 }
                }));

            #endregion


            foreach (var edge in Frankfurt.OutgoingEdges)
            {
                Console.WriteLine(edge.Target["label"] + " " + edge["s"] + "km");
            }

            Console.WriteLine(g.VertexCount);
            Console.WriteLine(g.EdgeCount);

            var path = BreadthFirstSearch.Search(g, Frankfurt, Muenchen);

            foreach (var v in path)
            {
                Console.WriteLine(v["label"]);
            }

            // Write to graph ml file
            Console.WriteLine($"Write: {g.VertexCount} vertices and {g.EdgeCount} edges.");
            GraphMLWriter writer = new GraphMLWriter(true);
            writer.AddAttribute("label", "string", "label", "node");
            writer.AddAttribute("s", "string", "s", "edge");
            writer.Write(g, "germany.graphml");

            // Read graph ml file
            GraphMLReader reader = new GraphMLReader();
            FileStream stream = new FileStream("germany.graphml", FileMode.Open);

            var g2 = new Database();
            reader.Read(g2,stream);

            Console.WriteLine($"Read: {g2.VertexCount} vertices and {g2.EdgeCount} edges.");
            Console.ReadKey();
        }
    }
}
