namespace OR.Domain.Entities
{
    public class Raffle
    {
        public Raffle()
        {
            Id = Guid.NewGuid();
            UserId = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Award = string.Empty;
            Theme = string.Empty;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Award { get; private set; }
        public string Theme { get; private set; }
        public int NumberOfTickets { get; private set; }
        public decimal TicketPrice { get; private set; }
        public bool AutomaticDraw { get; private set; }
        public DateTimeOffset DrawDate { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
        public Ticket? TicketDrawn { get; private set; }

        private List<Ticket> _tickets = new List<Ticket>();
        public IReadOnlyCollection<Ticket> Tickets { get { return _tickets; } }

        public void AddTickets(params Ticket[] tickets)
        {
            _tickets.AddRange(tickets);
        }

        public static class Factor
        {
            public static Raffle Generate(
                string userId,
                string name,
                string description,
                string award,
                string theme,
                int numberOfTickets,
                decimal ticketPrice,
                bool automaticDraw,
                List<TicketValue> ticketValues)
            {
                var raffle = new Raffle();
                raffle.UserId = userId;
                raffle.Name = name;
                raffle.Description = description;
                raffle.Award = award;
                raffle.Theme = theme;
                raffle.NumberOfTickets = numberOfTickets;
                raffle.TicketPrice = ticketPrice;
                raffle.AutomaticDraw = automaticDraw;

                var random = new Random();
                var totalTicketValues = ticketValues.Count;
                List<int> idxSelecteds = new List<int>();

                for (int i = 0; i < raffle.NumberOfTickets; i++)
                {
                    var newIdx = false;
                    int idx = -1;
                    do
                    {
                        idx = random.Next(totalTicketValues);
                        newIdx = idxSelecteds.Any(x => x == idx);
                    } while (!newIdx);

                    var value = ticketValues[idx].Value;
                    var ticket = new Ticket(value);

                    raffle.AddTickets(ticket);
                }

                return raffle;
            }
        }
    }
}
