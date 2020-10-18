using Vs.Graph.Abstractions.Structure;

namespace Vs.Graph.Abstractions.IO
{
    public interface IGraphWriter
    {
        bool Write(IGraph myGraph, string myLocation);
    }
}
