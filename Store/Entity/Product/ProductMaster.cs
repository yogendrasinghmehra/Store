using Store.Entity.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Product
{    
    public class ProductMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]        
        public int CategoryId { get; set; }
        
        public int SubCategoryId { get; set; }
              
        public int BrandId { get; set; }
        
        [Required]       
        public int Quantity { get; set; }

        public string ProductDescription { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual ProductBrand ProductBrand { get; set; }      


    }

    
}