using Abstraction.Models;

namespace Abstraction.Interfaces {
    public interface IBookingService {

        bool IsOverlapping(Booking new_booking, IBookingRepository bookings);

    }
}
