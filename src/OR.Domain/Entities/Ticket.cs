namespace OR.Domain.Entities
{
    public class Ticket
    {
        public Ticket(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Value { get; private set; }
        public string? Owner { get; private set; }
        public string? PhoneNumber { get; private set; }
        public DateTimeOffset? PurchaseDate { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
    }
}
