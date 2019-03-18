namespace SpaceTrucker.View
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

	public enum ViewMode
	{
		TitleScreen,
		Map,
		Inventory,
		TrendReport,
		Market,
	}
}
