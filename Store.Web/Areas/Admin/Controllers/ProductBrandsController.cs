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
    public class ProductBrandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductBrands
        public ActionResult Index()
        {
            return View(db.productBrand.ToList());
        }

        // GET: Admin/ProductBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = db.productBrand.Find(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // GET: Admin/ProductBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandId,BrandName")] ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                db.productBrand.Add(productBrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productBrand);
        }

        // GET: Admin/ProductBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = db.productBrand.Find(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // POST: Admin/ProductBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandId,BrandName")] ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productBrand);
        }

        // GET: Admin/ProductBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = db.productBrand.Find(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // POST: Admin/ProductBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductBrand productBrand = db.productBrand.Find(id);
            db.productBrand.Remove(productBrand);
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
