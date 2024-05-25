using GloboTicketApp.ViewModels;

namespace GloboTicketApp.Messages
{
	internal class StatusChangedMessage
	{
		public Guid EventId { get; set; }
		public EventStatus EventStatus { get; set; }
	}
}
