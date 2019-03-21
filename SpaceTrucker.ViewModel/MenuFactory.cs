using System.Collections.Generic;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	class MenuFactory
	{
		internal Menu CreateTravelMenu(Dictionary<Planet, int> closestPlanets = null)
		{
			var options = new List<IOption>();

			foreach (var planet in closestPlanets)
			{
				options.Add(new Option($"{planet.Key.Name} ({planet.Key.ShortName})", OptionType.Planet,false));
			}

			options[0].IsSelected = true;

			return new Menu("Select a planet to travel to...", options);
		}

		internal Menu CreateMainMenu()
		{
			var options = new List<IOption>
			{
				new Option("Continue Game", OptionType.Continue, true),
				new Option("New Game", OptionType.NewGame, false),
				new Option("Quit", OptionType.Quit,false),
			};

			return new Menu("Main Menu", options);
		}

		internal Menu CreateGameMenu()
		{
			var options = new List<IOption>
			{
				new Option("Travel to a different planet", OptionType.GoToTravel,true),
				new Option("Trade with the planet's market", OptionType.GoToTradeMarket,false),
				new Option("Purchase more fuel cells", OptionType.PurchaseFuel,false),
				new Option("Main Menu", OptionType.BackMainMenu,false),
			};

			return new Menu("Select an option below", options);
		}

		internal Menu CreateBuySellMenu()
		{
			var options = new List<IOption>
			{
				new Option("Buy", OptionType.GoToBuy, true),
				new Option("Sell", OptionType.GoToSell, false),
			};

			return new Menu("Trade Market", options);
		}

		internal Menu CreateOreMenu(string prompt, List<string> ores, OptionType optionType)
		{
			var options = new List<IOption>();

			foreach (var ore in ores)
			{
				options.Add(new Option(ore, optionType, false));
			}

			options[0].IsSelected = true;

			return new Menu(prompt, options);
		}

		internal Menu CreateConfirmationMenu(string prompt)
		{
			var options = new List<IOption>
			{
				new Option("Yes", OptionType.Yes, true),
				new Option("No", OptionType.No, false),
			};

			return new Menu(prompt, options);
		}
	}
}
