namespace NightlifeEntertainment.Interfaces
{
    using System.Collections.Generic;
    using NightlifeEntertainment.Models;

    public interface IVenue
    {
        string Name { get; }

        string Location { get; }

        int Seats { get; }

        IList<PerformanceType> AllowedTypes { get; }
    }
}
