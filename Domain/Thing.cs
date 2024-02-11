namespace Domain
{
    public class Thing
    {
        public Thing(string name, Location location, bool playerCanTake)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required");
            }

            Name = name;
            Location = location ?? throw new ArgumentNullException("location");
            PlayerCanTake = playerCanTake;
        }
        public string Name { get;  }

        public Location Location { get; private set; }

        public bool PlayerCanTake { get;  }

        public void SetLocation(Location newLocation)
        {
            this.Location = newLocation ?? throw new ArgumentNullException();
        }
    }
}
