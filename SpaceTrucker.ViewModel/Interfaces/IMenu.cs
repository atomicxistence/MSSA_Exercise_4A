using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	public interface IMenu
	{
		string Prompt { get; }
		List<IOption> Options { get; }
	}
}
