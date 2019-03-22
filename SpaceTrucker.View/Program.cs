using SpaceTrucker.ViewModel;
using System;

namespace SpaceTrucker.View
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			Console.Title = "    Space Trucker    |      Jeff Adams & Sam Amara";

			new Game().Run();
		}
	}
}
