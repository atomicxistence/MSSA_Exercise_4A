using System;
using System.Threading.Tasks;
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
		private int messageBoxHeight = 10;

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

			Console.BackgroundColor = Write.ColorMessageBG;

			PrintMessageBox();
			PrintMessageBorder();

			Console.ForegroundColor = Write.ColorMessageFG;

			for (int i = 0; i < message.Length; i++)
			{
				Console.SetCursorPosition(origin.X + 2, origin.Y - messageBoxHeight + 2 + i);
				Console.Write(message[i]);
			}
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
			Console.Write("└─                                              ─┘");

			Console.SetCursorPosition(origin.X, origin.Y - messageBoxHeight);
			Console.Write("┌─                                              ─┐");
		}
	}
}
