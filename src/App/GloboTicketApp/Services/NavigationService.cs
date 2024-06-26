﻿namespace GloboTicketApp.Services
{
	internal class NavigationService : INavigationService
	{
		public async Task GoToAddEvent()
			=> await Shell.Current.GoToAsync("event/add");
		

		public async Task GoToEventDetail(Guid id)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { { "EventId", id } };
			await Shell.Current.GoToAsync("event", parameters);
		}
	}
}
