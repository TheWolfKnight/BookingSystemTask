using Abstraction.Interfaces;
using Abstraction.Models;
using Udlejningsmaskineoversigt.Data;

namespace Udlejningsmaskineoversigt.Src.Repositorys {
    public class BookingRepository : IBookingRepository {

        private UdlejningDataContext _Ctx = new UdlejningDataContext();

        public void Add(BookingDTO resource) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            try
            {
                Booking booking = _Ctx.Bookings.Find(id);

                if (booking == null)
                {
                    throw new Exception($"There is no booking with the id {id}");
                }

                _Ctx.Bookings.Remove(booking);
                _Ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"An error has occurred while deleting the booking with id {id}: {ex.Message}");
            }

        }

        public IEnumerable<BookingDTO> GetAllElements() {
            return _Ctx.Bookings.Select(b => new BookingDTO(b));
        }

        public BookingDTO GetById(int id) {
            try {
                Booking booking = _Ctx.Bookings.First(b => b.Id == id);
                return new BookingDTO(booking);
            } catch (Exception) {
                throw new Exception($"Could not find the element with id: {id}");
            }
        }

        public void Update(BookingDTO booking) {
            try {
                Booking old = _Ctx.Bookings.First(b => b.Id == booking.Id);
                old = new Booking(booking);

                _Ctx.Bookings.Update(old);
                _Ctx.SaveChanges();

            } catch (Exception) {
                throw new Exception($"Could not find the element with id: {booking.Id}");
            }
        }
    }
}
