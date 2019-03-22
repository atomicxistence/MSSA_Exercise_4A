using SpaceTrucker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceTrucker.ViewModel
{
    class ConsoleFormatter
    {
        private string currencyPrefix = "฿";

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

        internal string[] FormatMarketPriceTable(Dictionary<Ore, int> marketTable)
        {
            var priceOffsetX = 34;

            var oreName = marketTable.Select(o => o.Key.name).ToArray();
            var orePrice = marketTable.Select(o => o.Value).ToArray();
            var priceArray = new string[marketTable.Count];

            for (int i = 0; i < oreName.Length; i++)
            {
                var emptySpace = priceOffsetX - oreName[i].Length;

                var sb = new StringBuilder();
                sb.Append(oreName[i]).Append(' ', emptySpace);
                sb.Append(currencyPrefix);
                sb.Append(Economy.ToKMB(orePrice[i]));

                priceArray[i] = sb.ToString();
            }

            return priceArray;
        }

        internal string[] FormatInventoryTable(List<Ore> inventory)
        {
            return inventory.Select(o => o.name).ToArray();
        }

        internal string[] FormatTrendReport(List<Trend> trends)
        {
            var priceOffsetX = 16;
            var topSellerOffsetX = 9;

            var report = new string[trends.Count];

            int i = 0; 
            foreach (var item in trends)
            {
                var sb = new StringBuilder();

                var emptySpace = priceOffsetX - item.ore.name.Length + 1;
                sb.Append(item.ore.name).Append(' ', emptySpace);

                sb.Append('│', 1).Append(' ', 1);

                var priceMin = $"{currencyPrefix}{item.minPrice}";
                var priceMax = $"{currencyPrefix}{item.maxPrice}";
                
                emptySpace = 6 - priceMin.Length;
                sb.Append(priceMin).Append(' ', emptySpace);
                sb.Append('-', 1).Append(' ', 1);

                emptySpace = 8 - priceMax.Length;
                sb.Append(priceMax).Append(' ', emptySpace);
                sb.Append('│', 1).Append(' ', 1);

                foreach (var seller in item.topSellers)
                {
                    emptySpace = topSellerOffsetX - seller.Length;
                    sb.Append(seller).Append(' ', emptySpace);
                    sb.Append('│', 1).Append(' ', 1);
                }

                foreach (var buyer in item.topBuyers)
                {
                    emptySpace = topSellerOffsetX - buyer.Length;
                    sb.Append(buyer).Append(' ', emptySpace);
                    sb.Append('│', 1).Append(' ', 1);
                }

                report[i++] = sb.ToString();
            }

            return report;
        }
    }
}
