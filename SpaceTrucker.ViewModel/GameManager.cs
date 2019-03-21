using System;
using System.Collections.Generic;
using System.Linq;
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
				case ActionType.NextTable:
					//TODO: go to next market table
					break;
				case ActionType.PreviousTable:
					//TODO: go to previous market table
					break;
				case ActionType.Map:
					CurrentViewMode = ViewScreenMode.Map;
					break;
				case ActionType.Inventory:
					CurrentViewMode = ViewScreenMode.Inventory;
					break;
				case ActionType.TrendReport:
					CurrentViewMode = ViewScreenMode.TrendReport;
					break;
				case ActionType.Quit:
					//TODO: bring up verification menu
					break;
			}
		}


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

			//TODO: initialize viewscreen
		}

		private void PerformSelection()
		{
			switch (CurrentGameState)
			{
				case GameState.MainMenu:
					MainMenuSelection();
					break;
				case GameState.Message:
					break;
				case GameState.FullMenuSelection:
					GameMenuSelections();
					break;
				case GameState.Market:
                    DisplaySelectedPlanetMarket();
                    break;
				case GameState.Travel:
					TravelToSelectedPlanet();
					break;
			}
		}

        private void DisplaySelectedPlanetMarket()
        {
            throw new NotImplementedException();
        }

        private void GoToPreviousMenu()
		{
			switch (CurrentGameState)
			{
				case GameState.MainMenu:
					//TODO: go to quit prompt
					break;
				case GameState.FullMenuSelection:
					break;
				case GameState.Market:
					menuOptions = menuFactory.CreateGameMenu();
					ChangeMenuSelections();
					eventBroadcaster.SelectionDisplayMenu(menuOptions);
					CurrentGameState = GameState.FullMenuSelection;
					break;
				case GameState.Travel:
					menuOptions = menuFactory.CreateGameMenu();
					ChangeMenuSelections();
					eventBroadcaster.SelectionDisplayMenu(menuOptions);
					CurrentGameState = GameState.FullMenuSelection;
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
					CurrentGameState = GameState.FullMenuSelection;
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

		private void GameMenuSelections()
		{
			switch (menuOptions.Options[currentSelection].OptionType)
			{
				case OptionType.GoToTravel:
					closestPlanets = Economy.ClosestPlanets(player.MyShip.CurrentLocation, 9);
					menuOptions = menuFactory.CreateTravelMenu(closestPlanets);
					CurrentGameState = GameState.Travel;
					ChangeMenu();
					break;
				case OptionType.GoToTradeMarket:
					//TODO: create trade market menus based on current location
					CurrentGameState = GameState.Market;
					CurrentViewMode = ViewScreenMode.Market;
					ChangeMenu();
					//TODO: pass market menu to viewscreen
					break;
				case OptionType.PurchaseFuel:
					//TODO: purchase fuel

					//TESTING!!
					eventBroadcaster.ChangeViewScreenMode(ViewScreenMode.Message);
					eventBroadcaster.SendMessageToViewScreen(Messages.narrative[0]);
					break;
                    //TODO: purchase fuel
                    player.MyShip.Refuel(Economy.fuelCost);
                    eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
                    break;
				case OptionType.BackMainMenu:
					menuOptions = menuFactory.CreateMainMenu();
					CurrentViewMode = ViewScreenMode.TitleScreen;
					CurrentGameState = GameState.MainMenu;
					ChangeMenu();
					break;
			}
		}

		private void TravelToSelectedPlanet()
		{
			player.MyShip.FlyToPlanet(closestPlanets.Keys.ElementAt(currentSelection));
			eventBroadcaster.ChangeLocation(console.FormatLocation(player.MyShip.CurrentLocation.longName));
			eventBroadcaster.ChangeFuelCells(console.FormatFuelCells(player.MyShip.FuelLevel));
			eventBroadcaster.ChangeResetDays(console.FormatResetDays(player.MyShip.LifeSpan));
			menuOptions = menuFactory.CreateGameMenu();
			CurrentGameState = GameState.FullMenuSelection;
			ChangeMenu();
		}

		private void ChangeMenu()
		{
			previousSelection = currentSelection = 0;
			eventBroadcaster.SelectionDisplayMenu(menuOptions);
		}
	}
}
