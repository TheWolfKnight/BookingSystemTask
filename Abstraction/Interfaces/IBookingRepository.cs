using Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interfaces {
    public interface IBookingRepository {

        /// <summary>
        /// Return all elements from the database
        /// </summary>
        /// <returns> An enumerable of BookingDTO </returns>
        IEnumerable<BookingDTO> GetAllElements();

        /// <summary>
        /// Gets a specific element from the database
        /// </summary>
        /// <param name="id"> The id of the element that to get </param>
        /// <returns> An instance of BookingDTO </returns>
        BookingDTO GetById(int id);

        /// <summary>
        /// Commits a BookingDTO to the database
        /// </summary>
        /// <param name="resource"> The new BookingDTO </param>
        void Add(BookingDTO resource);
        /// <summary>
        /// Removes a BookingDTO from the database
        /// </summary>
        /// <param name="id"> The id of the BookingDTO to be deleted </param>
        void Delete(int id);
        /// <summary>
        /// Updates a BookingDTO on the database
        /// </summary>
        /// <param name="resource"> The BookingDTO data for the update </param>
        void Update(BookingDTO resource);


    }
}
