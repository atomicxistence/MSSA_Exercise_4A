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
			CenterConsoleWindow();
			PrintConsoleDisplay(); 
		}

		private void CenterConsoleWindow()
		{
			var windowCenterX = Console.WindowWidth / 2;
			var windowCenterY = Console.WindowHeight / 2;

			offsetX = windowCenterX - sizeWidth / 2;
			offsetY = windowCenterY - sizeHeight / 2;
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
			Console.BackgroundColor = colorBGSurface;
			Console.ForegroundColor = colorFG;

			for (int i = 0; i < sizeHeight; i++)
			{
				Console.SetCursorPosition(offsetX, offsetY + i);
				Write.EmptySpace(sizeWidth);
			}
		}

		private void PrintViewScreenBevel()
		{
			
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
