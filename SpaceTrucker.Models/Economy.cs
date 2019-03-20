using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace SpaceTrucker.Models
{
    public class Economy
    {
        public static List<Planet> planets;
        public static List<Ore> ores;
        public static List<Trend> trends;

        public static void InitializeEconomy()
        {
            InitOres();
            InitPlanets();
            SetPlanetDescription();
            BuildTrendReport();      
        }

        static void InitOres()
        {
            ores = new List<Ore>();
            ores.Add(new Ore("Lithium"));
            ores.Add(new Ore("Gold"));
            ores.Add(new Ore("Rhodium"));
            ores.Add(new Ore("Platinum"));
            ores.Add(new Ore("Diamonds"));
            ores.Add(new Ore("Black Opals"));
            ores.Add(new Ore("Rubies"));
            ores.Add(new Ore("Painite"));
            ores.Add(new Ore("Blue Garnets"));
            ores.Add(new Ore("Jadeite"));
        }

        static void InitPlanets()
        {
            planets = new List<Planet>();
            Dictionary<Ore, (int price, int qty)> offer = new Dictionary<Ore, (int price, int qty)>();
            Dictionary<Ore, int> demand = new Dictionary<Ore, int>();

            // Planets ordered by distance to Earth (home)
            FillEarth(offer, demand);
            FillPCb(offer, demand);
            FillLb(offer, demand);
            FillKb(offer, demand);
            FillW1061c(offer, demand);
            FillG667Cc(offer, demand);
            FillT1d(offer, demand);
            FillL1140b(offer, demand);
            FillG163c(offer, demand);
            planets.Add(new Planet("Piscium 109b", new Location(106, 0), "P109b")); // Fuel stop only
            FillK218b(offer, demand);
            FillK23d(offer, demand);
            planets.Add(new Planet("Andromedae 14b", new Location(241, -64), "A14b")); // Fuel stop only
            FillKe438b(offer, demand);
            FillKe186f(offer, demand);

        }

        static void FillEarth(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market EarthMarket = new Market();
            offer.Add(ores[0], (1, 100));
            offer.Add(ores[1], (1200, 50));
            offer.Add(ores[2], (1500, 25));
            offer.Add(ores[3], (1000, 75));
            offer.Add(ores[4], (1500000, 15));

            demand.Add(ores[5], 2100000);
            demand.Add(ores[6], 2200000);
            demand.Add(ores[7], 7100000);
            demand.Add(ores[8], 200000000);
            demand.Add(ores[9], 400000000);

            EarthMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Earth", new Location(0, 0), "Home", EarthMarket));

            offer.Clear();
            demand.Clear();
        }

        static void FillPCb(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market PCbMarket = new Market();
            offer.Add(ores[0], (2, 100));
            offer.Add(ores[1], (1000, 50));
            offer.Add(ores[2], (2000, 25));
            offer.Add(ores[3], (500, 75));
            offer.Add(ores[4], (1450000, 15));

            demand.Add(ores[5], 2500000);
            demand.Add(ores[6], 2300000);
            demand.Add(ores[7], 8100000);
            demand.Add(ores[8], 190000000);
            demand.Add(ores[9], 410000000);

            PCbMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Proxima Centauri b", new Location(3, 2), "PCb", PCbMarket));

            offer.Clear();
            demand.Clear();
        }

        static void FillLb(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market LbMarket = new Market();

            offer.Add(ores[0], (4, 100));
            offer.Add(ores[1], (1100, 50));
            offer.Add(ores[2], (3000, 25));
            offer.Add(ores[3], (600, 75));
            offer.Add(ores[5], (2000000, 10));

            demand.Add(ores[4], 1600000);
            demand.Add(ores[6], 2400000);
            demand.Add(ores[7], 8000000);
            demand.Add(ores[8], 200000000);
            demand.Add(ores[9], 450000000);

            LbMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Luyten b", new Location(0, 12), "Lb", LbMarket));

            offer.Clear();
            demand.Clear();
        }

        static void FillKb(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market KbMarket = new Market();

            offer.Add(ores[0], (4, 100));
            offer.Add(ores[2], (3000, 25));
            offer.Add(ores[3], (600, 50));
            offer.Add(ores[4], (1600000, 15));
            offer.Add(ores[6], (2000000, 5));

            demand.Add(ores[1], 1300);
            demand.Add(ores[5], 2600000);
            demand.Add(ores[7], 7500000);
            demand.Add(ores[8], 180000000);
            demand.Add(ores[9], 390000000);

            KbMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Kapteyn b", new Location(-2, -13), "Kb", KbMarket));

            offer.Clear();
            demand.Clear();
        }

        static void FillW1061c(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market W1061cMarket = new Market();

            offer.Add(ores[1], (1200, 75));
            offer.Add(ores[4], (1600000, 25));
            offer.Add(ores[5], (2400000, 10));
            offer.Add(ores[6], (1900000, 15));
            offer.Add(ores[7], (6000000, 5));

            demand.Add(ores[0], 5);
            demand.Add(ores[2], 6000);
            demand.Add(ores[3], 1200);
            demand.Add(ores[8], 200000000);
            demand.Add(ores[9], 400000000);

            W1061cMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Wolf 1061c", new Location(7, -12), "W1061c", W1061cMarket));

            offer.Clear();
            demand.Clear();
        }

        static void FillG667Cc(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market G667CcMarket = new Market();

            offer.Add(ores[0], (10, 100));
            offer.Add(ores[1], (2000, 50));
            offer.Add(ores[3], (1000, 50));
            offer.Add(ores[5], (1000000, 25));
            offer.Add(ores[8], (150000000, 5));

            demand.Add(ores[2], 5000);
            demand.Add(ores[4], 1800000);
            demand.Add(ores[6], 3000000);
            demand.Add(ores[7], 7000000);
            demand.Add(ores[9], 400000000);

            G667CcMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Gliese 667Cc", new Location(-23, 8), "G667Cc", G667CcMarket));

            offer.Clear();
            demand.Clear();
        }

        static void FillT1d(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market T1dMarket = new Market();

            offer.Add(ores[0], (10, 100));
            offer.Add(ores[2], (4000, 30));
            offer.Add(ores[3], (1500, 50));
            offer.Add(ores[4], (1800000, 15));
            offer.Add(ores[5], (2000000, 10));

            demand.Add(ores[1], 3000);
            demand.Add(ores[6], 2500000);
            demand.Add(ores[7], 7000000);
            demand.Add(ores[8], 200000000);
            demand.Add(ores[9], 400000000);

            T1dMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Trappist-1d", new Location(22, 32), "T1d", T1dMarket));

            offer.Clear();
            demand.Clear();

        }

        static void FillL1140b(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market L1140bMarket = new Market();

            offer.Add(ores[0], (18, 75));
            offer.Add(ores[1], (2900, 50));
            offer.Add(ores[2], (3000, 50));
            offer.Add(ores[4], (2000000, 10));
            offer.Add(ores[7], (5000000, 5));

            demand.Add(ores[3], 2000);
            demand.Add(ores[5], 2100000);
            demand.Add(ores[6], 2500000);
            demand.Add(ores[8], 180000000);
            demand.Add(ores[9], 500000000);

            L1140bMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("LHS 1140b", new Location(-20, 35), "L1140b", L1140bMarket));

            offer.Clear();
            demand.Clear();

        }

        static void FillG163c(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market G163cMarket = new Market();

            offer.Add(ores[1], (3000, 50));
            offer.Add(ores[2], (2000, 50));
            offer.Add(ores[6], (2000000, 10));
            offer.Add(ores[9], (100000000, 5));
            offer.Add(ores[8], (350000000, 5));

            demand.Add(ores[3], 20);
            demand.Add(ores[5], 4000);
            demand.Add(ores[6], 3000000);
            demand.Add(ores[8], 2200000);
            demand.Add(ores[9], 7200000);

            G163cMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Gliese 163c", new Location(-49, 0), "G163c", G163cMarket));

            offer.Clear();
            demand.Clear();

        }

        static void FillK218b(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market K218bMarket = new Market();

            offer.Add(ores[1], (9500, 25));
            offer.Add(ores[2], (6000, 50));
            offer.Add(ores[3], (500, 75));
            offer.Add(ores[7], (1000000, 15));
            offer.Add(ores[9], (3000000, 10));

            demand.Add(ores[0], 45);
            demand.Add(ores[4], 5000000);
            demand.Add(ores[5], 10000000);
            demand.Add(ores[6], 3000000);
            demand.Add(ores[8], 300000000);

            K218bMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("K2-18b", new Location(-38, -104), "K218b", K218bMarket));

            offer.Clear();
            demand.Clear();

        }

        static void FillK23d(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market K23dMarket = new Market();

            offer.Add(ores[0], (40, 100));
            offer.Add(ores[3], (400, 75));
            offer.Add(ores[4], (4500000, 15));
            offer.Add(ores[5], (8000000, 10));
            offer.Add(ores[6], (2500000, 25));

            demand.Add(ores[1], 10000);
            demand.Add(ores[2], 8000);
            demand.Add(ores[7], 2000000);
            demand.Add(ores[8], 350000000);
            demand.Add(ores[9], 4000000);

            K23dMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("K2-3d", new Location(-24, -135), "K23d", K23dMarket));

            offer.Clear();
            demand.Clear();

        }

        static void FillKe438b(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market Ke438bMarket = new Market();

            offer.Add(ores[4], (300000, 25));
            offer.Add(ores[6], (100000, 30));
            offer.Add(ores[7], (300000, 20));
            offer.Add(ores[8], (1000000, 15));
            offer.Add(ores[9], (1200000, 5));

            demand.Add(ores[0], 900000);
            demand.Add(ores[1], 400000);
            demand.Add(ores[2], 50000);
            demand.Add(ores[3], 60000);
            demand.Add(ores[5], 500000);

            Ke438bMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Kepler-438b", new Location(444, -162), "Ke438b", Ke438bMarket));

            offer.Clear();
            demand.Clear();

        }

        static void FillKe186f(Dictionary<Ore, (int price, int qty)> offer, Dictionary<Ore, int> demand)
        {
            Market Ke186fMarket = new Market();

            offer.Add(ores[5], (400000, 25));
            offer.Add(ores[6], (50000, 75));
            offer.Add(ores[7], (200000, 50));
            offer.Add(ores[8], (2000000, 5));
            offer.Add(ores[9], (1000000, 10));

            demand.Add(ores[0], 1000000);
            demand.Add(ores[1], 500000);
            demand.Add(ores[2], 45000);
            demand.Add(ores[3], 100000);
            demand.Add(ores[4], 400000);

            Ke186fMarket.UpdateMarket(offer, demand);

            planets.Add(new Planet("Kepler-186f", new Location(552, -97), "Ke186f", Ke186fMarket));

            offer.Clear();
            demand.Clear();

        }

        static void SetPlanetDescription()
        {
            foreach (var p in planets)
            {
                p.Description = "";
                p.Description += $"Welcome to {p.Name} a.k.a {p.ShortName}";
                if (p.MyMarket != null)
                {
                    p.Description += "\n\nWe offer: \n";
                    foreach (var item in p.MyMarket.OfferedOres)
                    {
                        p.Description += $"- {item.Key.name} (${ToKMB(item.Value.price)}, Qty {item.Value.qty})\n";
                    }

                    p.Description += "\nWe buy: \n";
                    foreach (var item in p.MyMarket.InDemandOres)
                    {
                        p.Description += $"- {item.Key.name} (${ToKMB(item.Value)})\n";
                    }

                    p.Description += "\nListed prices are per unit.";
                }
                else
                {
                    p.Description += $"\n\nWe only offer fuel here!";
                }

                p.Description += $"\n\nYou are {Trip.GetDistance(p.MyLocation, planets[0].MyLocation)} light years from {planets[0].ShortName}.";

            }
        }

        public static void BuildTrendReport()
        { 
           Dictionary<string, int> TopSellersPerOre = new Dictionary<string, int>();
           Dictionary<string, int> TopBuyersPerOre = new Dictionary<string, int>();
           trends = new List<Trend>();

            foreach (var o in ores)
            {
                foreach(var p in planets)
                {
                    if (p.MyMarket != null)
                    {
                        if (p.MyMarket.OfferedOres.TryGetValue(o, out var t))
                        {
                                TopSellersPerOre.Add(p.ShortName, t.price);
                        }
                        
                        if (p.MyMarket.InDemandOres.TryGetValue(o, out int price))
                        {
                                TopBuyersPerOre.Add(p.ShortName, price);
                        }
                    }
                }

                var sortedSellers = TopSellersPerOre.OrderBy(x => x.Value).Take(3);
                var sortedBuyers = TopBuyersPerOre.OrderByDescending(x => x.Value).Take(3);

                trends.Add(new Trend(o, ToKMB(sortedSellers.First().Value), ToKMB(sortedBuyers.First().Value),
                                        sortedSellers.Select(kvp => kvp.Key).ToArray(), 
                                        sortedBuyers.Select(kvp => kvp.Key).ToArray()));

                TopSellersPerOre.Clear();
                TopBuyersPerOre.Clear();

            }
        }

        public static string TrendReportToString()
        {
            if (trends == null) return "Trend Report Not Available Yet!";

            string str = "";
            
            foreach (var item in trends)
            {
                str += $"{item.ore.name} (€{item.minPrice}-€{item.maxPrice}) \n{String.Join(", ", item.topSellers)} | {String.Join(", ", item.topBuyers)}\n";
            }

            return str;
        }

        public static Dictionary<Planet, int> ClosestPlanets(Location l, int count = 3)
        {
            Dictionary<Planet, int> planetDistance = new Dictionary<Planet, int>();
            int distance;
            foreach (var p in planets)
            {
                distance = Trip.GetDistance(l, p.MyLocation);
                if (distance != 0)
                {
                    planetDistance.Add(p, distance);
                }
            }

            return planetDistance.OrderBy(x => x.Value).Take(count).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

       
        public static void PrintClosestPlanet() // TODO: Remove method, just for testing
        {
            Console.Clear();
            foreach (var p in Economy.planets)
            {
                Console.Write($"{p.ShortName}: ");
                foreach (var pd in Economy.ClosestPlanets(p.MyLocation))
                {
                    Console.Write($"{pd.Key.ShortName} ({pd.Value} ly) | ");
                }
                Console.WriteLine();
            }
        }

        public static string ToKMB(int num)
        {
            if (num > 999999999 || num < -999999999)
            {
                return num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
            }
            else if (num > 999999)
            {
                return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
            }
            else if (num > 999)
            {
                return num.ToString("0,.#K", CultureInfo.InvariantCulture);
            }
            else
            {
                return num.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
