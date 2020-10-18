using System.Collections.Generic;
using Vs.Graph.Abstractions.Structure.Meta;

namespace Vs.Graph.Abstractions.Structure
{
    /// <summary>
    /// root interface for describing a graph structure.
    /// 

    /// </summary>
    public interface IGraph : IDBObject
    {
        #region Properties

        /// <summary>
        /// return all vertices
        /// </summary>
        IEnumerable<IVertex> Vertices { get; }

        /// <summary>
        /// return all edges
        /// </summary>
        IEnumerable<IEdge> Edges { get; }

        /// <summary>
        /// return number of vertices
        /// </summary>
        long VertexCount { get; }

        /// <summary>
        /// return number of edges
        /// </summary>
        long EdgeCount { get; }

        /// <summary>
        /// graph is directed or not
        /// </summary>
        bool IsDirected { get; }

        #endregion

        #region Methods

        #region Vertices

        #region Add

        /// <summary>
        /// Adds a vertex with the given uuid
        /// </summary>
        /// <param name="myUUID"></param>
        /// <returns></returns>
        IVertex AddVertex(string myUUID);

        /// <summary>
        /// Adds a vertex with the given attributes
        /// </summary>
        /// <param name="myAttributes"></param>
        /// <returns></returns>
        IVertex AddVertex(IDictionary<string, object> myAttributes);

        /// <summary>
        /// Adds a vertex to the graph.
        /// </summary>
        /// <param name="myVertex">The vertex</param>
        /// <returns></returns>
        bool AddVertex(IVertex myVertex);

        /// <summary>
        /// Add vertices to the graph.
        /// </summary>
        /// <param name="myVertices">The vertices to be added</param>
        /// <returns>The vertices which were not added</returns>
        IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> myVertices);

        #endregion

        #region Remove

        /// <summary>
        /// Removes a vertex from the graph if it exists.
        /// </summary>
        /// <param name="myVertex">The vertex to be removed</param>
        /// <returns>True if the vertex has been removed, else false</returns>
        bool RemoveVertex(IVertex myVertex);

        /// <summary>
        /// Removes vertices from the graph if they exist.
        /// </summary>
        /// <param name="myVertices"></param>
        /// <returns></returns>
        IEnumerable<IVertex> RemoveVertices(IEnumerable<IVertex> myVertices);

        #endregion

        #region Degree

        long GetDegree(IVertex myVertex);

        long GetInDegree(IVertex myVertex);

        long GetOutDegree(IVertex myVertex);

        #endregion

        #region Neighbourhood

        IEnumerable<IEdge> GetOutgoingEdges(IVertex myVertex);

        IEnumerable<IEdge> GetIncomingEdges(IVertex myVertex);

        #endregion

        #endregion

        #region Edges

        #region Add

        IEdge AddEdge(IVertex mySource, IVertex myTarget);

        IEdge AddEdge(string myUUID, IVertex mySource, IVertex myTarget);

        IEdge AddEdge(IVertex mySource, IVertex myTarget, IDictionary<string, object> myAttributes);

        IEdge AddEdge(string myUUID, IVertex mySource, IVertex myTarget, IDictionary<string, object> myAttributes);

        bool AddEdge(IEdge myEdge);

        IEnumerable<IEdge> AddEdges(IEnumerable<IEdge> myEdges);

        #endregion

        #region Remove

        bool RemoveEdge(IEdge myEdge);

        IEnumerable<IEdge> RemoveEdges(IEnumerable<IEdge> myEdges);

        #endregion

        #endregion

        #endregion

    }
}
