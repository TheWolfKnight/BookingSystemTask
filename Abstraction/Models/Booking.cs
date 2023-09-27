
using Abstraction.Models;

namespace Abstraction.Models {
    /// <summary>
    /// 
    /// </summary>
    public class Booking {

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Resource Resource { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public Booking() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="resource"></param>
        public Booking(DateTime start, DateTime end, Resource resource) {
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
        public Booking(int id, DateTime start, DateTime end, Resource resource) {
            Id = id;
            Resource = resource;
            Start = start;
            End = end;
        }


    }
}
