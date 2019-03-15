using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class DisplayManager
	{
		private MainMenuDisplay mainMenu;

		private List<IDisplay> displays = new List<IDisplay>();

		private ShipConsoleDisplay shipConsole;
		private HeadsUpDisplay hud;
		private SelectionDisplay selectionScreen;
		private ViewScreenDisplay viewScreen;

		public DisplayManager()
		{
			Initialize();
		}

		private void Initialize()
		{
			mainMenu = new MainMenuDisplay();

			shipConsole = new ShipConsoleDisplay();
			hud = new HeadsUpDisplay();
			selectionScreen = new SelectionDisplay();
			viewScreen = new ViewScreenDisplay();

			displays.Add(shipConsole);
			displays.Add(hud);
			displays.Add(selectionScreen);
			displays.Add(viewScreen);
		}
	}
}
