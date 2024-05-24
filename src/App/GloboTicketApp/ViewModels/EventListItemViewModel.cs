using CommunityToolkit.Mvvm.ComponentModel;

namespace GloboTicketApp.ViewModels
{
	public partial class EventListItemViewModel : ObservableObject
	{
		[ObservableProperty]
		private Guid _id;
		[ObservableProperty]
		private string? _imageUrl;
		[ObservableProperty]
		private string _name;
		[ObservableProperty]
		private double _price;
		[ObservableProperty]
		private DateTime _date;
		[ObservableProperty]
		private EventStatus _eventStatus;
		[ObservableProperty]
		private List<string> _artists;
		[ObservableProperty]
		private CategoryViewModel? _category;


		public EventListItemViewModel(
			Guid id,
			string name,
			double price,
			DateTime date,
			List<string> artists,
			EventStatus status,
			string? imageUrl = null,
			CategoryViewModel? category = null)
		{
			Id = id;
			ImageUrl = imageUrl;
			Name = name;
			Price = price;
			Date = date;
			Artists = artists;
			EventStatus = status;
			Category = category;
		}
	}
}
