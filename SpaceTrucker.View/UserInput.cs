using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class UserInput
	{
		public ActionType AwaitUserKeyResponse(InputRequestType requestType)
		{
			var input = Console.ReadKey(true).Key;

			switch (requestType)
			{
				case InputRequestType.FullSelectionInput:
					return FullSelection(input);
				case InputRequestType.MenuOnly:
					return MenuOnlySelection(input);
				default:
					return ActionType.Invalid;
			}
		}

		private ActionType FullSelection(ConsoleKey input)
		{
			switch (input)
			{
				case ConsoleKey.DownArrow:
					return ActionType.NextItem;
				case ConsoleKey.UpArrow:
					return ActionType.PreviousItem;
				case ConsoleKey.RightArrow:
					return ActionType.IncreaseWarpFactor;
				case ConsoleKey.LeftArrow:
					return ActionType.DecreaseWarpFactor;
				case ConsoleKey.Enter:
					return ActionType.Select;
				case ConsoleKey.M:
					return ActionType.Map;
				case ConsoleKey.T:
					return ActionType.Market;
				case ConsoleKey.R:
					return ActionType.TrendReport;
				case ConsoleKey.Escape:
					return ActionType.Back;
				default:
					return ActionType.Invalid;
			}
		}

		private ActionType MenuOnlySelection(ConsoleKey input)
		{
			switch (input)
			{
				case ConsoleKey.DownArrow:
					return ActionType.NextItem;
				case ConsoleKey.UpArrow:
					return ActionType.PreviousItem;
				case ConsoleKey.Enter:
					return ActionType.Select;
				case ConsoleKey.Escape:
					return ActionType.Quit;
				default:
					return ActionType.Invalid;
			}
		}
	}
}
