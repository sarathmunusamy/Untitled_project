using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace untitled_Project.Models
{
	public class ProductDetailsWithImages
	{
		 public productDetail  productdetails = new  productDetail();
		 public productImage productimages = new productImage();


		public ProductDetailsWithImages PutProductDetails(productDetail pd,productImage pi) {
			ProductDetailsWithImages finalModel= new ProductDetailsWithImages();
			finalModel.productdetails = pd;
			finalModel.productimages = pi;
			return finalModel;
	
		}
	}
}