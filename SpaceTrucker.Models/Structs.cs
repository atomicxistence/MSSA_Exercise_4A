using System;

namespace SpaceTrucker.Models
{
    struct Location
    {
        public int x;
        public int y;
        public string name;

        public Location(int x, int y, string name = "")
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
    }

    struct Trip
    {
        public int speed; // Speed of Light
        public int distance; // Light Years
        public int duration; // days
        public int fuelUsage; // %

        public Trip(Location o, Location d, WarpFactor warp)
        {
            speed = GetSpeed(warp);
            distance = GetDistance(o, d);
            duration = (int)Math.Round(distance / (speed * 365.0));
            fuelUsage = (int)(((double)warp/10.0) * distance);
        }

        
        public static int GetDistance(Location o, Location d) 
                            => (int)Math.Sqrt(Math.Pow(d.x - o.x, 2) + Math.Pow(d.y - o.y, 2));

        public static int GetSpeed(WarpFactor warp)
                            => (int) Math.Pow((double) warp, 10 / 3.0); // only good for warp <=9

    }

    struct Ore
    {
        public string name;
        public string description;

        public Ore(string name, string description="")
        {
            this.name = name;
            this.description = description;
        }

    }
}