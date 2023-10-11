
using Abstraction.Interfaces;
using Abstraction.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Udlejningsmaskineoversigt.Data;
using Udlejningsmaskineoversigt.Src.Services;

namespace Udlejningsmaskineoversigt.Src.Repositorys
{
    /// <summary>
    /// The repository for the Resources
    /// </summary>
    public class RessourceRepository : IRescourceRepository
    {

        private readonly IRessourceService _ressourceServices = null!;
        private readonly IBookingRepository _bookingRepo = null!;

        private readonly UdlejningDataContext _Ctx = new UdlejningDataContext();

        /// <summary>
        /// The constructor
        /// </summary>
        public RessourceRepository(IRessourceService ressourceService, IBookingRepository bookingRepository)
        {
            _bookingRepo = bookingRepository;
            _ressourceServices = ressourceService;
        }

        /// <summary>
        /// Gets all Resources in the database
        /// </summary>
        /// <returns> An enumerable with the databases Resources </returns>
        IEnumerable<ResourceDTO> IRescourceRepository.GetAllElements() {
            return _Ctx.Resources.AsNoTracking().Select(r => new ResourceDTO(r));
        }

        /// <summary>
        /// Get a specific Resource by id
        /// </summary>
        /// <param name="id"> The id of the resource </param>
        /// <returns> An instance of Resource </returns>
        /// <exception cref="Exception"> If the item cannot be found, throw exception </exception>
        ResourceDTO IRescourceRepository.GetById(int id) {
            try {
                Resource resource = _Ctx.Resources.AsNoTracking().First(re => re.Id == id);
                ResourceDTO result = new ResourceDTO(resource);
                return result;
            } catch (Exception) {
                throw new Exception($"Could not find item with id: {id}");
            }
        }

        /// <summary>
        /// Commits a Resource to the database
        /// </summary>
        /// <param name="resource"> The instance of Resource to be inserted </param>
        void IRescourceRepository.Add(ResourceDTO resource) {
            Resource result = new Resource(resource);
            _Ctx.Resources.Add(result);
            _Ctx.SaveChanges();
        }

        /// <summary>
        /// Remove a Resource from the database
        /// </summary>
        /// <param name="id"> The id of the Resource to be deleted </param>
        /// <exception cref="Exception"> Thrown if the id cannot be found in the database </exception>
        void IRescourceRepository.Delete(int id) {
            try {
                Resource to_be_deleted = _Ctx.Resources.First(re => re.Id == id);

                if (_ressourceServices.IsRented(to_be_deleted, _bookingRepo)) {
                    throw new Exception("Ressource is booked");
                }

                _Ctx.Resources.Remove(to_be_deleted);
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
        void IRescourceRepository.Update(ResourceDTO resource) {
            try {
                Resource old = _Ctx.Resources.First(re => re.Id == resource.Id);
                old.Price = resource.Price;
                old.Specification = resource.Specification;
                old.Description = resource.Description;

                _Ctx.Resources.Update(old);

                _Ctx.SaveChanges();
            } catch (Exception) {
                throw new Exception($"Could not find the item with id: {resource.Id}");
            }
        }
    }
}
