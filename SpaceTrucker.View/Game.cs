using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Game
	{
		private DisplayManager display;
		private UserInput input;
		private EventBroadcaster eventBroadcaster;
		private GameManager gm;

		private MenuState currentGameState = MenuState.MainMenu;

		public Game()
		{
			eventBroadcaster = new EventBroadcaster();
			input = new UserInput();
			display = new DisplayManager(eventBroadcaster);
			gm = new GameManager(eventBroadcaster);

			eventBroadcaster.GameState += ChangeGameState;
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

				gm.ActionUserInput(action);
				gm.GameOver();
			}
		}

		private ActionType GetUserInput(MenuState currentGameState)
		{
			switch (currentGameState)
			{
				case MenuState.MainMenu:
				case MenuState.QuitMenu:
					return input.AwaitUserKeyResponse(InputRequestType.MenuOnly);
				case MenuState.MarketMenu:
				case MenuState.TransactionMenu:
				case MenuState.GameMenu:
				case MenuState.TravelMenu:
					return input.AwaitUserKeyResponse(InputRequestType.FullSelectionInput);
				default:
					return ActionType.Invalid;
			}
		}

		private void ChangeGameState(object sender, MenuState nextGameState)
		{
			currentGameState = nextGameState;
		}
    }
}
