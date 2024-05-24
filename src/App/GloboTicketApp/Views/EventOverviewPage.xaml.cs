using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventOverviewPage : ContentPage
{
	public EventOverviewPage(EventListOverviewViewModel eventListOverviewViewModel)
	{
		InitializeComponent();

		BindingContext = eventListOverviewViewModel;
	}
}