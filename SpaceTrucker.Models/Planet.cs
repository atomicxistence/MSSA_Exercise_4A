using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.Models
{
    class Planet
    {
        public string Name { get; private set; }
        public string ShortName { get; private set; }

        public string Description { get; set; }

        public Location MyLocation;

        public Market MyMarket { get; private set; }

        public bool hasUpgrade { get; }

        public Planet(string name, Location myLocation, string shortName="", Market myMarket = null, string description = "",  bool hasUpgrade = false)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.Description = description;
            this.MyLocation = myLocation;
            this.MyLocation.name = shortName;
            this.hasUpgrade = hasUpgrade;

            this.MyMarket = myMarket;
        }

        public void Upgrade(Ship s)
        {
            // TODO: upgrade ship
        }

        public void UpdateMarket()
        {
            // TODO: update market
        }
    }
}
