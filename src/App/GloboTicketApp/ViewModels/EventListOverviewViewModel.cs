using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace GloboTicketApp.ViewModels
{
	public partial class EventListOverviewViewModel : ObservableObject
	{
		[ObservableProperty]
		private ObservableCollection<EventListItemViewModel> _events = new();

		[ObservableProperty]
		private EventListItemViewModel? _selectedEvent;
		public EventListOverviewViewModel()
		{
			Events = new ObservableCollection<EventListItemViewModel>
		{
			new(Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
				"John Egbert Live",
				65,
				DateTime.Now.AddMonths(6),
				new List<string> { "John Egbert", "Jane Egbert" },
				EventStatus.OnSale,
				"https://lindseybroospluralsight.blob.core.windows.net/globoticket/images/banjo.jpg",
				new CategoryViewModel
				{
					Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
					Name = "Concert"
				}),
			new(Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
				"The State of Affairs: Michael Live!", 85,
				DateTime.Now.AddMonths(9),
				new List<string> { "John Johnson" },
				EventStatus.OnSale,
				"https://lindseybroospluralsight.blob.core.windows.net/globoticket/images/michael.jpg",
				new CategoryViewModel
				{
					Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
					Name = "Concert"
				})
		};

			AddEvent().GetAwaiter();

		}

		private async Task AddEvent()
		{
			await  Task.Delay(5000);

			var @event = new EventListItemViewModel(Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C09}"),
				"Clash of the DJs!", 
				85,
				DateTime.Now.AddMonths(4),
				new List<string> { "DJ 'The Mike'" },
				EventStatus.OnSale,
				"https://lindseybroospluralsight.blob.core.windows.net/globoticket/images/dj.jpg",
				new CategoryViewModel
				{
					Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
					Name = "Concert"
				});

			Events.Add(@event);
		}
	}
}
