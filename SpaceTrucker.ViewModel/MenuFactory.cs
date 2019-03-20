using System.Collections.Generic;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	class MenuFactory
	{
		public Menu CreateTravelMenu(Dictionary<Planet, int> closestPlanets = null)
		{
			var options = new List<IOption>();

			foreach (var planet in closestPlanets)
			{
				options.Add(new Option($"{planet.Key.Name} ({planet.Key.ShortName})", OptionType.Planet,false));
			}

			options[0].IsSelected = true;

			return new Menu("Select a planet to travel to...", options);
		}

		public Menu CreateMainMenu()
		{
			var options = new List<IOption>
			{
				new Option("Continue Game", OptionType.Continue, true),
				new Option("New Game", OptionType.NewGame, false),
				new Option("Quit", OptionType.Quit,false),
			};

			return new Menu("Main Menu", options);
		}

		public Menu CreateGameMenu()
		{
			var options = new List<IOption>
			{
				new Option("Travel to a different planet", OptionType.GoToTravel,true),
				new Option("View the planet's trade market", OptionType.GoToTradeMarket,false),
				new Option("Purchase more fuel cells", OptionType.PurchaseFuel,false),
				new Option("Back to Main Menu", OptionType.BackMainMenu,false),
			};

			return new Menu("Select an option below", options);
		}

		public Menu CreateConfirmationMenu()
		{
			var options = new List<IOption>
			{
				new Option("Yes", OptionType.Yes,true),
				new Option("No", OptionType.No,false),
			};

			return new Menu("Are you sure?", options);
		}
	}
}
