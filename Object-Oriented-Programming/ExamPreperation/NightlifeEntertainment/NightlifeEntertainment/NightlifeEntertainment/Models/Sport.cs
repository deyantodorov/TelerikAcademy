namespace NightlifeEntertainment.Models
{
    using System.Collections.Generic;

    public class Sport : Venue
    {
        public Sport(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Sport, PerformanceType.Concert })
        {
        }
    }
}
