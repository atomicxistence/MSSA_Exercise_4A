using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class TravelAnimation : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.TravelAnimation;

		private Coord origin;

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintAnimation();
		}

		public void EventSubscribe() { }

		public void EventUnsubscribe() { }

		private void PrintAnimation()
		{
			//TODO: make string arrays for each animation frame
		}
	}
}
