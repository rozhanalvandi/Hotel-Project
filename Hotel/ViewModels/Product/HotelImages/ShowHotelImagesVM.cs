using System;
using Hotel.Models.Entities.Product;

namespace Hotel.ViewModels.Product.HotelImages
{
	public class ShowHotelImagesVM
	{
		public int Id { get; set; }
		public IEnumerable<HotelGallery> hotelGalleries { get; set; }
	}
} 

