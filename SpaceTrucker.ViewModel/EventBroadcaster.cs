using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.ViewModel
{
	public class EventBroadcaster
	{
		#region Event Handlers
		public event EventHandler<GameState> GameState;
		public event EventHandler<ViewScreenMode> ViewMode;

		public event EventHandler<string[]> Message;

		public event EventHandler<IMenu> Menu;

		public event EventHandler<string> FuelCells;
		public event EventHandler<string> Balance;
		public event EventHandler<string> Location;
		public event EventHandler<string> ResetDays;
		#endregion

		#region Event Triggers
		internal void ChangeGameState(GameState nextGameState)
		{
			GameState?.Invoke(this, nextGameState);
		}

		internal void ChangeViewScreenMode(ViewScreenMode nextViewMode)
		{
			ViewMode?.Invoke(this, nextViewMode);
		}

		internal void SendMessageToViewScreen(string[] message)
		{
			Message?.Invoke(this, message);
		}

		internal void SelectionDisplayMenu(IMenu nextMenu)
		{
			Menu?.Invoke(this, nextMenu);
		}

		internal void ChangeFuelCells(string fuelCells)
		{
			FuelCells?.Invoke(this, fuelCells);
		}

		internal void ChangeBalance(string balance)
		{
			Balance?.Invoke(this, balance);
		}

		internal void ChangeLocation(string planetName)
		{
			Location?.Invoke(this, planetName);
		}

		internal void ChangeResetDays(string remainingDays)
		{
			ResetDays?.Invoke(this, remainingDays);
		}
		#endregion
	}
}
