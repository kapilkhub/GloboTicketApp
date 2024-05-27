namespace GloboTicketApp.Services
{
	public interface INavigationService
	{
		Task GoToAddEvent();
		Task GoToEventDetail(Guid id);
	}
}
