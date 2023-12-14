using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.ViewModels.Product.HotelRooms
{
	public class AddRoomVM
	{
        public int HotelId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(20, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(20, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        [Display(Name = "ظرفیت")]
        public int Capacity { get; set; }

        [Display(Name = "تعداد تخت")]
        public int BedCount { get; set; }

        [Display(Name = "تصویر ")]
        public IFormFile File { get; set; }
    }	
}

