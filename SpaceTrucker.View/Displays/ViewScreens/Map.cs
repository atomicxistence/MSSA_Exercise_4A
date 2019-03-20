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
				"┌─                                                                                                      ─┐",
				"    ○ L1140B                      ˙                                                                    ˙  ",
				"                ○ T1D                                               ˙         TRADE_ROUTE : ALPHA.8.00    ",
				"      ˙                                                                                                   ",
				"          ○ LB                                                                                            ",
				" G667CC ○    ○ PCB                  ○ P109B                                      ˙                        ",
				"           ○ Earth                                                                                  ˙     ",
				"     ○ G163C                                             ˙                                                ",
				"             ○ W1061C                                                                                     ",
				"          ○ KB              ˙                                                                             ",
				"    ˙                                                                                                     ",
				"                                                   ˙                                        ˙             ",
				"                                                                           ˙                              ",
				"                                                                                                          ",
				"           ˙                                   ○ A14B                                                     ",
				"                                                                                                          ",
				"                                                                                                          ",
				"                              ˙                                                                           ",
				"                                                               ˙                                 ○ KE186F ",
				" ○ K218B                                                                                                  ",
				"             ˙                                                                                            ",
				"                                                                                       ˙                  ",
				"     ○  K23D                                                                                              ",
				"                                                    ˙                                                     ",
				"                                                                                                          ",
				"                                                                           ○ KE438B                       ",
				"                                                                                                          ",
				"                            ˙                                                                             ",
				"      ˙                                                          ˙                   ˙                    ",
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
