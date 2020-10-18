using System.IO;
using Vs.Graph.Abstractions.Structure;

namespace Vs.Graph.Abstractions.IO
{
    public interface IGraphReader
    {
        #region Methods

        /// <summary>
        /// Reads a graph from a given inputstream
        /// </summary>
        /// <param name="myGraph">the graph instance where the data will be stored</param>
        /// <param name="myInputStream">the stream to read the graph from</param>
        /// <returns>true if stream was successfully read</returns>
        bool Read(IGraph myGraph, FileStream myInputStream);

        #endregion
    }
}
