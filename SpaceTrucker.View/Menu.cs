using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Menu : IMenu
	{
		public string Prompt { get; }
		public List<IOption> Options { get; set; }

		public Menu(string prompt, List<IOption> options)
		{
			Prompt = prompt;
			Options = options;
		}
	}
}
