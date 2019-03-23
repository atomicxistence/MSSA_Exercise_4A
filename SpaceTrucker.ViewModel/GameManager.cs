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
		private int _currentWarpFactor;
		
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

		internal int CurrentWarpFactor
		{
			get => _currentWarpFactor;
			set
			{
				_currentWarpFactor = value;
				eventBroadcaster.ChangeWarpFactor(_currentWarpFactor);
			}
		}

		private bool thresholdLowAlert = true;
		private bool thresholdHighAlert = true;
		private bool gameStart = true;
		private int thresholdWinBalance = 1000000000;
		private int thresholdLowBalance = 1500;
		private int thresholdHighBalance = 700000000;

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
            eventBroadcaster.maxWarp = (int)player.MyShip.EngineTopSpeed;
            CurrentWarpFactor = (int)player.MyShip.CurrentSpeed;

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
                    if (CurrentWarpFactor + 1 <= (int)player.MyShip.EngineTopSpeed)
                    {
                        CurrentWarpFactor += 1;
                        player.MyShip.CurrentSpeed += 1;
                    }
                    UpdateTravelMenu();
                    break;
                case ActionType.DecreaseWarpFactor:
                    if (CurrentWarpFactor - 1 > 0)
                    {
                        CurrentWarpFactor -= 1;
                        player.MyShip.CurrentSpeed -= 1;
                    }
                    UpdateTravelMenu();
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
                        eventBroadcaster.isErrorMessage = true;
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

		public bool GameOver()
		{
			// check if days are below threshold -> game over (loss)
			// check if balance is below losing threshold -> game over (loss)
			if (player.MyShip.LifeSpan < 1 || player.MyShip.Balance <= 0)
			{
				CurrentViewMode = ViewScreenMode.Message;
				eventBroadcaster.SendMessageToViewScreen(Messages.narrative[5]);
				return true;
			}
			// check if balance is above winning threshold -> game over (win)
			if (player.MyShip.Balance >= thresholdWinBalance)
			{
				CurrentViewMode = ViewScreenMode.Message;
				eventBroadcaster.SendMessageToViewScreen(Messages.narrative[6]);
				return true;
			}

			// check if balance is below negative threshold -> warning message
			if (player.MyShip.Balance > thresholdLowBalance)
			{
				thresholdLowAlert = true;
			}
			if (player.MyShip.Balance < thresholdLowBalance && thresholdLowAlert)
			{
				CurrentViewMode = ViewScreenMode.Message;
				eventBroadcaster.SendMessageToViewScreen(Messages.narrative[2]);
				thresholdLowAlert = false;
			}

			// check if balance is above positive threshold -> positive message
			if (player.MyShip.Balance < thresholdHighBalance)
			{
				thresholdHighAlert = true;
			}
			if (player.MyShip.Balance > thresholdHighBalance && thresholdHighAlert)
			{
				CurrentViewMode = ViewScreenMode.Message;
				eventBroadcaster.SendMessageToViewScreen(Messages.narrative[3]);
				thresholdHighAlert = false;
			}
			// TODO: check if days are at ??? -> narrative injection message
			if (gameStart && player.MyShip.LifeSpan == 18249 && CurrentGameState == GameState.GameMenu)
			{
				CurrentViewMode = ViewScreenMode.Message;
				eventBroadcaster.SendMessageToViewScreen(Messages.narrative[0]);
				gameStart = false;
			}

			return false;
		}

        #region Private Methods

        private void ChangeMenuSelections()
		{
            if(menuOptions.Options?.Count > 0)
            {
			    menuOptions.Options[previousSelection].IsSelected = false;
			    menuOptions.Options[currentSelection].IsSelected = true;
			    previousSelection = currentSelection;
            }
            else
            {
                CurrentViewMode = ViewScreenMode.Message;
                eventBroadcaster.isErrorMessage = true;
                eventBroadcaster.SendMessageToViewScreen(Messages.errorInsufficientFuel);
            }
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
				case GameState.QuitMenu:
					QuitMenuSelection();
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
            eventBroadcaster.isErrorMessage = false; 
        }

        private void GoToPreviousMenu()
		{
			switch (CurrentGameState)
			{
				case GameState.MainMenu:
					CurrentGameState = GameState.QuitMenu;
					menuOptions = menuFactory.CreateConfirmationMenu("Are you sure you want to quit?");
					ChangeMenu();
					break;
				case GameState.QuitMenu:
					CurrentGameState = GameState.MainMenu;
					menuOptions = menuFactory.CreateMainMenu();
					ChangeMenu();
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
					CurrentGameState = GameState.QuitMenu;
					menuOptions = menuFactory.CreateConfirmationMenu("Are you sure you want to quit?");
					ChangeMenu();
					break;
			}
		}

		private void QuitMenuSelection()
		{
			switch (menuOptions.Options[currentSelection].OptionType)
			{
				case OptionType.Yes:
					Environment.Exit(0);
					break;
				case OptionType.No:
					CurrentGameState = GameState.MainMenu;
					menuOptions = menuFactory.CreateMainMenu();
					ChangeMenu();
					break;
			}
		}

		private void GameMenuSelection()
		{
            switch (menuOptions.Options[currentSelection].OptionType)
            {
                case OptionType.GoToTravel:
                    CurrentGameState = GameState.TravelMenu;
                    UpdateTravelMenu();
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
                        eventBroadcaster.ChangeBalance(console.FormatBalance(player.MyShip.Balance));
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

        private void UpdateTravelMenu()
        {
            if (CurrentGameState == GameState.TravelMenu)
            {
                closestPlanets = Economy.ClosestPlanets(player.MyShip.CurrentLocation, 9,
                                                        (WarpFactor)CurrentWarpFactor,
                                                        player.MyShip.FuelLevel,
                                                        player.MyShip.LifeSpan);
                menuOptions = menuFactory.CreateTravelMenu(closestPlanets);
                ChangeMenu();
            }
        }

        private void TravelMenuSelection()
		{
			try
			{
				currentPlanet = closestPlanets.Keys.ElementAt(currentSelection);
				player.MyShip.FlyToPlanet(currentPlanet, player.MyShip.CurrentSpeed);
				eventBroadcaster.ChangeLocation(console.FormatLocation(player.MyShip.CurrentLocation.longName));
				eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
				eventBroadcaster.ChangeResetDays(console.FormatResetDays(player.MyShip.LifeSpan));

				menuOptions = menuFactory.CreateGameMenu();
				CurrentGameState = GameState.GameMenu;
				ChangeMenu();
			}
			catch (Exception)
			{
				CurrentViewMode = ViewScreenMode.Message;
                eventBroadcaster.isErrorMessage = true;
                eventBroadcaster.SendMessageToViewScreen(Messages.errorInsufficientFuel);
            }
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
						ores = FormatTransactionList(currentPlanet.MyMarket.OfferedOresWithoutQty);
						prompt = $"{currentPlanet.Name} is currently selling...";
						DisplayTransactionMenu(ores, prompt, OptionType.OreBuy);
					}
					catch (NullReferenceException)
					{
						CurrentViewMode = ViewScreenMode.Message;
                        eventBroadcaster.isErrorMessage = true;
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
                        eventBroadcaster.isErrorMessage = true;
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
					try
					{
						var buyList = currentPlanet.MyMarket.OfferedOresWithoutQty;
						selectedOre = buyList.ElementAt(currentSelection);
						player.MyShip.Buy(selectedOre.Key, selectedOre.Value);
						UpdateAfterTransaction();
					}
					catch (Exception)
					{
						CurrentViewMode = ViewScreenMode.Message;
                        eventBroadcaster.isErrorMessage = true;
                        eventBroadcaster.SendMessageToViewScreen(Messages.errorInventoryFull);
                        
                    }
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
			eventBroadcaster.UpdateMarketBuyTable(console.FormatMarketPriceTable(currentPlanet.MyMarket.OfferedOresWithoutQty));
			eventBroadcaster.UpdateMarketSellTable(console.FormatMarketPriceTable(currentPlanet.MyMarket.InDemandOres));
			eventBroadcaster.UpdateMarketInventoryTable(console.FormatInventoryTable(player.MyShip.Inventory));
		}

		private List<string> FormatTransactionList(Dictionary<Ore, int> marketTable)
		{
			var priceOffsetX = 40;
			var pricePrefix = "฿";

			var oreName = marketTable.Select(o => o.Key.name).ToArray();
			var orePrice = marketTable.Select(o => o.Value).ToArray();
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
