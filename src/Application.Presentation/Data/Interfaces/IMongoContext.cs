using MongoDB.Driver;

namespace Conecta.Doa.Application.Presentation.Data.Interfaces;

public interface IMongoContext
{
    public IMongoCollection<T> Collection<T>();
    public void Dipose();
}
