using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
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

		public Menu()
		{
		}
	}
}
