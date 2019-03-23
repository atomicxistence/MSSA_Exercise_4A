using System.Collections.Generic;
using System.Linq;

namespace SpaceTrucker.Models
{
    public class Market
    {
        public Dictionary<Ore, (int price, int qty)> OfferedOres { get; private set; }
        public Dictionary<Ore, int> OfferedOresWithoutQty { get; private set; }
        public Dictionary<Ore, int> InDemandOres { get; private set; }

        public Market()
        {
            this.OfferedOres = new Dictionary<Ore, (int price, int qty)>();
            this.InDemandOres = new Dictionary<Ore, int>();
            OfferedOresWithoutQty = new Dictionary<Ore, int>();
        }

        public void UpdateMarket(Dictionary<Ore, (int price, int qty)> offer,
                                     Dictionary<Ore, int> demand)
        {
            foreach(var item in offer)
            {
                OfferedOres.Add(item.Key, item.Value);
                OfferedOresWithoutQty.Add(item.Key, item.Value.price);
            }

            foreach (var item in demand)
            {
                InDemandOres.Add(item.Key, item.Value);
            }
            InDemandOres = InDemandOres.OrderByDescending(v => v.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            OfferedOresWithoutQty = OfferedOresWithoutQty.OrderBy(v => v.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}