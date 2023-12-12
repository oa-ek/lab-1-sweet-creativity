
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class User : IdentityUser
    {
        //public string FirstName { get; set; } 
        public string? Email { get; set; } 
        public string? FullName { get; set; } 
        public int? PhoneNumber { get; set; }
        public string? UrlSocialnetwork { get; set; }
        public string? CoverPath { get; set; } = "\\img\\user\\no_cover.jpg";
        [NotMapped]
        public IFormFile? CoverFile { get; set; }

        //public virtual ICollection<Listing>? Listings { get; set; } // один до багатьох(1 користувач може мати багато оголошень)
        public List<Listing>? Listings { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Construction>? Constructions { get; set; }
        public virtual ICollection<Response>? Responses { get; set; }
    }
}