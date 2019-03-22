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
		public static ConsoleColor ColorDisplayFG => ConsoleColor.Yellow;
		public static ConsoleColor ColorDisplayBG => ConsoleColor.Black;
		public static ConsoleColor ColorSelectedOptionFG => ConsoleColor.Black;
		public static ConsoleColor ColorSelectedOptionBG => ConsoleColor.Green;
		public static ConsoleColor ColorUnselectedOptionFG => ConsoleColor.DarkGreen;
		public static ConsoleColor ColorDisplayTable => ConsoleColor.DarkYellow;
		public static ConsoleColor ColorMessageFG => ConsoleColor.Cyan;
		public static ConsoleColor ColorMessageBG => ConsoleColor.Black;

		public static ConsoleColor ColorHighFuel => ConsoleColor.Cyan;
		public static ConsoleColor ColorLowFuel => ConsoleColor.Yellow;
		public static ConsoleColor ColorUrgentFuel => ConsoleColor.Red;

		public static string SelectionIndicator => " ► ";
		public static string WarpIndicator => "▲";

		public static void EmptySpace(int width)
		{
			for (int i = 0; i < width; i++)
			{
				Console.Write(" ");
			}
		}
	}
}
