using System;

namespace SpaceTrucker.View
{
	class ViewScreenDisplay : IDisplay
	{
		private Coord origin;

		public void InitialRefresh(Coord origin)
		{
			this.origin = origin;
			//TODO: print background and current text
		}
	}
}
