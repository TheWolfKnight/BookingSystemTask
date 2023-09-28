using Abstraction.Interfaces;
using Abstraction.Models;

namespace Udlejningsmaskineoversigt.Src.Services {
    public class BookingService : IBookingService {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="new_booking"></param>
        /// <param name="bookings"></param>
        /// <returns></returns>
        public bool IsOverlapping(Booking new_booking, IBookingRepository bookings) {

            foreach (BookingDTO other in bookings.GetAllElements()) {
                if (new_booking.Resource != other.Resource) continue;
                bool start_overlapping = new_booking.Start > other.Start && new_booking.Start < other.End;
                bool end_overlapping = new_booking.End < other.End && new_booking.End > other.Start;

                if (start_overlapping || end_overlapping) return true;
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="bookings"></param>
        /// <returns></returns>
        public bool IsRented(ResourceDTO resource, IBookingRepository bookings)
        {
            return bookings.GetAllElements().Any(booking => booking.Resource.Id == resource.Id);
        }
    }
}
