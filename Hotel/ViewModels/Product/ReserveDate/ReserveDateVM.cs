using System;
using System.Collections.Generic;

namespace Hotel.ViewModels.Product.ReserveDate
{
	public class ReserveDateVM
	{
		public int RoomId { get; set; }
		public List<DateTime> reserveDate { get; set; }
	}
}

