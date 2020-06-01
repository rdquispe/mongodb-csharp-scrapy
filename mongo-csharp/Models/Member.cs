using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongocsharp.Models
{
    public class Member
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}
