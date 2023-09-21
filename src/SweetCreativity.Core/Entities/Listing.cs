﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class Listing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        //public string ImageListing { get; set; } //?
        public string Description { get; set; }
        public string Product { get; set; }
        public DateTime CreatedAtListing { get; set; } //?
        public string Location { get; set; }
        public decimal Price { get; set; }
        //public User UserId { get; set; } //??????
        public int Weight { get; set; }

        public virtual User? User { get; set; } //з таблички юзер витягується юзкр id
        public int? UserId { get; set; }
        public virtual Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ListingImage> ListingImages { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}