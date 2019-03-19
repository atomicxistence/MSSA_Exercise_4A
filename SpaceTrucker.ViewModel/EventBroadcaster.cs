using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.ViewModel
{
	public class EventBroadcaster
	{
		#region Event Handlers
		public event EventHandler<string> FuelCells;
		public event EventHandler<string> Balance;
		public event EventHandler<string> Location;
		public event EventHandler<string> ResetDays;

		#endregion

		internal void ChangeFuelCells(string fuelCells)
		{
			FuelCells.Invoke(this, fuelCells);
		}

		internal void ChangeBalance(string balance)
		{
			Balance.Invoke(this, balance);
		}

		internal void ChangeLocation(string planetName)
		{
			Location.Invoke(this, planetName);
		}

		internal void ChangeResetDays(string remainingDays)
		{
			ResetDays.Invoke(this, remainingDays);
		}
	}
}
