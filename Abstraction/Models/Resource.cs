﻿using Abstraction.Enumerators;
using Abstraction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstraction.Models {
    /// <summary>
    /// 
    /// </summary>
    public class Resource {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; private set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Specification Specification { get; private set; } = Specification.UNSPECIFIED;
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Resource() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="spec"></param>
        /// <param name="price"></param>
        public Resource(string desc, Specification spec, double price) {
            Description = desc;
            Specification = spec;
            Price = price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public Resource(ResourceDTO source) {
            Id = source.Id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        public Resource(int id, ResourceDTO source) {
            Id = id;
            Description = source.Description;
            Specification = source.Specification;
            Price = source.Price;
        }

    }
}
