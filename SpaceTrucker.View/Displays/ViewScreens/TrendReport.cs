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
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
            PrintTrendReportTable();
		}

        private void PrintTrendReportTable()
		{
            var table = new string[]
            {
				"                                                                                                          ",
				"                                      ╭─                          ─╮                                      ",
                "                                         TOP SECRET: TREND REPORT                                         ",
                "                                      ╰─                          ─╯                                      ",
                "                                                                                                          ",
                " ╭──────────────────┬─────────────────┬────────────────────────────────┬────────────────────────────────╮ ",
                " │ Item             │   Price Range   │          Top 3 Sellers         │          Top 3 Buyers          │ ",
                " ├──────────────────┼─────────────────┼──────────┬──────────┬──────────┼──────────┬──────────┬──────────┤ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " │                  │                 │          │          │          │          │          │          │ ",
                " ╰──────────────────┴─────────────────┴──────────┴──────────┴──────────┴──────────┴──────────┴──────────╯ ",
                "  ╭─                                                                                                   ─╮ ",
                "    Important Note:                                                                                       ",
                "                                                                                                          ",
                "  ╰─                                                                                                   ─╯ ",
			};

            Console.ForegroundColor = Write.ColorMessageFG;
            Console.BackgroundColor = Write.ColorDisplayBG;

            for (int i = 0; i < 5; i++)
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
            
            Console.BackgroundColor = Write.ColorDisplayBG;

            for (int i = 0; i < trendReport.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = Write.ColorDefaultFG;
                    
                }
                else
                {
                    Console.ForegroundColor = Write.ColorDisplayFG;
                }

                Console.SetCursorPosition(origin.X + 3, origin.Y - 21 + i);
                Console.Write(trendReport[i]);
            }
        }
    }
}
