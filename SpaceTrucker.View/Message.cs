using System;
using System.Threading.Tasks;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Message : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Message;

		private Coord origin;

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 6;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
		}


	}
}
