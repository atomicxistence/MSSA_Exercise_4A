using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Map : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Map;

		private Coord origin;

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 3;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
		}

		private void PrintMap()
		{
			//TODO: print map string array
		}
	}
}
