using System.Data;
using Abstraction.Models;

namespace Abstraction.Interfaces
{
    /// <summary>
    /// Interface for a rescource repository
    /// </summary>
    public interface IRescourceRepository
    {
        /// <summary>
        /// Return all elements from the database
        /// </summary>
        /// <returns> An enumerable of Resources </returns>
        IEnumerable<ResourceDTO> GetAllElements();

        /// <summary>
        /// Gets a specific element from the database
        /// </summary>
        /// <param name="id"> The id of the element that to get </param>
        /// <returns> An instance of Resource </returns>
        ResourceDTO GetById(int id);

        /// <summary>
        /// Commits a Resource to the database
        /// </summary>
        /// <param name="resource"> The new Resource </param>
        void Add(ResourceDTO resource);
        /// <summary>
        /// Removes a Resource from the database
        /// </summary>
        /// <param name="id"> The id of the Resource to be deleted </param>
        void Delete(int id);
        /// <summary>
        /// Updates a Resource on the database
        /// </summary>
        /// <param name="resource"> The Resource data for the update </param>
        void Update(ResourceDTO resource);

    }
}
