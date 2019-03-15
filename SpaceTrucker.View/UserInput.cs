using System;

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

		public string AwaitUserTypeResponse(int maxStringLength)
		{
			Console.CursorVisible = true;
			var input = Console.ReadLine();
			Console.CursorVisible = false;

			if (input.Length > maxStringLength)
			{
				//TODO: is this the right way to throw an exception???
				throw new Exception($"{maxStringLength} max characters: {input.Length} given");
			}

			return input;
		}

		private ActionType FullSelection(ConsoleKey input)
		{
			switch (input)
			{
				case ConsoleKey.DownArrow:
					return ActionType.NextItem;
				case ConsoleKey.UpArrow:
					return ActionType.PreviousItem;
				case ConsoleKey.Enter:
					return ActionType.Select;
				case ConsoleKey.M:
					return ActionType.Map;
				case ConsoleKey.I:
					return ActionType.Inventory;
				case ConsoleKey.T:
					return ActionType.TrendReport;
				case ConsoleKey.Escape:
					return ActionType.Quit;
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
				case ConsoleKey.RightArrow:
					return ActionType.NextTable;
				case ConsoleKey.LeftArrow:
					return ActionType.PreviousTable;
				case ConsoleKey.Enter:
					return ActionType.Select;
				case ConsoleKey.Escape:
					return ActionType.Back;
				default:
					return ActionType.Invalid;
			}
		}
	}
}
