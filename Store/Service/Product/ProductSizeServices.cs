using Store.Entity.Product;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Product
{
   public class ProductSizeServices
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public void AddProductSize(List<ProductSize> productSizeList, int productId, ApplicationDbContext db)
        {

            if (productSizeList.Any(s => s.IsSelected))
            {
                foreach (ProductSize productSize in productSizeList)
                {
                    if (productSize.IsSelected == true)
                    {
                        ProductSizeMaster productSizeMaster = new ProductSizeMaster
                        {
                            ProductId = productId,
                            SizeId = productSize.SizeId
                        };
                        db.ProductSizeMaster.Add(productSizeMaster);
                       
                    }

                }
                db.SaveChanges();
            }
        }

    }
}
