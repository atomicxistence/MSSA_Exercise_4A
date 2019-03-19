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

		internal void ChangeFuelCells(int fuelPercent)
		{
			var numOfCells = fuelPercent / 5;

			var sb = new StringBuilder(20);
			sb.Append('▌', numOfCells).Append(' ', 20 - numOfCells);

			FuelCells.Invoke(this, sb.ToString());
		}

		internal void ChangeBalance(int balance)
		{
			//TODO: format balance to string with euro symbol
			Balance.Invoke(this, balance.ToString());
		}

		internal void ChangeLocation(string planetName)
		{
			Location.Invoke(this, planetName);
		}

		internal void ChangeResetDays(int remainingDays)
		{
			//TODO: format remaining days to string with " days"
			ResetDays.Invoke(this, "");
		}
	}
}
