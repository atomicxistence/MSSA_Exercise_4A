using System;
using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	class MainMenu
	{
		public event EventHandler<IMenu> MainMenuDisplayEvent;

		private IMenu menuOptions;
		
		public MainMenu()
		{
			Initialize();
		}

		public void Run()
		{
			bool isUsing = true;

			do
			{
				//TODO: how do we get a return when an option is selected?
				MainMenuDisplayEvent?.Invoke(this, menuOptions);

			} while (isUsing);
		}

		private void Initialize()
		{
			//TODO: initialize the current menu options and add them to the list
		}
	}
}

