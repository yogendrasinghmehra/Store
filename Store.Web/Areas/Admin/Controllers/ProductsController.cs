using System.Linq;
using System.Web.Mvc;
using Store.Models;
using Store.Web.ViewModels.Product;
using Store.Service.Product;
using Store.Entity.Product;
using System;
using Store.Web.Areas.Admin.ViewModels.Product;

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


        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewModelProduct viewModelProduct = db.ViewModelProducts.Find(id);
        //    if (viewModelProduct == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(viewModelProduct);
        //}


        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewModelProduct viewModelProduct = db.ViewModelProducts.Find(id);
        //    if (viewModelProduct == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(viewModelProduct);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductId,Name,CategoryId,SubCategoryId,BrandId,Quantity,ProductDescription,Price,Stock")] ViewModelProduct viewModelProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(viewModelProduct).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(viewModelProduct);
        //}


        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewModelProduct viewModelProduct = db.ViewModelProducts.Find(id);
        //    if (viewModelProduct == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(viewModelProduct);
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ViewModelProduct viewModelProduct = db.ViewModelProducts.Find(id);
        //    db.ViewModelProducts.Remove(viewModelProduct);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
