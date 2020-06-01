using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongocsharp.Models
{
    public class Album
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string @Type { get; set; }

        [BsonElement("year")]
        public string Year { get; set; }
    }
}
