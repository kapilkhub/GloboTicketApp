using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage()
	{
		InitializeComponent();
		BindingContext = new EventDetailViewModel();

		LabelEventName.SetBinding(Label.TextProperty, nameof(EventDetailViewModel.Name), BindingMode.OneWay);
	}
}