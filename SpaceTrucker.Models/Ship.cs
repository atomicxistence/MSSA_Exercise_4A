using System;
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

        public Trip FlyToPlanet(Location newLocation) => FlyToPlanet(newLocation, EngineTopSpeed);

		public Trip FlyToPlanet(Planet destination) => FlyToPlanet(destination.MyLocation);

		public Trip FlyToPlanet(Planet destination, WarpFactor warp) => FlyToPlanet(destination.MyLocation, warp);

		public void Buy(Ore o, int price)
        {
            if (Inventory?.Count > (int)MaxCapacity)
            {
                throw new Exception($"You cannot buy more than {MaxCapacity} items.");
            }
            else if (Balance - price < 0)
            {
                throw new Exception($"Insuficient funds, Balance: {Balance}, Price: {price}.");
            }
            else
            {
                Inventory.Add(o);
                Balance -= price;
            }

        }

        public void Sell(Ore o, int price)
        {
            if(Inventory.Contains(o))
            {
                Inventory.Remove(o);
                Balance += price;
            }
        }

    }
}