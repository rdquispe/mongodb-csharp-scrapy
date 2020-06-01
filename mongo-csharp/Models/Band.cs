using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongocsharp.Models
{
    public class Band
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("formed_in")]
        public string FormedIn { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }

        [BsonElement("lyrical")]
        public string Lyrical { get; set; }

        [BsonElement("years_active")]
        public string YearsActive { get; set; }

        [BsonElement("label")]
        public string Label { get; set; }

        [BsonElement("members")]
        public List<Member> Members { get; set; }

        [BsonElement("albums")]
        public List<Album> Albums { get; set; }
    }
}
