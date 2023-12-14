using System;
using Hotel.Models.Entities.Product;

namespace Hotel.ViewModels.Product.Advantage
{
	public class ShowAdvantagesRoomVM
	{
		public int RoomId { get; set; }
        public string Name { get; set; }
		public List<AdvantageRoom> advantageRooms { get; set; }
	}
}

