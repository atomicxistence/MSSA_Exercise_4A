using System;
using System.Threading.Tasks;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Message : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Message;

		private Coord origin;

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			throw new NotImplementedException();
		}
	}
}
