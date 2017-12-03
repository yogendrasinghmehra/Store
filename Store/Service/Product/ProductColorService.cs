using Store.Entity.Product;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Product
{
   public  class ProductColorService
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        public void AddProductColor(List<ProductColor> productColorList, int productId, ApplicationDbContext db)
        {
            try
            {

                if (productColorList.Any(m => m.IsSelected))
                {

                    foreach (ProductColor productColor in productColorList)
                    {
                        if (productColor.IsSelected == true)
                        {
                            ProductColorMaster productColorMaster = new ProductColorMaster
                            {
                                ProductId = productId,
                                ColorId = productColor.ColorId
                            };
                            db.ProductColorMaster.Add(productColorMaster);
                            
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }


    }
}
