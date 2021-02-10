using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class AnimalTypeService
    {
        private readonly IMongoCollection<AnimalType> _animalType;
        public AnimalTypeService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _animalType = database.GetCollection<AnimalType>(settings.AnimalTypeColName);
        }

        public List<AnimalType> Get() =>
            _animalType.Find(_ => true).ToList();

        public AnimalType Get(string id) =>
            _animalType.Find(animalType => animalType.Id == id).FirstOrDefault();
    }
}
