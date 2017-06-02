using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace untitled_Project.Models
{ 
	public class DataModel
	{
		public List<productDetail> productDetail { get; set; }
		public List<productImage> productImage { get; set; }

		public productImage pi{get;set;}
		public productDetail pd { get; set; }
		//public List<productImage> GetImage()
		//{
			
			
		//		string connectionString =
		//			ConfigurationManager.ConnectionStrings[ "DefaultConnection" ].ConnectionString;

		//		List<productImage> productImage = new List<productImage>();

		//		using( SqlConnection con = new SqlConnection( connectionString ) )
		//		{
		//			SqlCommand cmd = new SqlCommand( "GetMainImages", con );
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			con.Open();
		//			SqlDataReader rdr = cmd.ExecuteReader();
		//			while( rdr.Read() )
		//			{
		//				productImage productimage = new productImage();
		//				productimage.pID = Convert.ToInt32( rdr[ "pID" ] );
		//				productimage.mainImg = (byte[]) rdr[ "mainImg" ];

		//				productImage.Add( productimage );
		//			}
		//		}

		//		return productImage;
			
		//}

	}
}