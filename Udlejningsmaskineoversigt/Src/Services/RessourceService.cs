using Abstraction.Interfaces;
using Abstraction.Models;

namespace Udlejningsmaskineoversigt.Src.Services {
    public class RessourceService : IRessourceService {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="bookings"></param>
        /// <returns></returns>
        public bool IsRented(Resource resource, IBookingRepository bookings) {
            return bookings.GetAllElements().Any(booking => booking.Resource.Id == resource.Id);
        }


    }
}
