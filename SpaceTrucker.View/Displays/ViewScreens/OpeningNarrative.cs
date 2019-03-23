using System;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class OpeningNarrative : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.OpeningNarrative;

		private Coord origin;

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintOpeningNarrative();
		}

		public void EventSubscribe() { }

		public void EventUnsubscribe() { }

		private void PrintOpeningNarrative()
		{
			var narrative = new string[]
			{
				"                                               *                                                          ",
				"                                                                                     *                    ",
				"      *                                                                                           *       ",
				"                          *                                                                               ",
				"                                                                                                          ",
				"                                                          *                                               ",
				"         ╭───────────────────────────────────────────────────────────────────────────────────────╮        ",
				"         │                                                                                       │        ",
				"         │    The universe was made a much smaller place once faster than light travel became    │        ",
				"         │ possible. Trading planetary ores is a lucrative business and Weyland Consortium is    │        ",
				"         │ the universal leader.                                                                 │        ",
				"         │                                                                                       │        ",
				"         │    Weyland contracts autonomous galactic truckers to trade and transport their goods  │        ",
				"         │ and services through the most hostile trade routes. Each pilot is outfitted with      │        ",
				"         │ cutting edge Microsoft AI technology, learning and adapting to the changing universal │        ",
				"         │ economy.                                                                              │        ",
				"         │                                                                                       │        ",
				"         │    These pilots are designed to last for only 50 years. Only the most profitable      │        ",
				"         │ pilots are refitted into new ships, the rest are scrapped...                          │        ",
				"         │                                                                                       │        ",
				"         ╰───────────────────────────────────────────────────────────────────────────────────────╯        ",
				"                                                                                                          ",
				"                    *                                                                                     ",
				"                                                                                                          ",
				"                                                                                                          ",
				"           *                                                               *                              ",
				"     *                            *                                                                       ",
				"                                                                                                          ",
				"                                                                                                          ",
			};

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < narrative.Length; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
				Console.Write(narrative[i]);
			}
		}
	}
}
