namespace SpaceTrucker.ViewModel
{
	class Option : IOption
	{
		public string Title { get; }
		public OptionType OptionType { get; }
		public bool IsSelected { get; set; }

		public Option(string title, OptionType optionType, bool isSelected)
		{
			Title = title;
			OptionType = optionType;
			IsSelected = isSelected;
		}
	}
}
