using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class DisplayManager
	{
		#region Class References
		private MainMenuDisplay mainMenu;

		private List<IDisplay> displays;

		private ShipConsoleDisplay shipConsole;
		private HeadsUpDisplay hud;
		private SelectionDisplay selectionScreen;
		private ViewScreenDisplay viewScreen;

		private int displayWidth = 150;
		private int displayHeight = 50;

		private Coord displayOrigin;
		#endregion

		#region Public Methods
		public DisplayManager()
		{
			Initialize();
			CompleteRefresh();
		}

		public void CompleteRefresh()
		{
			CenterConsoleWindow();
			foreach (var display in displays)
			{
				display.InitialRefresh(displayOrigin);
			}
		}
		#endregion

		#region Private Methods
		private void CenterConsoleWindow()
		{
			var windowCenterX = Console.WindowWidth / 2;
			var windowCenterY = Console.WindowHeight / 2;

			displayOrigin = new Coord(windowCenterX - displayWidth / 2, 
									  windowCenterY + displayHeight / 2);
		}

		private void Initialize()
		{
			Console.CursorVisible = false;

			SetWindowSize();
			InitializeDisplays();
			AddDisplaysToList();
		}

		private void SetWindowSize()
		{
			Console.SetWindowSize(displayWidth + 2, displayHeight + 2);
			//Console.SetBufferSize(displayWidth, displayHeight);
		}

		private void InitializeDisplays()
		{
			mainMenu = new MainMenuDisplay(displayWidth, displayHeight, displayOrigin);

			shipConsole = new ShipConsoleDisplay(displayWidth, displayHeight);
			hud = new HeadsUpDisplay();
			selectionScreen = new SelectionDisplay();
			viewScreen = new ViewScreenDisplay();
		}

		private void AddDisplaysToList()
		{
			displays = new List<IDisplay>
			{
				shipConsole,
				hud,
				selectionScreen,
				viewScreen
			};
		}
		#endregion
	}
}
