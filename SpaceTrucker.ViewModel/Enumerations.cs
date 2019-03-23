﻿namespace SpaceTrucker.ViewModel
{
	public enum InputRequestType
	{
		FullSelectionInput,
		MenuOnly,
		Market,
		EnterOnly,
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

	public enum GameState
	{
		ApplicationOpen,
		GameStart,
		GamePlaying,
		GameOver,
	}

	public enum MenuState
	{
		MainMenu,
		QuitMenu,
		GameMenu,
		TravelMenu,
		TravelConfirmationMenu,
		MarketMenu,
		TransactionMenu,
		TransactionConfirmationMenu,
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
		OpeningNarrative,
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
