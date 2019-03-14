using System;
using System.Collections.Generic;

namespace SpaceTrucker.View
{
	class MainMenu
	{
		private IMenu menuOptions;
		private int currentSelection = 0;

		public MainMenu()
		{
			Initialize();
		}

		public void Run()
		{
			var userInput = new UserInput();
			do
			{
				RefreshMenu();

				ActionType action = ActionType.Invalid;
				while (action == ActionType.Invalid)
				{
					action = userInput.AwaitUserKeyResponse(InputRequestType.MenuOnly);
				}

				//TODO: action the menu input 

			} while (true);
		}

		private void Initialize()
		{
			//TODO: initialize the current menu options and add them to the list
		}

		private void RefreshMenu()
		{
			//TODO: do we want to refresh the menu from in here?
		}

		private void ActionUserInput(ActionType action)
		{
			switch (action)
			{
				case ActionType.NextItem:
					currentSelection = currentSelection >= menuOptions.Options.Count
									 ? 0
									 : (currentSelection + 1);
					break;
				case ActionType.PreviousItem:
					currentSelection = currentSelection <= 0 
								     ? menuOptions.Options.Count 
									 : (currentSelection - 1);
					break;
				case ActionType.Select:
					//TODO: action currently selected option
					break;
				case ActionType.Quit:
					//TODO: bring up verification menu
					break;
				case ActionType.Invalid:
					break;

			}
		}
	}
}
