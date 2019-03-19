namespace SpaceTrucker.ViewModel
{
	public enum InputRequestType
	{
		FullSelectionInput,
		MenuOnly,
		Market,
	}

	public enum ActionType
	{
		NextItem,
		PreviousItem,
		NextTable,
		PreviousTable,
		Select,
		Back,
		Map,
		TrendReport,
		Inventory,
		Quit,
		Invalid,
	}

	public enum GameState
	{
		MainMenu,
		Message,
		FullMenuSelection,
		Market,
	}

	public enum ViewScreenMode
	{
		TitleScreen,
		Map,
		Inventory,
		TrendReport,
		Market,
	}
}
