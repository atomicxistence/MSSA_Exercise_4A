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
        public WarpFactor CurrentSpeed { get; set; }
        public Capacity MaxCapacity { get; set; }

        public WeaponSystem WeaponSystemPower { get; set; }

        public List<Ore> Inventory { get; set; }

        public Ship(string name)
        {
            this.Name = name;
            this.LifeSpan = 18249; // days
            this.Balance = 1000000; // Creds 

            this.CurrentLocation = new Location(0, 0, "Home", "Earth");
            this.FuelLevel = 100; // percentage 
            this.EngineTopSpeed = WarpFactor.WarpFive;
            this.WeaponSystemPower = WeaponSystem.Weak;
            this.MaxCapacity = Capacity.Small;
            CurrentSpeed = EngineTopSpeed;

            this.Inventory = new List<Ore>();
        }

        public void FlyToPlanet(Location newLocation, WarpFactor warp)
        {
            Trip myTrip = new Trip(CurrentLocation, newLocation, warp);

            if (myTrip.fuelUsage > 100 || FuelLevel < myTrip.fuelUsage)
            {
                throw new InsuficientFuelException();
            }
            else if (LifeSpan - myTrip.duration < 0)
            {
                throw new AgeOutException();
            }

            CurrentLocation = newLocation;
            LifeSpan -= myTrip.duration;
            FuelLevel -= myTrip.fuelUsage;
        }

        public void FlyToPlanet(Location newLocation) => FlyToPlanet(newLocation, EngineTopSpeed);

        public void FlyToPlanet(Planet destination) => FlyToPlanet(destination.MyLocation);

        public void FlyToPlanet(Planet destination, WarpFactor warp) => FlyToPlanet(destination.MyLocation, warp);

        public void Buy(Ore o, int price)
        {
            if (Inventory?.Count >= (int)MaxCapacity)
            {
                throw new MaxCapacityReachedException();
            }
            else if (Balance - price < 0)
            {
                throw new InsuficientFundsException();
            }
            else
            {
                Inventory.Add(o);
                Balance -= price;
            }

        }

        public void Sell(Ore o, int price)
        {
            if (Inventory.Contains(o))
            {
                Inventory.Remove(o);
                Balance += price;
            }
        }

        public void Refuel(int price)
        {
            int topOff = price * (100 - FuelLevel);

            if (Balance - topOff < 0)
            {
                throw new InsuficientFundsException();
            }
            else
            {
                Balance -= topOff;
                FuelLevel = 100;
            }
        }
    }

    public class InsuficientFuelException : Exception {  }
    public class InsuficientFundsException : Exception { }
    public class MaxCapacityReachedException : Exception { }
    public class AgeOutException : Exception { }
}