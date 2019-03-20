using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class ViewScreenDisplay : IDisplay
	{
		EventBroadcaster eventBroadcaster;

		private Coord origin;

		private int sizeWidth = 106;
		private int sizeHeight = 30;

		public ViewScreenDisplay(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
		}

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintBlankViewScreen();
		}

		#region Private Methods
		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < sizeHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel - i);
				Write.EmptySpace(sizeWidth + (bevel * 2));
			}
		}

		internal void PrintBlankViewScreen()
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < sizeHeight; i++)
			{
				Console.SetCursorPosition(origin.X , origin.Y - i);
				Write.EmptySpace(sizeWidth);
			}
		}
		#endregion
	}
}
