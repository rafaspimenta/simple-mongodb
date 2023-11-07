using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Luppy.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public required string Name { get; set; }
    public int Age { get; set; }
}