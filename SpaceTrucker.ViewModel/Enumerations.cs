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
		Travel,
	}

	public enum ViewScreenMode
	{
		TitleScreen,
		Map,
		Inventory,
		TrendReport,
		Market,
		Message,
	}

	public enum OptionType
	{
		NewGame,
		Continue,
		SaveGame,
		Quit,
		GoToTravel,
		GoToTradeMarket,
		PurchaseFuel,
		BackMainMenu,
		Planet,
		Yes,
		No,
	}
}
