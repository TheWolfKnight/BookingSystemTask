using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Models {
    public class BookingDTO {

        /// <summary>
        /// 
        /// </summary>
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
        public Resource Resource { get; set; }

        public BookingDTO(Booking source) {
            this.Id = source.Id;
            this.Start = source.Start;
            this.End = source.End;
            this.Resource = source.Resource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="resource"></param>
        public BookingDTO(DateTime start, DateTime end, Resource resource) {
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
        public BookingDTO(int id, DateTime start, DateTime end, Resource resource) {
            Id = id;
            Resource = resource;
            Start = start;
            End = end;
        }

    }
}
