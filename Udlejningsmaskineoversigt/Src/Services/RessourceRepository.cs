
using Abstraction.Interfaces;
using Abstraction.Models;

namespace Udlejningsmaskineoversigt.Src.Services {
    /// <summary>
    /// The repository for the Resources
    /// </summary>
    public class RessourceRepository : IRescourceRepository {

        private readonly static List<ResourceDTO> _Ressources = new List<ResourceDTO>();
        private static int _Id = -1;

        /// <summary>
        /// The constructor
        /// </summary>
        public RessourceRepository() {}

        /// <summary>
        /// Gets all Resources in the database
        /// </summary>
        /// <returns> An enumerable with the databases Resources </returns>
        public IEnumerable<ResourceDTO> GetAllElements() {
            return _Ressources;
        }

        /// <summary>
        /// Get a specific Resource by id
        /// </summary>
        /// <param name="id"> The id of the resource </param>
        /// <returns> An instance of Resource </returns>
        /// <exception cref="Exception"> If the item cannot be found, throw exception </exception>
        public ResourceDTO GetById(int id) {
            ResourceDTO result = _Ressources.Find(re => re.Id == id) ?? throw new Exception($"Could not find item with id: {id}");
            return result;
        }

        /// <summary>
        /// Commits a Resource to the database
        /// </summary>
        /// <param name="resource"> The instance of Resource to be inserted </param>
        public void Add(ResourceDTO resource) {
            ResourceDTO result = new ResourceDTO(++_Id, resource);
            _Ressources.Add(result);
        }

        /// <summary>
        /// Remove a Resource from the database
        /// </summary>
        /// <param name="id"> The id of the Resource to be deleted </param>
        /// <exception cref="Exception"> Thrown if the id cannot be found in the database </exception>
        public void Delete(int id) {
            ResourceDTO to_be_deleted = _Ressources.Find(re => re.Id == id) ?? throw new Exception($"Could not find the item with id: {id}");
            _Ressources.Remove(to_be_deleted);
        }

        /// <summary>
        /// Updates a Resource in the database
        /// </summary>
        /// <param name="resource"> The resource to be updated </param>
        /// <exception cref="Exception"> Thrown if no Resource with given id can be found </exception>
        public void Update(ResourceDTO resource) {
            ResourceDTO old = _Ressources.Find(re => re.Id == resource.Id) ?? throw new Exception($"Could not find the item with id: {resource.Id}");;
            int idx = _Ressources.IndexOf(old);
            _Ressources[idx] = resource;
        }
    }
}
