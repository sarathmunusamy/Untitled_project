using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using untitled_Project.Models;

namespace untitled_Project.Controllers
{
	public class AdminController : Controller
	{
		private masterEntities db = new masterEntities();

		public int productID;
		//
		// GET: /Admin/

		[HttpGet]
		public ActionResult Index()
		{

			return View();


		}

		[HttpPost]
		public ActionResult Index( string uname, string password )
		{

			var a = ( db.ValidateLogin( uname, password ) ).ToList();

			if( a[ 0 ] == 1 )
			{

				return RedirectToAction( "AdminDetails", "Admin" );
			}
			else
			{
				ViewData[ "errormessage" ] = "yes";
				return View();
			}


		}

		public ActionResult AdminDetails()
		{

			List<productImage> imageList = new List<productImage>();
			DataModel datamodel = new DataModel();

			datamodel.productDetail = db.productDetails.ToList();
			datamodel.productImage = db.GetMainImage().ToList<productImage>();

			//ViewData["imageList"] = imageList;

			return View( datamodel );
		}

		//public ActionResult ViewDetails()
		//{	DataModel datamodel = new DataModel();

		//	datamodel.productDetail = db.productDetails.ToList();


		//	ViewData[ "productImage" ] = datamodel.productDetail;
		//	return View(db.productDetails.ToList());
		//}


		public ActionResult EditImage( int id = 0 )
		{
			productImage ProductImage = new productImage();

			ProductImage = db.GetMainImage().ToList<productImage>().Find( x => x.pID == id );

			productID = id;
			ViewBag.id = id;

			return View( ProductImage );
		}

		[HttpPost]
		public ActionResult AddImage( HttpPostedFileBase postedFile )
		{
			string columnName = Request.Form[ Request.Form.AllKeys[ 0 ] ].ToString();
			int ProductID = Convert.ToInt32( Request.Form[ Request.Form.AllKeys[ 1 ] ] );
			byte[] bytes = new byte[ 1000 ];
			if( ModelState.IsValid )
			{

				using( BinaryReader br = new BinaryReader( postedFile.InputStream ) )
				{
					bytes = br.ReadBytes( postedFile.ContentLength );
				}

			}


			db.AddImage1( bytes, ProductID, columnName );


			return View();
		}

		public ActionResult Details( int id = 0 )
		{
			productDetail productdetail = db.productDetails.Find( id );
			if( productdetail == null )
			{
				return HttpNotFound();
			}
			return View( productdetail );
		}

		//
		// GET: /Admin/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Admin/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( productDetail productdetail )
		{
			if( ModelState.IsValid )
			{
				db.productDetails.Add( productdetail );
				db.SaveChanges();
				return RedirectToAction( "AddNewImage" );
			}

			return View( productdetail );
		}


		public ActionResult AddNewImage()
		{
			productImage ProductImage = new productImage();
			var ID = db.GetNewProductID().ToList();


			if( db.GetMainImage().ToList<productImage>().Find( x => x.pID == ID[ 0 ] ) != null )
			{
				ProductImage = db.GetMainImage().ToList<productImage>().Find( x => x.pID == ID[ 0 ] );

			}

			ViewBag.id = ID[ 0 ];

			return View( ProductImage );

		}

		[HttpPost]
		public ActionResult AddNewImage( HttpPostedFileBase postedFile )
		{
			string columnName = Request.Form[ Request.Form.AllKeys[ 0 ] ].ToString();
			int ProductID = Convert.ToInt32( Request.Form[ Request.Form.AllKeys[ 1 ] ] );
			byte[] bytes = new byte[ 1000 ];
			if( ModelState.IsValid )
			{

				using( BinaryReader br = new BinaryReader( postedFile.InputStream ) )
				{
					bytes = br.ReadBytes( postedFile.ContentLength );
				}

			}

			if( columnName == "mainImg" )
				db.AddNewImage( bytes, ProductID, columnName );
			else
				db.AddImage1( bytes, ProductID, columnName );

			productImage ProductImage = new productImage();
			var ID = db.GetNewProductID().ToList();


			if( db.GetMainImage().ToList<productImage>().Find( x => x.pID == ID[ 0 ] ) != null )
			{
				ProductImage = db.GetMainImage().ToList<productImage>().Find( x => x.pID == ID[ 0 ] );

			}

			ViewBag.id = ID[ 0 ];

			return View( ProductImage );


		
		}

		//
		// GET: /Admin/Edit/5

		public ActionResult Edit( int id = 0 )
		{
			productDetail productdetail = db.productDetails.Find( id );
			if( productdetail == null )
			{
				return HttpNotFound();
			}
			return View( productdetail );
		}

		//
		// POST: /Admin/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( productDetail productdetail )
		{
			if( ModelState.IsValid )
			{
				db.Entry( productdetail ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			return View( productdetail );
		}

		//
		// GET: /Admin/Delete/5

		public ActionResult Delete( int id = 0 )
		{
			productDetail productdetail = db.productDetails.Find( id );
			if( productdetail == null )
			{
				return HttpNotFound();
			}
			return View( productdetail );
		}

		//
		// POST: /Admin/Delete/5

		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( int id )
		{
			productDetail productdetail = db.productDetails.Find( id );
			db.productDetails.Remove( productdetail );
			db.SaveChanges();
			return RedirectToAction( "Index" );
		}

		protected override void Dispose( bool disposing )
		{
			db.Dispose();
			base.Dispose( disposing );
		}
	}
}