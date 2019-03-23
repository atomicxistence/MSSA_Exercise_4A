using System;
using System.Threading;
using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Message : IViewScreen
	{
		public ViewScreenMode ModeType => ViewScreenMode.Message;

		private Coord origin;
		private EventBroadcaster eventBroadcaster;

		private string[] message;

		private int messageBoxWidth = 50;
		private int messageBoxHeight = 12;

		public Message(EventBroadcaster eventBroadcaster)
		{
			this.eventBroadcaster = eventBroadcaster;
			eventBroadcaster.Message += PrintMessage;
		}

		public void CompleteRefresh(Coord shipConsoleOrigin)
		{
			int offsetX = 28;
			int offsetY = 18;
			origin = new Coord(shipConsoleOrigin.X + offsetX, shipConsoleOrigin.Y - offsetY);
		}

		public void EventUnsubscribe() { }

		public void EventSubscribe() { }

		private void PrintMessage(object sender, string[] incomingMessage)
		{
			message = incomingMessage;
            var isErrorMessage = (sender as EventBroadcaster).isErrorMessage;

			Console.BackgroundColor = Write.ColorMessageBG;

			PrintMessageBox();
			PrintMessageBorder();

			Console.ForegroundColor = isErrorMessage ? Write.ColorErrorMessageFG : Write.ColorMessageFG ;

            Console.Beep(1000, 20);
			Console.Beep(1200, 10);

			for (int i = 0; i < message.Length; i++)
			{
				Console.SetCursorPosition(origin.X + 2, origin.Y - messageBoxHeight + 1 + i);       

                if (!isErrorMessage && i > 2 && i < message.Length - 2)
				{
                    foreach (var ch in message[i])
                    {
                        Thread.Sleep(20);
                        Console.Write(ch);
                    }
                }
                else
                {
                    Console.Write(message[i]);
                }
			}

			Console.Beep(1000, 20);
			Console.Beep(1200, 10);
		}

		private void PrintMessageBox()
		{
			for (int i = 0; i < messageBoxHeight; i++)
			{
				Console.SetCursorPosition(origin.X, origin.Y - i);

				Write.EmptySpace(messageBoxWidth);
			}
		}

		private void PrintMessageBorder()
		{
			Console.ForegroundColor = Write.ColorDisplayTable;

			Console.SetCursorPosition(origin.X, origin.Y);
			Console.Write("╰─                                              ─╯");

			Console.SetCursorPosition(origin.X, origin.Y - messageBoxHeight);
			Console.Write("╭─                                              ─╮");
		}
	}
}
