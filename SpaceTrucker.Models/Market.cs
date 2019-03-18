using System.Collections.Generic;

namespace SpaceTrucker.Models
{
    public class Market
    {
        public Dictionary<Ore, (int price, int qty)> OfferedOres { get; private set; }
        public Dictionary<Ore, int> InDemandOres { get; private set; }

        public int FuelPrice { get; set; }

        public Market(int fuelPrice = 1)
        {
            this.OfferedOres = new Dictionary<Ore, (int price, int qty)>();
            this.InDemandOres = new Dictionary<Ore, int>();

            this.FuelPrice = fuelPrice;
        }

        public void UpdateMarket(Dictionary<Ore, (int price, int qty)> offer,
                                     Dictionary<Ore, int> demand)
        {
            foreach(var item in offer)
            {
                OfferedOres.Add(item.Key, item.Value);
            }

            foreach (var item in demand)
            {
                InDemandOres.Add(item.Key, item.Value);
            }
        }

    }
}