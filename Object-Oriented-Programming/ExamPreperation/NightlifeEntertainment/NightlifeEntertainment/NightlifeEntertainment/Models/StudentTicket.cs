namespace NightlifeEntertainment.Models
{
    using System;
    using NightlifeEntertainment.Interfaces;

    public class StudentTicket : Ticket
    {
        private const decimal StudentDiscount = 80;

        public StudentTicket(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException("The price cannot be calculated because there is no performance for this ticket.");
            }

            var studentPrice = (this.Performance.BasePrice * StudentTicket.StudentDiscount) / 100m;

            return studentPrice;
        }
    }
}
