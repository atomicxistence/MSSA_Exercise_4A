using System;

namespace SpaceTrucker.View
{
	class SelectionDisplay : IDisplay
	{
		private Coord origin;

		public SelectionDisplay()
		{

		}

		public void InitialRefresh(Coord origin)
		{
			this.origin = origin;
			//TODO: print background
		}
	}
}
