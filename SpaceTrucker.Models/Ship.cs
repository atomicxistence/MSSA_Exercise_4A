using System.Collections.Generic;

namespace SpaceTrucker.Models
{
    public class Ship
    {
        public string Name { get; private set; }

        public int LifeSpan { get; private set; }
        public long Balance { get; set; }
        public int FuelLevel { get; set; }

        public Location CurrentLocation;

        public WarpFactor EngineTopSpeed { get; set; }
        public Capacity MaxCapacity { get; set; }

        public WeaponSystem WeaponSystemPower { get; set; }

        private List<Ore> Inventory { get; set; }

        public Ship(string name)
        {
            this.Name = name;
            this.LifeSpan = 18250; // days
            this.Balance = 1000000; // Creds 

            this.CurrentLocation = new Location(0, 0, "Earth"); 
            this.FuelLevel = 100; // percentage 
            this.EngineTopSpeed = WarpFactor.WarpFive;
            this.WeaponSystemPower = WeaponSystem.Weak; 
            this.MaxCapacity = Capacity.Small; 

            this.Inventory = new List<Ore>();

            // TODO: Hard code initial Inventory
        }

        public Trip  FlyToPlanet(Location newLocation, WarpFactor warp)
        {
            Trip myTrip = new Trip(CurrentLocation, newLocation, warp);

            CurrentLocation = newLocation;
            LifeSpan -= myTrip.duration;
            FuelLevel -= myTrip.fuelUsage;

            return myTrip;
        }

        public Trip FlyToPlanet(Location newLocation)
        {
            return FlyToPlanet(newLocation, EngineTopSpeed);
        }

        public void LoadMarchandize(List<Ore> ores)
        {
            // TODO: check capacity
            Inventory = ores;
        }

        public void Buy(List<Ore> ores, int cost)
        {
            // TODO: update inventory, balance and capacity
        }

        public void Sell(List<Ore> ores, int price)
        {
            // TODO: update inventory, balance and capacity
        }

    }
}