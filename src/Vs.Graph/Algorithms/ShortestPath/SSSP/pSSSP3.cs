﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using Vs.Graph.Abstractions.Structure;

namespace Vs.Graph.Algorithms.ShortestPath.SSSP
{
    public class pSSSP3 : ABreadthFirstSearch
    {
        public static void Search(IGraph myGraph, IVertex mySource, Func<IVertex, bool> myMatchingFunc = null)
        {
            Search(myGraph, mySource, false, myMatchingFunc);
        }

        /// <summary>
        /// BFS for st-connectivity
        /// </summary>
        /// <param name="myGraph"></param>
        /// <param name="mySource"></param>
        /// <param name="myTarget"></param>
        /// <param name="myMatchingFunc"></param>
        /// <returns></returns>
        public static void Search(IGraph myGraph, IVertex mySource, bool myInitGraph, Func<IVertex, bool> myMatchingFunc = null)
        {
            #region Init

            if (myInitGraph)
            {
                InitGraph(myGraph);
            }
            mySource.IsVisited = true;
            mySource.Distance = 0;

            // bool if matching function has to be called
            var doMatching = myMatchingFunc != null;

            // use Concurrent Queue for parallel access
            IEnumerable<IVertex> from = new List<IVertex>();
            IEnumerable<IVertex> to = new List<IVertex>();

            var lockObj = new object();

            #endregion

            #region BFS

            // enqueue the source vertex
            ((List<IVertex>)from).Add(mySource);

            while (from.Any())
            {
                to = new List<IVertex>();

                Parallel.ForEach(
                    // the values to be aggregated
                    from,
                    // local initial partial result
                    () => new List<IVertex>(),
                    // loop body
                    (u, loopState, partialResult) =>
                    {
                        //Parallel.ForEach<IEdge>(u.OutgoingEdges, outEdge =>
                        foreach (var outEdge in u.OutgoingEdges)
                        {
                            // neighbour node
                            var v = outEdge.Target;

                            if (!v.IsVisited) // not the target
                            {
                                // set as visited (Color.RED)
                                v.IsVisited = true;
                                // set the predecessor
                                v.Predecessor = u;
                                //increment the distance
                                v.Distance = u.Distance + 1;
                                // and enqueue that node (if matching condition == true)
                                if (doMatching)
                                {
                                    // matches condition?
                                    if (myMatchingFunc(v))
                                    {
                                        // matches, add to local set
                                        partialResult.Add(v);
                                    }
                                    // do nothing
                                }
                                else
                                {
                                    // no matching necessary, add to local set
                                    partialResult.Add(v);
                                }
                            }
                        }

                        return partialResult;
                    },
                    //the final step of each local context
                    (localPartialSet) =>
                    {
                        lock (lockObj)
                        {
                            to = to.Union(localPartialSet);
                            //to.AddRange(localPartialSet);
                        }
                    });

                // switch queues
                from = to;
            }

            #endregion
        }
    }
}
