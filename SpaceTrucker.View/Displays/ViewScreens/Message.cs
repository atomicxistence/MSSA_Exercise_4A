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
			int offsetX = 3;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
		}

		private void PrintMessage()
		{
			//TODO: print messages, where do we reference the messages?
		}
	}
}
