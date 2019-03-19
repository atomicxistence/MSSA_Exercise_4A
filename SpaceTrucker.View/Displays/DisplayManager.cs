using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class DisplayManager : IDisplayManager
	{
		#region Class References
		private List<IDisplay> displays;
		private List<IViewScreen> viewScreenModes;

		private ViewMode currentMode = ViewMode.TitleScreen;

		private GameState currentGameState;

		private ShipConsoleDisplay shipConsole;
		private HeadsUpDisplay hud;
		private SelectionDisplay selectionScreen;
		private ViewScreenDisplay viewScreen;
		private TitleScreen titleScreen;

		private int displayWidth = 110;
		private int displayHeight = 50;

		private Coord displayOrigin;
		private Coord currentWindowSize;
		#endregion

		#region Public Methods
		public DisplayManager()
		{
			Initialize();
			CompleteRefresh();
		}

		public void CompleteRefresh()
		{
			Console.Clear();
			Console.CursorVisible = false;

			CenterConsoleWindow();
			foreach (var display in displays)
			{
				display.InitialRefresh(displayOrigin);
			}
			RefreshViewScreen();
		}

		public void Refresh(DisplayInfo newGameInfo)
		{
			// TODO: change view mode

			if (WindowSizeHasChanged())
			{
				CompleteRefresh();
			}

		}
		#endregion

		#region Private Methods

		private void Initialize()
		{
			Console.CursorVisible = false;

			SetWindowSize();
			InitializeDisplays();
			AddDisplaysToList();
		}

		private void SetWindowSize()
		{
			var bufferWidth = 4;
			var bufferHeight = 3;

			Console.SetWindowSize(displayWidth + bufferWidth, displayHeight + bufferHeight);
			Console.SetBufferSize(displayWidth + bufferWidth, displayHeight + bufferHeight);
			currentWindowSize = new Coord(Console.WindowWidth, Console.WindowHeight);
		}

		private void InitializeDisplays()
		{
			shipConsole = new ShipConsoleDisplay(displayWidth, displayHeight);
			hud = new HeadsUpDisplay();
			selectionScreen = new SelectionDisplay();
			viewScreen = new ViewScreenDisplay();

			titleScreen = new TitleScreen();
			// TODO: add more view screens
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

			viewScreenModes = new List<IViewScreen>
			{
				titleScreen,
			};
		}

		private bool WindowSizeHasChanged()
		{
			if (currentWindowSize.X != Console.WindowWidth || 
				currentWindowSize.Y != Console.WindowHeight)
			{
				currentWindowSize = new Coord(Console.WindowWidth, Console.WindowHeight);
				return true;
			}
			else
			{
				return false;
			}
		}

		private void CenterConsoleWindow()
		{
			var windowCenterX = Console.WindowWidth / 2;
			var windowCenterY = Console.WindowHeight / 2;

			displayOrigin = new Coord(windowCenterX - displayWidth / 2, 
									  windowCenterY + displayHeight / 2);
		}

		private void RefreshViewScreen()
		{
			foreach (var mode in viewScreenModes)
			{
				if (mode.ModeType == currentMode)
				{
					mode.CompleteRefresh(displayOrigin);
				}
			}
		}
		#endregion
	}
}
