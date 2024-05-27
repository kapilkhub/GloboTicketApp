﻿using GloboTicketApp.Views;

namespace GloboTicketApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("event", typeof(EventDetailPage));
			Routing.RegisterRoute("event/add", typeof(EventAddEditPage));
		}
	}
}
