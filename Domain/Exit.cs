namespace Domain
{
    public class Exit
    {
        public string Description { get; set; }

        public ExitDirection Direction { get; set; }

        public Location Destination { get; set; }
    }
}
