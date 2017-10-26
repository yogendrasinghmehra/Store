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
        [Required]
      
        public int SubCategoryId { get; set; }
        [Required]
       
        public int BrandId { get; set; }
        [Required]
       
        public int ColorId { get; set; }
        [Required]
       
        public int SizeId { get; set; }
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
        public virtual ProductColor ProductColor { get; set; }
        public virtual ProductSize ProductSize { get; set; }


    }

    //model for adding product
    public class ProductViewModel
    {
       
        public int ProductId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]

        public int CategoryId { get; set; }
        [Required]

        public int SubCategoryId { get; set; }
        [Required]

        public int BrandId { get; set; }
        [Required]

        public int ColorId { get; set; }
        [Required]

        public int SizeId { get; set; }
        [Required]

        public int Quantity { get; set; }
        public string ProductDescription { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Stock { get; set; }

        public List<ProductCategory> ProductCategory { get; set; }
        public List<ProductSubCategory> ProductSubCategory { get; set; }
        public List<ProductBrand> ProductBrand { get; set; }
        public List<ProductColor> ProductColor { get; set; }
        public List<ProductSize> ProductSize { get; set; }

    }
}