using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GloboTicketApp.Models;
using GloboTicketApp.Services;
using GloboTicketApp.ViewModels.Base;
using System.Collections.ObjectModel;

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

		[ObservableProperty]
		private EventStatus _eventStatus;

		[ObservableProperty]
		private CategoryViewModel _category = new();

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(AddArtistCommand))]
		private string _addedArtist= default!;

		public ObservableCollection<CategoryViewModel> Categories { get; set; } = new();

		public ObservableCollection<string> Artists { get; set; } = new();

		[RelayCommand(CanExecute =nameof(CanAddArtist))]
		private void AddArtist() 
		{
			Artists.Add(AddedArtist);
			AddedArtist = string.Empty;
		}

		private bool CanAddArtist() 
		{
			return AddedArtist != string.Empty;
		}


		private readonly ICategoryService _categoryService;

		public EventAddEditViewModel(ICategoryService categoryService)
        {
			PageTitle = "Add Event";
			Price = 25;
			_categoryService = categoryService;
		}

		public async override Task LoadAsync()
		{
			await Loading(async () => {
				var categories = await _categoryService.GetCategories();
				MapCategoryModel(categories);
			});
		}

		private void MapCategoryModel(List<CategoryModel> categories)
		{
			foreach (var category in categories)
			{
				Categories.Add(new CategoryViewModel
				{
					Id = category.Id,
					Name = category.Name
				});
			}
		}

		public List<EventStatus> StatusList { get; set; } 
			= Enum.GetValues(typeof(EventStatus)).Cast<EventStatus>().ToList();

        //[ObservableProperty]
        //private CategoryViewModel? _category = new();

    }
}
