using Conecta.Doa.Application.Presentation.Domain.Entities;

namespace Conecta.Doa.Application.Presentation.Data.Interfaces;

public interface IDonatorRepository
{
    public Task<Donator> GetDonatorAsync(string document);
}
