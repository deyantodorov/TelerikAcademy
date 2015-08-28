namespace NightlifeEntertainment.Models
{
    using System.Collections.Generic;

    public class Opera : Venue
    {
        public Opera(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre })
        {
        }
    }
}
