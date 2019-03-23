using System;

namespace SpaceTrucker.ViewModel
{
	public class EventBroadcaster
	{
		#region Event Handlers
		public event EventHandler<MenuState> GameState;
		public event EventHandler<ViewScreenMode> ViewMode;

		public event EventHandler<string[]> Message;

		public event EventHandler<IMenu> Menu;

        public event EventHandler<string[]> TrendReport;

        public event EventHandler<string[]> MarketBuy;
		public event EventHandler<string[]> MarketSell;
		public event EventHandler<string[]> MarketInventory;

		public event EventHandler<string> FuelCells;
		public event EventHandler<string> Balance;
		public event EventHandler<string> Location;
		public event EventHandler<int> Warp;
		public event EventHandler<string> ResetDays;

        public int maxWarp = 9;
        public bool isErrorMessage;
        #endregion

        #region Event Triggers
        internal void ChangeGameState(MenuState nextGameState)
		{
			GameState?.Invoke(this, nextGameState);
		}

		internal void ChangeViewScreenMode(ViewScreenMode nextViewMode)
		{
			ViewMode?.Invoke(this, nextViewMode);
		}

		internal void SendMessageToViewScreen(string[] message)
		{
			Message?.Invoke(this, message);
		}

		internal void SelectionDisplayMenu(IMenu nextMenu)
		{
			Menu?.Invoke(this, nextMenu);
		}

		internal void ChangeFuelCells(string fuelCells)
		{
			FuelCells?.Invoke(this, fuelCells);
		}

		internal void ChangeBalance(string balance)
		{
			Balance?.Invoke(this, balance);
		}

		internal void ChangeLocation(string planetName)
		{
			Location?.Invoke(this, planetName);
		}

		internal void ChangeWarpFactor(int warpFactor)
		{
			Warp?.Invoke(this, warpFactor);
		}

		internal void ChangeResetDays(string remainingDays)
		{
			ResetDays?.Invoke(this, remainingDays);
		}

		internal void UpdateMarketBuyTable(string[] marketBuyTable)
		{
			MarketBuy?.Invoke(this, marketBuyTable);
		}

		internal void UpdateMarketSellTable(string[] marketSellTable)
		{
			MarketSell?.Invoke(this, marketSellTable);
		}

		internal void UpdateMarketInventoryTable(string[] marketInventoryTable)
		{
			MarketInventory?.Invoke(this, marketInventoryTable);
		}

        internal void UpdateTrendReport(string[] trendReport)
        {
            TrendReport?.Invoke(this, trendReport);
        }
        #endregion
    }
}
