using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class SelectionDisplay : IDisplay
	{
		private Coord origin;

		private int selectionWidth = 57;
		private int selectionHeight = 13;

		private IMenu previousMenuOptions;

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 51;
			int offsetY = 2;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintSelectionScreen();
			PrintSelectionBorder();

			//Dummy List Test
			var dummyMenu = CreateDummyList(1);
			PrintMenuSelections(dummyMenu);
			Console.ReadKey(true);
			dummyMenu = CreateDummyList(2);
			PrintMenuSelections(dummyMenu);
			Console.ReadKey(true);
			var newDummyMenu = CreateDummyList(3);
			PrintMenuSelections(newDummyMenu);
		}

		/// <summary>
		/// Displays a menu of options for selection with a prompt message
		/// </summary>
		/// <param name="menu">Max 9 menu options allowed</param>
		public void PrintMenuSelections(IMenu menu)
		{
			var optionWidth = selectionWidth - 2;

			if (previousMenuOptions == null || previousMenuOptions != menu)
			{
				Console.SetCursorPosition(origin.X + 2, origin.Y - 11);
				PrintMenuPrompt(menu.Prompt, optionWidth);
			}

			for (int i = 0; i < menu.Options.Count; i++)
			{
				Console.SetCursorPosition(origin.X + 1, origin.Y - 9 + i);

				if (previousMenuOptions == null || previousMenuOptions != menu)
				{
					if (menu.Options[i].IsSelected)
					{
						PrintSelectedOption(menu.Options[i].Title, optionWidth);
					}
					else
					{
						PrintUnselectedOption(menu.Options[i].Title, optionWidth);
					}
				}
				else
				{
					if (previousMenuOptions.Options[i].IsSelected && !menu.Options[i].IsSelected)
					{
						PrintUnselectedOption(menu.Options[i].Title, optionWidth);
					}
					else if(!previousMenuOptions.Options[i].IsSelected && menu.Options[i].IsSelected)
					{
						PrintSelectedOption(menu.Options[i].Title, optionWidth);
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
			Console.Write("┌─                                                     ─┐");

			//Bottom border
			Console.SetCursorPosition(origin.X, origin.Y);
			Console.Write("└─                                                     ─┘");
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
			Console.ForegroundColor = Write.ColorUnselectedOptionFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			Console.Write(prompt);
			Write.EmptySpace(optionWidth - prompt.Length - 2);
		}

		private Menu CreateDummyList(int dummyListNum)
		{
			var dummyList = new List<IOption>();
			string dummyListPrompt = "Main Menu";

			switch (dummyListNum)
			{
				case 1:
					dummyList.Add(new Option("New Game", true));
					dummyList.Add(new Option("Continue Game", false));
					dummyList.Add(new Option("Options", false));
					dummyList.Add(new Option("Quit", false));
					break;
				case 2:
					dummyList.Add(new Option("New Game", false));
					dummyList.Add(new Option("Continue Game", true));
					dummyList.Add(new Option("Options", false));
					dummyList.Add(new Option("Quit", false));
					break;
				case 3:
					dummyList = new List<IOption>
					{
						new Option("Yes", true),
						new Option("No", false)
					};
					dummyListPrompt = "Are you sure?";
					break;
				default:
					break;
			}

			var menu = new Menu(dummyListPrompt, dummyList);
			return menu;
		}
		#endregion
	}
}
