using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GloboTicketApp.ViewModels
{

	public class EventDetailViewModel : INotifyPropertyChanged
	{
		private double _price;
		private bool _showLargerImage;
		private EventStatus _eventStatus;

		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public double Price
		{
			get => _price; 
			set
			{
				
				if (!Equals(_price, value))
				{
					_price = value;
					OnPropertyChanged();
				}
			}
		}
		public string ImageUrl { get; set; }
		public EventStatus EventStatus { get => _eventStatus; set  {
				if (value != _eventStatus) 
				{
					_eventStatus = value;
					OnPropertyChanged();
					((Command)CancelEventCommand).ChangeCanExecute();
				}
			} 
		}
		public DateTime Date { get; set; } = DateTime.Now;
		public string Description { get; set; }
		public List<string> Artists { get; set; } = new();
		public CategoryViewModel Category { get; set; } = new();

		public bool ShowThumbnailImage => !ShowLargerImage;
		public bool ShowLargerImage { get => _showLargerImage; set {
				if (!Equals(_showLargerImage, value))
				{
					_showLargerImage = value;
					OnPropertyChanged();
					OnPropertyChanged(nameof(ShowThumbnailImage));
				}
			} 
		}
		public EventDetailViewModel()
		{
			CancelEventCommand = new Command(CancelEvent, CanCancelEvent);
			Id = Guid.Parse("EE272F8B-6096-4CB6-8625-BB4BB2D89E8B");
			Name = "John Egberts Live";
			Price = 65;
			ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/globoticket/images/banjo.jpg";
			EventStatus = EventStatus.OnSale;
			Date = DateTime.Now.AddMonths(6);
			Description = "Join John for his farewell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.";
			Artists = new List<string> { "John Egbert", "Jane Egbert" };
			Category = new CategoryViewModel
			{
				Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
				Name = "Concert"
			};
		}

		private bool CanCancelEvent(object arg)
		{
			return EventStatus != EventStatus.Cancelled;
		}

		private void CancelEvent(object obj)
		{
			EventStatus = EventStatus.Cancelled;
		}

		public ICommand CancelEventCommand { get; }

		public event PropertyChangedEventHandler? PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string? propertyName=null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


	}
}
