namespace GloboTicketApp.Services
{
	public interface INavigationService
	{
		Task GoToEventDetail(Guid id);
	}
}
