using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models.Entities.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MiniBanersController : Controller
    {
        MyContext _context;

        public MiniBanersController(MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListOfBaners()
        {
            var baners = await _context.firstBaners.ToListAsync();
            return View(baners);
        }
        public IActionResult CreateBaner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBaner(FirstBaner firstBaner)
        {
            if(ModelState.IsValid)
            {
                var newbaner = new FirstBaner()
                {
                    BanerTitle = firstBaner.BanerTitle,
                    BanerButton = firstBaner.BanerButton,
                    ImageName = firstBaner.ImageName
                };
                _context.firstBaners.Add(newbaner);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListOfBaners));
            }
            ModelState.AddModelError("ModelOnly", "لطفا فیلد ها را کامل پر کنید");
            return View(firstBaner);
        }
        public IActionResult EditBaner(int? id)
        {
            if(id!=null)
            {
                var baner = _context.firstBaners.SingleOrDefault(e => e.Id == id);
                if(baner!= null)
                {
                    return View(baner);
                }
            }
            return RedirectToAction(nameof(ListOfBaners));
        }
        [HttpPost]
        public IActionResult EditBaner(int? id,FirstBaner firstBaner)
        {
            if(id == firstBaner.Id)
            {
               if (ModelState.IsValid)
               {
                   var mybaner = _context.firstBaners.SingleOrDefault(e => e.Id == id);
                    mybaner.BanerTitle = firstBaner.BanerTitle;
                    mybaner.BanerButton = firstBaner.BanerButton;
                    mybaner.ImageName = firstBaner.ImageName;
                   _context.firstBaners.Update(mybaner);
                   _context.SaveChanges();
                   return RedirectToAction(nameof(ListOfBaners));
               }

                ModelState.AddModelError("ModelOnly", "لطفا فیلد ها را پر کنید");
                return View(firstBaner);
            }
            
            ModelState.AddModelError("ModelOnly", "لطفا فیلد ها را پر کنید");
            return View(firstBaner);
        }
        public IActionResult DeleteBaner(int? id)
        {
            if (id != null)
            {
                var baner = _context.firstBaners.SingleOrDefault(e => e.Id == id);
                if (baner != null)
                {
                    return View(baner);
                }
            }
            return RedirectToAction(nameof(ListOfBaners));
        }
        [HttpPost]
        public IActionResult DeleteBaner(int? id, FirstBaner firstBaner)
        {
            if (id == firstBaner.Id)
            {
                
                    var mybaner = _context.firstBaners.SingleOrDefault(e => e.Id == id);
                    _context.firstBaners.Remove(mybaner);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(ListOfBaners));
                
            }

            ModelState.AddModelError("ModelOnly", "لطفا فیلد ها را پر کنید");
            return View(firstBaner);
        }
    }
}

