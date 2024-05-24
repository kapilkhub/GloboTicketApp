using GloboTicketApp.Models;

namespace GloboTicketApp.Repositories
{
	public interface IEventRepository
	{
		Task<EventModel?> GetEvent(Guid id);
		Task<List<EventModel>> GetEvents();
		Task<bool> UpdateStatus(Guid id, EventStatusModel status);
	}
}
