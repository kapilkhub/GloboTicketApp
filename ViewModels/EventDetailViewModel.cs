namespace GloboTicketApp.ViewModels
{

	public class EventDetailViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public double Price { get; set; }
		public string ImageUrl { get; set; }
		public EventStatus EventStatus { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public string Description { get; set; }
		public List<string> Artists { get; set; } = new();
		public CategoryViewModel Category { get; set; } = new();

		public EventDetailViewModel()
		{
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
	}
}
