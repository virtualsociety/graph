namespace Vs.Graph.Parsers.GraphML
{
    /// <summary>
    /// Class defines the XML tokens which are used for parsing.
    /// 
    /// author:         Martin Junghanns (martin.junghanns@gmx.net)
    /// </summary>
    public class GraphMLTokens
    {
        #region graph data

        public const string GRAPHML = "graphml";
        public const string GRAPH = "graph";
        public const string VERTEX = "node";
        public const string EDGE = "edge";
        public const string EDGEDEFAULT = "edgedefault";
        public const string DIRECTED = "directed";
        public const string UNDIRECTED = "undirected";
        public const string SOURCE = "source";
        public const string TARGET = "target";

        #region attributes

        public const string DATA = "data";
        public const string ID = "id";
        public const string KEY = "key";
        public const string FOR = "for";
        public const string ATTRIBUTE_NAME = "attr.name";
        public const string ATTRIBUTE_TYPE = "attr.type";
        public const string DEFAULT = "default";

        public const string LON = "lon";
        public const string LAT = "lat";

        #endregion

        #endregion

        #region base types

        public const string STRING = "string";
        public const string INT = "int";
        public const string BOOLEAN = "boolean";
        public const string FLOAT = "float";
        public const string DOUBLE = "double";
        public const string LONG = "long";

        #endregion

        #region tags

        public const string NODE_END_TAG = "</node>";

        public const string EDGE_END_TAG = "</edge>";

        public const string DATA_END_TAG = "</data>";

        public const string END_GRAPHML_TAG = "</graphml>";
        public const string END_GRAPH_TAG = "</graph>";

        public const string COMMENT_BEGIN_TAG = "<!--";
        public const string COMMENT_END_TAG = "-->";

        #endregion
    }
}
