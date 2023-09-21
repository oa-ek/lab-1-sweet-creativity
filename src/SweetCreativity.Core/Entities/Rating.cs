using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RatingPoint { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        //public int ResponseId { get; set; }
        //public Response ResponseId { get; set; }
    }
}
