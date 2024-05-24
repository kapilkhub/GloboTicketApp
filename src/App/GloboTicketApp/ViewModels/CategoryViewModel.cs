using CommunityToolkit.Mvvm.ComponentModel;

namespace GloboTicketApp.ViewModels
{

	public partial class CategoryViewModel: ObservableObject
	{
		[ObservableProperty]
		private Guid _id;

		[ObservableProperty]
		private string _name = default!;
	}
}
