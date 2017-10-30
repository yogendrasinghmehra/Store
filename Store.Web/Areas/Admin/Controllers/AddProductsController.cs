using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using Store.Web.ViewModels.Product;

namespace Store.Web.Areas.Admin.Controllers
{
    public class AddProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

     
        public ActionResult Index()
        {
            ViewModelProduct VMP = new ViewModelProduct();
            VMP.ProductCategory = db.productCategory.ToList();



            return View(VMP);
        }





        public ActionResult Create()
        {
            ViewModelProduct VMP = new ViewModelProduct();
            VMP.ProductCategory = db.productCategory.ToList();
            VMP.ProductColor = db.productColor.ToList();
            VMP.ProductSize = db.productSize.ToList();
            VMP.ProductBrand = db.productBrand.ToList();


            return View(VMP);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductId,Name,CategoryId,SubCategoryId,BrandId,Quantity,ProductDescription,Price,Stock")] ViewModelProduct viewModelProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ViewModelProducts.Add(viewModelProduct);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(viewModelProduct);
        //}

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
