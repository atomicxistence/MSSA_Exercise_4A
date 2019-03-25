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

        private bool subscribed = false;

        public Market(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;

			eventBroadcaster.MarketBuy += PrintMarketBuy;
			eventBroadcaster.MarketSell += PrintMarketSell;
			eventBroadcaster.MarketInventory += PrintMarketInventory;
            subscribed = true;

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
            if (subscribed)
            {
                eventBroadcaster.MarketBuy -= PrintMarketBuy;
                eventBroadcaster.MarketSell -= PrintMarketSell;
                eventBroadcaster.MarketInventory -= PrintMarketInventory;
                subscribed = false;
            }

        }

		public void EventSubscribe()
		{
            if (!subscribed)
            {
                eventBroadcaster.MarketBuy += PrintMarketBuy;
                eventBroadcaster.MarketSell += PrintMarketSell;
                eventBroadcaster.MarketInventory += PrintMarketInventory;
                subscribed = true;
            }
		}

		private void PrintMarketTable()
		{
			var table = new string[]
			{
				"╭──────────────────┬────────────────────────────────┬───────────────┬────────────────────────────────────╮",
				"│  BEING OFFERED ○─╯                                │   IN DEMAND ○─╯                                    │",
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

            var maxCapacity = (sender as EventBroadcaster)?.maxCapacity;
            Console.SetCursorPosition(origin.X + 88, origin.Y - 9 );
            Console.Write($"Max Capacity: {maxCapacity}");
            var offset = 0;

            if (previousInventoryLength > marketInventoryTable.Length)
			{
                offset = marketInventoryTable.Length / 5 * 44;
                for (int i = marketInventoryTable.Length; i < previousInventoryLength; i++)
				{
                    
                    Console.SetCursorPosition(origin.X + 3 + offset, origin.Y - 6 + (i % 5));
					Write.EmptySpace(25);
                    
                }
                offset = 0;
			}
            //TODO: adjust for loop to print more than 5 items
            
			for (int i = 0; i < marketInventoryTable.Length; i++)
			{
                offset += ( i > 0 && (i % 5 == 0))? 44 : 0;

                Console.SetCursorPosition(origin.X + 3 + offset, origin.Y - 6 + (i % 5));
				Console.Write($"{marketInventoryTable[i]}");
			}

			previousInventoryLength = marketInventoryTable.Length;
		}
	}
}
