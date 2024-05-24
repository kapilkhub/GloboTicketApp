using GloboTicketApp.Models;
using GloboTicketApp.Repositories;

namespace GloboTicketApp.Services
{
	public class EventService : IEventService
	{
		private readonly IEventRepository _eventRepository;

		public EventService(IEventRepository eventRepository)
        {
			_eventRepository = eventRepository;
		}
        public Task<EventModel?> GetEvent(Guid id)
		{
			return _eventRepository.GetEvent(id);
		}

		public Task<List<EventModel>> GetEvents()
		{
			return _eventRepository.GetEvents();
		}

		public Task<bool> UpdateStatus(Guid id, EventStatusModel status)
		{
			return _eventRepository.UpdateStatus(id, status);	
		}
	}
}
