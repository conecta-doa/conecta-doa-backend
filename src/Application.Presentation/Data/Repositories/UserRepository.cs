using Conecta.Doa.Application.Presentation.Data.Interfaces;
using Conecta.Doa.Application.Presentation.Domain.Entities;
using Conecta.Doa.Application.Presentation.Domain.Interfaces;
using MongoDB.Driver;

namespace Conecta.Doa.Application.Presentation.Data.Repositories;

public class UserRepository(IMongoContext context) : IUserRepository
{
    private readonly IMongoCollection<User> _userCollection = context.Collection<User>();

    public async Task<bool> GetByDocumentAsync(string document)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Document, document);

        return await _userCollection.Find(filter).AnyAsync();
    }

    public async Task<User> GetUserByDocumentAsync(string document)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Document, document);

        return await _userCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> SaveUserAsync(User user)
    {
        await _userCollection.InsertOneAsync(user);

        return true;
    }
}
