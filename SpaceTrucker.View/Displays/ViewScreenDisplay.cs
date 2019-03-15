using System;

namespace SpaceTrucker.View
{
	class ViewScreenDisplay : IDisplay
	{
		private Coord origin;

		private int sizeWidth = 790;
		private int sizeHeight = 590;
	

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 5;
			int offsetY = 100; 
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintBlankViewScreen();
		}

		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorSurfaceFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < sizeHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel + i);
				Write.EmptySpace(sizeWidth + (bevel * 2));
			}
		}

		private void PrintBlankViewScreen()
		{
			//TODO: print blanked display
		}
	}
}
