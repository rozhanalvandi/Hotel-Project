using Hotel.Models.Entities.Product;
using Hotel.ViewModels.Product.Advantage;
using Hotel.ViewModels.Product.Hotel;
using Hotel.ViewModels.Product.HotelRooms;
using Hotel.ViewModels.Product.HotelRules;
using Hotel.ViewModels.Product.ReserveDate;

namespace Hotel.Core
{
    public interface IHotelService
    {

        #region hotel base
        public IEnumerable<Hotell> GetAllHotels();
        public void AddHotel(Hotell hotel);
        public void AddAddress(HotelAdderss hotelAdderss);
        public void UpdateHotel(Hotell hotel);
        public void UpdateAddress(HotelAdderss address);
        public Hotell GetHotelById(int id);
        public EditHotelViewModel GetHotelViewModel(int id);
        public void DeleteHotel(Hotell hotell);
        public void DeleteAdderss(HotelAdderss hotelAdderss);
        
        #endregion
        #region hotel gallery
        public IEnumerable<HotelGallery> HotelGalleries(int id);
        public void AddImage(HotelGallery hotelGallery);
        public HotelGallery GetImageById(int id);
        public void DeleteGallery(HotelGallery hotelGallery);
        public bool DeleteImage(string imagename);
        #endregion
        #region hotel rules
        public IEnumerable<HotelRules> ShowAllRules(int id);
        public void AddRule(HotelRules hotelRules);
        public CrudForRulesVM GetRuleViewModel(int id);
        public HotelRules FindHotelRule(int id);
        public void EditRule(HotelRules hotelRules);
        public void DeleteRule(HotelRules hotelRules);
        #endregion
        #region hotel rooms
        public ShowAllRoomsVM ShowAllRooms(int id);
        public void AddRoom(HotelRoom hotelRoom);
        public HotelRoom GetRoomById(int id);
        public EditandDeleteRoomVM GetRoom(int id);
        public int EditRoom(EditandDeleteRoomVM VM);
        public int DeleteRoom(int id);



        #endregion
        #region Advantage
         public ICollection<AdvantageRoom> ShowAllAdvantage();
         public AdvantageRoom FindAdvantageRoom(int id);
         public void AddAdvantage(AdvantageRoom incomeModel);
         public void EditAdvantage(AdvantageRoom viewModel);
         public void DeleteAdvantage(AdvantageRoom incomeModel);

        #endregion
        #region AdvantageToRoom
        public ShowAdvantagesRoomVM ShowAdvantagesRoom(int id);
        public AddAdvantageRoomVM GetAdvantageRoom(int id);
        public void AddAdvantageToRoom(List<AdvantageToRoom> advantageToRoom);
        public void DeleteAdvantageforRoom(int id);

        #endregion
        #region reservedate
        public ShowAllReserveDateVM ShowAllReserveDate(int id);
        public ReserveDateVM GetAddReserveDate(int id);
        //public int AddReserveDate(ReserveDateVM reserveDate);
        #endregion


    }
}


