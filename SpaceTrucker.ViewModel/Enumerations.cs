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
		IncreaseWarpFactor,
		DecreaseWarpFactor,
		Select,
		Back,
		Map,
		TrendReport,
		Market,
		Quit,
		Invalid,
	}

	public enum MenuState
	{
		MainMenu,
		QuitMenu,
		GameMenu,
		TravelMenu,
		MarketMenu,
		TransactionMenu,
	}

	public enum ViewScreenMode
	{
		TitleScreen,
		Map,
		Inventory,
		TrendReport,
		Market,
		Message,
		TravelAnimation,
	}

	public enum OptionType
	{
		NewGame,
		Continue,
		SaveGame,
		Quit,
		GoToTravel,
		GoToTradeMarket,
		GoToBuy,
		GoToSell,
		OreBuy,
		OreSell,
		PurchaseFuel,
		BackMainMenu,
		Planet,
		Yes,
		No,
	}
}
