using System;

namespace SpaceTrucker.View
{
	static class Write
	{
		public static ConsoleColor ColorDefaultFG => ConsoleColor.White;
		public static ConsoleColor ColorDefaultBG => ConsoleColor.Black;
		public static ConsoleColor ColorSurfaceFG => ConsoleColor.DarkGray;
		public static ConsoleColor ColorSurfaceBG => ConsoleColor.Gray;
		public static ConsoleColor ColorBevelBG => ConsoleColor.DarkGray;
		public static ConsoleColor ColorDisplayFG => ConsoleColor.Cyan;
		public static ConsoleColor ColorDisplayBG => ConsoleColor.Black;
		public static ConsoleColor ColorDisplayTable => ConsoleColor.DarkYellow;

		public static void EmptySpace(int width)
		{
			for (int i = 0; i < width; i++)
			{
				Console.Write(" ");
			}
		}
	}
}
