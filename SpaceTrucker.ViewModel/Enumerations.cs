namespace SpaceTrucker.ViewModel
{
	public enum InputRequestType
	{
		FullSelectionInput,
		MenuOnly,
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
}
