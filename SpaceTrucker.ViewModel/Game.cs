using SpaceTrucker.Models;
using System;
using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	public class Game
	{
		private IDisplayManager display;
		private IUserInput input;
		private DisplayInfo currentDisplayInfo; 

		private GameState currentGameState = GameState.MainMenu;

		public Game(IDisplayManager display, IUserInput input)
		{
			this.display = display;
			this.input = input;
		}

		public void Run()
		{
			var action = ActionType.Invalid;
			currentDisplayInfo = DefaultDisplayInfo();

			while (true)
			{
				display.Refresh(currentDisplayInfo);
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

		private DisplayInfo DefaultDisplayInfo()
		{
			var defaultDisplayInfo = new DisplayInfo();
			defaultDisplayInfo.CurrentGameState = GameState.MainMenu;

			var defaultOptions = new List<IOption>
			{
				new Option("New Game", true),
				new Option("Continue Game", false),
				new Option("Options", false),
				new Option("Quit", false),
			};

			defaultDisplayInfo.MenuOptions = new Menu("Main Menu", defaultOptions);
			defaultDisplayInfo.FuelPercent = 100;
			defaultDisplayInfo.Location = "Earth";
			defaultDisplayInfo.Balance = 1000000000;
			defaultDisplayInfo.DaysRemaining = 18249;
			defaultDisplayInfo.MarketBuy = null;
			defaultDisplayInfo.MarketSell = null;
			defaultDisplayInfo.TrendReport = null;

			return defaultDisplayInfo;
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
