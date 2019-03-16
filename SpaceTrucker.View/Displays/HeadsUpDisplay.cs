using System;

namespace SpaceTrucker.View
{
	class HeadsUpDisplay : IDisplay
	{
		private Coord origin;

		private int hudWidth = 40;
		private int hudHeight = 13;

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 2;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintHUDScreen();
		}

		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < hudHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel - i);
				Write.EmptySpace(hudWidth + (bevel * 2));
			}
		}

		private void PrintHUDScreen()
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < hudHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Write.EmptySpace(hudWidth);
			}
		}
	}
}
