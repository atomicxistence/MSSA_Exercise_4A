using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	public class GameManager
	{
		private ViewScreenMode _currentViewMode = ViewScreenMode.TitleScreen;
		private GameState _currentGameState = GameState.MainMenu;
		
		internal ViewScreenMode CurrentViewMode
		{
			get => _currentViewMode;
			set
			{
				_currentViewMode = value;
				eventBroadcaster.ChangeViewScreenMode(_currentViewMode);
			}
		}
		internal GameState CurrentGameState
		{
			get => _currentGameState;
			set
			{
				_currentGameState = value;
				eventBroadcaster.ChangeGameState(_currentGameState);
			}
		}

		private int previousSelection;
		private int currentSelection = 0;
		private IMenu menuOptions;

		private Player player;
		private Planet currentPlanet;

		private Dictionary<Planet, int> closestPlanets;

		private EventBroadcaster eventBroadcaster;
		private ConsoleFormatter console;
		private MenuFactory menuFactory;

		public GameManager(EventBroadcaster eventBroadcaster)
		{
			Economy.InitializeEconomy();
			this.eventBroadcaster = eventBroadcaster;

			console = new ConsoleFormatter();
			menuFactory = new MenuFactory();
			player = new Player();
			currentPlanet = Economy.planets[0];

			InitializeDisplayFields();
		}

		public void ActionUserInput(ActionType action)
		{
			switch (action)
			{
				case ActionType.NextItem:
					currentSelection = currentSelection >= menuOptions.Options.Count - 1
									 ? 0
									 : (currentSelection + 1);
					ChangeMenuSelections();
					eventBroadcaster.SelectionDisplayMenu(menuOptions);
					break;
				case ActionType.PreviousItem:
					currentSelection = currentSelection <= 0
									 ? menuOptions.Options.Count - 1
									 : (currentSelection - 1);
					ChangeMenuSelections();
					eventBroadcaster.SelectionDisplayMenu(menuOptions);
					break;
				case ActionType.Select:
					PerformSelection();		
					break;
				case ActionType.Back:
                    previousSelection = currentSelection = 0;
                    GoToPreviousMenu();
					break;
				case ActionType.IncreaseWarpFactor:
					//TODO: increase current warp factor
					//TODO: event display current warp factor
					CurrentViewMode = ViewScreenMode.Message;
					eventBroadcaster.SendMessageToViewScreen(Messages.narrative[0]);
					break;
				case ActionType.DecreaseWarpFactor:
					//TODO: decrease current warp factor
					//TODO: event display current warp factor
					CurrentViewMode = ViewScreenMode.Message;
					eventBroadcaster.SendMessageToViewScreen(Messages.narrative[1]);
					break;
				case ActionType.Map:
					CurrentViewMode = ViewScreenMode.Map;
					break;
				case ActionType.Market:
					CurrentViewMode = ViewScreenMode.Market;
					try
					{
						DisplayCurrentMarketInfo();
					}
					catch (NullReferenceException)
					{
						CurrentViewMode = ViewScreenMode.Message;
						eventBroadcaster.SendMessageToViewScreen(Messages.errorPlanetNoShop);
					}
					break;
				case ActionType.TrendReport:
					CurrentViewMode = ViewScreenMode.TrendReport;
                    DisplayTrendReport();
					break;
				case ActionType.Quit:
					//TODO: bring up verification menu
					break;
			}
		}


        #region Private Methods

        private void ChangeMenuSelections()
		{
			menuOptions.Options[previousSelection].IsSelected = false;
			menuOptions.Options[currentSelection].IsSelected = true;
			previousSelection = currentSelection;
		}

		private void InitializeDisplayFields()
		{
			menuOptions = menuFactory.CreateMainMenu();
			eventBroadcaster.SelectionDisplayMenu(menuOptions);

			eventBroadcaster.ChangeBalance(console.FormatBalance(player.MyShip.Balance));
			eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
			eventBroadcaster.ChangeLocation(console.FormatLocation(player.MyShip.CurrentLocation.longName));
			eventBroadcaster.ChangeResetDays(console.FormatResetDays(player.MyShip.LifeSpan));
		}

		#endregion

		#region Menu State Machine

		private void PerformSelection()
		{
			switch (CurrentGameState)
			{
				case GameState.MainMenu:
					MainMenuSelection();
					break;
				case GameState.ConfirmationMenu:
					break;
				case GameState.GameMenu:
					GameMenuSelection();
					break;
				case GameState.TravelMenu:
					TravelMenuSelection();
					break;
				case GameState.MarketMenu:
					BuySellSelection();
					break;
				case GameState.TransactionMenu:
					TransactionSelection();
					break;
			}
		}

        private void GoToPreviousMenu()
		{
			switch (CurrentGameState)
			{
				case GameState.MainMenu:
					//TODO: go to quit prompt
					break;
				case GameState.ConfirmationMenu:
					break;
				case GameState.GameMenu:
					CurrentGameState = GameState.MainMenu;
					menuOptions = menuFactory.CreateMainMenu();
					ChangeMenu();
					break;
				case GameState.MarketMenu:
				case GameState.TravelMenu:
					CurrentGameState = GameState.GameMenu;
					menuOptions = menuFactory.CreateGameMenu();
					ChangeMenu();
					break;
				case GameState.TransactionMenu:
					CurrentGameState = GameState.MarketMenu;
					menuOptions = menuFactory.CreateBuySellMenu();
					ChangeMenu();
					break;
				default:
					break;
			}
		}

		private void MainMenuSelection()
		{
			switch (menuOptions.Options[currentSelection].OptionType)
			{
				case OptionType.NewGame:
					CurrentGameState = GameState.GameMenu;
					menuOptions = menuFactory.CreateGameMenu();
					ChangeMenu();
					break;
				case OptionType.Continue:
					// TODO: error message if no save file, else load save game
					break;
				case OptionType.SaveGame:
					// TODO: save the game to JSON
					break;
				case OptionType.Quit:
					break;
			}
		}

		private void GameMenuSelection()
		{
            switch (menuOptions.Options[currentSelection].OptionType)
            {
                case OptionType.GoToTravel:
                    closestPlanets = Economy.ClosestPlanets(player.MyShip.CurrentLocation, 9);
                    menuOptions = menuFactory.CreateTravelMenu(closestPlanets);
                    CurrentGameState = GameState.TravelMenu;
                    ChangeMenu();
                    break;
                case OptionType.GoToTradeMarket:
					menuOptions = menuFactory.CreateBuySellMenu();
					CurrentGameState = GameState.MarketMenu;
					ChangeMenu();
					break;
                case OptionType.PurchaseFuel:
                    if (player.MyShip.FuelLevel < 100)
                    {
                        player.MyShip.Refuel(Economy.fuelCost);
                        eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
                        eventBroadcaster.ChangeBalance(console.FormatBalance((int)player.MyShip.Balance));
                    }
                    break;
				case OptionType.BackMainMenu:
					menuOptions = menuFactory.CreateMainMenu();
					CurrentViewMode = ViewScreenMode.TitleScreen;
					CurrentGameState = GameState.MainMenu;
					ChangeMenu();
					break;
			}
		}

		private void TravelMenuSelection()
		{
			currentPlanet = closestPlanets.Keys.ElementAt(currentSelection);
			player.MyShip.FlyToPlanet(currentPlanet);
			eventBroadcaster.ChangeLocation(console.FormatLocation(player.MyShip.CurrentLocation.longName));
			eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
			eventBroadcaster.ChangeResetDays(console.FormatResetDays(player.MyShip.LifeSpan));


			menuOptions = menuFactory.CreateGameMenu();
			CurrentGameState = GameState.GameMenu;
			ChangeMenu();
		}

		private void BuySellSelection()
		{
			List<string> ores = new List<string> { "" };
			string prompt;

			switch (menuOptions.Options[currentSelection].OptionType)
			{
				case OptionType.GoToBuy:
					try
					{
						ores = FormatTransactionList(currentPlanet.MyMarket.OfferedOresWithoutQty());
						prompt = $"{currentPlanet.Name} is currently selling...";
						DisplayTransactionMenu(ores, prompt, OptionType.OreBuy);
					}
					catch (NullReferenceException)
					{
						CurrentViewMode = ViewScreenMode.Message;
						eventBroadcaster.SendMessageToViewScreen(Messages.errorPlanetNoShop);
					}
					break;
				case OptionType.GoToSell:
					try
					{
						ores = FormatTransactionList(currentPlanet.MyMarket.InDemandOres);
						prompt = $"{currentPlanet.Name} is currently buying...";
						DisplayTransactionMenu(ores, prompt, OptionType.OreSell);
					}
					catch (NullReferenceException)
					{
						CurrentViewMode = ViewScreenMode.Message;
						eventBroadcaster.SendMessageToViewScreen(Messages.errorPlanetNoShop);
					}
					break;
			}
		}

		private void TransactionSelection()
		{
			var oreName = menuOptions.Options[currentSelection].Title;
			KeyValuePair<Ore, int> selectedOre;

			switch (menuOptions.Options[currentSelection].OptionType)
			{

				case OptionType.OreBuy:
					var buyList = currentPlanet.MyMarket.OfferedOresWithoutQty();
					selectedOre = buyList.ElementAt(currentSelection);
					player.MyShip.Buy(selectedOre.Key, selectedOre.Value);
					UpdateAfterTransaction();
					break;
				case OptionType.OreSell:
					var sellList = currentPlanet.MyMarket.InDemandOres;
					selectedOre = sellList.ElementAt(currentSelection);
					player.MyShip.Sell(selectedOre.Key, selectedOre.Value);
					UpdateAfterTransaction();
					break;
			}
		}

        #endregion

        #region Utilities

        private void DisplayTrendReport()
        {
            eventBroadcaster.UpdateTrendReport(console.FormatTrendReport(Economy.trends));
        }

		private void DisplayCurrentMarketInfo()
		{
			eventBroadcaster.UpdateMarketBuyTable(console.FormatMarketPriceTable(currentPlanet.MyMarket.OfferedOresWithoutQty()));
			eventBroadcaster.UpdateMarketSellTable(console.FormatMarketPriceTable(currentPlanet.MyMarket.InDemandOres));
			eventBroadcaster.UpdateMarketInventoryTable(console.FormatInventoryTable(player.MyShip.Inventory));
		}

		private List<string> FormatTransactionList(Dictionary<Ore, int> marketTable)
		{
			var priceOffsetX = 40;
			var pricePrefix = "฿";
			var sortedMarketTable = marketTable.OrderBy(x => x.Value);

			var oreName = sortedMarketTable.Select(o => o.Key.name).ToArray();
			var orePrice = sortedMarketTable.Select(o => o.Value).ToArray();
			var priceArray = new List<string>();

			for (int i = 0; i < oreName.Length; i++)
			{
				var emptySpace = priceOffsetX - oreName[i].Length;

				var sb = new StringBuilder();
				sb.Append(oreName[i]).Append(' ', emptySpace);
				sb.Append(pricePrefix);
				sb.Append(Economy.ToKMB(orePrice[i]));

				priceArray.Add(sb.ToString());
			}

			return priceArray;
		}

		private void DisplayTransactionMenu(List<string> ores, string prompt, OptionType optionType)
		{
			menuOptions = menuFactory.CreateOreMenu(prompt, ores, optionType);
			CurrentGameState = GameState.TransactionMenu;
			ChangeMenu();
		}

		private void UpdateAfterTransaction()
		{
			eventBroadcaster.ChangeBalance(console.FormatBalance(player.MyShip.Balance));
			eventBroadcaster.UpdateMarketInventoryTable(console.FormatInventoryTable(player.MyShip.Inventory));
		}

		private void ChangeMenu()
		{
			previousSelection = currentSelection = 0;
			eventBroadcaster.SelectionDisplayMenu(menuOptions);
		}

		#endregion
	}
}
