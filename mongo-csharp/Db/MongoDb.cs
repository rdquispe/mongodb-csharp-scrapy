using MongoDB.Driver;
using Newtonsoft.Json;

namespace mongocsharp.Db
{
    public class MongoDb : MongoClient
    {
        JsonSerializer serialization = null;
        public IMongoDatabase db = null;

        public MongoDb() : base("mongodb://127.0.0.1")
        {
            db = this.GetDatabase("metalhead");
            serialization = new JsonSerializer();
        }

        public void insertOne<T>(string name, T item)
        {
            var collection = db.GetCollection<T>(name);
            collection.InsertOne(item);
        }

        public IMongoCollection<T> all<T>(string name)
        {
            return db.GetCollection<T>(name);
        }
    }
}
