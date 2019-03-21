using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Map : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Map;

		private Coord origin;

		private string[] map = new string[]
			{
                "┌─                                                                            ┌─                        ─┐",
                "      ˙                                            .              ˙             TRADE_ROUTE : ALPHA.8.00  ",
                "        ○        ○ T1d           ˙                                            └─                        ─┘",
                "      L1140b                                                                                              ",
                "                                         ˙                    ˙                                           ",
				"      ˙     ○ Lb                                                                       .                  ",
				" G667Cc ○                                                                                                 ",
				"             ○ PCb                                                    ˙                                   ",
                "  ○         ⓿                          ○ P109b                                                          ˙ ",
				" G163C     Earth                                            ˙                                             ",
				"                                                                                      ˙                   ",
				"                                                                                                          ",
                "    ˙    Kb ○ ⃝ W1061c                                                     ˙                              ",
				"                                             .                                                ˙           ",
                "                          ˙                                                                               ",
				"                                                                   ○ A14b                                 ",
                "           .                                                                     .                        ",
				"                                                                                                          ",
				"                                                 .                                                        ",
				"                              ˙                                                                           ",
                "   ○ K218b                                                            ˙                          KE186f ○ ",
				"                                                                                                          ",
				"             ˙                                                                                            ",
                "                                                ˙                                      ˙                  ",
                "      ○ K23b                                                       ˙                                      ",
				"                                                                                                          ",
				"                                                                                  ○ KE438b                ",
                "                    ˙                               .                                                     ",
				"                                                                                                          ",				
				"└─                                                                                                      ─┘",
			};
		//private string[] starField = new string[]
		//{
		//	"                                                                                                          ",
		//	"                          ˙                                                                    ˙          ",
		//	"                                                               ˙              TRADE_ROUTE : ALPHA.8.00    ",
		//	"      ˙                                                                                                   ",
		//	"                                                                                                          ",
		//	"                                                         ˙                                                ",
		//	"                                                                                                  ˙       ",
		//	"                                                  ˙                                                       ",
		//	"                                                                                                          ",
		//	"                        ˙                                                                                 ",
		//	"    ˙                                                                                                     ",
		//	"                                                   ˙                                        ˙             ",
		//	"                                                                           ˙                              ",
		//	"                                                                                                          ",
		//	"           ˙                                                                                              ",
		//	"                                                                                                          ",
		//	"                                                                                                          ",
		//	"                              ˙                                                                           ",
		//	"                                                               ˙                                          ",
		//	"                                                                                                          ",
		//	"             ˙                                                                                            ",
		//	"                                                                                       ˙                  ",
		//	"                                                                                                          ",
		//	"                                                    ˙                                                     ",
		//	"                                                                                                          ",
		//	"                                                                                                          ",
		//	"                                                                                                          ",
		//	"                            ˙                                                                             ",
		//	"      ˙                                                          ˙                   ˙                    ",
		//	"                                                                                                          ",
		//};

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintMap();
		}

		private void PrintMap()
		{
			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < map.Length; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
				Console.Write(map[i]);
			}
		}
	}
}
