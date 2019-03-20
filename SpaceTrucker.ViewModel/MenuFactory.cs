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

			foreach (var planet in Economy.planets)
			{
				options.Add(new Option($"{planet.ShortName} - {planet.Name}", false));
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
