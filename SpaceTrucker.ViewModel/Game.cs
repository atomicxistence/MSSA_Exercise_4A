using System;

namespace SpaceTrucker.ViewModel
{
	public class Game
	{
		public void Run()
		{
			while (true)
			{
				new MainMenu().Run();
				GameLoop();
			}
		}

		private void GameLoop()
		{
			//TODO: game loop
		}
	}
}
