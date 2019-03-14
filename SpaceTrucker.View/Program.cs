using SpaceTrucker.ViewModel;

namespace SpaceTrucker.View
{
	class Program
	{
		static void Main(string[] args)
		{
			new DisplayManager();
			new Game().Run();
		}
	}
}
