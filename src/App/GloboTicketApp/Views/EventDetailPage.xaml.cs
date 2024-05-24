using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage(EventDetailViewModel eventDetailViewModel)
	{
		InitializeComponent();
		BindingContext = eventDetailViewModel;

		
	}
}