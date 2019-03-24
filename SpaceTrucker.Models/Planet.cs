using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.Models
{
    public class Planet
    {
        public string Name { get; private set; }
        public string ShortName { get; private set; }

        public string Description { get; set; }

        public Location MyLocation;

        public Market MyMarket { get; private set; }

        public bool hasUpgrade { get; private set; }

        public int fuelCost = 10;

        public WarpFactor EngineUpgrade;
        public Capacity CapacityUpgrade;
        public WeaponSystem WeaponSystemUpgrade;
        public int UpgradeCost { get; set; }

        public Planet(string name, Location myLocation, string shortName = "", Market myMarket = null, string description = "", bool hasUpgrade = false)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.Description = description;
            this.MyLocation = myLocation;
            this.MyLocation.shortName = shortName;
            this.MyLocation.longName = name;
            this.hasUpgrade = hasUpgrade;

            this.MyMarket = myMarket;
        }

        public void Upgrade(Ship s)
        {
            if (!hasUpgrade) return;

            if (s.Balance < UpgradeCost)
            {
                throw new InsuficientFundsException();
            }
            else
            {
                var charge = false;

                if (s.EngineTopSpeed < EngineUpgrade)
                {
                    s.EngineTopSpeed = EngineUpgrade;
                    charge = true;
                }

                if(s.MaxCapacity < CapacityUpgrade)
                {
                    s.MaxCapacity = CapacityUpgrade;
                    charge = true;
                }

                if(s.WeaponSystemPower < WeaponSystemUpgrade)    
                {
                    s.WeaponSystemPower = WeaponSystemUpgrade;
                    charge = true;
                }

                if(charge)
                {
                    s.Balance -= UpgradeCost;
                }
            }

            hasUpgrade = false;
        }

        public void UpdateMarket()
        {
            // TODO: update market
        }
    }
}
