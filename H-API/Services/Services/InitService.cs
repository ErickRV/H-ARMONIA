using H_API.Services.Interfaces;
using HARMONIA.Core.Interfaces;
using HARMONIA.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace H_API.Services.Services
{
    public class InitService : IInitService
    {
        private readonly IDbService dbService;

        public InitService(IDbService dbService)
        {
            this.dbService = dbService;
        }

        public void Init()
        {
            foreach (string colection in Enum.GetNames(typeof(DataBaseContainers))) {
                if (!CollectionExists(colection)) {
                    CreateCollection(colection);
                }
            }
        }

        private bool CollectionExists(string container) {

            var filter = new BsonDocument("name", container);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return dbService.GetMongoDbHandler().ListCollectionNames(options).Any();
        }

        private void CreateCollection(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
                throw new Exception("DB service Exception!");

            if (CollectionExists(collectionName))
                throw new Exception("A collection is already using that name!");

            dbService.GetMongoDbHandler().CreateCollection(collectionName);
        }
    }
}
