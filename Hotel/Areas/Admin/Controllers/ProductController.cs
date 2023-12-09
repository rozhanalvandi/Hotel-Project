using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Core;
using Hotel.Models.Entities.Product;
using Hotel.ViewModels.Product.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private IHotelService _service;
        public ProductController (IHotelService service)
        {
            _service = service;
        }
        // GET: /<controller>/
        public IActionResult ShowAllHotels()
        {
           
            return View(_service.GetAllHotels());
        }


        public IActionResult CreateHotel()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult CreateHotel(CreateHotelViewModel createHotelView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var hotel = new Hotell()
                    {
                        Title = createHotelView.Title,
                        dateTime = createHotelView.dateTime,
                        Description = createHotelView.Description,
                        EnteryTime = createHotelView.EnteryTime,
                        ExitTime = createHotelView.ExitTime, 
                        RoomCount = createHotelView.RoomCount,
                        StageCount = createHotelView.StageCount


                    };
                    _service.AddHotel(hotel);
                    hotel.IsActive = true;
                    var address = new HotelAdderss()
                    {
                        Address = createHotelView.Address,
                        City = createHotelView.City,
                        State = createHotelView.State,
                        PostalCode = createHotelView.PostalCode,
                        HotelId = hotel.Id

                    };
                    _service.AddAddress(address);
                    return RedirectToAction("ShowAllHotels");
                }
                catch(Exception)
                {
                    ModelState.AddModelError(nameof(createHotelView.Title), "لطفا فیلد ها را پر کنید");
                    return (View(createHotelView));

                }


            }
            ModelState.AddModelError(nameof(createHotelView.Title), "لطفا فیلد ها را پر کنید");
            return View();
        }
        public IActionResult EditHotel(int id)
        {
            var vm = _service.GetHotelViewModel(id);
            if (vm != null)
            {
                return View(vm);
            }
            return RedirectToAction("ShowAllHotels");
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult EditHotel(int id,EditHotelViewModel editHotelViewModel)
        {
            if ( ModelState.IsValid)
            {
                if(id==editHotelViewModel.Id)
                {
                    var hotel = _service.GetHotelById(id);
                    hotel.Title = editHotelViewModel.Title;
                    hotel.ExitTime = editHotelViewModel.ExitTime;
                    hotel.ExitTime = editHotelViewModel.EnteryTime;
                    hotel.Description = editHotelViewModel.Description;
                    hotel.IsActive = editHotelViewModel.IsActive;
                    hotel.RoomCount = editHotelViewModel.RoomCount;
                    hotel.StageCount = editHotelViewModel.StageCount;
                    
                    var myAddress = hotel.hotelAdderss;
                    myAddress.Address = editHotelViewModel.Address;
                    myAddress.PostalCode = editHotelViewModel.PostalCode;
                    myAddress.City = editHotelViewModel.City;
                    myAddress.State = editHotelViewModel.State;

                    _service.UpdateHotel(hotel);
                    _service.UpdateAddress(myAddress);
                    return RedirectToAction("ShowAllHotels");

                }
                ModelState.AddModelError(nameof(editHotelViewModel.Title), "لطفا فیلد ها را پر کنید");
                return (View(editHotelViewModel));
            }
            ModelState.AddModelError(nameof(editHotelViewModel.Title), "لطفا موارد ارسالی را مجددا چک کنید");
            return (View(editHotelViewModel));

        }
         public IActionResult DeleteHotel(int id)
         {

            var vm = _service.GetHotelViewModel(id);
            if (vm != null)
            {
                return View(vm);
            }
            return RedirectToAction("ShowAllHotels");
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult DeleteHotel(int? id)
        {
            var hotel = _service.GetHotelById(id.Value);
            if (hotel != null)
            {
                _service.DeleteHotel(hotel);
                _service.DeleteAdderss(hotel.hotelAdderss);
                return RedirectToAction("ShowAllHotels");
            }

            return RedirectToAction("ShowAllHotels");
        }
    }
}

