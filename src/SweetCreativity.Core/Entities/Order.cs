using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameOrder { get; set; }

        public int Quantity { get; set; } 
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAtOrder { get; set; }
        public int CustomerNumber { get; set; }

        public string? CoverPath { get; set; } = "\\img\\user\\no_cover.jpg";
        [NotMapped]
        public IFormFile? CoverFile { get; set; }

        public virtual User? User { get; set; }
       public int? UserId { get; set; }
        public virtual Listing? Listing { get; set; }
        public int? ListingId { get; set; }

        [ForeignKey("StatusId")]

        public virtual Status? Status { get; set; }
        public int? StatusId { get; set; }//?
    }
}
