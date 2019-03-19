using System;
using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	public class GameManager
	{
		private int previousSelection = 0;
		private int currentSelection = 0;
		private IMenu menuOptions;

		private ViewScreenMode viewScreenMode = ViewScreenMode.TitleScreen;
		private GameState gameState = GameState.MainMenu;

		private EventBroadcaster eventBroadcaster;

		private int fuelPercent = 100;

		public GameManager(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
		}

		public void ActionUserInput(ActionType action)
		{
			switch (action)
			{
				case ActionType.NextItem:
					currentSelection = currentSelection >= menuOptions.Options.Count
									 ? 0
									 : (currentSelection + 1);
					ChangeMenuSelections();
					//TODO: send menuOptions to appropriate display
					
					break;
				case ActionType.PreviousItem:
					currentSelection = currentSelection <= 0
									 ? menuOptions.Options.Count
									 : (currentSelection - 1);
					ChangeMenuSelections();
					//TODO: send menuOptions to appropriate display
					break;
				case ActionType.Select:
					//TODO: action currently selected option
					eventBroadcaster.ChangeFuelCells(fuelPercent);
					fuelPercent -= 5;
					break;
				case ActionType.Back:
					//TODO: go back to previous menu?
					eventBroadcaster.ChangeFuelCells(fuelPercent);
					fuelPercent += 5;
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
	}
}
