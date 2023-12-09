using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entities.Product
{
	public class HotelGallery
	{
		[Key]
		public int Id { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        public string ImageName { get; set; }

		public int HotelId { get; set; }
		[ForeignKey(nameof(HotelId))]
		public Hotell hotel { get; set; }
	}
}

