using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Entity.Product;
using Store;

namespace Store.Web.Areas.Admin.Controllers
{
    public class ProductSubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductSubCategories
        public ActionResult Index()
        {
            var productSubCategory = db.productSubCategory.Include(p => p.ProductCategory);
            return View(productSubCategory.ToList());
        }

        // GET: Admin/ProductSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSubCategory productSubCategory = db.productSubCategory.Find(id);
            if (productSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(productSubCategory);
        }

        // GET: Admin/ProductSubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/ProductSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryId,CategoryId,SubCategoryName")] ProductSubCategory productSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.productSubCategory.Add(productSubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productSubCategory.CategoryId);
            return View(productSubCategory);
        }

        // GET: Admin/ProductSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSubCategory productSubCategory = db.productSubCategory.Find(id);
            if (productSubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productSubCategory.CategoryId);
            return View(productSubCategory);
        }

        // POST: Admin/ProductSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryId,CategoryId,SubCategoryName")] ProductSubCategory productSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productSubCategory.CategoryId);
            return View(productSubCategory);
        }

        // GET: Admin/ProductSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSubCategory productSubCategory = db.productSubCategory.Find(id);
            if (productSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(productSubCategory);
        }

        // POST: Admin/ProductSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSubCategory productSubCategory = db.productSubCategory.Find(id);
            db.productSubCategory.Remove(productSubCategory);
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
