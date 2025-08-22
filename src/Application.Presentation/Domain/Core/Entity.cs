using MongoDB.Bson.Serialization.Attributes;

namespace Conecta.Doa.Application.Presentation.Domain.Core;

public class Entity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid Id { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
