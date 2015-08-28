namespace NightlifeEntertainment.Models
{
    using System;
    using NightlifeEntertainment.Interfaces;

    public class RegularTicket : Ticket
    {
        public RegularTicket(IPerformance performance)
            : base(performance, TicketType.Regular)
        {
        }
    }
}
