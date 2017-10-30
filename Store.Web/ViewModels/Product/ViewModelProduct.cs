using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Entity;
using System.ComponentModel.DataAnnotations;
using Store.Entity.Product;

namespace Store.Web.ViewModels.Product
{
    public class ViewModelProduct
    {

        [Key]
        public int ProductId { get; set; }

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

        public List <ProductCategory> ProductCategory { get; set; }
        public List <ProductColor> ProductColor { get; set; }
        public List<ProductBrand> ProductBrand { get; set; }
        public List<ProductSize> ProductSize { get; set; }
        public List <ProductImages> ProductImages { get; set; }

        public List<ProductMaster> ProductLists { get; set; }




    }
}