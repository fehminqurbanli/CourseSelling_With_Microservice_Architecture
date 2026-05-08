using MongoDB.Bson.Serialization.Attributes;

namespace CourseSelling.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        public Guid Id { get; set; }
    }
}
