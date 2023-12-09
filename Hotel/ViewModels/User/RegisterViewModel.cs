 using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Hotel.ViewModels
{
	public class RegisterViewModel
	{
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        [Compare(nameof(Password),ErrorMessage ="تکرار کلمه عبور هم خوانی ندارد")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

    }
}

