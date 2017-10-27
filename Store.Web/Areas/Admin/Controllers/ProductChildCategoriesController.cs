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
    public class ProductChildCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductChildCategories
        public ActionResult Index()
        {
            var childCategory = db.childCategory.Include(p => p.ProductCategory).Include(p => p.ProductSubCategory);
            return View(childCategory.ToList());
        }

        // GET: Admin/ProductChildCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductChildCategory productChildCategory = db.childCategory.Find(id);
            if (productChildCategory == null)
            {
                return HttpNotFound();
            }
            return View(productChildCategory);
        }

        // GET: Admin/ProductChildCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName");
            ViewBag.SubCategoryId = new SelectList("", "SubCategoryId", "SubCategoryName");
            return View();
        }

        // POST: Admin/ProductChildCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChildCategoryId,SubCategoryId,CategoryId,ChildCategoryName")] ProductChildCategory productChildCategory)
        {
            if (ModelState.IsValid)
            {
                db.childCategory.Add(productChildCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productChildCategory.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName", productChildCategory.SubCategoryId);
            return View(productChildCategory);
        }

        // GET: Admin/ProductChildCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductChildCategory productChildCategory = db.childCategory.Find(id);
            if (productChildCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productChildCategory.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName", productChildCategory.SubCategoryId);
            return View(productChildCategory);
        }

        // POST: Admin/ProductChildCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChildCategoryId,SubCategoryId,CategoryId,ChildCategoryName")] ProductChildCategory productChildCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productChildCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName", productChildCategory.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.productSubCategory, "SubCategoryId", "SubCategoryName", productChildCategory.SubCategoryId);
            return View(productChildCategory);
        }

        // GET: Admin/ProductChildCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductChildCategory productChildCategory = db.childCategory.Find(id);
            if (productChildCategory == null)
            {
                return HttpNotFound();
            }
            return View(productChildCategory);
        }

        // POST: Admin/ProductChildCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductChildCategory productChildCategory = db.childCategory.Find(id);
            db.childCategory.Remove(productChildCategory);
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
