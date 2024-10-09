using HARMONIA.Domain.Enums;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Core.Interfaces
{
    public interface IDbService
    {
        public List<T> GetDocuments<T>(DataBaseContainers table);
        public T GetDocument<T>(DataBaseContainers table, string property, Object propertyValue);
        public T InsertDocument<T>(DataBaseContainers table, T Document);
        public void UpdateDocument<T>(DataBaseContainers table, string id, T Document);
        public bool DeleteDocument<T>(DataBaseContainers table, string id);
        public IMongoDatabase GetMongoDbHandler();
    }
}
