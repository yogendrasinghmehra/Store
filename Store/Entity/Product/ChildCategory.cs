using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Product
{
   public class ProductChildCategory
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChildCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string ChildCategoryName { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductSubCategory  ProductSubCategory{ get; set; }
    }
}
