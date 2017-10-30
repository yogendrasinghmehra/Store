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

        
        public ActionResult Index()
        {
            var childCategory = db.childCategory.Include(p => p.ProductCategory).Include(p => p.ProductSubCategory);
            return View(childCategory.ToList());
        }

        
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

        
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.productCategory, "CategoryId", "CategoryName");
            ViewBag.SubCategoryId = new SelectList("", "SubCategoryId", "SubCategoryName");
            return View();
        }

        
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

        [HttpGet]
        public JsonResult GetSubCategories(int CatId)
        {
           
            return Json((from a in db.productSubCategory
                         where a.CategoryId == CatId
                         select new { a.SubCategoryId, a.SubCategoryName }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetChildCategories(int SubCatId)
        {

            return Json((from a in db.childCategory
                         where a.SubCategoryId == SubCatId
                         select new { a.ChildCategoryId, a.ChildCategoryName }).ToList(), JsonRequestBehavior.AllowGet);
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
