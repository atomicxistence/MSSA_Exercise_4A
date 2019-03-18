using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class GameManager
	{
		private DisplayManager display;
		private UserInput input;

		public GameManager()
		{
			display = new DisplayManager();
			input = new UserInput();
		}

		public IUserInput GetInputReference()
		{
			return input;
		}

		public IDisplayManager GetDisplayReference()
		{
			return display;
		}
	}
}
