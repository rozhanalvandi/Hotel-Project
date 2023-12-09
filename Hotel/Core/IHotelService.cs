using Hotel.Models.Entities.Product;
using Hotel.ViewModels.Product.Hotel;

namespace Hotel.Core
{
    public interface IHotelService
    {


        public IEnumerable<Hotell> GetAllHotels();
        public void AddHotel(Hotell hotel);
        public void AddAddress(HotelAdderss hotelAdderss);

        public void UpdateHotel(Hotell hotel);
        public void UpdateAddress(HotelAdderss address);
        public Hotell GetHotelById(int id);
        public EditHotelViewModel GetHotelViewModel(int id);
        public void DeleteHotel(Hotell hotell);
        public void DeleteAdderss(HotelAdderss hotelAdderss);



    }
}

