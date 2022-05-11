using MediatR;
using prmToolkit.NotificationPattern;
using System.Text.Json.Serialization;

namespace OR.Domain.Commands
{
    public class GenerateRaffleRequest : Notifiable, IRequest<GenerateRaffleResponse>
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Award { get; set; }
        public string? Theme { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TicketPrice { get; set; }
        public bool AutomaticDraw { get; set; }
        public DateTimeOffset DrawDate { get; set; }

        public void Validate()
        {

        }
    }
}
