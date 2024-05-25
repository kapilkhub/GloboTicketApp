using CommunityToolkit.Mvvm.Input;

namespace GloboTicketApp.ViewModels.Base
{
	public interface IViewModdelBase
	{
		public IAsyncRelayCommand InitializeAsyncCommand {get;}
	}
}