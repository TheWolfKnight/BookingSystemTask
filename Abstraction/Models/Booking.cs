
using Abstraction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstraction.Models {
    /// <summary>
    /// 
    /// </summary>
    public class Booking {

        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
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

        public Booking(BookingDTO source) {
            this.Id = source.Id;
            this.Start = source.Start;
            this.End = source.End;
            this.Resource = source.Resource;
        }
    }
}
