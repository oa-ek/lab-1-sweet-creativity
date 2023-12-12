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
    public class Construction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserSellerId { get; set; }

        public string? NameConstruction { get; set; }
        public string? Form { get; set; }
        public string? ViewDescription { get; set; }
        public string? Ingredients { get; set; }

        public int Quantity { get; set; }
        
        public DateTime CreatedAtOrder { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; } = DateTime.Now;


        public string? CoverPath { get; set; } = "\\img\\user\\no_cover.jpg";
        [NotMapped]
        public IFormFile? CoverFile { get; set; }

        public string? Additionaly { get; set; }
        public int CustomerNumber { get; set; }

        public virtual User? User { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("StatusId")]

        public virtual Status? Status { get; set; }
        public int? StatusId { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}