using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Product
{
    
    public class ProductSize
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }
        [Required]
        [StringLength(50)]
        public string SizeText { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

    }
}