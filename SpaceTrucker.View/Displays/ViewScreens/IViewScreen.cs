using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	interface IViewScreen
	{
		ViewScreenMode ModeType { get; }
		void CompleteRefresh(Coord shipConsoleOrigin);
		void EventUnsubscribe();
		void EventSubscribe();
	}
}
