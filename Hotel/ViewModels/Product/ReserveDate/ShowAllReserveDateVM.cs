using System;
using Hotel.Models.Entities.Product;

namespace Hotel.ViewModels.Product.ReserveDate
{
	public class ShowAllReserveDateVM
	{
		public int Id { get; set; }
		public List<Reserve> reserveDates { get; set; }
	}
}

