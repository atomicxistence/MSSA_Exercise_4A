using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Market : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Market;

		private Coord origin;
		private EventBroadcaster eventBroadcaster;

		private int previousInventoryLength = 0;

		public Market(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;

			eventBroadcaster.MarketBuy += PrintMarketBuy;
			eventBroadcaster.MarketSell += PrintMarketSell;
			eventBroadcaster.MarketInventory += PrintMarketInventory;
		}

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintMarketTable();
		}

		public void EventUnsubscribe()
		{
			eventBroadcaster.MarketBuy -= PrintMarketBuy;
			eventBroadcaster.MarketSell -= PrintMarketSell;
			eventBroadcaster.MarketInventory -= PrintMarketInventory;
		}

		public void EventSubscribe()
		{
			eventBroadcaster.MarketBuy += PrintMarketBuy;
			eventBroadcaster.MarketSell += PrintMarketSell;
			eventBroadcaster.MarketInventory += PrintMarketInventory;
		}

		private void PrintMarketTable()
		{
			var table = new string[]
			{
				"╭────────┬──────────────────────────────────────────┬──────────┬─────────────────────────────────────────╮",
				"│  BUY ○─╯                                          │   SELL ○─╯                                         │",
				"│    Item                           Price           │    Item                           Price            │",
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
				"╰───────────────────────────────────────────────────┴────────────────────────────────────────────────────╯",
				"╭────────────────┬───────────────────────────────────────────────────────────────────────────────────────╮",
				"│   INVENTORY  ○─╯                                                                                       │",                        
				"├────────────────────────────────────────────────────────────────────────────────────────────────────────┤",
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

		private void PrintMarketBuy(object sender, string[] marketBuyTable)
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < marketBuyTable.Length; i++)
			{
				Console.SetCursorPosition(origin.X + 3, origin.Y - 24 + i);
				Console.Write(marketBuyTable[i]);
			}
		}

		private void PrintMarketSell(object sender, string[] marketSellTable)
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < marketSellTable.Length; i++)
			{
				Console.SetCursorPosition(origin.X + 55, origin.Y - 24 + i);
				Console.Write(marketSellTable[i]);
			}
		}

		private void PrintMarketInventory(object sender, string[] marketInventoryTable)
		{
			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			if (previousInventoryLength > marketInventoryTable.Length)
			{
				for (int i = marketInventoryTable.Length; i < previousInventoryLength; i++)
				{
					Console.SetCursorPosition(origin.X + 3, origin.Y - 6 + i);
					Write.EmptySpace(25);
				}
			}
			//TODO: adjust for loop to print more than 5 items
			for (int i = 0; i < marketInventoryTable.Length; i++)
			{
				Console.SetCursorPosition(origin.X + 3, origin.Y - 6 + i);
				Console.Write($"{marketInventoryTable[i]}              ");
			}

			previousInventoryLength = marketInventoryTable.Length;
		}
	}
}
