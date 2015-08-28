namespace NightlifeEntertainment
{
    using System;
    using System.Linq;
    using System.Text;
    using NightlifeEntertainment.Interfaces;
    using NightlifeEntertainment.Models;

    public class CinemaEngineExtended : CinemaEngine
    {
        private const string PerformancesFindTitle = "Performances:";
        private const string NoResultsTitle = "no results";
        private const string VenuesFindTitle = "Venues:";

        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new Opera(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new Sport(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new Concert(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "theatre":
                    {
                        var venue = this.GetVenue(commandWords[5]);
                        var theatre = new PerformanceTheatre(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                        this.Performances.Add(theatre);
                    }
                    break;
                case "concert":
                    {
                        var venue = this.GetVenue(commandWords[5]);
                        var concert = new PerformanceConcert(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                        this.Performances.Add(concert);
                    }
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }
                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            string nameToFind = commandWords[1];
            var performance = this.GetPerformance(nameToFind);

            var soldTickets = this.GetSoldTickets(performance);
            var totalPrice = this.GetTotalTicketsPrice(performance);

            var output = new StringBuilder();

            // TODO: Should refacto curency sign
            output.AppendLine(string.Format("{0}: {1} ticket(s), total: ${2:F2}", performance.Name, soldTickets, totalPrice));
            output.AppendLine(string.Format("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location));
            output.AppendLine(string.Format("Start time: {0}", performance.StartTime));

            this.Output.Append(output);
        }



        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string searchName = commandWords[1];
            DateTime searchTime = DateTime.Parse(commandWords[2]);

            this.Output.AppendLine(string.Format("Search for \"{0}\"", searchName));

            this.FindPerformance(searchName, searchTime);
            this.FindVenue(searchName, searchTime);
        }

        private void FindPerformance(string searchName, DateTime searchTime)
        {
            var performaces = this.Performances
                .Where(x => x.Name.ToLower().Contains(searchName.ToLower()) && x.StartTime >= searchTime)
                .OrderBy(x => x.StartTime)
                .ThenByDescending(x => x.BasePrice)
                .ThenBy(x => x.Name);

            this.Output.AppendLine(PerformancesFindTitle);

            if (!performaces.Any())
            {
                this.Output.AppendLine(NoResultsTitle);
            }
            else
            {
                foreach (var performance in performaces)
                {
                    // -<performance_name>
                    this.Output.AppendLine(string.Format("-{0}", performance.Name));
                }
            }
        }

        private void FindVenue(string searchName, DateTime searchTime)
        {
            var venues = this.Venues
                .Where(x => x.Name.ToLower().Contains(searchName.ToLower()))
                .OrderBy(x => x.Name);

            this.Output.AppendLine(VenuesFindTitle);

            if (!venues.Any())
            {
                this.Output.AppendLine(NoResultsTitle);
            }
            else
            {
                foreach (var venue in venues)
                {
                    this.Output.AppendLine(string.Format("-{0}", venue.Name));

                    var venueName = venue.Name;

                    var performances = this.Performances
                        .Where(x => x.Venue.Name.Equals(venueName) && x.StartTime >= searchTime)
                        .OrderBy(x => x.StartTime)
                        .ThenByDescending(x => x.BasePrice)
                        .ThenBy(x => x.Name);

                    if (performances.Any())
                    {
                        foreach (var performance in performances)
                        {
                            this.Output.AppendLine(string.Format("--{0}", performance.Name));
                        }
                    }
                }
            }
        }

        private decimal GetTotalTicketsPrice(IPerformance performance)
        {
            var soldTickets = performance.Tickets.Where(x => x.Status == TicketStatus.Sold);
            decimal totalPrice = soldTickets.Sum(ticket => ticket.Price);

            return totalPrice;
        }

        private int GetSoldTickets(IPerformance performance)
        {
            var tickets = performance.Tickets.Count(x => x.Status == TicketStatus.Sold);
            return tickets;
        }
    }
}
