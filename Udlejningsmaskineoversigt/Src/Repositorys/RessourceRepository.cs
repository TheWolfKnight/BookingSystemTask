
using Abstraction.Interfaces;
using Abstraction.Models;
using Microsoft.EntityFrameworkCore;
using Udlejningsmaskineoversigt.Data;

namespace Udlejningsmaskineoversigt.Src.Repositorys
{
    /// <summary>
    /// The repository for the Resources
    /// </summary>
    public class RessourceRepository : IRescourceRepository
    {

        private Services.BookingService _services = new Services.BookingService();
        private IBookingRepository _bookingRepository;

        private UdlejningDataContext _Ctx = new UdlejningDataContext();

        /// <summary>
        /// The constructor
        /// </summary>
        public RessourceRepository(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Gets all Resources in the database
        /// </summary>
        /// <returns> An enumerable with the databases Resources </returns>
        public IEnumerable<ResourceDTO> GetAllElements() {
            return _Ctx.Resources.Select(r => new ResourceDTO(r));
        }

        /// <summary>
        /// Get a specific Resource by id
        /// </summary>
        /// <param name="id"> The id of the resource </param>
        /// <returns> An instance of Resource </returns>
        /// <exception cref="Exception"> If the item cannot be found, throw exception </exception>
        public ResourceDTO GetById(int id) {
            try {
                ResourceDTO result = GetAllElements().First(re => re.Id == id);
                return result;
            } catch (Exception) {
                throw new Exception($"Could not find item with id: {id}");
            }
        }

        /// <summary>
        /// Commits a Resource to the database
        /// </summary>
        /// <param name="resource"> The instance of Resource to be inserted </param>
        public void Add(ResourceDTO resource) {
            Resource result = new Resource(resource);
            _Ctx.Resources.Add(result);
            _Ctx.SaveChanges();
        }

        /// <summary>
        /// Remove a Resource from the database
        /// </summary>
        /// <param name="id"> The id of the Resource to be deleted </param>
        /// <exception cref="Exception"> Thrown if the id cannot be found in the database </exception>
        public void Delete(int id) {
            try {
                ResourceDTO to_be_deleted = GetAllElements().First(re => re.Id == id);
                if (_services.IsRented(to_be_deleted, _bookingRepository)) { throw new Exception($"The resource with the id: {id} is currently being used in a booking, and can therefore not be deleted.");}
                Resource result = new Resource(to_be_deleted);
                _Ctx.Resources.Remove(result);
                _Ctx.SaveChanges();
            } catch (Exception) {
                throw new Exception($"Could not find the item with id: {id}");
            }
        }

        /// <summary>
        /// Updates a Resource in the database
        /// </summary>
        /// <param name="resource"> The resource to be updated </param>
        /// <exception cref="Exception"> Thrown if no Resource with given id can be found </exception>
        public void Update(ResourceDTO resource) {
            try {
                ResourceDTO old = GetAllElements().First(re => re.Id == resource.Id);
                old = resource;
                _Ctx.Resources.Update(new Resource(old));
                _Ctx.SaveChanges();
            } catch (Exception) {
                throw new Exception($"Could not find the item with id: {resource.Id}");
            }
        }
    }
}
