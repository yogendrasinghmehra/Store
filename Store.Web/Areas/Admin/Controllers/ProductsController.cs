using System.Linq;
using System.Web.Mvc;
using Store;
using Store.Web.ViewModels.Product;
using Store.Service.Product;
using Store.Entity.Product;
using System;
using Store.Web.Areas.Admin.ViewModels.Product;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Store.Web.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

     
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.ProductCategory = db.productCategory.ToList();
            viewModel.ProductCategory.Insert(0, new ProductCategory { CategoryId = 0, CategoryName = "Select Main Category" });
            return View(viewModel);
        }

        public ActionResult Create()
        {
            ViewModelProduct VMP = new ViewModelProduct();
            VMP.ProductCategory = db.productCategory.ToList();
            VMP.ProductCategory.Insert(0, new ProductCategory { CategoryId = 0, CategoryName = "Select Category" });           
            VMP.ProductColor = db.productColor.ToList();
            VMP.ProductSize = db.productSize.ToList();
            VMP.ProductBrand = db.productBrand.ToList();


            return View(VMP);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelProduct viewModelProduct)
        {


            ProductImagesService productImagesService = new ProductImagesService();
            ProductColorService productColorService = new ProductColorService();
            ProductSizeServices productSizeServices = new ProductSizeServices();
            if (ModelState.IsValid)
            {


                //mapping with product master
                ProductMaster productMaster = new ProductMaster
                {
                    Name = viewModelProduct.Name,
                    CategoryId = viewModelProduct.CategoryId,
                    SubCategoryId = viewModelProduct.SubCategoryId,
                    ChildCategoryId = viewModelProduct.ChildCategoryId,
                    BrandId = viewModelProduct.BrandId,
                    Quantity = viewModelProduct.Quantity,
                    ProductDescription = viewModelProduct.ProductDescription,
                    Price = viewModelProduct.Price,
                    Stock = viewModelProduct.Stock,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                //adding product master details.
                db.productMaster.Add(productMaster);
                db.SaveChanges();
                if (viewModelProduct.productImages[0]!=null)
                {
                    //saving product images
                    string[] productImagesList = productImagesService.SaveProductImages(viewModelProduct.productImages, db.productCategory.Single(x => x.CategoryId == viewModelProduct.CategoryId).CategoryName);
                    //adding product images to table
                    productImagesService.AddProductImages(productImagesList, productMaster.ProductId, db);
                }
                //adding product Color
                productColorService.AddProductColor(viewModelProduct.ProductColor, productMaster.ProductId, db);
                //adding product Size
                productSizeServices.AddProductSize(viewModelProduct.ProductSize, productMaster.ProductId, db);
                ModelState.Clear();
                return RedirectToAction("Create");
            }
            
            return View(viewModelProduct);
        }

        public JsonResult GetSubCategory(int CatId)
         {
            var res = (from subCatList in db.productSubCategory
                       where subCatList.CategoryId == CatId
                       select new { subCatList.SubCategoryId, subCatList.SubCategoryName }).ToList();

            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetChildCategory(int SubCatId)
        {
            var res = (from ChildCatList in db.childCategory
                       where ChildCatList.SubCategoryId == SubCatId
                       select new { ChildCatList.ChildCategoryId, ChildCatList.ChildCategoryName }).ToList();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductsListByCategory(int CategoryId)
        {
            var productList = new { productList = db.productMaster.Where(p => p.CategoryId == CategoryId).ToList(), SubCategoryList = db.productSubCategory.Where(s => s.CategoryId == CategoryId).ToList() };

            return Json(productList);
        }

        public JsonResult GetProductsListBySubCategory(int SubCategoryId)
        {
            var productList = new { productList = db.productMaster.Where(p => p.SubCategoryId == SubCategoryId).ToList(), ChildCategoryList = db.childCategory.Where(s => s.SubCategoryId==SubCategoryId).ToList() };

            return Json(productList);
        }

        public JsonResult GetProductsListByChildCategory(int ChildCategoryId)
        {
            var productList = new { productList = db.productMaster.Where(p => p.ChildCategoryId == ChildCategoryId).ToList()};

            return Json(productList);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           DetailViewModel viewModel = new DetailViewModel();
          viewModel.productMaster= db.productMaster.Find(id);
            viewModel.ImageList = db.productImages.Where(i => i.ProductId == id).ToList();
            viewModel.ColorList = db.ProductColorMaster.Where(c => c.ProductId == id).ToList();
            viewModel.SizeList = db.ProductSizeMaster.Where(c => c.ProductId == id).ToList();
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditViewModel viewModel = new EditViewModel();
            viewModel.Product = db.productMaster.Find(id);

            viewModel.Category = db.productCategory.ToList();            
            viewModel.SubCategory = db.productSubCategory.Where(i => i.CategoryId == viewModel.Product.CategoryId).ToList();
            viewModel.ChildCategory = db.childCategory.Where(i => i.ChildCategoryId == viewModel.Product.ChildCategoryId).ToList();
            viewModel.producBrand = db.productBrand.ToList();

            viewModel.ColorList = db.ProductColorMaster.Where(c => c.ProductId == id).ToList();
            viewModel.SizeList = db.ProductSizeMaster.Where(s => s.ProductId == id).ToList();
            viewModel.ImageList = db.productImages.Where(i => i.ProductId == id).ToList();
            viewModel.colors = (from color in db.productColor
                                where !db.ProductColorMaster.Any(f => f.ColorId == color.ColorId && f.ProductId == id)
                                select color).ToList();

            viewModel.sizes = (from size in db.productSize
                               where !db.ProductSizeMaster.Any(s => s.SizeId == size.SizeId && s.ProductId == id)
                               select size).ToList();

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Product.CreatedOn = DateTime.Now;
                viewModel.Product.ModifiedOn = DateTime.Now;
                db.Entry(viewModel.Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            return View();
        }


        [HttpPost, ActionName("Delete")]       
        public ActionResult DeleteConfirmed(int id)
        {
            var imzList = db.productImages.Where(i => i.ProductId == id).ToList();

            //deleting images
            foreach (var img in imzList)
            {

               
                if (System.IO.File.Exists(Path.Combine(HttpContext.Server.MapPath("/"), img.ImageUrl)))
                {                    
                    System.IO.File.Delete(Path.Combine(HttpContext.Server.MapPath("/"), img.ImageUrl)); 
                }
                db.productImages.RemoveRange(imzList);
            }

            //deleting colors
            var colorList = db.ProductColorMaster.Where(i => i.ProductId == id).ToList();
            db.ProductColorMaster.RemoveRange(colorList);

            //deleting sizes
            var sizeList = db.ProductSizeMaster.Where(i => i.ProductId == id).ToList();
            db.ProductSizeMaster.RemoveRange(sizeList);

            //deleting product
            db.productMaster.Remove(db.productMaster.Where(i=>i.ProductId==id).SingleOrDefault());
            db.SaveChanges();



            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //update image section
        public JsonResult RemoveImage(int id)
        {
            ProductImagesService service = new ProductImagesService();
            bool status = service.RemoveProductImage(id);
            
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]        
        public ActionResult AddImages(HttpPostedFileBase[] imagesFiles)
        {
            int catId = Convert.ToInt32(Request.Form["catId"]);
            int productId = Convert.ToInt32(Request.Form["productId"]);
            if (imagesFiles[0]!=null && catId > 0 && productId > 0)
            {
                ProductImagesService productImagesService = new ProductImagesService();              
                //saving product images
                string[] productImagesList = productImagesService.SaveProductImages(imagesFiles, db.productCategory.Single(x => x.CategoryId == catId).CategoryName);
                //adding product images to table
                productImagesService.AddProductImages(productImagesList, productId, db);

            }

            return RedirectToAction("Edit", new { id = productId });
        }
        
        //update color section
        [HttpPost]
        public ActionResult AddColors(string[] color)
        {
            int productId = Convert.ToInt32(Request.Form["productId"]);

            if (productId > 0 && color != null)
            {
                foreach (var c in color)
                {
                    ProductColorMaster mc = new ProductColorMaster
                    {
                        ColorId=Convert.ToInt32(c),
                         ProductId=productId

                    };
                    db.ProductColorMaster.Add(mc);
                }
                db.SaveChanges();
            }

            

            return RedirectToAction("Edit", new { id = productId });
        }

        [HttpPost]
        public ActionResult RemoveColor(int colorId,int productId)
        {
            
            if (productId > 0 && colorId>0)
            {
                var getColor = db.ProductColorMaster.Where(i => i.ColorId == colorId && i.ProductId == productId).SingleOrDefault();
                if (getColor!=null)
                {

                    db.ProductColorMaster.Remove(getColor);
                    db.SaveChanges();
                }
            }
            return Json("success");
        }
        
        //update size section
        [HttpPost]
        public ActionResult AddSize(string[] size)
        {
            int productId = Convert.ToInt32(Request.Form["productId"]);

            if (productId > 0 && size != null)
            {
                foreach (var c in size)
                {
                    ProductSizeMaster mc = new ProductSizeMaster
                    {
                        SizeId = Convert.ToInt32(c),
                        ProductId = productId

                    };
                    db.ProductSizeMaster.Add(mc);
                }
                db.SaveChanges();
            }



            return RedirectToAction("Edit", new { id = productId });
        }

        [HttpPost]
        public ActionResult RemoveSize(int sizeId, int productId)
        {

            if (productId > 0 && sizeId > 0)
            {
                var getSize = db.ProductSizeMaster.Where(i => i.SizeId == sizeId && i.ProductId == productId).SingleOrDefault();
                if (getSize != null)
                {

                    db.ProductSizeMaster.Remove(getSize);
                    db.SaveChanges();
                }
            }
            return Json("success");
        }

    }
}
