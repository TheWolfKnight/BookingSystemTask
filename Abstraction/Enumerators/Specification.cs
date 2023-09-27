using System.ComponentModel;

namespace Abstraction.Enumerators {
    /// <summary>
    /// The type of the resource
    /// </summary>
    public enum Specification {
        /// <summary>
        /// The resources type is not known
        /// </summary>
        UNSPECIFIED,

        /// <summary>
        /// The resource is used for heavy construction
        /// </summary>
        HEAVY_CONSTRUCTION,

        /// <summary>
        /// The resource is used for light construction
        /// </summary>
        LIGHT_CONSTRUCTION,

    }
}
