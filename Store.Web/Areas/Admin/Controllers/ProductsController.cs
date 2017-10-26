using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Entity.Product;
using Store.Models;

namespace Store.Web.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var productMaster = db.productMaster.Include(p => p.ProductBrand).Include(p => p.ProductCategory).Include(p => p.ProductColor).Include(p => p.ProductSize).Include(p => p.ProductSubCategory);
            return View(productMaster.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.productMaster.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.productBrand, "BrandId", "BrandName");
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName");
            ViewBag.ColorId = new SelectList(db.productColor, "ColorId", "ColorText");
            ViewBag.SizeId = new SelectList(db.productSize, "SizeId", "SizeText");
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,CategoryId,SubCategoryId,BrandId,ColorId,SizeId,Quantity,ProductDescription,Price,Stock")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.productMaster.Add(productMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.productBrand, "BrandId", "BrandName", productMaster.BrandId);
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productMaster.CategoryId);
            ViewBag.ColorId = new SelectList(db.productColor, "ColorId", "ColorText", productMaster.ColorId);
            ViewBag.SizeId = new SelectList(db.productSize, "SizeId", "SizeText", productMaster.SizeId);
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName", productMaster.SubCategoryId);
            return View(productMaster);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.productMaster.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.productBrand, "BrandId", "BrandName", productMaster.BrandId);
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productMaster.CategoryId);
            ViewBag.ColorId = new SelectList(db.productColor, "ColorId", "ColorText", productMaster.ColorId);
            ViewBag.SizeId = new SelectList(db.productSize, "SizeId", "SizeText", productMaster.SizeId);
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName", productMaster.SubCategoryId);
            return View(productMaster);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,CategoryId,SubCategoryId,BrandId,ColorId,SizeId,Quantity,ProductDescription,Price,Stock")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.productBrand, "BrandId", "BrandName", productMaster.BrandId);
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productMaster.CategoryId);
            ViewBag.ColorId = new SelectList(db.productColor, "ColorId", "ColorText", productMaster.ColorId);
            ViewBag.SizeId = new SelectList(db.productSize, "SizeId", "SizeText", productMaster.SizeId);
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName", productMaster.SubCategoryId);
            return View(productMaster);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.productMaster.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductMaster productMaster = db.productMaster.Find(id);
            db.productMaster.Remove(productMaster);
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
    }
}
