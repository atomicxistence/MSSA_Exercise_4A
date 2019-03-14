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
			PrintConsoleDisplay(); 
		}

		private void CenterConsoleWindow()
		{
			//TODO: set offsets to center the display in the console window
		}

		private void PrintConsoleDisplay()
		{
			PrintSurface();
			PrintViewScreenBevel();
			PrintHUDBevel();
			PrintSelectionBevel();
		}

		private void PrintSurface()
		{
			throw new NotImplementedException();
		}

		private void PrintViewScreenBevel()
		{
			throw new NotImplementedException();
		}

		private void PrintHUDBevel()
		{
			throw new NotImplementedException();
		}

		private void PrintSelectionBevel()
		{
			throw new NotImplementedException();
		}
	}
}
