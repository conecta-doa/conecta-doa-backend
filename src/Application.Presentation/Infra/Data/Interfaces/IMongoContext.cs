using MongoDB.Driver;

namespace Conecta.Doa.Application.Presentation.Infra.Data.Interfaces;

public interface IMongoContext
{
    public IMongoCollection<T> Collection<T>();
    public void Dipose();
}
