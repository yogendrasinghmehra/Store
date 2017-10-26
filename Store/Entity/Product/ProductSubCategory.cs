using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Product
{
    
    public class ProductSubCategory
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubCategoryId { get; set; }       
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string SubCategoryName { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}