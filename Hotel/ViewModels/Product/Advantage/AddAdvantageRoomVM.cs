using System;
using Hotel.Models.Entities.Product;

namespace Hotel.ViewModels.Product.Advantage
{
	public class AddAdvantageRoomVM
	{
		public int RoomId { get; set; }
		public List<int> AdvantageId { get; set; }
        public List<AdvantageRoom>? advantageRooms { get; set; }
    }
}

