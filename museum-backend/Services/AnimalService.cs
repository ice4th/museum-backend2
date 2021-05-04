using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class AnimalService 
    {
        private readonly IMongoCollection<Animal> _animal;
        public AnimalService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _animal = database.GetCollection<Animal>(settings.AnimalColName);
        }

        public List<Animal> Get() =>
            _animal.Find(_ => true).ToList();

        public Animal Get(string id) =>
            _animal.Find(animal => animal.Id == id).FirstOrDefault();

    }
}
