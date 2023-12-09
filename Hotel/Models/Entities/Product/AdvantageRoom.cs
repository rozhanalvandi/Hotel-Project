using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.Entities.Product
{
	public class AdvantageRoom
	{
		[Key]
		public int Id { get; set; }
		[Display(Name ="نام")]
		[Required(ErrorMessage ="لطفا فیلد {0} را پر کنید")]
		[MaxLength(25,ErrorMessage ="تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
		[MinLength(2,ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
		public string Name { get; set; }

        public ICollection<AdvantageToRoom> advantageToRooms { get; set; }
    }

	
}

