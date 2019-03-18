namespace SpaceTrucker.ViewModel
{
	class Option : IOption
	{
		public string Title { get; }
		public bool IsSelected { get; set; }

		public Option(string title, bool isSelected)
		{
			Title = title;
			IsSelected = isSelected;
		}
	}
}
