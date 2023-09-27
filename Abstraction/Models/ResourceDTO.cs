using Abstraction.Enumerators;

namespace Abstraction.Models {
    /// <summary>
    /// 
    /// </summary>
    public class ResourceDTO {

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Specification Specification { get; set; } = Specification.UNSPECIFIED;
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ResourceDTO() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <param name="specification"></param>
        /// <param name="price"></param>
        public ResourceDTO(string description, Specification specification, double price) {
            Description = description;
            Specification = specification;
            Price = price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        public ResourceDTO(int id, ResourceDTO source) {
            Id = id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }
    }
}
