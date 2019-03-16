using System;

namespace SpaceTrucker.View
{
	class ViewScreenDisplay : IDisplay
	{
		private Coord origin;

		private int sizeWidth = 144;
		private int sizeHeight = 30;
	

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintBlankViewScreen();
		}

		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < sizeHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel - i);
				Write.EmptySpace(sizeWidth + (bevel * 2));
			}
		}

		private void PrintBlankViewScreen()
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < sizeHeight; i++)
			{
				Console.SetCursorPosition(origin.X , origin.Y - i);
				Write.EmptySpace(sizeWidth);
			}
		}
	}
}
