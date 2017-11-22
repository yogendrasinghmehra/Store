using Store.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Areas.Admin.ViewModels.Product
{
    public class EditViewModel
    {
        public ProductMaster Product { get; set; }
        public List<ProductCategory> Category { get; set; }
        public List<ProductSubCategory> SubCategory { get; set; }
        public List<ProductChildCategory> ChildCategory { get; set; }
        public List<ProductBrand> producBrand { get; set; }
        public List<ProductImages> ImageList { get; set; }
        public List<ProductColorMaster> ColorList { get; set; }
        public List<ProductSizeMaster> SizeList { get; set; }
        public List<ProductColor> colors { get; set; }
        public List<ProductSize> sizes { get; set; }

    }
}