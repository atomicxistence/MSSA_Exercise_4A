using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Market : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Market;

		private Coord origin;
		private EventBroadcaster eventBroadcaster;

		public Market(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
		}

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintMarket();
		}

		private void PrintMarket()
		{
			PrintMarketTable();
			PrintMarketBuy();
			PrintMarketSell();
			PrintMarketInventory();
		}

		private void PrintMarketTable()
		{
			var table = new string[]
			{
				"╭────────┬──────────────────────────────────────────┬──────────┬─────────────────────────────────────────╮",
				"│  BUY ○─┘                                          │   SELL ○─┘                                         │",
				"│    Item                    Price            QTY   │    Item                    Price                   │",
				"├───────────────────────────────────────────────────┼────────────────────────────────────────────────────┤",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"│                                                   │                                                    │",
				"├───────────────┬───────────────────────────────────┴────────────────────────────────────────────────────┤",
				"│  INVENTORY  ○─┘                                                                                        │",
				"├────────────────────────────────────────────────────────────────────────────────────────────────────────┤",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"│                                                                                                        │",
				"╰────────────────────────────────────────────────────────────────────────────────────────────────────────╯",
			};

			Console.ForegroundColor = Write.ColorDisplayTable;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < table.Length; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
				Console.Write(table[i]);
			}
		}

		private void PrintMarketBuy()
		{
			// TODO: market buy formatting
		}

		private void PrintMarketSell()
		{
			// TODO: market sell formatting
		}

		private void PrintMarketInventory()
		{
			// TODO: inventory formatting
		}
	}
}
