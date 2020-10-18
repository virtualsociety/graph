﻿using System.Threading.Tasks;
using Vs.Graph.Abstractions.Structure;

namespace Vs.Graph.Algorithms.ShortestPath
{
    public class ABreadthFirstSearch
    {
        protected enum Color
        {
            GREEN, RED, WHITE
        }
        /// <summary>
        /// Attribute key .. Used to store state of the vertex
        /// </summary>
        protected static string COLOR_ATTRIBUTE_KEY = "__color";
        /// <summary>
        /// Attribute key .. used to store the distance of the vertex
        /// </summary>
        protected static string DISTANCE_ATTRIBUTE_KEY = "__dist";

        /// <summary>
        /// Attribute key .. Used to store the reference to the predecessor at a vertex
        /// </summary>
        protected static string PREDECESSOR_ATTRIBUTE_KEY = "__pred";

        public static void InitGraph(IGraph myGraph)
        {
            // do this in parallel, it's data parallelism
            Parallel.ForEach(myGraph.Vertices, v =>
            {
                // used for benchmarks
                //v.IsVisited = false;
                //v.Predecessor = null;
                //v.Distance = Int32.MaxValue;

                v[COLOR_ATTRIBUTE_KEY] = Color.WHITE;
                v[PREDECESSOR_ATTRIBUTE_KEY] = null;
                v[DISTANCE_ATTRIBUTE_KEY] = int.MaxValue;
            });
        }

    }
}
