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
    public class ProductSizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductSizes
        public ActionResult Index()
        {
            return View(db.productSize.ToList());
        }

        // GET: Admin/ProductSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.productSize.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // GET: Admin/ProductSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SizeId,SizeText")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.productSize.Add(productSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productSize);
        }

        // GET: Admin/ProductSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.productSize.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: Admin/ProductSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SizeId,SizeText")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productSize);
        }

        // GET: Admin/ProductSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.productSize.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: Admin/ProductSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSize productSize = db.productSize.Find(id);
            db.productSize.Remove(productSize);
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
