using System;
using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	public class GameManager
	{
		private int previousSelection;
		private int currentSelection = 0;
		private IMenu menuOptions;

		private ViewScreenMode viewScreenMode = ViewScreenMode.TitleScreen;
		private GameState gameState = GameState.MainMenu;

		private EventBroadcaster eventBroadcaster;
		private ConsoleFormatter console;
		private MenuFactory menuFactory;

		public GameManager(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
			console = new ConsoleFormatter();
			menuFactory = new MenuFactory();

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
					//currentSelection = 0;
					//TODO: action currently selected option		
					break;
				case ActionType.Back:
					//TODO: go back to previous menu?
					break;
				case ActionType.NextTable:
					//TODO: go to next market table
					break;
				case ActionType.PreviousTable:
					//TODO: go to previous market table
					break;
				case ActionType.Map:
					//TODO: change viewscreen to map
					break;
				case ActionType.Inventory:
					//TODO: change viewscreen to inventory
				case ActionType.TrendReport:
					//TODO: change viewscreen to trend report
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
			menuOptions = menuFactory.MainMenu;
			eventBroadcaster.SelectionDisplayMenu(menuOptions);
		}
	}
}
