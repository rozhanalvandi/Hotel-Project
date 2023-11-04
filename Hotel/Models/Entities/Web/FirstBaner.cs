using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.Entities.Web
{
	public class FirstBaner
	{
		[Key]
		public int Id { get; set; }

		[Display(Name ="عنوان")]
		[Required(ErrorMessage ="لطفا{0} را کامل کنید")]
		
		public string BanerTitle { get; set; }

        [Display(Name ="متن دکمه")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
		public string BanerButton { get; set; }

        [Display(Name ="تصویر بنر")]
       
        public string ImageName { get; set; }
	}
}

