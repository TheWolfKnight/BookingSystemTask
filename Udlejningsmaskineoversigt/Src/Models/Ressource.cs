using Udlejningsmaskineoversigt.Src.Enumerators;

namespace Udlejningsmaskineoversigt.Src.Models {
    public class Ressource {
        public int Id { get; private set; } = -1;
        public string Description { get; private set; } = null!;
        public Specification Specification { get; private set; } = Specification.UNSPECIFIED;
        public double Price { get; private set; }

        public Ressource(string desc, Specification spec, double price) {
            Description = desc;
            Specification = spec;
            Price = price;
        }

        public Ressource(RessourceDTO source) {
            Id = source.Id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

        public Ressource(int id, RessourceDTO source) {
            Id = id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

    }
}
