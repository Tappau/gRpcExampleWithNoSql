using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSql.Core.Contracts
{
    /// <summary>
    /// Contract defining abstraction around documents (entities in mongodb)
    /// </summary>
    public interface IBaseDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}