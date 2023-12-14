using System;
namespace Hotel.ViewModels.Product.HotelRooms
{
	public class ShowAllRoomsVM
	{
		public int Id { get; set; }
		public IEnumerable<ShowSingleRoomVM>  showSingleRooms { get; set; }

	}
}
