using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OR.Domain.Entities;
using OR.Infra.Dto;
using OR.Infra.Settings;

namespace OR.Infra.Repositories
{
    public class RaffleRepository
    {
        public RaffleRepository(IOptions<MongoDbSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _raffleCollection = database.GetCollection<RaffleDto>("Raffles");

        }

        private readonly IMongoCollection<RaffleDto> _raffleCollection;

        public async Task CreateAsync(Raffle raffle)
        {
            var dto  = (RaffleDto)raffle;
            await _raffleCollection.InsertOneAsync(dto);
        }
    }
}
