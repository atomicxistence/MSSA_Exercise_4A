using System;

namespace SpaceTrucker.View
{
	class HeadsUpDisplay : IDisplay
	{
		private Coord origin;

		public void InitialRefresh(Coord origin)
		{
			this.origin = origin;
			//TODO: refresh background and display values
		}
	}
}
