namespace NightlifeEntertainment.Models
{
    using System;
    using NightlifeEntertainment.Interfaces;

    public class VipTicket : Ticket
    {
        private const decimal VipIncreasePrice = 50;

        public VipTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException("The price cannot be calculated because there is no performance for this ticket.");
            }

            var vipPrice = (this.Performance.BasePrice * VipTicket.VipIncreasePrice) / 100m + this.Performance.BasePrice;

            return vipPrice;
        }
    }
}
