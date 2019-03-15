using System;

namespace SpaceTrucker.View
{
	class ViewScreenDisplay : IDisplay
	{
		private Coord shipConsoleOrigin;
		private Coord origin;

		private int sizeWidth = 790;
		private int sizeHeight = 590;
	

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			this.shipConsoleOrigin = shipConsoleOrigin;
			PrintBevel();
			PrintBlankViewScreen();
		}

		private void PrintBevel()
		{
			//TODO: print bevel
		}

		private void PrintBlankViewScreen()
		{
			//TODO: print blanked display
		}
	}
}
