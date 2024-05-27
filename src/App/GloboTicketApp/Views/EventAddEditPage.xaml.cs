using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Views;

public partial class EventAddEditPage : ContentPageBase
{
	public EventAddEditPage(EventAddEditViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}