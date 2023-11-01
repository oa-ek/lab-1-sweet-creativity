using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Entities
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string StatusName { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
        
        //public bool IsComplicted { get; set; }
        //[InverseProperty("Status")]
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
