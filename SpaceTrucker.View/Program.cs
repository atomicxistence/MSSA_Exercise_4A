using SpaceTrucker.ViewModel;
using System;

namespace SpaceTrucker.View
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.Unicode;

			new DisplayManager();
			new Game().Run();
		}
	}
}
