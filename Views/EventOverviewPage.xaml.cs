using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventOverviewPage : ContentPage
{
	public EventOverviewPage()
	{
		InitializeComponent();

		BindingContext = new EventListOverviewViewModel();
	}
}