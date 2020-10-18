using Vs.Graph.Abstractions.Structure.Meta;

namespace Vs.Graph.Abstractions.Structure
{
    public interface IEdge : IDBObject
    {
        #region Properties

        IGraph Graph { get; set; }

        IVertex Source { get; }

        IVertex Target { get; }

        #endregion
    }
}
