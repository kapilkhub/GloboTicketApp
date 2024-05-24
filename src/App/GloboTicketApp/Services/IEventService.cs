using GloboTicketApp.Models;

namespace GloboTicketApp.Services
{
	public interface IEventService
	{
		Task<EventModel?> GetEvent(Guid id);
		Task<List<EventModel>> GetEvents();
		Task<bool> UpdateStatus(Guid id, EventStatusModel status);
	}
}
