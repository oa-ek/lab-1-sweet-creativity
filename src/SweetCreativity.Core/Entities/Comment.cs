using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TextComment { get; set; }
        public DateTime CreatedAtResponse { get; set; } = DateTime.Now;

        public virtual User? User { get; set; }
        public string? UserId { get; set; }
        public virtual Construction? Construction { get; set; }
        public int? ConstructionId { get; set; }
        //public Rating RatingId { get; set; }

    }
}
