using Conecta.Doa.Application.Presentation.Data.Interfaces;
using Conecta.Doa.Application.Presentation.Domain.Entities;
using MongoDB.Driver;

namespace Conecta.Doa.Application.Presentation.Data.Repositories;

public class DonatorRepository(IMongoContext context) : IDonatorRepository
{
    private readonly IMongoCollection<Donator> _donatorCollection = context.Collection<Donator>();

    public async Task<Donator> GetDonatorAsync(string document)
    {
        var filter = Builders<Donator>.Filter.Eq(d => d.Document.Number, document);

        var result = await _donatorCollection.Find(filter).FirstOrDefaultAsync();

        return result;
    }
}
