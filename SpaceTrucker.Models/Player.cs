using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Ship MyShip { get; set; }

        public Player(string name = "Player 1")
        {
            this.Name = name;
            this.MyShip = new Ship("THX-1138");
        }

        public void saveGame()
        {
            // TODO: save player's paused game 
        }
    }
}
