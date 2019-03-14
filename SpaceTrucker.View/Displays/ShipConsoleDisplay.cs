using System;

namespace SpaceTrucker.View
{
	class ShipConsoleDisplay : IDisplay
	{
		private ConsoleColor colorFG = ConsoleColor.Black;
		private ConsoleColor colorBGSurface = ConsoleColor.Gray;
		private ConsoleColor colorBGBevel = ConsoleColor.DarkGray;
		
		private int offsetX;
		private int offsetY;

		private int sizeWidth = 800;
		private int sizeHeight = 600;

		public void InitialRefresh()
		{
			//TODO: run through print methods
		}

		private void CenterConsoleWindow()
		{
			//TODO: set offsets to center the display in the console window
		}
	}
}
