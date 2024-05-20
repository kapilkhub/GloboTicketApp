using GloboTicketApp.ViewModels;
using System.Globalization;

namespace GloboTicketApp.Converters
{
	public class StatusEnumToTextConvertor : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if (value is not EventStatus status)
			{
				return string.Empty;
			}
			return status switch
			{
				EventStatus.AlmostSoldOut => "Almost sold out",
				EventStatus.Cancelled => "Event Cancelled",
				EventStatus.OnSale => "On Sale",
				EventStatus.SalesClosed => "Sales Closed",
				_ => string.Empty
			};
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
