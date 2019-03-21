using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class TrendReport : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.TrendReport;

		private Coord origin;
		private EventBroadcaster eventBroadcaster;

		public TrendReport(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
		}

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 3;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
		}

		private void PrintTrendReport()
		{
			// TODO: print trend report, how are we sending the latest trend report?
		}
	}
}
