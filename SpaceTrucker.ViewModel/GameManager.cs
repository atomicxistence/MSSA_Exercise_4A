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
		private MenuState _currentMenuState = MenuState.MainMenu;
		private GameState _currentGameState = GameState.ApplicationOpen;
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
		internal MenuState CurrentMenuState
		{
			get => _currentMenuState;
			set
			{
				_currentMenuState = value;
				eventBroadcaster.ChangeMenuState(_currentMenuState);
			}
		}
		internal GameState CurrentGameState
		{
			get { return _currentGameState; }
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
		private Planet destinationPlanet;

		private Dictionary<Planet, Trip> closestPlanets;

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

		public void GameStateCheck()
		{
			switch (CurrentGameState)
			{
				case GameState.ApplicationOpen:
					break;
				case GameState.GameStart:
					if (gameStart && player.MyShip.LifeSpan == 18249)
					{
						CurrentViewMode = ViewScreenMode.Message;
						eventBroadcaster.SendMessageToViewScreen(Messages.narrative[0]);
					}
					CurrentGameState = GameState.GamePlaying;
					break;
				case GameState.GamePlaying:
					 // check if days are below threshold -> game over (loss)
					 // check if balance is below losing threshold -> game over (loss)
					if (player.MyShip.LifeSpan < 1 || player.MyShip.Balance <= 0)
					{
						CurrentViewMode = ViewScreenMode.Message;
						eventBroadcaster.SendMessageToViewScreen(Messages.narrative[5]);
						CurrentGameState = GameState.GameOver;
					}
					// check if balance is above winning threshold -> game over (win)
					if (player.MyShip.Balance >= thresholdWinBalance)
					{
						CurrentViewMode = ViewScreenMode.Message;
						eventBroadcaster.SendMessageToViewScreen(Messages.narrative[6]);
						CurrentGameState = GameState.GameOver;
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
					break;
				case GameState.GameOver:
					break;
				default:
					break;
			}

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
			switch (CurrentMenuState)
			{
				case MenuState.MainMenu:
					MainMenuSelection();
					break;
				case MenuState.QuitMenu:
					QuitMenuSelection();
					break;
				case MenuState.StartMenu:
					CurrentViewMode = ViewScreenMode.OpeningNarrative;
					GameStartConfirmation();
					break;
				case MenuState.GameMenu:
					GameMenuSelection();
					break;
				case MenuState.TravelMenu:
					TravelMenuSelection();
					break;
				case MenuState.TravelConfirmationMenu:
					TravelConfirmationMenuSelection();
					break;
				case MenuState.MarketMenu:
					BuySellSelection();
					break;
				case MenuState.TransactionMenu:
					TransactionSelection();
					break;
				case MenuState.TransactionConfirmationMenu:
					TransactionConfirmationSelection();
					break;
			}
            eventBroadcaster.isErrorMessage = false; 
        }

        private void GoToPreviousMenu()
		{
			switch (CurrentMenuState)
			{
				case MenuState.MainMenu:
					CurrentMenuState = MenuState.QuitMenu;
					menuOptions = menuFactory.CreateConfirmationMenu("Are you sure you want to quit?");
					ChangeMenu();
					break;
				case MenuState.QuitMenu:
				case MenuState.StartMenu:
				case MenuState.GameMenu:
					CurrentViewMode = ViewScreenMode.TitleScreen;
					CurrentMenuState = MenuState.MainMenu;
					menuOptions = menuFactory.CreateMainMenu();
					ChangeMenu();
					break;
				case MenuState.MarketMenu:
				case MenuState.TravelMenu:
					CurrentMenuState = MenuState.GameMenu;
					menuOptions = menuFactory.CreateGameMenu();
					ChangeMenu();
					break;
				case MenuState.TransactionMenu:
					CurrentMenuState = MenuState.MarketMenu;
					menuOptions = menuFactory.CreateBuySellMenu();
					ChangeMenu();
					break;
				case MenuState.TransactionConfirmationMenu:
					CurrentMenuState = MenuState.TransactionMenu;
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
					CurrentViewMode = ViewScreenMode.OpeningNarrative;
					CurrentMenuState = MenuState.StartMenu;
					menuOptions = menuFactory.CreateConfirmationMenu("This will overwrite any saved progress. Proceed?");
					ChangeMenu();
					break;
				case OptionType.Continue:
					// TODO: error message if no save file, else load save game
					break;
				case OptionType.SaveGame:
					// TODO: save the game to JSON
					break;
				case OptionType.Quit:
					CurrentMenuState = MenuState.QuitMenu;
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
					CurrentMenuState = MenuState.MainMenu;
					menuOptions = menuFactory.CreateMainMenu();
					ChangeMenu();
					break;
			}
		}

		private void GameStartConfirmation()
		{
			switch (menuOptions.Options[currentSelection].OptionType)
			{
				case OptionType.Yes:
					CurrentViewMode = ViewScreenMode.Map;
					CurrentGameState = GameState.GameStart;
					CurrentMenuState = MenuState.GameMenu;
					menuOptions = menuFactory.CreateGameMenu();
					ChangeMenu();
					break;
				case OptionType.No:
					CurrentGameState = GameState.ApplicationOpen;
					CurrentViewMode = ViewScreenMode.TitleScreen;
					CurrentMenuState = MenuState.MainMenu;
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
                    CurrentMenuState = MenuState.TravelMenu;
                    UpdateTravelMenu();
                    break;
                case OptionType.GoToTradeMarket:
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
					menuOptions = menuFactory.CreateBuySellMenu();
					CurrentMenuState = MenuState.MarketMenu;
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
					CurrentMenuState = MenuState.MainMenu;
					ChangeMenu();
					break;
			}
		}

        private void TravelMenuSelection()
		{
            if (closestPlanets?.Count > 1)
            {
                destinationPlanet = closestPlanets.Keys.ElementAt(currentSelection);
                var estimatedTrip = new Trip(currentPlanet.MyLocation, destinationPlanet.MyLocation, (WarpFactor)CurrentWarpFactor);
                var travelPrompt = $"Estimated {estimatedTrip.duration} days & {estimatedTrip.fuelUsage}% fuel. Are you sure?";

                CurrentMenuState = MenuState.TravelConfirmationMenu;
                menuOptions = menuFactory.CreateConfirmationMenu(travelPrompt);
                ChangeMenu();
            }
		}

		private void TravelConfirmationMenuSelection()
		{
			switch (menuOptions.Options[currentSelection].OptionType)
			{
				case OptionType.Yes:
					try
					{
						player.MyShip.FlyToPlanet(destinationPlanet, player.MyShip.CurrentSpeed);
						eventBroadcaster.ChangeLocation(console.FormatLocation(player.MyShip.CurrentLocation.longName));
						eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
						eventBroadcaster.ChangeResetDays(console.FormatResetDays(player.MyShip.LifeSpan));
						currentPlanet = destinationPlanet;

						menuOptions = menuFactory.CreateGameMenu();
						CurrentMenuState = MenuState.GameMenu;
						ChangeMenu();
					}
					catch (Exception)
					{
						CurrentViewMode = ViewScreenMode.Message;
					    eventBroadcaster.isErrorMessage = true;
					    eventBroadcaster.SendMessageToViewScreen(Messages.errorInsufficientFuel);
					}
					break;
				case OptionType.No:
					CurrentMenuState = MenuState.TravelMenu;
					UpdateTravelMenu();
					break;
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
						prompt = $"{currentPlanet.Name} is currently offering...";
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
						prompt = $"{currentPlanet.Name} is currently demanding...";
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

		private void TransactionConfirmationSelection()
		{
			//TODO: transaction confirmation selection switch
		}

		#endregion

		#region Utilities

        private void UpdateTravelMenu()
        {
			if (CurrentMenuState == MenuState.TravelMenu)
			{
				closestPlanets = Economy.ClosestPlanets(player.MyShip.CurrentLocation, 9,
				                                        (WarpFactor)CurrentWarpFactor,
				                                        player.MyShip.FuelLevel,
				                                        player.MyShip.LifeSpan);

				menuOptions = menuFactory.CreateTravelMenu(closestPlanets);
				ChangeMenu();
			}
        }

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
			CurrentMenuState = MenuState.TransactionMenu;
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
