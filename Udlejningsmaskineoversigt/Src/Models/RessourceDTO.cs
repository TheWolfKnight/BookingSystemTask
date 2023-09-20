using Udlejningsmaskineoversigt.Src.Enumerators;

namespace Udlejningsmaskineoversigt.Src.Models {
    public class RessourceDTO {
        public int Id { get; private set; } = -1;
        public string Description { get; set; } = null!;
        public Specification Specification { get; set; } = Specification.UNSPECIFIED;
        public double Price { get; set; }

        public RessourceDTO() {}

        public RessourceDTO(string description, Specification specification, double price) {
            Description = description;
            Specification = specification;
            Price = price;
        }

        public RessourceDTO(int id, RessourceDTO source) {
            Id = id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }
    }
}
