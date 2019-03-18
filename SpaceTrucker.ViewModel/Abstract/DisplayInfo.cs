using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	public struct DisplayInfo
	{
		public GameState CurrentGameState { get; internal set; }
		public IMenu MenuOptions { get; internal set; }
		public int FuelPercent { get; internal set; }
		public string Location { get; internal set; }
		public int Balance { get; internal set; }
		// TODO: ship upgrades
		public int DaysRemaining { get; internal set; }
		// TODO: map info
		public IMenu MarketBuy { get; internal set; }
		public IMenu MarketSell { get; internal set; }
		public List<string> TrendReport { get; internal set; }
	}
}
