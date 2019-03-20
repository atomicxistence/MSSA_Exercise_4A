namespace SpaceTrucker.ViewModel
{
	public interface IOption
	{
		string Title { get; }
		OptionType OptionType { get; }
		bool IsSelected { get; set; }
	}
}
