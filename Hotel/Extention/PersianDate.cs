using System;
using System.Globalization;

namespace Hotel.Extention
{
	public  static class PersianDate
	{
		public static string ToShamsiDate(this DateTime date)
		{

			PersianCalendar pc = new PersianCalendar();
			return pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date).ToString("00");

		}
		public static DateTime ToMiladi(this DateTime date)
		{
			return new DateTime(date.Year , date.Year, date.Month, new PersianCalendar());
		}
	}
}

