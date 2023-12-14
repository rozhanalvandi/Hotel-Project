using Hotel.Core;
using Hotel.Models.Entities.Product;
using Hotel.ViewModels.Product.Advantage;
using Hotel.ViewModels.Product.Hotel;
using Hotel.ViewModels.Product.HotelImages;
using Hotel.ViewModels.Product.HotelRooms;
using Hotel.ViewModels.Product.HotelRules;
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
        public ProductController(IHotelService service)
        {
            _service = service;
        }
        // GET: /<controller>/
        

        #region base hotel
        public IActionResult ShowAllHotels()
        {
            return View(_service.GetAllHotels());
        }
        public IActionResult CreateHotel()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
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
                catch (Exception)
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
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHotel(int id, EditHotelViewModel editHotelViewModel)
        {
            if (ModelState.IsValid)
            {
                if (id == editHotelViewModel.Id)
                {
                    var hotel = _service.GetHotelById(id);
                    hotel.Title = editHotelViewModel.Title;
                    hotel.ExitTime = editHotelViewModel.ExitTime;
                    hotel.ExitTime = editHotelViewModel.EnteryTime;
                    hotel.Description = editHotelViewModel.Description;
                    hotel.IsActive = editHotelViewModel.IsActive;
                    hotel.RoomCount = editHotelViewModel.RoomCount;
                    hotel.StageCount = editHotelViewModel.StageCount;

                    var myAddress = hotel.hotelAdderss;     //also we can new hoteladdress but it is better using address ofthat hotel for hight performance
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
        [HttpPost, ValidateAntiForgeryToken]
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
        #endregion


        #region hotel gallery
        public IActionResult ShowAllhotelImage(int id)
        {
            return View(new ShowHotelImagesVM
            {
                Id = id,
                hotelGalleries = _service.HotelGalleries(id)

            });
        }
        public IActionResult AddImage(int id)
        {
            return View(new AddandDeleteImageVM
            {
                Id = id,
            });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddImage(AddandDeleteImageVM addandDeleteImageVM)
        {
            if (ModelState.IsValid)
            {
                if (addandDeleteImageVM.File != null)
                {
                    string imgName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(addandDeleteImageVM.File.FileName);
                    string imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelImages", imgName);

                    using (var strem = new FileStream(imgpath, FileMode.Create))
                    {
                        addandDeleteImageVM.File.CopyTo(strem);
                    }
                    var image = new HotelGallery()
                    {
                        HotelId = addandDeleteImageVM.Id,
                        ImageName = imgName
                    };
                    _service.AddImage(image);
                }
                ModelState.AddModelError(nameof(addandDeleteImageVM.File), "لطفا تصویر را وارد کنید");
                return RedirectToAction("ShowAllhotelImage", new { id = addandDeleteImageVM.Id });
            }
            return View();

        }
        public IActionResult DeleteImage(int id)
        {
            return View(new AddandDeleteImageVM()
            {
                Id = id,
                ImageName = _service.GetImageById(id).ImageName

            });

        }

        public IActionResult DeleteImagefromgallery(int? id)
        {
            if (id != null)
            {
                var image = _service.GetImageById(id.Value);
                if (image != null)
                {
                    if (_service.DeleteImage(image.ImageName))
                    {
                        _service.DeleteGallery(image);
                        return RedirectToAction("ShowAllhotelImage", new { id = image.HotelId });
                    }
                    else
                    {

                        return View(new AddandDeleteImageVM()
                        {
                            Id = id.Value,
                            ImageName = _service.GetImageById(id.Value).ImageName

                        });
                    }

                }
                else
                {
                    return View("ShowAllHotels");
                }
            }
            return View("ShowAllHotels");
        }
        #endregion

        #region hotel rules
        public IActionResult ShowAllRules(int id)
        {
            ViewBag.HotelId = id;
            return View(_service.ShowAllRules(id));

        }
        public IActionResult AddRules(int id)
        {
            return View(new CrudForRulesVM
            {
                Id = id
            });

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddRules(CrudForRulesVM viewModel)
        {
            if (ModelState.IsValid)
            {
                HotelRules hotelRules = new()
                {
                    HotelId = viewModel.Id,
                    Description = viewModel.Description
                };
                _service.AddRule(hotelRules);
                return RedirectToAction("ShowAllRules", new { id = viewModel.Id });
            }
            ModelState.AddModelError(nameof(viewModel.Description), "لطفا تمامی فیلد هارا پر کنید");
            
            return View(viewModel);
        }
        public IActionResult EditRule(int id)
        {

            return View(_service.GetRuleViewModel(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditRule(CrudForRulesVM viewModel)
        {
            var rule = _service.FindHotelRule(viewModel.Id);
            if (ModelState.IsValid)
            {
                rule.Description = viewModel.Description;
                _service.EditRule(rule);
                return RedirectToAction("ShowAllRules", new { id = rule.HotelId });
            }
            ModelState.AddModelError(nameof(viewModel.Description), "لطفا تمامی فیلد هارا پر کنید");
            return View(viewModel);
        }

        public IActionResult DeleteRule(int id)
        {

            return View(_service.GetRuleViewModel(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteRule(CrudForRulesVM viewModel)
        {
            var rule = _service.FindHotelRule(viewModel.Id);
            if (ModelState.IsValid)
            {

                _service.DeleteRule(rule);
                return RedirectToAction("ShowAllRules", new { id = rule.HotelId });
            }
            ModelState.AddModelError(nameof(viewModel.Description), "لطفا تمامی فیلد هارا پر کنید");
            return View(viewModel);
        }

        #endregion
        #region hotel room
        public IActionResult ShowAllRooms(int id)
        {
            return View(_service.ShowAllRooms(id));
        }
        public IActionResult AddRoom(int id)
        {

            return View(new AddRoomVM() {HotelId = id});
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult AddRoom(AddRoomVM viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.File != null)
                {
                   
                        string imgName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(viewModel.File.FileName);
                        string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelRoom", imgName);

                        using (var strem = new FileStream(imgPath, FileMode.Create))
                        {
                            viewModel.File.CopyTo(strem);
                        }
                        _service.AddRoom(new HotelRoom()
                        {
                            HotelId = viewModel.HotelId,
                            BedCount = viewModel.BedCount,
                            Capacity = viewModel.Capacity,
                            Count = viewModel.Count,
                            ImageName = imgName,
                            Description = viewModel.Description,
                            Price = viewModel.Price,
                            Title = viewModel.Title,
                           
                        });
                        
                        return RedirectToAction(nameof(ShowAllRooms), new { id = viewModel.HotelId });

                }
                ModelState.AddModelError(nameof(viewModel.File), "لطفا تصویر را وارد کنید");
                return View(viewModel);
            }
            ModelState.AddModelError(nameof(viewModel.Title), "لطفا تمامی فیلد هارا پر کنید");
            return View(viewModel);
        }
        public IActionResult EditRoom(int id)
        {

            return View(_service.GetRoom(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditRoom(EditandDeleteRoomVM editandDeleteRoomVM)
        {

            if(ModelState.IsValid)
            {
                switch(_service.EditRoom(editandDeleteRoomVM))
                {
                    case 0:
                        return RedirectToAction("ShowAllHotels");
                    case 1:
                        ModelState.AddModelError(nameof(editandDeleteRoomVM.Title), "لطفا مجددا تلاش کنید");
                        return View(editandDeleteRoomVM);
                    case 2:
                        ModelState.AddModelError(nameof(editandDeleteRoomVM.IsActive), "لطفا ابتدا تاریخ رزرو را بروز کنید و دوباره تلاش کنید   ");
                        return View(editandDeleteRoomVM);
                    case 3:
                        return RedirectToAction("ShowAllRooms",new {id= editandDeleteRoomVM .HotelId});
                }
                

            }
            ModelState.AddModelError(nameof(editandDeleteRoomVM.Title), "لطفا تمامی فیلد هارا پر کنید");
            return View(editandDeleteRoomVM);
        }
        public IActionResult DeleteRoom(int id)
        {
            return View( _service.GetRoom(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteRoom(EditandDeleteRoomVM editandDeleteRoomVM)
        {
            switch (_service.DeleteRoom(editandDeleteRoomVM.Id))
            {
                case 2:
                    return RedirectToAction("ShowAllHotels");
                case 0:
                    ModelState.AddModelError(nameof(editandDeleteRoomVM.Title), "لطفا مجددا تلاش کنید");
                    return View(editandDeleteRoomVM);
                case 1:
                    return RedirectToAction("ShowAllRooms", new { id = editandDeleteRoomVM.HotelId });
            }
            return View(_service.GetRoom(editandDeleteRoomVM.Id));
        }
        #endregion
        #region Advantage
        public IActionResult ShowAllAdvantage()
        {
            return View(_service.ShowAllAdvantage());
        }
        public IActionResult AddAdvantage()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult AddAdvantage(CrudforAdvantageVM crudforAdvantageVM)
        {
            if(ModelState.IsValid)
            {
                _service.AddAdvantage(new AdvantageRoom()
                {
                    Id= crudforAdvantageVM.Id,

                });
               return RedirectToAction("ShowAllAdvantage");
            }
            ModelState.AddModelError(nameof(crudforAdvantageVM.Name), "لطفا تمامی فیلد هارا پر کنید");
            return View(crudforAdvantageVM);
        }

        public IActionResult Editdvantage(int id )
        {
            var advantage = _service.FindAdvantageRoom(id);
            if (advantage != null)
            {
                return View(new CrudforAdvantageVM()
                {
                    Id = advantage.Id,
                    Name = advantage.Name
                });
            }
            return RedirectToAction("ShowAllAdvantage");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditAdvantage(CrudforAdvantageVM crudforAdvantageVM)
        {
            if(ModelState.IsValid)
            {
                var advantage = _service.FindAdvantageRoom(crudforAdvantageVM.Id);
                if(advantage != null)
                {
                    advantage.Name = crudforAdvantageVM.Name;
                    _service.EditAdvantage(advantage);
                    return RedirectToAction("ShowAllAdvantage"); 
                }
                return RedirectToAction("ShowAllAdvantage");
            }
            ModelState.AddModelError(nameof(crudforAdvantageVM.Name), "لطفا تمامی فیلد هارا پر کنید");
            return View("ShowAllAdvantage");
        }

        public IActionResult Deletedvantage(int id)
        {
            var advantage = _service.FindAdvantageRoom(id);
            if (advantage != null)
            {
                return View(new CrudforAdvantageVM()
                {
                    Id = advantage.Id,
                    Name = advantage.Name
                });
            }
            return RedirectToAction("ShowAllAdvantage");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Deleteadvantage(CrudforAdvantageVM crudforAdvantageVM)
        {
            var advantage = _service.FindAdvantageRoom(crudforAdvantageVM.Id);
            if (advantage != null)
            {
               
                _service.DeleteAdvantage(advantage);
                return RedirectToAction("ShowAllAdvantage");
            }
            return RedirectToAction("ShowAllAdvantage");
        }
        #endregion
        #region advantageforroom
        public IActionResult ShowAdvantagesRoom(int id)
        {
            return View(_service.ShowAdvantagesRoom(id));
        }
        public IActionResult AddAdvanatgeToRoom(int id)
        {
            return View(_service.GetAdvantageRoom(id));
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult AddAdvanatgeToRoom(AddAdvantageRoomVM addAdvantageRoomVM)
        {
            
                _service.DeleteAdvantageforRoom(addAdvantageRoomVM.RoomId);
                if(addAdvantageRoomVM.AdvantageId != null)
                {

                   var advantage = new List<AdvantageToRoom>();
                   foreach (var item in addAdvantageRoomVM.AdvantageId)
                   {
                       advantage.Add(new AdvantageToRoom()
                       {
                          AdvantageId = item,
                          RoomId = addAdvantageRoomVM.RoomId

                       });
                    _service.AddAdvantageToRoom(advantage);
                    return RedirectToAction("ShowAllAdvantage", new { id = addAdvantageRoomVM.RoomId });
                   }



                }
                
            
            return View(_service.GetAdvantageRoom(addAdvantageRoomVM.RoomId));
        }
        #endregion
        #region reserve date
        public IActionResult ShowAllReserveDate(int id)
        {
            return View(_service.ShowAllReserveDate(id));
        }
        public IActionResult AddReserveDateToRoom(int id)
        {
            return View(_service.GetAddReserveDate(id));
        }
        #endregion
    }
}
