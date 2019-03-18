using SpaceTrucker.ViewModel;
using System;

namespace SpaceTrucker.View
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.Unicode;

			var gameManager = new GameManager();
			var game = new Game(gameManager.GetDisplayReference(), gameManager.GetInputReference());

			game.Run();
		}
	}
}
