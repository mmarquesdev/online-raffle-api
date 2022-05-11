namespace OR.Domain.Entities
{
    public class TicketValue
    {
        public TicketValue(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
