using System;
using System.Collections.Generic;
using Hotel.Data;
using Hotel.Models.Entities.Product;
using Hotel.ViewModels.Product.Advantage;
using Hotel.ViewModels.Product.Hotel;
using Hotel.ViewModels.Product.HotelRooms;
using Hotel.ViewModels.Product.HotelRules;
using Hotel.ViewModels.Product.ReserveDate;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Core
{
	public class HotelService : IHotelService
	{
        private MyContext _myContext;

        

        public HotelService(MyContext myContext)
        {
            _myContext = myContext;
        }
  

        public void AddAddress(HotelAdderss hotelAdderss)
        {
            _myContext.hotelAddresses.Add(hotelAdderss);
            _myContext.SaveChanges();
        }
        #region hotel base
        public void AddHotel(Hotell hotel)
        {
            _myContext.hotels.Add(hotel);
            _myContext.SaveChanges();
        }

        public void DeleteAdderss(HotelAdderss hotelAdderss)
        {
            _myContext.hotelAddresses.Remove(hotelAdderss);
            _myContext.SaveChanges();
        }

        public void DeleteHotel(Hotell hotell)
        {
            _myContext.hotels.Remove(hotell);

        }

        public IEnumerable<Hotell> GetAllHotels()
        {
            return _myContext.hotels.ToList();

        }

        public Hotell GetHotelById(int id)
        {
            return _myContext.hotels.Include(a => a.hotelAdderss).SingleOrDefault(h => h.Id == id) ?? throw new Exception();
        }

        public EditHotelViewModel GetHotelViewModel(int id)
        {
            return _myContext.hotels.Include(a => a.hotelAdderss).Where(h => h.Id == id)
                .Select(eh => new EditHotelViewModel
                {
                    Id = eh.Id,
                    Title = eh.Title,
                    Description = eh.Description,
                    EnteryTime = eh.EnteryTime,
                    ExitTime = eh.ExitTime,
                    IsActive = eh.IsActive,
                    RoomCount = eh.RoomCount,
                    StageCount = eh.StageCount,
                    Address = eh.hotelAdderss.Address,
                    City = eh.hotelAdderss.City,
                    State = eh.hotelAdderss.State,
                    PostalCode = eh.hotelAdderss.PostalCode

                }).SingleOrDefault() ?? throw new Exception();
        }
        public void UpdateAddress(HotelAdderss address)
        {
            _myContext.hotelAddresses.Update(address);
            _myContext.SaveChanges();
        }

        public void UpdateHotel(Hotell hotel)
        {
            _myContext.hotels.Update(hotel);
            _myContext.SaveChanges();
        }

        #endregion
        #region hotel gallery
        public IEnumerable<HotelGallery> HotelGalleries(int id)
        {
            return _myContext.hotelGalleries.Where(h => h.HotelId == id).ToList();
        }
         
        public void AddImage(HotelGallery hotelGallery)
        {
            _myContext.hotelGalleries.Add(hotelGallery);
            _myContext.SaveChanges();
        }

        public HotelGallery GetImageById(int id)
        {
            var image = _myContext.hotelGalleries.Find(id) ?? throw new Exception(); 
            return image;
        }

        public void DeleteGallery(HotelGallery hotelGallery)
        {

            _myContext.hotelGalleries.Remove(hotelGallery);
            _myContext.SaveChanges();
        }

        public bool DeleteImage(string imagename)
        {
            try
            {
                 string path= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelImages", imagename);
                 File.Delete(path);
                 _myContext.SaveChanges();
                 return true;
            }
            catch
            {
                return false;

            }
        }

        #endregion
        #region hotel rules
        public IEnumerable<HotelRules> ShowAllRules(int id)
        {
            return _myContext.hotelRules.Where(h => h.HotelId == id).ToList();
        }

        public void AddRule(HotelRules hotelRules)
        {
            _myContext.hotelRules.Add(hotelRules);
            _myContext.SaveChanges();
             
        }

        public CrudForRulesVM GetRuleViewModel(int id)
        {
            var rule = FindHotelRule(id);
            return new CrudForRulesVM()
            {
                Id = rule.Id,
                Description = rule.Description
            };
        }

        public HotelRules FindHotelRule(int id)
        {
            return _myContext.hotelRules.Find(id) ?? throw new Exception();
        }

        public void EditRule(HotelRules hotelRules)
        {
            _myContext.hotelRules.Update(hotelRules);
            _myContext.SaveChanges();
        }

        public void DeleteRule(HotelRules hotelRules)
        {
            _myContext.hotelRules.Remove(hotelRules);
            _myContext.SaveChanges();
        }


        #endregion
        #region hotel rooms
        public ShowAllRoomsVM ShowAllRooms(int id)
        {
            var rooms= _myContext.hotelRooms.Include(d => d.reserves).Include(a => a.advantageToRooms).AsQueryable().
                 Where(r => r.HotelId == id);
            var showroom = rooms.Select(r => new ShowSingleRoomVM()
            {
                Id = r.Id,
                BedCount = r.BedCount,
                Capacity = r.Capacity,
                ImageName = r.ImageName,
                Title = r.Title,
                Price = r.Price,
                ReserveTime = r.reserves.SingleOrDefault(d => d.ReserveDate >= DateTime.Now).ReserveDate,
                advantagesRooms = r.advantageToRooms.Select(a => a.advantageRoom).ToList()

            }).ToList();
            return new ShowAllRoomsVM() { Id = id, showSingleRooms = showroom };
        }

        public void AddRoom(HotelRoom hotelRoom)
        {
            _myContext.hotelRooms.Add(hotelRoom);
            _myContext.SaveChanges();
           
        }
        public EditandDeleteRoomVM GetRoom(int id)
        {
            var room = GetRoomById(id);
            return new EditandDeleteRoomVM()
            {
                Id = room.Id,
                BedCount = room.BedCount,
                Capacity = room.Capacity,
                Count = room.Count,
                Description = room.Description,
                ImageName = room.ImageName,
                Price = room.Price,
                Title = room.Title,
                IsActive = room.IsActive
            };
        }

        public HotelRoom GetRoomById(int id)
        {
            return _myContext.hotelRooms.Include(d => d.reserves).SingleOrDefault(r => r.Id == id);
        }

        public int EditRoom(EditandDeleteRoomVM VM)
        {
            var room = GetRoomById(VM.Id);
            if(room!= null)
            {
                try
                {
                    if( VM.File != null)
                    {
                        string lastimage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelRoom", VM.ImageName);
                        File.Delete(lastimage);

                        string imgName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(VM.File.FileName);
                        string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelRoom", imgName);

                        using (var strem = new FileStream(imgPath, FileMode.Create))
                        {
                            VM.File.CopyTo(strem);
                        }
                        room.ImageName = imgName;
                    }
                    if (VM.IsActive && !room.reserves.Any(r => r.ReserveDate>=DateTime.Now))
                    {

                        return 2;
                    }
                    room.BedCount = VM.BedCount;
                    room.Capacity = VM.Capacity;
                    room.Description = VM.Description;
                    room.Count = VM.Count;
                    room.Price = VM.Price;
                    room.IsActive = VM.IsActive;
                    room.Title = VM.Title;
                    room.HotelId = VM.HotelId;
                    _myContext.hotelRooms.Update(room);
                    _myContext.SaveChanges(); 

                }
                catch
                {
                    return 1;

                }

            }
            return 0; 
        }

        public int DeleteRoom(int id)
        {
            var room = GetRoomById(id);
            if(room != null)
            {

               try
               {
                  string lastimage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelRoom", room.ImageName);
                  File.Delete(lastimage);
                  _myContext.hotelRooms.Remove(room);
                  _myContext.SaveChanges();
                  return 1;
               }
               catch(Exception)
               {
                return 0; 
               }

            }
            return 2;
            
        }

        #endregion
        #region Advantage

        public ICollection<AdvantageRoom> ShowAllAdvantage()
        {
            return _myContext.advantageRooms.ToList();
        }

        public AdvantageRoom FindAdvantageRoom(int id)
        {
            return _myContext.advantageRooms.SingleOrDefault(a => a.Id==id);
        }

        public void AddAdvantage(AdvantageRoom incomeModel)
        {
            _myContext.advantageRooms.Add(incomeModel);
            _myContext.SaveChanges();
        }

        public void EditAdvantage(AdvantageRoom viewModel)
        {
            _myContext.advantageRooms.Update(viewModel);
            _myContext.SaveChanges();
        }

        public void DeleteAdvantage(AdvantageRoom incomeModel)
        {
            _myContext.advantageRooms.Remove(incomeModel);
            _myContext.SaveChanges();
        }
        #region advantagetoroom
        public ShowAdvantagesRoomVM ShowAdvantagesRoom(int id)
        {
            var room = _myContext.hotelRooms.SingleOrDefault(a => a.Id == id);
            return new ShowAdvantagesRoomVM()
            {
                 RoomId = room.Id,
                 Name = room.Title,
                 advantageRooms = _myContext.advantageToRs.Include(a => a.advantageRoom)
                 .Where(x => x.RoomId == id).Select(x => x.advantageRoom).ToList()

            };
        }

        public AddAdvantageRoomVM GetAdvantageRoom(int id)
        {
            var room = _myContext.advantageRooms.SingleOrDefault(x => x.Id == id);
            if(room != null)
            {
                return new AddAdvantageRoomVM()
                {
                    advantageRooms = _myContext.advantageRooms.ToList(),
                    RoomId = room.Id,
                    AdvantageId = _myContext.advantageToRs.Where(e => e.RoomId == room.Id).Select(c => c.AdvantageId).ToList()

                };

            }
            return null;
        }

        public void AddAdvantageToRoom(List<AdvantageToRoom> advantageToRoom)
        {
            _myContext.advantageToRs.AddRange(advantageToRoom);
            _myContext.SaveChanges();
        }

        public void DeleteAdvantageforRoom(int id)
        {
            var advantage = _myContext.advantageToRs.Where(x => x.RoomId == id);
            _myContext.advantageToRs.RemoveRange(advantage);
            _myContext.SaveChanges(); 
        }

        
        #endregion

        #endregion

        #region reservedate
        public ShowAllReserveDateVM ShowAllReserveDate(int id)
        {
            return new ShowAllReserveDateVM()
            {
                reserveDates = _myContext.reserveDates.Where(x => x.RoomId == id && x.ReserveDate >= DateTime.Now).ToList(),
                Id = id
            };
         
        }

        public ReserveDateVM GetAddReserveDate(int id)
        {
            var datetimes = new List<DateTime>();
            for ( int i =0; i<30;i++)
            {
                datetimes.Add(DateTime.Now.AddDays(i));
            }
            return new ReserveDateVM()
            {
                RoomId = id,
                reserveDate = datetimes
            };
        }

        //public int AddReserveDate(ReserveDateVM reserveDate)
        //{
        //    try
        //    {

        //       var room = GetRoom(reserveDate.RoomId);
        //       var dates = new List<Reserve>();
        //       foreach(var item  in reserveDate.reserveDate)
        //       {
        //          dates.Add(new Reserve()
        //          {
        //            RoomId=room.Id,
        //            Count=room.Count,
        //            ReserveDate=item,
        //            Price=room.Price
        //          });
 
        //       }
        //       _myContext.reserveDates.AddRange(dates);
        //       _myContext.SaveChanges();

        //    }
        //    catch(Exception)
        //    {

        //        return 0;
        //    }
            
        //}
        #endregion

    }
}