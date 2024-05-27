using CommunityToolkit.Mvvm.ComponentModel;
using GloboTicketApp.ViewModels.Base;

namespace GloboTicketApp.ViewModels
{
	public partial class EventAddEditViewModel :ViewModelBase
	{
		[ObservableProperty]
		private string _name = default!;

		[ObservableProperty]
		private string _imageUrl = default!;

		[ObservableProperty]
		private double _price;

		[ObservableProperty]
		private DateTime? _date = DateTime.Now;

		[ObservableProperty]
		private string _description = default!;

		[ObservableProperty]
		private string _pageTitle;

        public EventAddEditViewModel()
        {
			PageTitle = "Add Event";
			Price = 25;
        }

        //[ObservableProperty]
        //private CategoryViewModel? _category = new();

    }
}
