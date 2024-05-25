using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GloboTicketApp.Models;
using GloboTicketApp.Services;
using GloboTicketApp.ViewModels.Base;
using System.Collections.ObjectModel;

namespace GloboTicketApp.ViewModels
{
	public partial class EventDetailViewModel : ViewModelBase, IQueryAttributable
	{

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof (CancelEventCommand))]
		private EventStatus _eventStatus;

		[ObservableProperty]
		private Guid _id;

		[ObservableProperty]
		private string _name = default!;

		[ObservableProperty]
		private double _price;

		[ObservableProperty]
		private string _imageUrl = default!;

		[ObservableProperty]
		private string _description = default!;

		[ObservableProperty]
		private ObservableCollection<string> _artists = new();

		[ObservableProperty]
		private CategoryViewModel _category = new();

		[ObservableProperty]
		private DateTime _date = DateTime.Now;

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(ShowThumbnailImage))]
		private bool _showLargerImage;

		private readonly IEventService _eventService;

		public bool ShowThumbnailImage => !ShowLargerImage;

		public override async Task LoadAsync()
		{
			await Loading(async () => {
				if (Id != Guid.Empty) { 
				  await GetEvent(Id);
				}
			});
		}

		[RelayCommand(CanExecute = nameof(CanCancelEvent))]
		private async Task CancelEvent()
		{
			if (await _eventService.UpdateStatus(Id, EventStatusModel.Cancelled))
			{
				EventStatus = EventStatus.Cancelled;
			}
		}
		private bool CanCancelEvent()
		{
			return EventStatus != EventStatus.Cancelled;
		}

		public EventDetailViewModel(IEventService eventService)
		{
			_eventService = eventService;
		}

		public async Task GetEvent(Guid id)
		{
			var @event = await _eventService.GetEvent(id);

			if (@event != null)
			{
				MapEventData(@event);
			}
		}

		private void MapEventData(EventModel @event)
		{
			Id = @event.Id;
			Name = @event.Name;
			Price = @event.Price;
			ImageUrl = @event.ImageUrl!;
			EventStatus = (EventStatus)@event.Status;
			Date = @event.Date;
			Artists = @event.Artists.ToObservableCollection();
			Description = @event.Description!;
			Category = new CategoryViewModel
			{
				Id = @event.Category.Id,
				Name = @event.Category.Name
			};
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			var eventId = Convert.ToString(query["EventId"]);
			if (Guid.TryParse(eventId, out var selectedEventId))
			{
				Id=selectedEventId;
			}
		}
	}
}
