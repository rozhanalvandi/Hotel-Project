using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.Entities.User
{
	public class User
	{
		[Key]
		public int Id { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        public string Password { get; set; }


        [Display(Name = "نام")]
        public string? Name { get; set; }


        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }
	}
}

