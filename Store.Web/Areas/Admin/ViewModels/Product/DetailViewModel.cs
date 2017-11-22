using Store.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Areas.Admin.ViewModels.Product
{
    public class DetailViewModel
    {

        public ProductMaster productMaster { get; set; }
        public List<ProductImages> ImageList { get; set; }
        public List<ProductColorMaster> ColorList { get; set; }
        public List<ProductSizeMaster> SizeList { get; set; }

    }
}