using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OR.Domain.Entities;

namespace OR.Infra.Dto
{
    public class RaffleDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Award { get; set; } = null!;
        public string Theme { get; set; } = null!;
        public int NumberOfTickets { get; set; }
        public decimal TicketPrice { get; set; }
        public bool AutomaticDraw { get; set; }
        public DateTimeOffset DrawDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        // public Ticket? TicketDrawn { get;  set; }

        public static explicit operator RaffleDto(Raffle entity)
        {
            return entity != null
                ? new RaffleDto
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Award = entity.Award,
                    Theme = entity.Theme,
                    NumberOfTickets = entity.NumberOfTickets,
                    TicketPrice = entity.TicketPrice,
                    AutomaticDraw = entity.AutomaticDraw,
                    CreatedAt = entity.CreatedAt,
                    DeletedAt = entity.DeletedAt
                }
                : new RaffleDto();
        }
    }
}
