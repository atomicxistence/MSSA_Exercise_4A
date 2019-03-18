using SpaceTrucker.Models;
using System;

namespace SpaceTrucker.ViewModel
{
	public class Game
	{
		public void Run()
		{
			while (true)
			{
				//new MainMenu().Run();
				GameLoop();
			}
		}

		private void GameLoop()
		{
            //TODO: game loop
            //Economy.InitializeEconomy();
            
            //foreach(var p in Economy.planets)
            //{
            //    Console.Clear();

            //    Console.WriteLine(p.Description);
            //    Console.ReadKey(true);
            //}

            Console.ReadKey(true);

        }
    }
}
