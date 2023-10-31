using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TextResponse { get; set; }
        public DateTime CreatedAtResponse { get; set; } = DateTime.Now;

        public virtual User? User { get; set; }
        public int? UserId { get; set; }
        public virtual Listing? Listing { get; set; }
        public int? ListingId { get; set; }
        //public Rating RatingId { get; set; }

    }
}
