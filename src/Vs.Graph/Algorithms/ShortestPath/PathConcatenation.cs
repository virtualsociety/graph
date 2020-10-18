using System.Collections.Generic;
using Vs.Graph.Abstractions.Structure;

namespace Vs.Graph.Algorithms.ShortestPath
{
    public class PathConcatenation
    {
        public static List<IVertex> ConcatPath(IVertex myTarget, string myAttributeKey, bool myReverted = true)
        {
            var path = new List<IVertex>();

            var tmp = myTarget;

            while (tmp != null)
            {
                path.Add(tmp);

                tmp = (IVertex)tmp[myAttributeKey];
            }

            if (myReverted)
            {
                path.Reverse();
            }

            return path;
        }
    }
}
