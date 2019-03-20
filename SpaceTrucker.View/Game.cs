using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Game
	{
		private DisplayManager display;
		private UserInput input;
		private EventBroadcaster eventBroadcaster;
		private GameManager gm;

		private GameState currentGameState = GameState.MainMenu;

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

		private void ChangeGameState(object sender, GameState nextGameState)
		{
			currentGameState = nextGameState;
		}
    }
}
