using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace untitled_Project.Controllers
{
    public class ImageController : Controller
    {
        private masterEntities db = new masterEntities();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View(db.productImages.ToList());
        }

        //
        // GET: /Image/Details/5

        public ActionResult Details(int id = 0)
        {
            productImage productimage = db.productImages.Find(id);
            if (productimage == null)
            {
                return HttpNotFound();
            }
            return View(productimage);
        }

        //
        // GET: /Image/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Image/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(productImage productimage)
        {
            if (ModelState.IsValid)
            {
                db.productImages.Add(productimage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productimage);
        }

        //
        // GET: /Image/Edit/5

        public ActionResult Edit(int id = 0)
        {
            productImage productimage = db.productImages.Find(id);
            if (productimage == null)
            {
                return HttpNotFound();
            }
            return View(productimage);
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(productImage productimage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productimage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productimage);
        }

        //
        // GET: /Image/Delete/5

        public ActionResult Delete(int id = 0)
        {
            productImage productimage = db.productImages.Find(id);
            if (productimage == null)
            {
                return HttpNotFound();
            }
            return View(productimage);
        }

        //
        // POST: /Image/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productImage productimage = db.productImages.Find(id);
            db.productImages.Remove(productimage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}