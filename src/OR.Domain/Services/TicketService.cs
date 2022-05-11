using OR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OR.Domain.Services
{
    public struct TicketValue
    {
        public string name;
    }

    public interface ITicketService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raffle"></param>
        /// <returns>Returns that Raffle with tickets</returns>
        Task<Raffle> GenerateTickets(Raffle raffle);
    }

    public class TicketService : ITicketService
    {
        public async Task<Raffle> GenerateTickets(Raffle raffle)
        {
            var values = GetValuesByTheme(raffle.Theme, raffle.NumberOfTickets);

            for (int i = 0; i < raffle.NumberOfTickets; i++)
            {
                // TODO : create new ticket
            }

            return raffle;
        }

        private List<TicketValue> GetValuesByTheme(string theme, int numberOfItems)
        {
            // TODO: read file by theme selected 
            List<TicketValue> values = new List<TicketValue>();
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });
            values.Add(new TicketValue { name = theme, });

            var length = values.Count;
            var random = new Random();

            List<TicketValue> valuesSelected = new List<TicketValue>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var valueIdxSelected = random.Next(0, length - 1);
                valuesSelected.Add(values[valueIdxSelected]);
            }

            return valuesSelected;
        }
    }


}
