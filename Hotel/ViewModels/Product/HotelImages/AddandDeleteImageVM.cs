using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace Hotel.ViewModels.Product.HotelImages
{
	public class AddandDeleteImageVM
	{
		public int Id { get; set; }
		public string? ImageName { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        public IFormFile File { get; set; }

	}
}

