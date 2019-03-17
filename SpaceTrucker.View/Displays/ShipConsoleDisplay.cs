using System;
using System.Collections.Generic;

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
			PrintButtons();
		}

		#region Private Methods
		private void PrintSurface()
		{
			Console.BackgroundColor = Write.ColorSurfaceBG;
			Console.ForegroundColor = Write.ColorSurfaceFG;

			for (int i = 0; i < sizeHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Write.EmptySpace(sizeWidth);
			}

			Console.ResetColor();
		}

		private void PrintButtons()
		{
			var buttonOffsetX = 44;
			var buttonOffsetY = 15;
			var buttonOrigin = new Coord(origin.X + buttonOffsetX, origin.Y - buttonOffsetY + 1);

			var buttonSize = 5;
			var buttons = 3;

			var buttonCharacters = new List<string>
			{
				"M",
				"I",
				"T"
			};

			Console.BackgroundColor = Write.ColorSurfaceBG;
			Console.ForegroundColor = Write.ColorSurfaceFG;

			for (int i = 0; i < buttons; i++)
			{
				var orderedButtonOffset = i * 5;

				PrintButtonBevel(buttonSize, orderedButtonOffset, buttonOrigin);
				PrintButtonSurface(orderedButtonOffset, buttonOrigin, buttonCharacters[i]);
			}

			Console.ResetColor();
		}

		private void PrintButtonBevel(int buttonSize, int orderedButtonOffset, Coord buttonOrigin)
		{
			Console.BackgroundColor = Write.ColorBevelBG;
			Console.ForegroundColor = Write.ColorSurfaceFG;

			for(int i = 0; i < 3; i++)
			{
				Console.SetCursorPosition(buttonOrigin.X, buttonOrigin.Y + orderedButtonOffset + i);
				Write.EmptySpace(buttonSize);
			}
		}

		private void PrintButtonSurface(int orderedButtonOffset, Coord buttonOrigin, string buttonCharacter)
		{
			Console.BackgroundColor = Write.ColorSurfaceBG;
			Console.ForegroundColor = Write.ColorSurfaceFG;

			var buttonTexts = new List<string>
			{
				"▀▀▀",
				$" {buttonCharacter} ",
				"▄▄▄"
			};

			for (int i = 0; i < 3; i++)
			{
				Console.SetCursorPosition(buttonOrigin.X + 1, buttonOrigin.Y + orderedButtonOffset + i);
				Console.Write(buttonTexts[i]);
			}
		}
		#endregion
	}
}
