using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Store.Entity.Product;
using Store;

namespace Store.Service.Product
{
   public class ProductImagesService
    {
        private ApplicationDbContext dbCon = new ApplicationDbContext();
        
        //save product images to folder
        public string[] SaveProductImages(HttpPostedFileBase[] imagesFiles,string FolderName)
        {
            string[] imageUrls = new string[imagesFiles.Length];

            //if main folder not does not exists...
            string directoryPath = HttpContext.Current.Server.MapPath("/ProductImages");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //if folder category path does not exists...
            string fullPath = Path.Combine(directoryPath, FolderName);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            //saving images to database and adding url to array...
            for (int i = 0; i < imagesFiles.Length; i++)
            {
                string uniqueImageName = string.Concat(GetUniqueName(), Path.GetExtension(imagesFiles[0].FileName));              
                imagesFiles[i].SaveAs(Path.Combine(fullPath, uniqueImageName));
                imageUrls[i] = Path.Combine("ProductImages", FolderName, uniqueImageName);
            }
            return imageUrls;
            
        }

        //save product url in database
        public void AddProductImages(string[] productImageUrls, int productId, ApplicationDbContext db)
        {
            try
            {
                foreach (string image in productImageUrls)
                {

                    ProductImages productImages = new ProductImages
                    {
                        ProductId = productId,
                        CreatedOn = DateTime.Now,
                        ImageUrl = image,
                        ShowThis = true
                    };
                    db.productImages.Add(productImages);
                }
               db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        //getting unique name for products
        private string GetUniqueName()
        {
            Guid newId = Guid.NewGuid();

            return newId.ToString();
        }

        //removing product images form folder and database
        public bool RemoveProductImage(int ImageId)
        {
            bool status = false;
            var image = dbCon.productImages.Where(i => i.ImageId == ImageId).SingleOrDefault();
            if (image!=null)
            {                            
                dbCon.productImages.Remove(image);
                dbCon.SaveChanges();

                if (File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~"), image.ImageUrl)))
                {
                    File.Delete(Path.Combine(HttpContext.Current.Server.MapPath("~"), image.ImageUrl));
                    status = true;
                }

            }

            return status;

        }
    }

   

    

   
}
