using System;
using System.Collections.Generic;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class TrendReport : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.TrendReport;

		private Coord origin;
		private EventBroadcaster eventBroadcaster;

		public TrendReport(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
            this.eventBroadcaster.TrendReport += PrintTrendReport;

            
        }

        public void EventUnsubscribe() {;}

        public void EventSubscribe(){;}
        

            public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 3;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
            PrintTrendReportTable();
		}

        private void PrintTrendReportTable()
		{
            var table = new string[]
            {
                "                                     ╭─                          ─╮                                     ",
                "                                        TOP SECRET: TREND REPORT                                        ",
                "                                     ╰─                          ─╯                                     ",
                "                                                                                                        ",
                "╭──────────────────┬─────────────────┬────────────────────────────────┬────────────────────────────────╮",
                "│ Item             │   Price Range   │          Top 3 Sellers         │          Top 3 Buyers          │",
                "├──────────────────┼─────────────────┼──────────┬──────────┬──────────┼──────────┬──────────┬──────────┤",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "│                  │                 │          │          │          │          │          │          │",
                "╰──────────────────┴─────────────────┴──────────┴──────────┴──────────┴──────────┴──────────┴──────────╯",
                " ╭─                                                                                                   ─╮",
                "   Important Note:                                                                                      ",
                "                                                                                                        ",
                " ╰─                                                                                                   ─╯",
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = Write.ColorDisplayBG;

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
                Console.Write(table[i]);
            }

            Console.ForegroundColor = Write.ColorDefaultFG;

            for (int i = 4; i < table.Length; i++)
            {
                Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
                Console.Write(table[i]);
            }
        }

        private void PrintTrendReport(object sender, string[] trendReport)
        {
            Console.ForegroundColor = Write.ColorDefaultFG;
            Console.BackgroundColor = Write.ColorDisplayBG;

            for (int i = 0; i < trendReport.Length; i++)
            {
                Console.SetCursorPosition(origin.X + 2, origin.Y - 22 + i);
                Console.Write(trendReport[i]);
            }
        }
    }
}
