using System;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Models.Entities.Product
{
	public class Hotell
	{
		[Key]
		public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Title { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [MaxLength(200 , ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(20, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "تعداد اتاق")]
        public int RoomCount { get; set; }

        [Display(Name = "تعداد طبقه")]
        public int StageCount { get; set; }

        [Display(Name = "زمان ورود")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        public string EnteryTime { get; set; }

        [Display(Name = "زمان خروج")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        public string ExitTime { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime dateTime { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }



		public HotelAdderss hotelAdderss { get; set; }
		public ICollection<HotelGallery> hotelGalleries { get; set; }
		public ICollection<Hotell> hotelRooms { get; set; }
        public ICollection<HotelRules> hotelRules  { get; set; }
		public ICollection<Reserve> reserves { get; set; }

	}
}

