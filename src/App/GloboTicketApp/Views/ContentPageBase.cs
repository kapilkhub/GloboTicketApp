using GloboTicketApp.ViewModels.Base;

namespace GloboTicketApp.Views
{
	public class ContentPageBase : ContentPage
	{
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			if (BindingContext is not IViewModdelBase vmbase)
			{
				return;
			}
			else
			{
				await vmbase.InitializeAsyncCommand.ExecuteAsync(null);
			}
		}
	}
}
