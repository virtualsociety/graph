using System.Collections.Generic;
using Vs.Graph.Abstractions.Structure.Meta;

namespace Vs.Graph.Abstractions.Structure
{
    public interface IVertex : IDBObject
    {
        #region used for benchmarks

        bool IsVisited { get; set; }

        int Distance { get; set; }

        IVertex Predecessor { get; set; }

        #endregion

        #region Graph

        /// <summary>
        /// Get/Set the corresponding graph.
        /// </summary>
        IGraph Graph { get; set; }

        #endregion

        #region Degree

        /// <summary>
        /// Get the total number of edges.
        /// </summary>
        long Degree { get; }
        /// <summary>
        /// Get the number of incoming edges.
        /// </summary>
        long InDegree { get; }
        /// <summary>
        /// Get the number of outgoing edges.
        /// </summary>
        long OutDegree { get; }

        #endregion

        #region Neighbourhood

        /// <summary>
        /// Get all incoming edges.
        /// </summary>
        IEnumerable<IEdge> IncomingEdges { get; }
        /// <summary>
        /// Get all outgoing edges.
        /// </summary>
        IEnumerable<IEdge> OutgoingEdges { get; }

        #endregion
    }
}
