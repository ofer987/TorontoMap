namespace TorontoMap.Models
{
    public class Coordinates
    {
        public int Longitude { get; }

        public int Latitude { get; }

        public Coordinates(int longitude, int latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
    }
}
