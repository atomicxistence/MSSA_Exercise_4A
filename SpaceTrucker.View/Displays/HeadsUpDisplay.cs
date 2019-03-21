using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class HeadsUpDisplay : IDisplay
	{
		private EventBroadcaster eventBroadcaster;
		private Coord origin;

		private int hudWidth = 40;
		private int hudHeight = 13;

		public HeadsUpDisplay(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;

			eventBroadcaster.FuelCells += PrintFuelCells;
			eventBroadcaster.Location += PrintLocation;
			eventBroadcaster.Balance += PrintBalance;
			eventBroadcaster.ResetDays += PrintResetDays;
		}

		public void InitialRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 2;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintBevel();
			PrintHUDScreen();
			PrintHUDTable();
			PrintFuelCells(this, "▌▌▌▌▌▌▌▌▌▌▌▌▌▌▌▌▌▌▌▌");
			PrintLocation(this, "Earth              ");
			PrintBalance(this, "฿ 1,000,000");
			PrintResetDays(this, "18,250 days");
		}

		/// <summary>
		/// Displays the current fuel level
		/// </summary>
		/// <param name="fuelLevel">20 characters needed, using "▌"</param>
		public void PrintFuelCells(object sender, string fuelLevel)
		{
			var fuelOrigin = new Coord(origin.X + 15, origin.Y - 11);

			Console.ForegroundColor = Write.ColorHighFuel;
			Console.BackgroundColor = Write.ColorDisplayBG;

			if (fuelLevel.IndexOf(' ') < 7)
			{
				Console.ForegroundColor = Write.ColorLowFuel;
			}
			if (fuelLevel.IndexOf(' ') < 3)
			{
				Console.ForegroundColor = Write.ColorUrgentFuel;
			}
			if (!fuelLevel.Contains(" "))
			{
				Console.ForegroundColor = Write.ColorHighFuel;
			}

			Console.SetCursorPosition(fuelOrigin.X, fuelOrigin.Y);
			Console.Write(fuelLevel);
		}

		/// <summary>
		/// Displays the current location
		/// </summary>
		/// <param name="location">20 characters needed</param>
		public void PrintLocation(object sender, string location)
		{
			var locationOrigin = new Coord(origin.X + 12, origin.Y - 9);
			PrintOverlay(locationOrigin, location);
		}

		/// <summary>
		/// Displays the current account balance
		/// </summary>
		/// <param name="balance">17 characters needed, beginning with "€ "</param>
		public void PrintBalance(object sender, string balance)
		{
			var balanceOrigin = new Coord(origin.X + 11, origin.Y - 7);
			PrintOverlay(balanceOrigin, balance);
		}

		/// <summary>
		/// Displays the current number of days until reset
		/// </summary>
		/// <param name="resetDays">11 characters needed, ending with " days"</param>
		public void PrintResetDays(object sender, string resetDays)
		{
			var resetDayOrigin = new Coord(origin.X + 21, origin.Y - 1);
			PrintOverlay(resetDayOrigin, resetDays);
		}

		private void PrintBevel()
		{
			int bevel = 1;

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorBevelBG;

			for (int i = 0; i < hudHeight + (bevel * 2); i++)
			{
				Console.SetCursorPosition(origin.X - bevel, origin.Y + bevel - i);
				Write.EmptySpace(hudWidth + (bevel * 2));
			}
		}

		private void PrintHUDScreen()
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < hudHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Write.EmptySpace(hudWidth);
			}
		}

		private void PrintHUDTable()
		{
			var table = new string[]
				{
					"┌──────────────────────────────────────┐",
					"│ Fuel Cells [                     ]   │",
					"├──────────────────────────────────────┤",
					"│ Location:                            │",
					"├──────────────────────────────────────┤",
					"│ Balance:                             │",
					"│                                      │",
					"│                                      │",
					"│                                      │",
					"│                                      │",
					"│ -----------------------------------  │",
					"│ Scheduled Reset in                   │",
					"└──────────────────────────────────────┘"
				};

			Console.ForegroundColor = Write.ColorDisplayTable;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < table.Length; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);
				Console.Write(table[table.Length - i - 1]);
			}
		}

		private void PrintOverlay(Coord overlayOrigin, string text)
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			Console.SetCursorPosition(overlayOrigin.X, overlayOrigin.Y);
			Console.Write(text);
		}
	}
}
