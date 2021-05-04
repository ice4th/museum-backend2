using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class DonerService
    {
        private readonly IMongoCollection<Doner> _doner;
        

        public DonerService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _doner = database.GetCollection<Doner>(settings.DonerColName);
        }

        public List<Doner> Get() =>
            _doner.Find(_ => true).ToList();

        public Doner Get(string id) =>
            _doner.Find(doner => doner.Id == id).FirstOrDefault();

        public void Create(Doner newDoner) => _doner.InsertOne(newDoner);

        public void Remove(Doner donerIn) =>
            _doner.DeleteOne(doner => doner.Id == donerIn.Id);
    }
}
