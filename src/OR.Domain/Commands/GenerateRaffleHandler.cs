using MediatR;
using OR.Domain.Entities;
using prmToolkit.NotificationPattern;

namespace OR.Domain.Commands
{
    public class GenerateRaffleHandler : Notifiable, IRequestHandler<GenerateRaffleRequest, GenerateRaffleResponse>
    {
        public async Task<GenerateRaffleResponse> Handle(GenerateRaffleRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.IsInvalid())
                return await Task.FromResult(new GenerateRaffleResponse { });

            // TODO: repositorio
            var ticketValues = new List<TicketValue>();

            var raffle = Raffle.Factor.Generate(
                request.UserId ?? string.Empty,
                request.Name ?? string.Empty,
                request.Description ?? string.Empty,
                request.Award ?? string.Empty,
                request.Theme ?? string.Empty,
                request.NumberOfTickets,
                request.TicketPrice,
                request.AutomaticDraw,
                ticketValues);
        }
    }
}
