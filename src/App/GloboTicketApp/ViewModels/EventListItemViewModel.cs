using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using GloboTicketApp.Messages;

namespace GloboTicketApp.ViewModels
{
	public partial class EventListItemViewModel : ObservableObject, IRecipient<StatusChangedMessage>
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

		void IRecipient<StatusChangedMessage>.Receive(StatusChangedMessage message)
		{
			if (message.EventId == Id)
			{
				EventStatus = message.EventStatus;
			}
		}
	}
}
