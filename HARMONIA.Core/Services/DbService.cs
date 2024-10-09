using HARMONIA.Core.Interfaces;
using HARMONIA.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Core.Services
{
    public class DbService : IDbService
    {
        private IMongoDatabase db;

        public DbService(string connectionString, string DbName)
        {
            MongoClient client = new MongoClient(connectionString);
            db = client.GetDatabase(DbName); //La base de datos se crea si no existe!
        }

        public T InsertDocument<T>(DataBaseContainers table, T Document)
        {
            var collection = db.GetCollection<T>(table.ToString());
            collection.InsertOne(Document);
            return Document;
        }

        public void UpdateDocument<T>(DataBaseContainers table, string id, T Document)
        {
            var collection = db.GetCollection<T>(table.ToString());
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = collection.ReplaceOne(filter, Document);
        }

        public List<T> GetDocuments<T>(DataBaseContainers table)
        {
            var collection = db.GetCollection<T>(table.ToString());
            return collection.Find(new BsonDocument()).ToList();
        }

        public T GetDocument<T>(DataBaseContainers table, string property, object propertyValue)
        {
            var collection = db.GetCollection<T>(table.ToString());
            var filter = Builders<T>.Filter.Eq(property, propertyValue);
            return collection.Find(filter).FirstOrDefault();
        }

        public bool DeleteDocument<T>(DataBaseContainers table, string id)
        {
            var collection = db.GetCollection<T>(table.ToString());
            var deleteFilter = Builders<T>.Filter.Eq("_id", id);
            return collection.DeleteOne(deleteFilter).IsAcknowledged;
        }

        public IMongoDatabase GetMongoDbHandler()
        {
            if(db == default)
                throw new ArgumentNullException(nameof(db));

            return db;
        }
    }
}
