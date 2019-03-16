using System;

namespace SpaceTrucker.View
{
	class SelectionDisplay : IDisplay
	{
		private Coord origin;

		private int selectionWidth;
		private int selectionHeight;

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			this.origin = shipConsoleOrigin;
			//TODO: print background
		}
	}
}
