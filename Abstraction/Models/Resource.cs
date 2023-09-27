using Abstraction.Enumerators;
using Abstraction.Models;

namespace Abstraction.Models {
    /// <summary>
    /// 
    /// </summary>
    public class Resource {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; private set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Specification Specification { get; private set; } = Specification.UNSPECIFIED;
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="spec"></param>
        /// <param name="price"></param>
        public Resource(string desc, Specification spec, double price) {
            Description = desc;
            Specification = spec;
            Price = price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public Resource(ResourceDTO source) {
            Id = source.Id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        public Resource(int id, ResourceDTO source) {
            Id = id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

    }
}
