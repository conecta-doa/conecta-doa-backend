using Conecta.Doa.Application.Presentation.Domain.Entities;

namespace Conecta.Doa.Application.Presentation.Domain.Interfaces;

public interface IUserRepository
{
    public Task<bool> SaveUserAsync(User user);
    public Task<bool> GetByDocumentAsync(string document);
    public Task<User> GetUserByDocumentAsync(string document);
}
