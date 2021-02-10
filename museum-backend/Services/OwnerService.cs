using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class OwnerService
    {
        private readonly IMongoCollection<Owner> _owner;

        public OwnerService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _owner = database.GetCollection<Owner>(settings.OwnerColName);
        }

        public List<Owner> Get() =>
            _owner.Find(_ => true).ToList();

        public Owner Get(string id) =>
            _owner.Find(owner => owner.Id == id).FirstOrDefault();
    }
}
