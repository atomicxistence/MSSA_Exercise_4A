using System;

namespace SpaceTrucker.View
{
	static class Write
	{
		public static void EmptySpace(int width)
		{
			for (int i = 0; i < width; i++)
			{
				Console.Write(" ");
			}
		}
	}
}
