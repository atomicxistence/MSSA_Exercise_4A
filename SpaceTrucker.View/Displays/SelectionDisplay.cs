using System;

namespace SpaceTrucker.View
{
	class SelectionDisplay : IDisplay
	{
		private Coord origin;

		private int selectionWidth = 57;
		private int selectionHeight = 13;

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 51;
			int offsetY = 2;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintSelectionScreen();
			PrintSelectionBorder();
		}

		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < selectionHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel - i);
				Write.EmptySpace(selectionWidth + (bevel * 2));
			}
		}

		private void PrintSelectionScreen()
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < selectionHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Write.EmptySpace(selectionWidth);
			}
		}

		private void PrintSelectionBorder()
		{
			Console.ForegroundColor = Write.ColorDisplayTable;
			Console.BackgroundColor = Write.ColorDisplayBG;
			
			// Top border
			Console.SetCursorPosition(origin.X, origin.Y - 12);
			Console.Write("┌─                                                     ─┐");

			//Bottom border
			Console.SetCursorPosition(origin.X, origin.Y);
			Console.Write("└─                                                     ─┘");
		}
	}
}
