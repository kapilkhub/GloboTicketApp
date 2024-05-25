﻿using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GloboTicketApp.Models;
using GloboTicketApp.Services;
using System.Collections.ObjectModel;

namespace GloboTicketApp.ViewModels
{
	public partial class EventListOverviewViewModel : ObservableObject
	{
		private readonly IEventService _eventService;

		[ObservableProperty]
		private ObservableCollection<EventListItemViewModel> _events = new();

		[ObservableProperty]
		private EventListItemViewModel? _selectedEvent;
		public EventListOverviewViewModel(IEventService eventService)
		{
			_eventService = eventService;
			GetEvents();
		}

		[RelayCommand]
		private void NavigateToSelectedDetailCommand()
		{
			
		}

		private async void GetEvents()
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
