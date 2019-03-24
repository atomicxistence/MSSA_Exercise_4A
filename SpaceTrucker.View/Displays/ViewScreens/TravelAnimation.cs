using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class TravelAnimation : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.TravelAnimation;

		private Coord origin;
		private EventBroadcaster eventBroadcaster;

		public TravelAnimation(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
		}

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 2;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);

			PrintAnimation();
		}

		public void EventSubscribe()
		{
			eventBroadcaster.Location += PrintDestinationTitle;
		}

		public void EventUnsubscribe()
		{
			eventBroadcaster.Location -= PrintDestinationTitle;
		}

		private void PrintAnimation()
		{
			var animationRate = 100;
			var keyFrameBegin = new string[]
				{
				"                        ˙                                                                                 ",
				"      ˙                                            .              ˙                            ˙          ",
				"                 ˙               ˙                                            ˙             ˙             ",
				"                                                                                                    ˙     ",
				"                                         ˙                    ˙                                           ",
				"      ˙     ˙                                                                          .                  ",
				"                           ˙                                                                              ",
				"                                                                      ˙                                   ",
				"  ˙         ˙                          ˙           ˙                                          ˙         ˙ ",
				"                                                                ˙                                         ",
				"                                                                                      ˙                   ",
				"                                     ˙                    ˙                                               ",
				"    ˙           ˙                                                          ˙                              ",
				"                                             .                                                ˙           ",
				"                          ˙                                                                               ",
				"                                                                   ˙                                      ",
				"           .                                               ˙                      .                       ",
				"                                                                                                          ",
				"                                                 .                                                        ",
				"                              ˙                                                               ˙           ",
				"   ˙                                                                 ˙                                  ˙ ",
				"                                                                                                          ",
				"             ˙                                                                                            ",
				"                                ˙                ˙                                      ˙                 ",
				"      ˙                                                          ˙                                        ",
				"                                                                                                          ",
				"                                      ˙                                            ˙                      ",
				"                    ˙                               .                                                     ",
				"                                                                                             ˙            ",
				"            ˙                                                                                             ",
				};
			var keyFrameEnd = new string[]
				{
				"                        ˙                                                                                 ",
				"      ˙                                            .              ˙                            ˙          ",
				"                 ˙               ˙                                            ˙             ˙             ",
				"                                                                                                    ˙     ",
				"                                         ˙                    ˙                                           ",
				"      ˙     ˙                                                                          .                  ",
				"                           ˙                                                                              ",
				"                                                                      ˙                                   ",
				"  ˙         ˙                          ˙           ˙                                          ˙         ˙ ",
				"                                                                ˙                                         ",
				"                                                                                      ˙                   ",
				"                                     ˙                    ˙                                               ",
				"    ˙           ˙                                                     ˙                                   ",
				"                                             .                                     ˙                      ",
				"                          ˙                       ▄███▄                                                   ",
				"                                                ▄███████▄             ˙                                   ",
				"           .                                    ▀███████▀                                 .               ",
				"                                                  ▀███▀                                                   ",
				"                                                 .                                                        ",
				"                              ˙                                                               ˙           ",
				"   ˙                                                                 ˙                                  ˙ ",
				"                                                                                                          ",
				"             ˙                                                                                            ",
				"                                ˙                ˙                                      ˙                 ",
				"      ˙                                                          ˙                                        ",
				"                                                                                                          ",
				"                                      ˙                                            ˙                      ",
				"                    ˙                               .                                                     ",
				"                                                                                             ˙            ",
				"            ˙                                                                                             ",
				};
			var animation = new List<string[]>
			{
				new string[]
				{
				"                        ˙                                                                                 ",
				"      ˙                                            .              ˙                            ˙          ",
				"                 ˙               ˙                                            ˙             ˙             ",
				"                                                                                                    ˙     ",
				"                                         ˙                    ˙                                           ",
				"      ˙     ˙                                                                          .                  ",
				"                           ˙                                                                              ",
				"                                                                      ˙                                   ",
				"  ˙         ˙                          ˙           ˙                                          ˙         ˙ ",
				"                                                                ˙                                         ",
				"                                                                                      ˙                   ",
				"                                     ˙                    ˙                                               ",
				"    ˙           ˙                                                          ˙                              ",
				"                                             .                                                ˙           ",
				"                          ˙                                                                               ",
				"                                                                   ˙                                      ",
				"           .                                               ˙                      .                       ",
				"                                                                                                          ",
				"                                                 .                                                        ",
				"                              ˙                                                               ˙           ",
				"   ˙                                                                 ˙                                  ˙ ",
				"                                                                                                          ",
				"             ˙                                                                                            ",
				"                                ˙                ˙                                      ˙                 ",
				"      ˙                                                          ˙                                        ",
				"                                                                                                          ",
				"                                      ˙                                            ˙                      ",
				"                    ˙                               .                                                     ",
				"                                                                                             ˙            ",
				"            ˙                                                                                             ",
				},
				new string[]
				{
				"                        ╲                                                                                 ",
				"      ╲                                            |              ╱                            ╱          ",
				"                 ╲               ╲                                            ╱             ╱             ",
				"                                                                                                    ╱     ",
				"                                         ╲                    ╱                                           ",
				"      ╲     ╲                                                                          ╱                  ",
				"                           ╲                                                                              ",
				"                                                                      ╱                                   ",
				"  ╲         ╲                          ╲           |                                          ╱         ˙ ",
				"                                                                ╱                                         ",
				"                                                                                      ╱                   ",
				"                                     ╲                    ╱                                               ",
				"    -           -                                                          ╱                              ",
				"                                             -                                                -           ",
				"                          -                                                                               ",
				"                                                                   -                                      ",
				"           ╱                                               ╲                      ╲                       ",
				"                                                                                                          ",
				"                                                 |                                                        ",
				"                              ╱                                                               ╲           ",
				"   ╱                                                                 ╲                                  ╲ ",
				"                                                                                                          ",
				"             ╱                                                                                            ",
				"                                ╱                |                                      ╲                 ",
				"      ╱                                                          ╲                                        ",
				"                                                                                                          ",
				"                                      ╱                                            ╲                      ",
				"                    ╱                               |                                                     ",
				"                                                                                             ╲            ",
				"            ╱                                                                                             ",
				},
				new string[]
				{
				"     ╲                  ╲                          │               ╱                            ╱         ",
				"      ╲         ╲               ╲                  |              ╱            ╱             ╱ ╱          ",
				"                 ╲               ╲                                            ╱             ╱             ",
				"                                        ╲                      ╱                                          ",
				"     ╲     ╲                             ╲                    ╱                         ╱                 ",
				"      ╲     ╲                                                                          ╱                  ",
				"                           ╲                                           ╱                                  ",
				" ╲         ╲                          ╲            │                  ╱                        ╱          ",
				"  ╲         ╲                          ╲           │             ╱                            ╱         ˙ ",
				"                                                                ╱                      ╱                  ",
				"                                    ╲                      ╱                          ╱                   ",
				"                                     ╲                    ╱                 ╱                             ",
				"   ──          ──                                                          ╱                              ",
				"                                             ─                                                ──          ",
				"                         ──                                                                               ",
				"                                                                   ──                                     ",
				"           ╱                                               ╲                      ╲                       ",
				"          ╱                                                 ╲                      ╲                      ",
				"                                                 │                                                        ",
				"                              ╱                  │                                            ╲           ",
				"   ╱                         ╱                                       ╲                         ╲        ╲ ",
				"  ╱                                                                   ╲                                   ",
				"             ╱                                                                                            ",
				"            ╱                   ╱                │                                      ╲                 ",
				"      ╱                        ╱                 │               ╲                       ╲                ",
				"     ╱                                                            ╲                                       ",
				"                                      ╱                                            ╲                      ",
				"                    ╱                ╱              │                               ╲                     ",
				"                   ╱                                │                                        ╲            ",
				"            ╱                                                                                 ╲           ",
				},
				new string[]
				{
				"     ╲         ╲        ╲      ╲                   │               ╱            ╱             ╱ ╱         ",
				"      ╲         ╲               ╲                  |              ╱            ╱             ╱ ╱          ",
				"                 ╲               ╲     ╲                        ╱             ╱             ╱             ",
				"    ╲     ╲                             ╲                      ╱                         ╱                ",
				"     ╲     ╲             ╲               ╲                    ╱                         ╱                 ",
				"      ╲     ╲             ╲                                             ╱              ╱                  ",
				"╲         ╲                ╲         ╲             │                   ╱                       ╱          ",
				" ╲         ╲                          ╲            │              ╱   ╱                       ╱           ",
				"  ╲         ╲                          ╲           │             ╱                      ╱    ╱          ˙ ",
				"                                   ╲                        ╱   ╱                      ╱                  ",
				"                                    ╲                      ╱                 ╱        ╱                   ",
				"                                     ╲                    ╱                 ╱                             ",
				"  ───         ───                                                          ╱                              ",
				"                                            ──                                                ───         ",
				"                        ───                                                                               ",
				"                                                                   ───                                    ",
				"           ╱                                               ╲                      ╲                       ",
				"          ╱                                                 ╲                      ╲                      ",
				"         ╱                                       │           ╲                      ╲                     ",
				"                              ╱                  │                                            ╲           ",
				"   ╱                         ╱                   │                   ╲                         ╲        ╲ ",
				"  ╱                         ╱                                         ╲                         ╲        ╲",
				" ╱           ╱                                                         ╲                                  ",
				"            ╱                    ╱                │                                      ╲                ",
				"      ╱    ╱                    ╱                 │               ╲                       ╲               ",
				"     ╱                         ╱                  │                ╲                       ╲              ",
				"    ╱                                 ╱                             ╲              ╲                      ",
				"                    ╱                ╱              │                               ╲                     ",
				"                   ╱                ╱               │                                ╲       ╲            ",
				"            ╱     ╱                                 │                                         ╲           ",
				},
				new string[]
				{
				"     ╲         ╲        ╲      ╲                   │               ╱            ╱             ╱ ╱         ",
				"      ╲         ╲               ╲     ╲            │             ╱╱            ╱             ╱ ╱          ",
				"   ╲     ╲       ╲               ╲     ╲                        ╱             ╱           ╱ ╱             ",
				"    ╲     ╲             ╲               ╲                      ╱                         ╱                ",
				"     ╲     ╲             ╲               ╲                    ╱          ╱              ╱                 ",
				"      ╲  ╲  ╲             ╲         ╲              │                    ╱              ╱        ╱         ",
				"╲         ╲                ╲         ╲             │               ╱   ╱                       ╱          ",
				" ╲         ╲                          ╲            │              ╱   ╱                  ╱    ╱           ",
				"  ╲         ╲                     ╲    ╲           │         ╱   ╱                      ╱    ╱          ˙ ",
				"                                   ╲                        ╱   ╱             ╱        ╱                  ",
				"                                    ╲                      ╱                 ╱        ╱                   ",
				"                                     ╲                    ╱                 ╱                             ",
				"─────       ─────                                                          ╱                              ",
				"                                           ───                                                ─────       ",
				"                      ─────                                                                               ",
				"                                                                   ─────                                  ",
				"           ╱                                               ╲                      ╲                       ",
				"          ╱                                                 ╲                      ╲                      ",
				"         ╱                                       │           ╲                      ╲                     ",
				"        ╱                     ╱                  │            ╲                      ╲        ╲           ",
				"   ╱                         ╱                   │                   ╲                         ╲        ╲ ",
				"  ╱                         ╱                    │                    ╲                         ╲        ╲",
				" ╱           ╱             ╱                                           ╲                         ╲        ",
				"╱           ╱                    ╱                │                     ╲                ╲                ",
				"      ╱    ╱                    ╱                 │               ╲                       ╲               ",
				"     ╱    ╱                    ╱                  │                ╲                       ╲              ",
				"    ╱                         ╱       ╱           │                 ╲              ╲        ╲             ",
				"   ╱                ╱                ╱              │                ╲              ╲                     ",
				"                   ╱                ╱               │                                ╲       ╲            ",
				"            ╱     ╱                ╱                │                                 ╲       ╲           ",
				},
				new string[]
				{
				"     ╲         ╲        ╲      ╲                   │               ╱            ╱             ╱ ╱         ",
				"      ╲         ╲               ╲     ╲            │             ╱╱            ╱             ╱ ╱          ",
				"   ╲     ╲       ╲               ╲     ╲                        ╱             ╱           ╱ ╱             ",
				"    ╲     ╲             ╲               ╲          │           ╱          ╱              ╱                ",
				"     ╲     ╲             ╲               ╲         │          ╱          ╱              ╱        ╱        ",
				"      ╲  ╲  ╲             ╲         ╲              │                ╱   ╱              ╱        ╱         ",
				"╲         ╲                ╲         ╲             │               ╱   ╱                  ╱    ╱          ",
				" ╲         ╲                          ╲            │          ╱   ╱   ╱                  ╱    ╱           ",
				"  ╲         ╲                     ╲    ╲           │         ╱   ╱             ╱        ╱    ╱          ˙ ",
				"                                   ╲                        ╱   ╱             ╱        ╱                  ",
				"                                    ╲                      ╱                 ╱        ╱                   ",
				"                                     ╲                    ╱                 ╱                             ",
				"─────    ────────                                                          ╱                              ",
				"                                          ────                                                ───────     ",
				"                    ───────                                                                               ",
				"                                                                   ───────                                ",
				"           ╱                                               ╲                      ╲                       ",
				"          ╱                                                 ╲                      ╲                      ",
				"         ╱                                       │           ╲                      ╲                     ",
				"        ╱                     ╱                  │            ╲                      ╲        ╲           ",
				"   ╱   ╱                     ╱                   │                   ╲                         ╲        ╲ ",
				"  ╱                         ╱                    │                    ╲                         ╲        ╲",
				" ╱           ╱             ╱                     │                     ╲                         ╲        ",
				"╱           ╱             ╱      ╱               ││                     ╲                ╲                ",
				"      ╱    ╱                    ╱                 │               ╲                       ╲               ",
				"     ╱    ╱                    ╱                  │                ╲                       ╲              ",
				"    ╱    ╱                    ╱       ╱           │                 ╲              ╲        ╲             ",
				"   ╱                ╱        ╱       ╱            │ │                ╲              ╲                     ",
				"  ╱                ╱                ╱               │                                ╲       ╲            ",
				"            ╱     ╱                ╱                │                                 ╲       ╲           ",
				},
			};

			Console.ForegroundColor = Write.ColorDefaultFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < keyFrameBegin.Length; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
				Console.Write(keyFrameBegin[i]);
			}

			Thread.Sleep(200);

			foreach (var frame in animation)
			{
				for (int i = 1; i < frame.Length; i++)
				{
					Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
					Console.Write(frame[i]);
				}

				Thread.Sleep(animationRate);
				animationRate -= 20;
			}

			for (int i = 0; i < keyFrameEnd.Length; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - 29 + i);
				Console.Write(keyFrameEnd[i]);
			}
		}

		private void PrintDestinationTitle(object sender, string destination)
		{
			var maxLength = 30;
			var emptySpaceOnEnds = (maxLength - destination.Length) / 2;

			var sb = new StringBuilder();
			sb.Append(' ', emptySpaceOnEnds).Append(destination).Append(' ', emptySpaceOnEnds);

			var title = new string[]
			{
				"┌─                        ─┐",
						sb.ToString(),
				"└─                        ─┘",
			};

			Console.ForegroundColor = Write.ColorDisplayFG;
			Console.BackgroundColor = Write.ColorDisplayBG;

			for (int i = 0; i < title.Length; i++)
			{
				Console.SetCursorPosition(origin.X + 76, origin.Y - 28 + i);
				Console.Write(title[i]);
			}
		}
	}
}
