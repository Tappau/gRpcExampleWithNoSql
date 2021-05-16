using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NoSql.Core.Contracts;

namespace NoSql.Core.Domain
{
    public abstract class BaseDocument : IBaseDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}