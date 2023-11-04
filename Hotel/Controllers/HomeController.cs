using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;
        public HomeController (MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var baner = _context.firstBaners.ToList();
            return View(baner);
        }
    }
}

