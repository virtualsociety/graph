using System.Collections.Generic;

namespace Vs.Graph.Abstractions.Structure.Meta
{
    /// <summary>
    /// Every object that can be "seen" from outside is an DBObject.
    /// 
    /// A DBObject has db specific attributes and also user defined attributes.
    /// 
    /// </summary>
    public interface IDBObject
    {
        #region Database-defined Properties

        string UUID { get; }

        #endregion


        #region User-defined Properties

        /// <summary>
        /// Returns all attributes for this graph associated object.
        /// </summary>
        IDictionary<string, object> Attributes { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets or sets the attribute-value associated with the specified key.
        /// </summary>
        /// <param name="myKey">the key of the element to be added or returned</param>
        /// <returns></returns>
        object this[string myKey] { get; set; }

        /// <summary>
        /// Removes the attribute-value with the specified key if it exists.
        /// </summary>
        /// <param name="myKey">the key of the element to remove</param>
        /// <returns></returns>
        bool RemoveAttribute(string myKey);

        #endregion
    }
}
