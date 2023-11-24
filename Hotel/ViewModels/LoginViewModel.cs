using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.ViewModels
{
	public class LoginViewModel
	{
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا{0} را کامل کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

