using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class MainMenuDisplay
	{
		private IMenu menuOptions;
		private int currentSelection = 0;

		private int sizeWidth;
		private int sizeHeight;
		private Coord origin;

		public MainMenuDisplay(int sizeWidth, int sizeHeight, Coord origin)
		{
			this.sizeWidth = sizeWidth;
			this.sizeHeight = sizeHeight;
			this.origin = origin;
		}


		public void MenuLoop()
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

				ActionUserInput(action); 

			} while (true);
		}

		private void RefreshMenu()
		{
			//TODO: print menu options
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
