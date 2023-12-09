using System;
using Hotel.Data;
using Hotel.Models.Entities.Product;
using Hotel.ViewModels.Product.Hotel;
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
    }
}