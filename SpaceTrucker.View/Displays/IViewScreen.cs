namespace SpaceTrucker.View
{
	interface IViewScreen
	{
		ViewMode ModeType { get; }
		void CompleteRefresh(Coord shipConsoleOrigin);
	}
}
