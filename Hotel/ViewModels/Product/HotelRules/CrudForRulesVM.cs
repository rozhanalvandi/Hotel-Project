using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.ViewModels.Product.HotelRules
{
    public class CrudForRulesVM
    {
        public int Id { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Description { get; set; }
    }

} 