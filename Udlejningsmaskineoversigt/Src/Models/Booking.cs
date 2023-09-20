namespace Udlejningsmaskineoversigt.Src.Models {
    public class Booking {

        public int Id { get; private set; } = -1;
        public DateTime Start, End;
        public Ressource Resource;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="resource"></param>
        /// <param name="bookings"></param>
        public Booking(DateTime start, DateTime end, Ressource resource, IEnumerable<Booking> bookings) {
            if (IsOverlapping(bookings)) throw new Exception("No overlap please");

            Resource = resource;
            Start = start;
            End = end;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="resource"></param>
        public Booking(int id, DateTime start, DateTime end, Ressource resource) {
            Id = id;
            Resource = resource;
            Start = start;
            End = end;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookings"></param>
        /// <returns></returns>
        public bool IsOverlapping(IEnumerable<Booking> bookings) {

            foreach (Booking other in bookings) {
                if (this.Resource != other.Resource) continue;
                bool start_overlapping = this.Start > other.Start && this.Start < other.End;
                bool end_overlapping = this.End < other.End && this.End > other.Start;

                if (start_overlapping || end_overlapping) return true;
            }

            return false;
        }

    }
}
