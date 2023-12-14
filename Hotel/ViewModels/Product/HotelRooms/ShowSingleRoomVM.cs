using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Hotel.Models.Entities.Product;

namespace Hotel.ViewModels.Product.HotelRooms
{
	public class ShowSingleRoomVM
	{
        public int Id { get; set; }

        [Display(Name = "ظرفیت")]
        public int Capacity { get; set; }

        [Display(Name = "تعداد تخت")]
        public int BedCount { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "تصویر اتاق")]
        public string ImageName { get; set; }

        public DateTime ReserveTime { get; set; }

        public ICollection<AdvantageRoom> advantagesRooms { get; set; }
    }

}

