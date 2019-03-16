using System;

namespace SpaceTrucker.View
{
	class ShipConsoleDisplay : IDisplay
	{
		private Coord origin;

		private int sizeWidth;
		private int sizeHeight;

		public ShipConsoleDisplay(int sizeWidth, int sizeHeight)
		{
			this.sizeWidth = sizeWidth;
			this.sizeHeight = sizeHeight;
		}

		public void InitialRefresh(Coord origin)
		{
			this.origin = origin;
			PrintSurface(); 
		}

		private void PrintSurface()
		{
			Console.BackgroundColor = Write.ColorSurfaceBG;
			Console.ForegroundColor = Write.ColorSurfaceFG;

			for (int i = 0; i < sizeHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Write.EmptySpace(sizeWidth);
			}
		}
	}
}
