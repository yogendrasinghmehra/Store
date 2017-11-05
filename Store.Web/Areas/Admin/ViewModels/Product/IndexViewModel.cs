using Store.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Areas.Admin.ViewModels.Product
{
    public class IndexViewModel
    {
        public List<ProductCategory> ProductCategory { get; set; }

    }
}