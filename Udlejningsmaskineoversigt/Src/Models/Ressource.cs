using Udlejningsmaskineoversigt.Src.Enumerators;

namespace Udlejningsmaskineoversigt.Src.Models {
    public class Ressource {
        public int Id { get; private set; } = -1;
        public string Description { get; private set; } = null!;
        public Specification Specification { get; private set; } = Specification.UNSPECIFIED;
        public Double Price { get; private set; }

        public Ressource(string description, Specification specification, double price) {
            Description = description;
            Specification = specification;
            Price = price;
        }

        public Ressource(int id, string description, Specification specification, double price) {
            Id = id;
            Description = description;
            Specification = specification;
            Price = price;
        }

        public Ressource(int id, Ressource source) {
            Id = id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

    }
}
