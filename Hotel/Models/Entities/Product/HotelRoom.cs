using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entities.Product
{
	public class HotelRoom
	{
		[Key]
		public int Id { get; set; }

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
        public int Price  { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }


        [Display(Name = "تصویر اتاق")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        public string ImageName { get; set; }

        [Display(Name = "ظرفیت")]
        public int Capacity { get; set; }

        [Display(Name = "تعداد تخت")]
        public int BedCount { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set;  }

		public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        public Hotell hotel { get; set; }

		public ICollection<AdvantageToRoom> advantageToRooms { get; set; }
        public ICollection<Reserve> reserves { get; set; }
    }
}

