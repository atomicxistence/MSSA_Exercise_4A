using System;
using System.Collections.Generic;
using System.Text;

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

		}

		private void CreateGameMenu()
		{
			//travel
			//market
			//buy fuel
			//main menu
		}

		private void CreateTravelMenu()
		{

		}

		private void CreateConfirmationMenu()
		{

		}
	}
}
