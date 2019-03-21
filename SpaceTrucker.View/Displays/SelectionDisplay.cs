using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class SelectionDisplay : IDisplay
	{
		private EventBroadcaster eventBroadcaster;

		private Coord origin;

		private int selectionWidth = 57;
		private int selectionHeight = 13;

		private IMenu previousMenuOptions;
		private int previousSelection;
		private int currentSelection;

		private bool forceRefresh = false;

		public SelectionDisplay(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
			eventBroadcaster.Menu += PrintMenuSelections;
		}

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			forceRefresh = true;
			int offsetX = 51;
			int offsetY = 2;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintSelectionScreen();
			PrintSelectionBorder();

			if (previousMenuOptions != null)
			{
				PrintMenuSelections(this, previousMenuOptions);
			}
		}

		/// <summary>
		/// Displays a menu of options for selection with a prompt message
		/// </summary>
		/// <param name="menu">Max 9 menu options allowed</param>
		public void PrintMenuSelections(object sender, IMenu menu)
		{
			var optionWidth = selectionWidth - 2;

			if (previousMenuOptions == null || previousMenuOptions != menu || forceRefresh)
			{
				PrintMenuPrompt(menu.Prompt, optionWidth);
				if (!forceRefresh)
				{
					previousSelection = currentSelection = 0;
				}
			}

			for (int i = 0; i < menu.Options.Count; i++)
			{
				Console.SetCursorPosition(origin.X + 1, origin.Y - 9 + i);

				if (previousMenuOptions == null || previousMenuOptions != menu || forceRefresh)
				{
					if (menu.Options[i].IsSelected)
					{
						previousSelection = i;
						PrintSelectedOption(menu.Options[i].Title, optionWidth);
					}
					else
					{
						PrintUnselectedOption(menu.Options[i].Title, optionWidth);
					}
				}
				else
				{
					if (previousSelection == i)
					{
						PrintUnselectedOption(menu.Options[i].Title, optionWidth);
					}

					if (menu.Options[i].IsSelected)
					{
						PrintSelectedOption(menu.Options[i].Title, optionWidth);
						currentSelection = i;
					}
				}
			}

			if (previousMenuOptions != null && 
				previousMenuOptions != menu && 
				previousMenuOptions.Options.Count > menu.Options.Count)
			{
				Console.BackgroundColor = Write.ColorDisplayBG;

				for (int i = menu.Options.Count; i < previousMenuOptions.Options.Count; i++)
				{
					Console.SetCursorPosition(origin.X + 1, origin.Y - 9 + i);
					Write.EmptySpace(optionWidth);
				}
			}

			forceRefresh = false;
			previousSelection = currentSelection;
			previousMenuOptions = menu;
		}

		#region Private Methods
		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < selectionHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel - i);
				Write.EmptySpace(selectionWidth + (bevel * 2));
			}
		}

		private void PrintSelectionScreen()
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < selectionHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Write.EmptySpace(selectionWidth);
			}
		}

		private void PrintSelectionBorder()
		{
			Console.ForegroundColor = Write.ColorDisplayTable;
			Console.BackgroundColor = Write.ColorDisplayBG;
			
			// Top border
			Console.SetCursorPosition(origin.X, origin.Y - 12);
			Console.Write("╭─                                                     ─╮");

			//Bottom border
			Console.SetCursorPosition(origin.X, origin.Y);
			Console.Write("╰─                                                     ─╯");
		}

		private static void PrintSelectedOption(string menuOption, int optionWidth)
		{
			Console.ForegroundColor = Write.ColorSelectedOptionFG;
			Console.BackgroundColor = Write.ColorSelectedOptionBG;

			Console.Write(Write.SelectionIndicator);
			Console.Write(menuOption);
			Write.EmptySpace(optionWidth - menuOption.Length - Write.SelectionIndicator.Length);
		}

		private static void PrintUnselectedOption(string menuOption, int optionWidth)
		{
			Console.ForegroundColor = Write.ColorUnselectedOptionFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			Console.Write(menuOption);
			Write.EmptySpace(optionWidth - menuOption.Length);
		}

		private void PrintMenuPrompt(string prompt, int optionWidth)
		{
			var promptIndention = 6;

			Console.ForegroundColor = Write.ColorUnselectedOptionFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			Console.SetCursorPosition(origin.X + promptIndention, origin.Y - 11);

			Console.Write(prompt);
			Write.EmptySpace(optionWidth - prompt.Length - promptIndention);
		}
		#endregion
	}
}
