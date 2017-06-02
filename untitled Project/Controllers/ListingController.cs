using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using untitled_Project.Models;
using System.Dynamic;

namespace untitled_Project.Controllers
{
    public class ListingController : Controller
    {
        private masterEntities db = new masterEntities();
		
        //
        // GET: /Listing/

        public ActionResult Index()
        {
			List<productImage> imageList = new List<productImage>();
			DataModel datamodel = new DataModel();

			datamodel.productDetail = db.productDetails.ToList();
			datamodel.productImage= db.GetMainImage().ToList<productImage>();
			
			//ViewData["imageList"] = imageList;

			return View( datamodel );
        }


		public ActionResult ProductDetail( int ID )
		{
			
			//ViewData["pd"] = db.productDetails.ToList().First( x => x.ID == ID );

			//ViewData[ "pi" ] = db.GetMainImage().ToList<productImage>().First( x => x.pID == ID );


			//dynamic detailModel = new ExpandoObject();
			//detailModel.productDetails = db.productDetails.ToList().First( x => x.ID == ID );
			//detailModel.productImage = db.GetMainImage().ToList<productImage>().First( x => x.pID == ID );]

		
			
			

			ProductDetailsWithImages detailsModel = new ProductDetailsWithImages();

			ProductDetailsWithImages finalModel = detailsModel.PutProductDetails( db.productDetails.ToList().First( x => x.ID == ID ), db.GetMainImage().ToList<productImage>().First( x => x.pID == ID ) );


			return View( finalModel );


		}

        //
        // GET: /Listing/Details/5

        public ActionResult Details(int id = 0)
        {
            productDetail productdetail = db.productDetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        //
        // GET: /Listing/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Listing/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(productDetail productdetail)
        {
            if (ModelState.IsValid)
            {
                db.productDetails.Add(productdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productdetail);
        }

        //
        // GET: /Listing/Edit/5

        public ActionResult Edit(int id = 0)
        {
            productDetail productdetail = db.productDetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        //
        // POST: /Listing/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(productDetail productdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productdetail);
        }

        //
        // GET: /Listing/Delete/5

        public ActionResult Delete(int id = 0)
        {
            productDetail productdetail = db.productDetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        //
        // POST: /Listing/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productDetail productdetail = db.productDetails.Find(id);
            db.productDetails.Remove(productdetail);
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