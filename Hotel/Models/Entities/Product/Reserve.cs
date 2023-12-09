using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entities.Product
{
	public class Reserve
	{
        [Key]
        public int Id { get; set; }

        [Display(Name = "تاریخ رزرو")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        public DateTime ReserveDate{ get; set; }


        [Display(Name = "تعداد رزرو")]
        public string Count { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsReserve { get; set; }


		public int RoomId { get; set; }
		[ForeignKey(nameof(RoomId))]
		public Hotell hotelroom { get; set; }



	}
}
