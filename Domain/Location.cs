using System.Collections.Generic;

namespace Domain
{
    public class Location
    {
        public Location() => this.Exits = new List<Exit>();

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Exit> Exits { get; set; }
    }
}
