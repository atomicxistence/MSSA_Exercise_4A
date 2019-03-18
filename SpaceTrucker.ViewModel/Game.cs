using SpaceTrucker.Models;
using System;

namespace SpaceTrucker.ViewModel
{
	public class Game
	{
		private IDisplayManager display;
		private IUserInput input;

		private GameState currentGameState = GameState.MainMenu;

		public Game(IDisplayManager display, IUserInput input)
		{
			this.display = display;
			this.input = input;
		}

		public void Run()
		{
			var action = ActionType.Invalid;

			while (true)
			{
				display.Refresh();
				do
				{
					action = GetUserInput(currentGameState);

				} while (action == ActionType.Invalid);
				
				// use the action response to "do stuff"
				// TODO: need to feed the display the newest info
			}
		}

		private ActionType GetUserInput(GameState currentGameState)
		{
			switch (currentGameState)
			{
				case GameState.MainMenu:
				case GameState.Message:
					return input.AwaitUserKeyResponse(InputRequestType.MenuOnly);
				case GameState.FullMenuSelection:
				case GameState.Market:
					return input.AwaitUserKeyResponse(InputRequestType.FullSelectionInput);
				default:
					return ActionType.Invalid;
			}
		}

		private void TestGameLoop()
		{
			//TODO: game loop
			Console.ReadKey(true);
			ModelTest();

        }

		private void ModelTest()
		{
			Economy.InitializeEconomy();

			foreach (var p in Economy.planets)
			{
				Console.Clear();

				Console.WriteLine(p.Description);
				Console.ReadKey(true);
			}
		}
    }
}
