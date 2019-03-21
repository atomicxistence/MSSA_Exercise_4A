using SpaceTrucker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceTrucker.ViewModel
{
	class ConsoleFormatter
	{
		internal string FormatFuelCells(int fuelPercent)
		{
			var maxCells = 20;
			var fullCells = fuelPercent / 5;

			var sb = new StringBuilder(maxCells);
			sb.Append('▌', fullCells).Append(' ', maxCells - fullCells);

			return sb.ToString();
		}

		internal string FormatLocation(string planetName)
		{
			var maxNameLength = 20;

			var sb = new StringBuilder(maxNameLength);
			sb.Append(planetName).Append(' ', maxNameLength - planetName.Length);

			return sb.ToString();
		}

		internal string FormatBalance(long balance)
		{
			var maxBalanceLength = 17;
			var currencyPrefix = "฿";
			var emptySpaceAmount = maxBalanceLength - (balance.ToString().Length + currencyPrefix.Length);

			var sb = new StringBuilder(maxBalanceLength);
			sb.Append(currencyPrefix).Append(balance.ToString("N0")).Append(' ', emptySpaceAmount);

			return sb.ToString();
		}

		internal string FormatResetDays(int daysRemaining)
		{
			var maxDaysRemaining = 11;
			var daysPostfix = " days";
			var emptySpaceAmount = maxDaysRemaining - (daysRemaining.ToString().Length + daysPostfix.Length);

			var sb = new StringBuilder(maxDaysRemaining);
			sb.Append(daysRemaining.ToString()).Append(' ', emptySpaceAmount);

			return sb.ToString();
		}

		internal string[] FormatMarketPriceTable(Dictionary<Ore,int> marketTable)
		{
			var priceOffsetX = 34;
			var pricePrefix = "฿";
			var sortedMarketTable = marketTable.OrderBy(x => x.Value);

			var oreName = sortedMarketTable.Select(o => o.Key.name).ToArray();
			var orePrice = sortedMarketTable.Select(o => o.Value).ToArray();
			var priceArray = new string[marketTable.Count];

			for (int i = 0; i < oreName.Length; i++)
			{
				var emptySpace = priceOffsetX - oreName[i].Length;

				var sb = new StringBuilder();
				sb.Append(oreName[i]).Append(' ', emptySpace);
				sb.Append(pricePrefix);
				sb.Append(Economy.ToKMB(orePrice[i]));

				priceArray[i] = sb.ToString();
			}

			return priceArray;
		}

		internal string[] FormatInventoryTable(List<Ore> inventory)
		{
			return inventory.Select(o => o.name).ToArray();
		}
	}
}
