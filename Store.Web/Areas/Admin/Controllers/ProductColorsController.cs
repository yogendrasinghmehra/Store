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
    public class ProductColorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductColors
        public ActionResult Index()
        {
            return View(db.productColor.ToList());
        }

        // GET: Admin/ProductColors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.productColor.Find(id);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            return View(productColor);
        }

        // GET: Admin/ProductColors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorId,ColorText")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                db.productColor.Add(productColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productColor);
        }

        // GET: Admin/ProductColors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.productColor.Find(id);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            return View(productColor);
        }

        // POST: Admin/ProductColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColorId,ColorText")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productColor);
        }

        // GET: Admin/ProductColors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.productColor.Find(id);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            return View(productColor);
        }

        // POST: Admin/ProductColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductColor productColor = db.productColor.Find(id);
            db.productColor.Remove(productColor);
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
