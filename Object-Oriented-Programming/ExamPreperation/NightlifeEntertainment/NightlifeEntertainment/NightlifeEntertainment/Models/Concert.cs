namespace NightlifeEntertainment.Models
{
    using System.Collections.Generic;

    public class Concert : Venue
    {
        public Concert(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Concert, PerformanceType.Opera, PerformanceType.Theatre })
        {
        }
    }
}
