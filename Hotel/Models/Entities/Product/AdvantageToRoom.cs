using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entities.Product
{
	public class AdvantageToRoom
	{
		public int RoomId { get; set; }
		public int AdvantageId { get; set; }

		[ForeignKey(nameof(RoomId))]
		public Hotell hotelRoom { get; set; }


        [ForeignKey(nameof(AdvantageId))]
        public AdvantageRoom advantageRoom { get; set; }
	}
}

