using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GloboTicketApp.Models;
using GloboTicketApp.Services;
using GloboTicketApp.ViewModels.Base;
using System.Collections.ObjectModel;

namespace GloboTicketApp.ViewModels
{
	public partial class EventListOverviewViewModel : ViewModelBase
	{
		private readonly IEventService _eventService;
		private readonly INavigationService _navigationService;
		[ObservableProperty]
		private ObservableCollection<EventListItemViewModel> _events = new();

		[ObservableProperty]
		private EventListItemViewModel? _selectedEvent;
		public EventListOverviewViewModel(IEventService eventService, INavigationService navigationService)
		{
			_eventService = eventService;
			_navigationService = navigationService;
			
		}

		[RelayCommand]
		private void NavigateToSelectedDetail()
		{
			if (SelectedEvent is not null)
			{
				_navigationService.GoToEventDetail(SelectedEvent.Id);
			}
		}

		[RelayCommand]
		private void NavigateToAddEvent() 
		{
			_navigationService.GoToAddEvent();
		}

		public override async Task LoadAsync()
		{
			await Loading(GetEvents);
		}

		private async Task GetEvents()
		{
			List<EventModel> events = await _eventService.GetEvents();
			List<EventListItemViewModel> listItems = new();
			foreach (var @event in events)
			{
				listItems.Add(MapEventModelToEventListItemViewModel(@event));
			}

			Events.Clear();
			Events = listItems.ToObservableCollection();
		}

		private EventListItemViewModel MapEventModelToEventListItemViewModel(EventModel @event)
		{
			var category = new CategoryViewModel
			{
				Id = @event.Category.Id,
				Name = @event.Category.Name,
			};

			return new EventListItemViewModel(
				@event.Id,
				@event.Name,
				@event.Price,
				@event.Date,
				@event.Artists,
				(EventStatus)@event.Status,
				@event.ImageUrl,
				category);
		}
	}


	


}
