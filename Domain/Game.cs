using System;
using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        public Game()
        {
            Locations = new List<Location>();
            Things = new List<Thing>();
            PlayerInventory = new List<Thing>();
            PlayerInventoryLocation = new Location { Name = "Player inventory" };
        }

        public Guid Id { get; set; }

        public List<Location> Locations { get; set; }

        public List<Thing> Things { get; set; }

        public List<Thing> PlayerInventory { get; set; }

        public Location PlayerLocation { get; set; }

        public Location PlayerInventoryLocation { get; set; }
    }
}
