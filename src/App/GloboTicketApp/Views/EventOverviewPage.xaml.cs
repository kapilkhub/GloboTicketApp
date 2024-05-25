using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventOverviewPage : ContentPageBase
{
	public EventOverviewPage(EventListOverviewViewModel eventListOverviewViewModel)
	{
		InitializeComponent();

		BindingContext = eventListOverviewViewModel;
	}
}