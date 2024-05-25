using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventDetailPage : ContentPageBase
{
	public EventDetailPage(EventDetailViewModel eventDetailViewModel)
	{
		InitializeComponent();
		BindingContext = eventDetailViewModel;
	}
}