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
        public DateTime CreatedAtResponse { get; set; }

        public User UserId { get; set; }
        public Listing ListingId { get; set; }
        public Rating RatingId { get; set; }
    }
}
