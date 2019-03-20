using System.Collections.Generic;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	class MenuFactory
	{
		public Menu MainMenu { get; private set; }
		public Menu GameMenu { get; private set; }
		public Menu TravelMenu { get; private set; }
		public Menu Confirmation { get; private set; }
		
		public MenuFactory()
		{
			CreateMainMenu();
			CreateGameMenu();
			CreateTravelMenu();
			CreateConfirmationMenu();
		}

		private void CreateMainMenu()
		{
			var options = new List<IOption>
			{
				new Option("Continue Game", true),
				new Option("New Game", false),
				new Option("Quit", false),
			};

			MainMenu = new Menu("Main Menu", options);
		}

		private void CreateGameMenu()
		{
			var options = new List<IOption>
			{
				new Option("Travel to a different planet", true),
				new Option("View the planet's trade market", false),
				new Option("Purchase more fuel cells", false),
				new Option("Back to Main Menu", false),
			};

			GameMenu = new Menu("Select an option below", options);
		}

		private void CreateTravelMenu()
		{
			var options = new List<IOption>();
			//TODO: initializing the economy will be handled elsewhere
			Economy.InitializeEconomy();
			var closestPlanets = Economy.ClosestPlanets(Economy.planets[0].MyLocation, 9);

			foreach (var planet in closestPlanets)
			{
				options.Add(new Option($"{planet.Key.ShortName} - {planet.Key.Name}", false));
			}

			TravelMenu = new Menu("Select a planet to travel to...", options);
		}

		private void CreateConfirmationMenu()
		{
			var options = new List<IOption>
			{
				new Option("Yes", true),
				new Option("No", false),
			};

			Confirmation = new Menu("Are you sure?", options);
		}
	}
}
